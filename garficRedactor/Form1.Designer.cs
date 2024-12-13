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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonPen, toolStripButtonText, toolStripButtonLine, toolStripButtonEllipse });
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
            toolStripButtonPen.Text = "toolStripButton1";
            // 
            // toolStripButtonText
            // 
            toolStripButtonText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonText.Image = (Image)resources.GetObject("toolStripButtonText.Image");
            toolStripButtonText.ImageTransparentColor = Color.Magenta;
            toolStripButtonText.Name = "toolStripButtonText";
            toolStripButtonText.Size = new Size(29, 24);
            toolStripButtonText.Text = "toolStripButton2";
            // 
            // toolStripButtonLine
            // 
            toolStripButtonLine.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLine.Image = (Image)resources.GetObject("toolStripButtonLine.Image");
            toolStripButtonLine.ImageTransparentColor = Color.Magenta;
            toolStripButtonLine.Name = "toolStripButtonLine";
            toolStripButtonLine.Size = new Size(29, 24);
            toolStripButtonLine.Text = "toolStripButton3";
            // 
            // toolStripButtonEllipse
            // 
            toolStripButtonEllipse.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEllipse.Image = (Image)resources.GetObject("toolStripButtonEllipse.Image");
            toolStripButtonEllipse.ImageTransparentColor = Color.Magenta;
            toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            toolStripButtonEllipse.Size = new Size(29, 24);
            toolStripButtonEllipse.Text = "toolStripButton4";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
    }
}
