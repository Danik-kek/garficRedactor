namespace garficRedactor
{
    public partial class Form1 : Form
    {
        public enum Tools
        {
            PEN = 1, TEXT, LINE, ELLIPSE, NULL = 0
        }

        private Tools currentTool = Tools.NULL;

        public Form1()
        {
            InitializeComponent();
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
    }
}
