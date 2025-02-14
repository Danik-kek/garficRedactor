using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        private Pen currentPen = new Pen(Color.Red);
        private Bitmap workingImage = null; // Рабочее изображение
        private float zoomLevel = 1.0f; // Масштаб
        private int eraserSize = 10; // Размер ластика
        private bool isGridVisible = false; // Сетка

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
            isGridVisible = toolStripButtonGrid.Checked;
            drawingPanel.Invalidate();
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            zoomLevel = trackBarZoom.Value / 100.0f;
            drawingPanel.Invalidate();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.ScaleTransform(zoomLevel, zoomLevel);

            if (workingImage != null)
            {
                g.DrawImage(workingImage, Point.Empty);
            }

            DrawGrid(g);

            if (isDrawing)
            {
                if (currentTool == Tools.LINE)
                {
                    Point currentPoint = GetScaledPoint(drawingPanel.PointToClient(Cursor.Position));
                    using (Graphics imgG = Graphics.FromImage(workingImage))
                    {
                        imgG.DrawLine(currentPen, startPoint, currentPoint);
                    }
                    drawingPanel.Invalidate();
                }
                else if (currentTool == Tools.ELLIPSE)
                {
                    Point currentPoint = GetScaledPoint(drawingPanel.PointToClient(Cursor.Position));
                    Rectangle rect = GetRectangleFromPoints(startPoint, currentPoint);
                    using (Graphics imgG = Graphics.FromImage(workingImage))
                    {
                        imgG.DrawEllipse(currentPen, rect);
                    }
                    drawingPanel.Invalidate();
                }
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == Tools.LINE || currentTool == Tools.ELLIPSE || currentTool == Tools.PEN || currentTool == Tools.ERASER)
            {
                isDrawing = true;
                startPoint = GetScaledPoint(e.Location);
            }
            else if (currentTool == Tools.TEXT)
            {
                string text = Prompt("Введите текст:", "Текст");
                if (!string.IsNullOrEmpty(text))
                {
                    AddText(GetScaledPoint(e.Location), text, currentPen.Color);
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
                    DrawFreeLine(GetScaledPoint(e.Location));
                    drawingPanel.Invalidate();
                }
                else if (currentTool == Tools.ERASER)
                {
                    EraseArea(GetScaledPoint(e.Location));
                    drawingPanel.Invalidate();
                }
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                if (currentTool == Tools.LINE || currentTool == Tools.ELLIPSE)
                {
                    drawingPanel.Invalidate();
                }
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workingImage = new Bitmap(openFileDialog.FileName);
                        drawingPanel.Size = workingImage.Size;
                        drawingPanel.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workingImage.Save(saveFileDialog.FileName, GetImageFormat(saveFileDialog.FileName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private ImageFormat GetImageFormat(string fileName)
        {
            if (fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)) return ImageFormat.Png;
            if (fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)) return ImageFormat.Jpeg;
            if (fileName.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase)) return ImageFormat.Bmp;
            return ImageFormat.Png; // По умолчанию PNG
        }

        private void DrawGrid(Graphics g)
        {
            if (isGridVisible)
            {
                int gridSize = 20;
                Pen gridPen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dot };
                int width = drawingPanel.ClientSize.Width;
                int height = drawingPanel.ClientSize.Height;

                for (int x = 0; x < width; x += gridSize)
                {
                    g.DrawLine(gridPen, x, 0, x, height);
                }

                for (int y = 0; y < height; y += gridSize)
                {
                    g.DrawLine(gridPen, 0, y, width, y);
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

        private void AddText(Point location, string text, Color color)
        {
            if (workingImage != null)
            {
                using (Graphics g = Graphics.FromImage(workingImage))
                {
                    using (Brush brush = new SolidBrush(color))
                    {
                        g.DrawString(text, new Font(FontFamily.GenericSansSerif, 12), brush, location);
                    }
                }
            }
        }

        private void DrawFreeLine(Point newPoint)
        {
            if (workingImage != null && currentTool == Tools.PEN)
            {
                using (Graphics g = Graphics.FromImage(workingImage))
                {
                    g.DrawLine(currentPen, startPoint, newPoint);
                }
                startPoint = newPoint;
            }
        }

        private void EraseArea(Point location)
        {
            if (workingImage != null && currentTool == Tools.ERASER)
            {
                Rectangle eraserArea = new Rectangle(location.X - eraserSize / 2, location.Y - eraserSize / 2, eraserSize, eraserSize);
                for (int x = eraserArea.X; x < eraserArea.X + eraserArea.Width; x++)
                {
                    for (int y = eraserArea.Y; y < eraserArea.Y + eraserArea.Height; y++)
                    {
                        if (x >= 0 && x < workingImage.Width && y >= 0 && y < workingImage.Height)
                        {
                            workingImage.SetPixel(x, y, Color.FromArgb(0, workingImage.GetPixel(x, y))); // Устанавливаем альфа-компонент в 0
                        }
                    }
                }
            }
        }

        private static Rectangle GetRectangleFromPoints(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);
            return new Rectangle(x, y, width, height);
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
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}