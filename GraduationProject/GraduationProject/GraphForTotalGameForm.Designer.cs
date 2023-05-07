
namespace GraduationProject
{
    partial class GraphForTotalGameForm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.closeButton = new System.Windows.Forms.Button();
            this.playTimesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalPlayTermChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.playTermChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.scoreChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.playTimesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPlayTermChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playTermChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreChart)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(622, 547);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(110, 46);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // playTimesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.playTimesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.playTimesChart.Legends.Add(legend1);
            this.playTimesChart.Location = new System.Drawing.Point(12, 12);
            this.playTimesChart.Name = "playTimesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.playTimesChart.Series.Add(series1);
            this.playTimesChart.Size = new System.Drawing.Size(350, 250);
            this.playTimesChart.TabIndex = 1;
            this.playTimesChart.Text = "chart1";
            // 
            // totalPlayTermChart
            // 
            chartArea2.Name = "ChartArea1";
            this.totalPlayTermChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.totalPlayTermChart.Legends.Add(legend2);
            this.totalPlayTermChart.Location = new System.Drawing.Point(382, 12);
            this.totalPlayTermChart.Name = "totalPlayTermChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.totalPlayTermChart.Series.Add(series2);
            this.totalPlayTermChart.Size = new System.Drawing.Size(350, 250);
            this.totalPlayTermChart.TabIndex = 1;
            this.totalPlayTermChart.Text = "chart1";
            // 
            // playTermChart
            // 
            chartArea3.Name = "ChartArea1";
            this.playTermChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.playTermChart.Legends.Add(legend3);
            this.playTermChart.Location = new System.Drawing.Point(12, 281);
            this.playTermChart.Name = "playTermChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.playTermChart.Series.Add(series3);
            this.playTermChart.Size = new System.Drawing.Size(350, 250);
            this.playTermChart.TabIndex = 1;
            this.playTermChart.Text = "chart1";
            // 
            // scoreChart
            // 
            chartArea4.Name = "ChartArea1";
            this.scoreChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.scoreChart.Legends.Add(legend4);
            this.scoreChart.Location = new System.Drawing.Point(382, 281);
            this.scoreChart.Name = "scoreChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.scoreChart.Series.Add(series4);
            this.scoreChart.Size = new System.Drawing.Size(350, 250);
            this.scoreChart.TabIndex = 1;
            this.scoreChart.Text = "chart1";
            // 
            // GraphForTotalGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(747, 604);
            this.Controls.Add(this.scoreChart);
            this.Controls.Add(this.playTermChart);
            this.Controls.Add(this.totalPlayTermChart);
            this.Controls.Add(this.playTimesChart);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphForTotalGameForm";
            this.Text = "グラフ表示（概要）";
            this.Load += new System.EventHandler(this.GraphForTotalGameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playTimesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPlayTermChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playTermChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart playTimesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart totalPlayTermChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart playTermChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart scoreChart;
    }
}