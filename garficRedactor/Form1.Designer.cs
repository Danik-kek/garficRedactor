namespace garficRedactor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripButtonPen = new ToolStripButton();
            toolStripButtonText = new ToolStripButton();
            toolStripButtonLine = new ToolStripButton();
            toolStripButtonEllipse = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            drawingPanel = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonPen, toolStripButtonText, toolStripButtonLine, toolStripButtonEllipse, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripButtonPen
            // 
            toolStripButtonPen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPen.Image = (Image)resources.GetObject("toolStripButtonPen.Image");
            toolStripButtonPen.ImageTransparentColor = Color.Magenta;
            toolStripButtonPen.Name = "toolStripButtonPen";
            toolStripButtonPen.Size = new Size(29, 24);
            toolStripButtonPen.Text = "карандаш ";
            // 
            // toolStripButtonText
            // 
            toolStripButtonText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonText.Image = (Image)resources.GetObject("toolStripButtonText.Image");
            toolStripButtonText.ImageTransparentColor = Color.Magenta;
            toolStripButtonText.Name = "toolStripButtonText";
            toolStripButtonText.Size = new Size(29, 24);
            toolStripButtonText.Text = "текст";
            // 
            // toolStripButtonLine
            // 
            toolStripButtonLine.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLine.Image = (Image)resources.GetObject("toolStripButtonLine.Image");
            toolStripButtonLine.ImageTransparentColor = Color.Magenta;
            toolStripButtonLine.Name = "toolStripButtonLine";
            toolStripButtonLine.Size = new Size(29, 24);
            toolStripButtonLine.Text = "линия";
            // 
            // toolStripButtonEllipse
            // 
            toolStripButtonEllipse.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEllipse.Image = (Image)resources.GetObject("toolStripButtonEllipse.Image");
            toolStripButtonEllipse.ImageTransparentColor = Color.Magenta;
            toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            toolStripButtonEllipse.Size = new Size(29, 24);
            toolStripButtonEllipse.Text = "элепс";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "кнопка делающая всё правильно ";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ActiveLinkColor = Color.Black;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 16);
            // 
            // drawingPanel
            // 
            drawingPanel.AutoSize = true;
            drawingPanel.BackColor = SystemColors.Control;
            drawingPanel.Location = new Point(155, 66);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(413, 326);
            drawingPanel.TabIndex = 2;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Right;
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton2 });
            toolStrip2.Location = new Point(656, 27);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(144, 401);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.White;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(141, 24);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip2);
            Controls.Add(drawingPanel);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonPen;
        private StatusStrip statusStrip1;
        private ToolStripButton toolStripButtonText;
        private ToolStripButton toolStripButtonLine;
        private ToolStripButton toolStripButtonEllipse;
        public ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripButton toolStripButton1;
        private Panel drawingPanel;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton2;
    }
}
