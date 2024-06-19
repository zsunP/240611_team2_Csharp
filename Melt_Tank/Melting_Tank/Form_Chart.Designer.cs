namespace Melting_Tank
{
    partial class Form_Chart
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Chart));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_Time = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_selctword = new System.Windows.Forms.Label();
            this.chart_no1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_Time = new System.Windows.Forms.ComboBox();
            this.button_Temp = new System.Windows.Forms.Button();
            this.button_Motorspeed = new System.Windows.Forms.Button();
            this.button_MELT_WEIGHT = new System.Windows.Forms.Button();
            this.button_INSP = new System.Windows.Forms.Button();
            this.button_Max = new System.Windows.Forms.Button();
            this.button_Min = new System.Windows.Forms.Button();
            this.label_analys_over = new System.Windows.Forms.Label();
            this.label_analys_low = new System.Windows.Forms.Label();
            this.textBox_search_over = new System.Windows.Forms.TextBox();
            this.textBox_search_low = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Chart = new System.Windows.Forms.DateTimePicker();
            this.chart_PassFail = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_no1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PassFail)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Time.Location = new System.Drawing.Point(12, 9);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(0, 15);
            this.label_Time.TabIndex = 0;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("에스코어 드림 5 Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_title.Location = new System.Drawing.Point(212, 595);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(375, 33);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "불량률 감소를 위한 데이터시각화";
            // 
            // label_selctword
            // 
            this.label_selctword.AutoSize = true;
            this.label_selctword.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_selctword.Location = new System.Drawing.Point(161, 663);
            this.label_selctword.Name = "label_selctword";
            this.label_selctword.Size = new System.Drawing.Size(127, 15);
            this.label_selctword.TabIndex = 2;
            this.label_selctword.Text = "날짜를선택하세요";
            // 
            // chart_no1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_no1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_no1.Legends.Add(legend1);
            this.chart_no1.Location = new System.Drawing.Point(24, 30);
            this.chart_no1.Name = "chart_no1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_no1.Series.Add(series1);
            this.chart_no1.Size = new System.Drawing.Size(794, 429);
            this.chart_no1.TabIndex = 4;
            this.chart_no1.Text = "chart1";
            // 
            // comboBox_Time
            // 
            this.comboBox_Time.FormattingEnabled = true;
            this.comboBox_Time.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "24:00"});
            this.comboBox_Time.Location = new System.Drawing.Point(509, 661);
            this.comboBox_Time.Name = "comboBox_Time";
            this.comboBox_Time.Size = new System.Drawing.Size(160, 20);
            this.comboBox_Time.TabIndex = 5;
            // 
            // button_Temp
            // 
            this.button_Temp.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Temp.Location = new System.Drawing.Point(136, 724);
            this.button_Temp.Name = "button_Temp";
            this.button_Temp.Size = new System.Drawing.Size(106, 35);
            this.button_Temp.TabIndex = 7;
            this.button_Temp.Text = "MELT_TEMP";
            this.button_Temp.UseVisualStyleBackColor = true;
            this.button_Temp.Click += new System.EventHandler(this.button_Temp_Click);
            // 
            // button_Motorspeed
            // 
            this.button_Motorspeed.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Motorspeed.Location = new System.Drawing.Point(284, 724);
            this.button_Motorspeed.Name = "button_Motorspeed";
            this.button_Motorspeed.Size = new System.Drawing.Size(108, 35);
            this.button_Motorspeed.TabIndex = 8;
            this.button_Motorspeed.Text = "MOTORSPEED";
            this.button_Motorspeed.UseVisualStyleBackColor = true;
            // 
            // button_MELT_WEIGHT
            // 
            this.button_MELT_WEIGHT.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_MELT_WEIGHT.Location = new System.Drawing.Point(426, 724);
            this.button_MELT_WEIGHT.Name = "button_MELT_WEIGHT";
            this.button_MELT_WEIGHT.Size = new System.Drawing.Size(121, 35);
            this.button_MELT_WEIGHT.TabIndex = 9;
            this.button_MELT_WEIGHT.Text = "MELT_WEIGHT";
            this.button_MELT_WEIGHT.UseVisualStyleBackColor = true;
            // 
            // button_INSP
            // 
            this.button_INSP.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_INSP.Location = new System.Drawing.Point(599, 724);
            this.button_INSP.Name = "button_INSP";
            this.button_INSP.Size = new System.Drawing.Size(95, 35);
            this.button_INSP.TabIndex = 10;
            this.button_INSP.Text = "INSP";
            this.button_INSP.UseVisualStyleBackColor = true;
            // 
            // button_Max
            // 
            this.button_Max.Location = new System.Drawing.Point(762, 619);
            this.button_Max.Name = "button_Max";
            this.button_Max.Size = new System.Drawing.Size(75, 23);
            this.button_Max.TabIndex = 11;
            this.button_Max.Text = "최대값표시";
            this.button_Max.UseVisualStyleBackColor = true;
            // 
            // button_Min
            // 
            this.button_Min.Location = new System.Drawing.Point(762, 655);
            this.button_Min.Name = "button_Min";
            this.button_Min.Size = new System.Drawing.Size(75, 23);
            this.button_Min.TabIndex = 12;
            this.button_Min.Text = "최소값표시";
            this.button_Min.UseVisualStyleBackColor = true;
            this.button_Min.Click += new System.EventHandler(this.button_Min_Click);
            // 
            // label_analys_over
            // 
            this.label_analys_over.AutoSize = true;
            this.label_analys_over.Location = new System.Drawing.Point(853, 604);
            this.label_analys_over.Name = "label_analys_over";
            this.label_analys_over.Size = new System.Drawing.Size(38, 12);
            this.label_analys_over.TabIndex = 13;
            this.label_analys_over.Text = "label1";
            // 
            // label_analys_low
            // 
            this.label_analys_low.AutoSize = true;
            this.label_analys_low.Location = new System.Drawing.Point(849, 641);
            this.label_analys_low.Name = "label_analys_low";
            this.label_analys_low.Size = new System.Drawing.Size(38, 12);
            this.label_analys_low.TabIndex = 14;
            this.label_analys_low.Text = "label2";
            // 
            // textBox_search_over
            // 
            this.textBox_search_over.Location = new System.Drawing.Point(844, 619);
            this.textBox_search_over.Name = "textBox_search_over";
            this.textBox_search_over.Size = new System.Drawing.Size(125, 21);
            this.textBox_search_over.TabIndex = 15;
            // 
            // textBox_search_low
            // 
            this.textBox_search_low.Location = new System.Drawing.Point(845, 656);
            this.textBox_search_low.Name = "textBox_search_low";
            this.textBox_search_low.Size = new System.Drawing.Size(125, 21);
            this.textBox_search_low.TabIndex = 16;
            // 
            // dateTimePicker_Chart
            // 
            this.dateTimePicker_Chart.Location = new System.Drawing.Point(294, 662);
            this.dateTimePicker_Chart.Name = "dateTimePicker_Chart";
            this.dateTimePicker_Chart.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_Chart.TabIndex = 17;
            this.dateTimePicker_Chart.Value = new System.DateTime(2020, 3, 4, 0, 0, 0, 0);
            // 
            // chart_PassFail
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_PassFail.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_PassFail.Legends.Add(legend2);
            this.chart_PassFail.Location = new System.Drawing.Point(870, 109);
            this.chart_PassFail.Name = "chart_PassFail";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_PassFail.Series.Add(series2);
            this.chart_PassFail.Size = new System.Drawing.Size(323, 289);
            this.chart_PassFail.TabIndex = 18;
            this.chart_PassFail.Text = "chart1";
            // 
            // Form_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 880);
            this.Controls.Add(this.chart_PassFail);
            this.Controls.Add(this.dateTimePicker_Chart);
            this.Controls.Add(this.textBox_search_low);
            this.Controls.Add(this.textBox_search_over);
            this.Controls.Add(this.label_analys_low);
            this.Controls.Add(this.label_analys_over);
            this.Controls.Add(this.button_Min);
            this.Controls.Add(this.button_Max);
            this.Controls.Add(this.button_INSP);
            this.Controls.Add(this.button_MELT_WEIGHT);
            this.Controls.Add(this.button_Motorspeed);
            this.Controls.Add(this.button_Temp);
            this.Controls.Add(this.comboBox_Time);
            this.Controls.Add(this.chart_no1);
            this.Controls.Add(this.label_selctword);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_Time);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chart_no1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PassFail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_selctword;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_no1;
        private System.Windows.Forms.ComboBox comboBox_Time;
        private System.Windows.Forms.Button button_Temp;
        private System.Windows.Forms.Button button_Motorspeed;
        private System.Windows.Forms.Button button_MELT_WEIGHT;
        private System.Windows.Forms.Button button_INSP;
        private System.Windows.Forms.Button button_Max;
        private System.Windows.Forms.Button button_Min;
        private System.Windows.Forms.Label label_analys_over;
        private System.Windows.Forms.Label label_analys_low;
        private System.Windows.Forms.TextBox textBox_search_over;
        private System.Windows.Forms.TextBox textBox_search_low;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PassFail;
    }
}