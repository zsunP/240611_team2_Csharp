namespace Melting_Tank
{
    partial class Form_Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Filter));
            this.Endindex_Filter = new System.Windows.Forms.NumericUpDown();
            this.Startindex_Filter = new System.Windows.Forms.NumericUpDown();
            this.textBox_Max = new System.Windows.Forms.TextBox();
            this.textBox_Min = new System.Windows.Forms.TextBox();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.label_End = new System.Windows.Forms.Label();
            this.label_Start = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.label_searchfilter = new System.Windows.Forms.Label();
            this.notice_Filter = new System.Windows.Forms.Label();
            this.button_viewFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Endindex_Filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Startindex_Filter)).BeginInit();
            this.SuspendLayout();
            // 
            // Endindex_Filter
            // 
            this.Endindex_Filter.Location = new System.Drawing.Point(143, 231);
            this.Endindex_Filter.Name = "Endindex_Filter";
            this.Endindex_Filter.Size = new System.Drawing.Size(120, 21);
            this.Endindex_Filter.TabIndex = 51;
            // 
            // Startindex_Filter
            // 
            this.Startindex_Filter.Location = new System.Drawing.Point(140, 181);
            this.Startindex_Filter.Name = "Startindex_Filter";
            this.Startindex_Filter.Size = new System.Drawing.Size(120, 21);
            this.Startindex_Filter.TabIndex = 50;
            // 
            // textBox_Max
            // 
            this.textBox_Max.Location = new System.Drawing.Point(141, 121);
            this.textBox_Max.Name = "textBox_Max";
            this.textBox_Max.Size = new System.Drawing.Size(119, 21);
            this.textBox_Max.TabIndex = 49;
            // 
            // textBox_Min
            // 
            this.textBox_Min.Location = new System.Drawing.Point(142, 61);
            this.textBox_Min.Name = "textBox_Min";
            this.textBox_Min.Size = new System.Drawing.Size(121, 21);
            this.textBox_Min.TabIndex = 48;
            // 
            // comboBox_Filter
            // 
            this.comboBox_Filter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Items.AddRange(new object[] {
            "NUM",
            "MELT_TEMP",
            "MOTORSPEED",
            "MELT_WEIGHT",
            "INSP",
            "TAG"});
            this.comboBox_Filter.Location = new System.Drawing.Point(142, 24);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Filter.TabIndex = 47;
            this.comboBox_Filter.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filter_SelectedIndexChanged);
            // 
            // label_End
            // 
            this.label_End.AutoSize = true;
            this.label_End.Location = new System.Drawing.Point(58, 233);
            this.label_End.Name = "label_End";
            this.label_End.Size = new System.Drawing.Size(65, 12);
            this.label_End.TabIndex = 46;
            this.label_End.Text = "인덱스범위";
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(58, 188);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(65, 12);
            this.label_Start.TabIndex = 45;
            this.label_Start.Text = "시작인덱스";
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Location = new System.Drawing.Point(58, 124);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(65, 12);
            this.label_Max.TabIndex = 44;
            this.label_Max.Text = "값최대범위";
            // 
            // label_Min
            // 
            this.label_Min.AutoSize = true;
            this.label_Min.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Min.Location = new System.Drawing.Point(58, 70);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(65, 12);
            this.label_Min.TabIndex = 43;
            this.label_Min.Text = "값최소범위";
            // 
            // label_searchfilter
            // 
            this.label_searchfilter.AutoSize = true;
            this.label_searchfilter.Location = new System.Drawing.Point(58, 27);
            this.label_searchfilter.Name = "label_searchfilter";
            this.label_searchfilter.Size = new System.Drawing.Size(53, 12);
            this.label_searchfilter.TabIndex = 42;
            this.label_searchfilter.Text = "검색항목";
            // 
            // notice_Filter
            // 
            this.notice_Filter.AutoSize = true;
            this.notice_Filter.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.notice_Filter.Location = new System.Drawing.Point(29, 281);
            this.notice_Filter.Name = "notice_Filter";
            this.notice_Filter.Size = new System.Drawing.Size(0, 15);
            this.notice_Filter.TabIndex = 52;
            // 
            // button_viewFilter
            // 
            this.button_viewFilter.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_viewFilter.Location = new System.Drawing.Point(122, 326);
            this.button_viewFilter.Name = "button_viewFilter";
            this.button_viewFilter.Size = new System.Drawing.Size(103, 23);
            this.button_viewFilter.TabIndex = 53;
            this.button_viewFilter.Text = "조회하기";
            this.button_viewFilter.UseVisualStyleBackColor = true;
            // 
            // Form_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 466);
            this.Controls.Add(this.button_viewFilter);
            this.Controls.Add(this.notice_Filter);
            this.Controls.Add(this.Endindex_Filter);
            this.Controls.Add(this.Startindex_Filter);
            this.Controls.Add(this.textBox_Max);
            this.Controls.Add(this.textBox_Min);
            this.Controls.Add(this.comboBox_Filter);
            this.Controls.Add(this.label_End);
            this.Controls.Add(this.label_Start);
            this.Controls.Add(this.label_Max);
            this.Controls.Add(this.label_Min);
            this.Controls.Add(this.label_searchfilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "필터링";
            ((System.ComponentModel.ISupportInitialize)(this.Endindex_Filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Startindex_Filter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Endindex_Filter;
        private System.Windows.Forms.NumericUpDown Startindex_Filter;
        private System.Windows.Forms.TextBox textBox_Max;
        private System.Windows.Forms.TextBox textBox_Min;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.Label label_End;
        private System.Windows.Forms.Label label_Start;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_searchfilter;
        private System.Windows.Forms.Label notice_Filter;
        private System.Windows.Forms.Button button_viewFilter;
    }
}