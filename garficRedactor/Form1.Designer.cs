namespace garficRedactor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEraser = new System.Windows.Forms.ToolStripButton(); // Ластик
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton(); // Открыть файл
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton(); // Сохранить файл
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton(); // Сетка
            this.toolStripButtonPaint = new System.Windows.Forms.ToolStripButton(); // Открыть Paint
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawingPanel = new garficRedactor.DoubleBufferedPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton(); // Выбор цвета
            this.trackBarZoom = new System.Windows.Forms.TrackBar(); // Масштабирование

            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();

            // toolStrip1
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripButtonPen,
                this.toolStripButtonText,
                this.toolStripButtonLine,
                this.toolStripButtonEllipse,
                this.toolStripButtonEraser,
                this.toolStripButtonOpen,
                this.toolStripButtonSave,
                this.toolStripButtonGrid,
                this.toolStripButtonPaint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);

            // toolStripButtonPen
            this.toolStripButtonPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPen.Image"))); // Укажите путь к иконке
            this.toolStripButtonPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPen.Name = "toolStripButtonPen";
            this.toolStripButtonPen.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonPen.Text = "Карандаш";

            // toolStripButtonText
            this.toolStripButtonText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonText.Image"))); // Укажите путь к иконке
            this.toolStripButtonText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonText.Name = "toolStripButtonText";
            this.toolStripButtonText.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonText.Text = "Текст";

            // toolStripButtonLine
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLine.Image"))); // Укажите путь к иконке
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonLine.Text = "Линия";

            // toolStripButtonEllipse
            this.toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEllipse.Image"))); // Укажите путь к иконке
            this.toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            this.toolStripButtonEllipse.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonEllipse.Text = "Эллипс";

            // toolStripButtonEraser
            this.toolStripButtonEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEraser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEraser.Image"))); // Укажите путь к иконке ластика
            this.toolStripButtonEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEraser.Name = "toolStripButtonEraser";
            this.toolStripButtonEraser.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonEraser.Text = "Ластик";

            // toolStripButtonOpen
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image"))); // Укажите путь к иконке открытия файла
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonOpen.Text = "Открыть";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);

            // toolStripButtonSave
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image"))); // Укажите путь к иконке сохранения файла
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSave.Text = "Сохранить";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);

            // toolStripButtonGrid
            this.toolStripButtonGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGrid.Image"))); // Укажите путь к иконке сетки
            this.toolStripButtonGrid.CheckOnClick = true;
            this.toolStripButtonGrid.Click += new System.EventHandler(this.toolStripButtonGrid_Click);

            // toolStripButtonPaint
            this.toolStripButtonPaint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaint.Image"))); // Укажите путь к иконке Paint
            this.toolStripButtonPaint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaint.Name = "toolStripButtonPaint";
            this.toolStripButtonPaint.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonPaint.Text = "Открыть Paint";
           

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel1 });
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 17);
            this.toolStripStatusLabel1.Text = "Графический редактор";

            // drawingPanel
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 27);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(656, 401);
            this.drawingPanel.TabIndex = 2;

            // toolStrip2
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripButtonColor }); // Выбор цвета
            this.toolStrip2.Location = new System.Drawing.Point(656, 27);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(144, 401);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";

            // toolStripButtonColor
            this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image"))); // Укажите путь к иконке выбора цвета
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonColor.Text = "Цвет";
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);

            // trackBarZoom
            this.trackBarZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBarZoom.Minimum = 10; // Минимальный масштаб (10%)
            this.trackBarZoom.Maximum = 200; // Максимальный масштаб (200%)
            this.trackBarZoom.Value = 100; // Значение по умолчанию (100%)
            this.trackBarZoom.TickFrequency = 10;
            this.trackBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.trackBarZoom_Scroll);
            this.Controls.Add(this.trackBarZoom);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Графический редактор";

            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPen;
        private System.Windows.Forms.ToolStripButton toolStripButtonText;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripButton toolStripButtonEraser; // Ластик
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen; // Открыть файл
        private System.Windows.Forms.ToolStripButton toolStripButtonSave; // Сохранить файл
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaint; // Открыть Paint
        private DoubleBufferedPanel drawingPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor; // Выбор цвета
        private System.Windows.Forms.ToolStripButton toolStripButtonGrid; // Сетка
        private System.Windows.Forms.TrackBar trackBarZoom; // Масштабирование
    }
}