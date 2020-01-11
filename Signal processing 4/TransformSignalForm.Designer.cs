namespace Signal_processing_4
{
    partial class TransformSignalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonHaar = new System.Windows.Forms.RadioButton();
            this.radioButtonDobeshi = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownItterations = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItterations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип преобразования";
            // 
            // radioButtonHaar
            // 
            this.radioButtonHaar.AutoSize = true;
            this.radioButtonHaar.Location = new System.Drawing.Point(12, 25);
            this.radioButtonHaar.Name = "radioButtonHaar";
            this.radioButtonHaar.Size = new System.Drawing.Size(50, 17);
            this.radioButtonHaar.TabIndex = 1;
            this.radioButtonHaar.TabStop = true;
            this.radioButtonHaar.Text = "Хаар";
            this.radioButtonHaar.UseVisualStyleBackColor = true;
            // 
            // radioButtonDobeshi
            // 
            this.radioButtonDobeshi.AutoSize = true;
            this.radioButtonDobeshi.Location = new System.Drawing.Point(12, 48);
            this.radioButtonDobeshi.Name = "radioButtonDobeshi";
            this.radioButtonDobeshi.Size = new System.Drawing.Size(66, 17);
            this.radioButtonDobeshi.TabIndex = 2;
            this.radioButtonDobeshi.TabStop = true;
            this.radioButtonDobeshi.Text = "Добеши";
            this.radioButtonDobeshi.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порог";
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.DecimalPlaces = 2;
            this.numericUpDownThreshold.Location = new System.Drawing.Point(292, 25);
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownThreshold.TabIndex = 4;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(90, 106);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(248, 106);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество иттераций";
            // 
            // numericUpDownItterations
            // 
            this.numericUpDownItterations.Location = new System.Drawing.Point(141, 25);
            this.numericUpDownItterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownItterations.Name = "numericUpDownItterations";
            this.numericUpDownItterations.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownItterations.TabIndex = 8;
            this.numericUpDownItterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TransformSignalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 161);
            this.Controls.Add(this.numericUpDownItterations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonDobeshi);
            this.Controls.Add(this.radioButtonHaar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TransformSignalForm";
            this.Text = "Преобразование сигнала";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonHaar;
        private System.Windows.Forms.RadioButton radioButtonDobeshi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownItterations;
    }
}