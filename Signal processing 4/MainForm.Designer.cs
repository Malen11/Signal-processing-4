namespace Signal_processing_4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectImageFileButton = new System.Windows.Forms.Button();
            this.selectCardioFileButton = new System.Windows.Forms.Button();
            this.selectReoFileButton = new System.Windows.Forms.Button();
            this.selectVeloFileButton = new System.Windows.Forms.Button();
            this.selectSpiroFileButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.transformSignalButton = new System.Windows.Forms.Button();
            this.showBaseSignalButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectImageFileButton);
            this.groupBox1.Controls.Add(this.selectCardioFileButton);
            this.groupBox1.Controls.Add(this.selectReoFileButton);
            this.groupBox1.Controls.Add(this.selectVeloFileButton);
            this.groupBox1.Controls.Add(this.selectSpiroFileButton);
            this.groupBox1.Controls.Add(this.fileNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 255);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Загрузить данные";
            // 
            // selectImageFileButton
            // 
            this.selectImageFileButton.Location = new System.Drawing.Point(6, 28);
            this.selectImageFileButton.Name = "selectImageFileButton";
            this.selectImageFileButton.Size = new System.Drawing.Size(120, 40);
            this.selectImageFileButton.TabIndex = 0;
            this.selectImageFileButton.Text = "Выбрать файл изображения...";
            this.selectImageFileButton.UseVisualStyleBackColor = true;
            this.selectImageFileButton.Click += new System.EventHandler(this.selectImageFileButton_Click);
            // 
            // selectCardioFileButton
            // 
            this.selectCardioFileButton.Location = new System.Drawing.Point(6, 88);
            this.selectCardioFileButton.Name = "selectCardioFileButton";
            this.selectCardioFileButton.Size = new System.Drawing.Size(120, 40);
            this.selectCardioFileButton.TabIndex = 2;
            this.selectCardioFileButton.Text = "Выбрать кардиофайл...";
            this.selectCardioFileButton.UseVisualStyleBackColor = true;
            this.selectCardioFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // selectReoFileButton
            // 
            this.selectReoFileButton.Location = new System.Drawing.Point(132, 88);
            this.selectReoFileButton.Name = "selectReoFileButton";
            this.selectReoFileButton.Size = new System.Drawing.Size(120, 40);
            this.selectReoFileButton.TabIndex = 4;
            this.selectReoFileButton.Text = "Выбрать реофайл...";
            this.selectReoFileButton.UseVisualStyleBackColor = true;
            this.selectReoFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // selectVeloFileButton
            // 
            this.selectVeloFileButton.Location = new System.Drawing.Point(6, 134);
            this.selectVeloFileButton.Name = "selectVeloFileButton";
            this.selectVeloFileButton.Size = new System.Drawing.Size(120, 40);
            this.selectVeloFileButton.TabIndex = 5;
            this.selectVeloFileButton.Text = "Выбрать велофайл...";
            this.selectVeloFileButton.UseVisualStyleBackColor = true;
            this.selectVeloFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // selectSpiroFileButton
            // 
            this.selectSpiroFileButton.Location = new System.Drawing.Point(132, 134);
            this.selectSpiroFileButton.Name = "selectSpiroFileButton";
            this.selectSpiroFileButton.Size = new System.Drawing.Size(120, 40);
            this.selectSpiroFileButton.TabIndex = 6;
            this.selectSpiroFileButton.Text = "Выбрать спирофайл...";
            this.selectSpiroFileButton.UseVisualStyleBackColor = true;
            this.selectSpiroFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoEllipsis = true;
            this.fileNameLabel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.fileNameLabel.Location = new System.Drawing.Point(6, 193);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(246, 59);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "Путь до файла";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.transformSignalButton);
            this.groupBox3.Controls.Add(this.showBaseSignalButton);
            this.groupBox3.Location = new System.Drawing.Point(263, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 415);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Основные операции";
            // 
            // transformSignalButton
            // 
            this.transformSignalButton.Location = new System.Drawing.Point(7, 72);
            this.transformSignalButton.Name = "transformSignalButton";
            this.transformSignalButton.Size = new System.Drawing.Size(120, 40);
            this.transformSignalButton.TabIndex = 11;
            this.transformSignalButton.Text = "Преобразовать сигнал";
            this.transformSignalButton.UseVisualStyleBackColor = true;
            this.transformSignalButton.Click += new System.EventHandler(this.transformSignalButton_Click);
            // 
            // showBaseSignalButton
            // 
            this.showBaseSignalButton.Location = new System.Drawing.Point(6, 26);
            this.showBaseSignalButton.Name = "showBaseSignalButton";
            this.showBaseSignalButton.Size = new System.Drawing.Size(120, 40);
            this.showBaseSignalButton.TabIndex = 1;
            this.showBaseSignalButton.Text = "Показать сигнал";
            this.showBaseSignalButton.UseVisualStyleBackColor = true;
            this.showBaseSignalButton.Click += new System.EventHandler(this.showBaseSignalButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainForm";
            this.Text = "Обработка сигналов лабораторная 4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectImageFileButton;
        private System.Windows.Forms.Button selectCardioFileButton;
        private System.Windows.Forms.Button selectReoFileButton;
        private System.Windows.Forms.Button selectVeloFileButton;
        private System.Windows.Forms.Button selectSpiroFileButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button showBaseSignalButton;
        private System.Windows.Forms.Button transformSignalButton;
    }
}

