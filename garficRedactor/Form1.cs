using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace garficRedactor
{
    public partial class Form1 : Form
    {
        public enum Tools
        {
            PEN = 1,
            TEXT,
            LINE,
            ELLIPSE,
            ERASER,
            NULL = 0
        }

        private Tools currentTool = Tools.NULL;
        private bool isDrawing = false;
        private Point startPoint;
        private List<Shape> shapes = new List<Shape>(); // Исправлен тип
        private List<Point> currentFreeLine = new List<Point>(); // Исправлен тип
        private Pen currentPen = new Pen(Color.Red);
        private float zoomLevel = 1.0f; // Масштаб
        private int eraserSize = 10; // Размер ластика
        private bool isGridVisible = false; // Сетка
        private Image backgroundImage = null; // Фоновое изображение

        public Form1()
        {
            InitializeComponent();
            drawingPanel.MouseDown += DrawingPanel_MouseDown;
            drawingPanel.MouseMove += DrawingPanel_MouseMove;
            drawingPanel.MouseUp += DrawingPanel_MouseUp;
            drawingPanel.Paint += DrawingPanel_Paint;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButtonPen":
                    currentTool = Tools.PEN;
                    toolStripStatusLabel1.Text = "Выбран карандаш";
                    break;
                case "toolStripButtonText":
                    currentTool = Tools.TEXT;
                    toolStripStatusLabel1.Text = "Создание надписей";
                    break;
                case "toolStripButtonLine":
                    currentTool = Tools.LINE;
                    toolStripStatusLabel1.Text = "Рисование линий";
                    break;
                case "toolStripButtonEllipse":
                    currentTool = Tools.ELLIPSE;
                    toolStripStatusLabel1.Text = "Рисование эллипсов";
                    break;
                case "toolStripButtonEraser":
                    currentTool = Tools.ERASER;
                    toolStripStatusLabel1.Text = "Ластик";
                    break;
            }
            SetToolStripButtonsPushedState((ToolStripButton)e.ClickedItem);
        }

        private void SetToolStripButtonsPushedState(ToolStripButton btnItem)
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton button)
                {
                    button.Checked = (button == btnItem);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string appPath = "C:\\Windows\\system32\\mspaint.exe";
            Process.Start(appPath);
            this.Close();
        }

        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentPen.Color = colorDialog.Color;
                    toolStripButtonColor.Image = new Bitmap(16, 16);
                    using (Graphics g = Graphics.FromImage(toolStripButtonColor.Image))
                    {
                        g.Clear(colorDialog.Color);
                    }
                }
            }
        }

        private void toolStripButtonGrid_Click(object sender, EventArgs e)
        {
            isGridVisible = toolStripButtonGrid.Checked; // Переключаем состояние сетки
            drawingPanel.Invalidate(); // Перерисовываем панель
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            zoomLevel = trackBarZoom.Value / 100.0f; // Обновляем масштаб
            drawingPanel.Invalidate(); // Перерисовываем панель
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == Tools.LINE || currentTool == Tools.ELLIPSE || currentTool == Tools.PEN)
            {
                isDrawing = true;
                startPoint = GetScaledPoint(e.Location); // Преобразуем координаты с учетом масштаба
            }
            else if (currentTool == Tools.TEXT)
            {
                string text = Prompt("Введите текст:", "Текст");
                if (!string.IsNullOrEmpty(text))
                {
                    Text textObject = new Text(GetScaledPoint(e.Location), text, currentPen.Color); // Преобразуем координаты
                    shapes.Add(textObject);
                    drawingPanel.Invalidate();
                }
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (currentTool == Tools.PEN)
                {
                    AddPointToFreeLine(GetScaledPoint(e.Location)); // Преобразуем координаты
                    drawingPanel.Invalidate();
                }
                else if (currentTool == Tools.LINE || currentTool == Tools.ELLIPSE)
                {
                    drawingPanel.Invalidate();
                }
                else if (currentTool == Tools.ERASER)
                {
                    Rectangle eraserArea = new Rectangle(
                        GetScaledPoint(e.Location).X - eraserSize / 2,
                        GetScaledPoint(e.Location).Y - eraserSize / 2,
                        eraserSize,
                        eraserSize
                    );
                    EraseShapes(eraserArea);
                    drawingPanel.Invalidate();
                }
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (currentTool == Tools.LINE)
                {
                    isDrawing = false;
                    shapes.Add(new Line(startPoint, GetScaledPoint(e.Location), currentPen)); // Преобразуем координаты
                }
                else if (currentTool == Tools.ELLIPSE)
                {
                    isDrawing = false;
                    shapes.Add(new Ellipse(startPoint, GetScaledPoint(e.Location), currentPen)); // Преобразуем координаты
                }
                else if (currentTool == Tools.PEN)
                {
                    isDrawing = false;
                    SaveFreeLine();
                }
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Рисуем фоновое изображение
            if (backgroundImage != null)
            {
                g.DrawImage(backgroundImage, Point.Empty);
            }

            // Применяем масштабирование
            g.ScaleTransform(zoomLevel, zoomLevel);

            // Рисуем все фигуры
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            // Рисуем сетку
            DrawGrid(g);

            // Отрисовка временных фигур
            if (isDrawing)
            {
                if (currentTool == Tools.LINE)
                {
                    Point currentPoint = GetScaledPoint(drawingPanel.PointToClient(Cursor.Position)); // Преобразуем координаты
                    g.DrawLine(currentPen, startPoint, currentPoint);
                }
                else if (currentTool == Tools.ELLIPSE)
                {
                    Point currentPoint = GetScaledPoint(drawingPanel.PointToClient(Cursor.Position)); // Преобразуем координаты
                    Rectangle rect = GetRectangleFromPoints(startPoint, currentPoint);
                    g.DrawEllipse(currentPen, rect);
                }
                else if (currentTool == Tools.PEN && currentFreeLine.Count > 1)
                {
                    for (int i = 0; i < currentFreeLine.Count - 1; i++)
                    {
                        g.DrawLine(currentPen, currentFreeLine[i], currentFreeLine[i + 1]);
                    }
                }
                else if (currentTool == Tools.ERASER)
                {
                    Point currentPoint = GetScaledPoint(drawingPanel.PointToClient(Cursor.Position)); // Преобразуем координаты
                    Rectangle eraserArea = new Rectangle(
                        currentPoint.X - eraserSize / 2,
                        currentPoint.Y - eraserSize / 2,
                        eraserSize,
                        eraserSize
                    );
                    using (Pen eraserPen = new Pen(Color.Red, 1))
                    {
                        g.DrawRectangle(eraserPen, eraserArea);
                    }
                }
            }
        }

        private Point GetScaledPoint(Point point)
        {
            return new Point(
                (int)(point.X / zoomLevel),
                (int)(point.Y / zoomLevel)
            );
        }

        private void AddPointToFreeLine(Point newPoint)
        {
            if (currentFreeLine.Count > 0)
            {
                Point lastPoint = currentFreeLine[currentFreeLine.Count - 1];
                if (Distance(lastPoint, newPoint) > 1)
                {
                    AddIntermediatePoints(lastPoint, newPoint);
                }
            }
            currentFreeLine.Add(newPoint);
        }

        private void AddIntermediatePoints(Point startPoint, Point endPoint)
        {
            int dx = Math.Abs(endPoint.X - startPoint.X);
            int dy = Math.Abs(endPoint.Y - startPoint.Y);
            int steps = Math.Max(dx, dy);
            float xIncrement = (endPoint.X - startPoint.X) / (float)steps;
            float yIncrement = (endPoint.Y - startPoint.Y) / (float)steps;

            for (int i = 1; i < steps; i++)
            {
                float newX = startPoint.X + i * xIncrement;
                float newY = startPoint.Y + i * yIncrement;
                currentFreeLine.Add(new Point((int)newX, (int)newY));
            }
        }

        private double Distance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        private void SaveFreeLine()
        {
            if (currentFreeLine.Count > 1)
            {
                for (int i = 0; i < currentFreeLine.Count - 1; i++)
                {
                    shapes.Add(new Line(currentFreeLine[i], currentFreeLine[i + 1], currentPen));
                }
            }
            currentFreeLine.Clear();
        }

        internal static Rectangle GetRectangleFromPoints(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);
            return new Rectangle(x, y, width, height);
        }

        private void EraseShapes(Rectangle eraserArea)
        {
            shapes.RemoveAll(shape =>
            {
                if (shape is Line line)
                {
                    Rectangle lineRect = new Rectangle(line.Start, new Size(line.End.X - line.Start.X, line.End.Y - line.Start.Y));
                    return eraserArea.IntersectsWith(lineRect);
                }
                else if (shape is Ellipse ellipse)
                {
                    return eraserArea.IntersectsWith(ellipse.Bounds);
                }
                return false;
            });
        }

        private string Prompt(string message, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label label = new Label() { Left = 50, Top = 20, Text = message };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(label);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void DrawGrid(Graphics g)
        {
            if (isGridVisible)
            {
                int gridSize = 20; // Размер ячейки сетки
                Pen gridPen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dot };

                int width = drawingPanel.ClientSize.Width;
                int height = drawingPanel.ClientSize.Height;

                for (int x = 0; x < width; x += gridSize)
                {
                    g.DrawLine(gridPen, x, 0, x, height); // Вертикальные линии
                }

                for (int y = 0; y < height; y += gridSize)
                {
                    g.DrawLine(gridPen, 0, y, width, y); // Горизонтальные линии
                }
            }
        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        backgroundImage = new Bitmap(openFileDialog.FileName); // Загружаем фон
                        drawingPanel.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при импорте изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Bitmap bitmap = new Bitmap(drawingPanel.ClientSize.Width, drawingPanel.ClientSize.Height))
                        {
                            drawingPanel.DrawToBitmap(bitmap, drawingPanel.ClientRectangle);
                            bitmap.Save(saveFileDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public abstract class Shape
    {
        public abstract void Draw(Graphics g);
    }

    public class Line : Shape
    {
        public Point Start { get; }
        public Point End { get; }
        public Pen Pen { get; }

        public Line(Point start, Point end, Pen pen)
        {
            Start = start;
            End = end;
            Pen = new Pen(pen.Color, pen.Width);
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, Start, End);
        }
    }

    public class Ellipse : Shape
    {
        public Rectangle Bounds { get; }
        public Pen Pen { get; }

        public Ellipse(Point start, Point end, Pen pen)
        {
            Bounds = Form1.GetRectangleFromPoints(start, end);
            Pen = new Pen(pen.Color, pen.Width);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, Bounds);
        }
    }

    public class Text : Shape
    {
        public Point Location { get; }
        public string Content { get; }
        public Color Color { get; }

        public Text(Point location, string content, Color color)
        {
            Location = location;
            Content = content;
            Color = color;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.DrawString(Content, new Font(FontFamily.GenericSansSerif, 12), brush, Location);
            }
        }
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}