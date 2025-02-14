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
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton(); // Сетка
            this.toolStripButtonImport = new System.Windows.Forms.ToolStripButton(); // Импорт
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton(); // Экспорт
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton(); // Выбор цвета
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton(); // Открыть Paint
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawingPanel = new garficRedactor.DoubleBufferedPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
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
                this.toolStripButtonGrid,
                this.toolStripButtonImport,
                this.toolStripButtonExport,
                this.toolStripButtonColor,
                this.toolStripButton1});
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

            // toolStripButtonGrid
            this.toolStripButtonGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGrid.Image"))); // Укажите путь к иконке сетки
            this.toolStripButtonGrid.CheckOnClick = true; // Позволяет кнопке быть "выбранной"
            this.toolStripButtonGrid.Click += new System.EventHandler(this.toolStripButtonGrid_Click); // Привязка события
            this.toolStripButtonGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGrid.Name = "toolStripButtonGrid";
            this.toolStripButtonGrid.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonGrid.Text = "Сетка";

            // toolStripButtonImport
            this.toolStripButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImport.Image"))); // Укажите путь к иконке импорта
            this.toolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImport.Name = "toolStripButtonImport";
            this.toolStripButtonImport.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonImport.Text = "Импорт";
            this.toolStripButtonImport.Click += new System.EventHandler(this.toolStripButtonImport_Click); // Привязка события

            // toolStripButtonExport
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExport.Image"))); // Укажите путь к иконке экспорта
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonExport.Text = "Экспорт";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click); // Привязка события

            // toolStripButtonColor
            this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image"))); // Укажите путь к иконке выбора цвета
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonColor.Text = "Цвет";
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click); // Привязка события

            // toolStripButton1
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image"))); // Укажите путь к иконке Paint
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "Открыть Paint";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click); // Привязка события

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
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripButtonColor });
            this.toolStrip2.Location = new System.Drawing.Point(656, 27);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(144, 401);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";

            // trackBarZoom
            this.trackBarZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBarZoom.Minimum = 10; // Минимальный масштаб (10%)
            this.trackBarZoom.Maximum = 200; // Максимальный масштаб (200%)
            this.trackBarZoom.Value = 100; // Значение по умолчанию (100%)
            this.trackBarZoom.TickFrequency = 10;
            this.trackBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.trackBarZoom_Scroll); // Привязка события
            this.Controls.Add(this.trackBarZoom); // Добавляем TrackBar на форму

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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonText;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripButton toolStripButtonEraser; // Ластик
        private System.Windows.Forms.ToolStripButton toolStripButtonGrid; // Сетка
        private System.Windows.Forms.ToolStripButton toolStripButtonImport; // Импорт
        private System.Windows.Forms.ToolStripButton toolStripButtonExport; // Экспорт
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1; // Открыть Paint
        private DoubleBufferedPanel drawingPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor; // Выбор цвета
        private System.Windows.Forms.TrackBar trackBarZoom; // Масштабирование
    }
}