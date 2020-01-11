namespace Signal_processing_4
{
    partial class ShowChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.maxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.changeIntervalButton = new System.Windows.Forms.Button();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // maxNumericUpDown
            // 
            this.maxNumericUpDown.Location = new System.Drawing.Point(623, 34);
            this.maxNumericUpDown.Name = "maxNumericUpDown";
            this.maxNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.maxNumericUpDown.TabIndex = 48;
            // 
            // minNumericUpDown
            // 
            this.minNumericUpDown.Location = new System.Drawing.Point(623, 9);
            this.minNumericUpDown.Name = "minNumericUpDown";
            this.minNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.minNumericUpDown.TabIndex = 47;
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Location = new System.Drawing.Point(483, 36);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(134, 13);
            this.maxValueLabel.TabIndex = 46;
            this.maxValueLabel.Text = "Максимальное значение";
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Location = new System.Drawing.Point(483, 11);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(128, 13);
            this.minValueLabel.TabIndex = 45;
            this.minValueLabel.Text = "Минимальное значение";
            // 
            // changeIntervalButton
            // 
            this.changeIntervalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeIntervalButton.Location = new System.Drawing.Point(678, 12);
            this.changeIntervalButton.Name = "changeIntervalButton";
            this.changeIntervalButton.Size = new System.Drawing.Size(94, 36);
            this.changeIntervalButton.TabIndex = 44;
            this.changeIntervalButton.Text = "Изменить диапазон";
            this.changeIntervalButton.UseVisualStyleBackColor = true;
            this.changeIntervalButton.Click += new System.EventHandler(this.changeIntervalButton_Click);
            // 
            // dataChart
            // 
            this.dataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "DataChartArea";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Location = new System.Drawing.Point(12, 60);
            this.dataChart.Name = "dataChart";
            series1.ChartArea = "DataChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "DataChartSeries";
            this.dataChart.Series.Add(series1);
            this.dataChart.Size = new System.Drawing.Size(760, 489);
            this.dataChart.TabIndex = 49;
            this.dataChart.Text = "chart1";
            // 
            // ShowChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.maxNumericUpDown);
            this.Controls.Add(this.minNumericUpDown);
            this.Controls.Add(this.maxValueLabel);
            this.Controls.Add(this.minValueLabel);
            this.Controls.Add(this.changeIntervalButton);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ShowChartForm";
            this.Text = "ShowChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown maxNumericUpDown;
        private System.Windows.Forms.NumericUpDown minNumericUpDown;
        private System.Windows.Forms.Label maxValueLabel;
        private System.Windows.Forms.Label minValueLabel;
        private System.Windows.Forms.Button changeIntervalButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
    }
}