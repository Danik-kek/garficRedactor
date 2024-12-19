using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace garficRedactor
{
    public partial class Form1 : Form
    {
        public enum Tools
        {
            PEN = 1, TEXT, LINE, ELLIPSE, NULL = 0
        }

        private Tools currentTool = Tools.NULL;
        private bool isDrawing = false;
        private Point startPoint;
        private List<Line> lines = new List<Line>(); // ������ ��� �������� �����
        private List<Point> currentFreeLine = new List<Point>(); // ������ ��� �������� ����� ������� ��������� �����

        public Form1()
        {
            InitializeComponent();

            // ������������� �� ������� ����
            drawingPanel.MouseDown += DrawingPanel_MouseDown;
            drawingPanel.MouseMove += DrawingPanel_MouseMove;
            drawingPanel.MouseUp += DrawingPanel_MouseUp;
            drawingPanel.Paint += DrawingPanel_Paint;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // ��������� ������� ��������� �����������
            switch (e.ClickedItem.Name)
            {
                case "toolStripButtonPen":
                    currentTool = Tools.PEN;
                    toolStripStatusLabel1.Text = "������ ��������";
                    break;
                case "toolStripButtonText":
                    currentTool = Tools.TEXT;
                    toolStripStatusLabel1.Text = "�������� ��������";
                    break;
                case "toolStripButtonLine":
                    currentTool = Tools.LINE;
                    toolStripStatusLabel1.Text = "��������� �����";
                    break;
                case "toolStripButtonEllipse":
                    currentTool = Tools.ELLIPSE;
                    toolStripStatusLabel1.Text = "��������� �������";
                    break;
            }

            // ������������� ��������� ������
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

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == Tools.LINE)
            {
                isDrawing = true;
                startPoint = e.Location; // ��������� ��������� �����
            }
            else if (currentTool == Tools.PEN)
            {
                isDrawing = true;
                currentFreeLine.Clear(); // ������� ���������� ��������� �����
                currentFreeLine.Add(e.Location); // ��������� ��������� �����
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (currentTool == Tools.LINE)
                {
                    // �������������� ������, ����� �������� �������
                    drawingPanel.Invalidate();
                }
                else if (currentTool == Tools.PEN)
                {
                    // ��������� ������� ����� � ������ ��������� �����
                    currentFreeLine.Add(e.Location);
                    // �������������� ������, ����� �������� �������
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
                    // ��������� ����� � ������
                    lines.Add(new Line(startPoint, e.Location));
                }
                else if (currentTool == Tools.PEN)
                {
                    isDrawing = false;
                    // ��������� ������� ��������� �����, �������� � � �������� ������
                    foreach (var point in currentFreeLine)
                    {
                        lines.Add(new Line(point, point)); // ������ ����� ���������� ������ ������ 0
                    }
                }
                // �������������� ������, ����� ���������� ������������� ���������
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // ������ ��� ����������� �����
            foreach (var line in lines)
            {
                g.DrawLine(Pens.Red, line.Start, line.End);
            }

            // ���� ������ ����� �����, ���������� �
            if (isDrawing)
            {
                if (currentTool == Tools.LINE)
                {
                    g.DrawLine(Pens.Red, startPoint, drawingPanel.PointToClient(Cursor.Position));
                }
                else if (currentTool == Tools.PEN)
                {
                    // ������ ��������� �����
                    if (currentFreeLine.Count > 0)
                    {
                        for (int i = 0; i < currentFreeLine.Count - 1; i++)
                        {
                            g.DrawLine(Pens.Red, currentFreeLine[i], currentFreeLine[i + 1]);
                        }
                    }
                }
            }
        }
    }

    public class Line
    {
        public Point Start { get; }
        public Point End { get; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}
//��� ����� ��� ����� 