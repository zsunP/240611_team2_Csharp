namespace test1
{
    partial class MoterSpeed
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoterSpeed));
            this.dataGridView_Main = new System.Windows.Forms.DataGridView();
            this.button_Csv = new System.Windows.Forms.Button();
            this.button_DBinsert = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.startDateComboBox = new System.Windows.Forms.ComboBox();
            this.endDateComboBox = new System.Windows.Forms.ComboBox();
            this.button_ChartShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Main
            // 
            this.dataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main.Location = new System.Drawing.Point(57, 62);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.RowTemplate.Height = 23;
            this.dataGridView_Main.Size = new System.Drawing.Size(764, 302);
            this.dataGridView_Main.TabIndex = 0;
            // 
            // button_Csv
            // 
            this.button_Csv.Location = new System.Drawing.Point(610, 435);
            this.button_Csv.Name = "button_Csv";
            this.button_Csv.Size = new System.Drawing.Size(102, 71);
            this.button_Csv.TabIndex = 1;
            this.button_Csv.Text = "CSV Read";
            this.button_Csv.UseVisualStyleBackColor = true;
            this.button_Csv.Click += new System.EventHandler(this.button_Csv_Click);
            // 
            // button_DBinsert
            // 
            this.button_DBinsert.Location = new System.Drawing.Point(745, 435);
            this.button_DBinsert.Name = "button_DBinsert";
            this.button_DBinsert.Size = new System.Drawing.Size(102, 71);
            this.button_DBinsert.TabIndex = 2;
            this.button_DBinsert.Text = "DB Insert";
            this.button_DBinsert.UseVisualStyleBackColor = true;
            this.button_DBinsert.Click += new System.EventHandler(this.button_DBinsert_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(394, 376);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(103, 39);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "필터";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // startDateComboBox
            // 
            this.startDateComboBox.FormattingEnabled = true;
            this.startDateComboBox.Location = new System.Drawing.Point(57, 386);
            this.startDateComboBox.Name = "startDateComboBox";
            this.startDateComboBox.Size = new System.Drawing.Size(150, 20);
            this.startDateComboBox.TabIndex = 1;
            // 
            // endDateComboBox
            // 
            this.endDateComboBox.FormattingEnabled = true;
            this.endDateComboBox.Location = new System.Drawing.Point(227, 386);
            this.endDateComboBox.Name = "endDateComboBox";
            this.endDateComboBox.Size = new System.Drawing.Size(150, 20);
            this.endDateComboBox.TabIndex = 3;
            // 
            // button_ChartShow
            // 
            this.button_ChartShow.Location = new System.Drawing.Point(481, 437);
            this.button_ChartShow.Name = "button_ChartShow";
            this.button_ChartShow.Size = new System.Drawing.Size(98, 69);
            this.button_ChartShow.TabIndex = 6;
            this.button_ChartShow.Text = "Chart출력";
            this.button_ChartShow.UseVisualStyleBackColor = true;
            this.button_ChartShow.Click += new System.EventHandler(this.button_ChartShow_Click);
            // 
            // MoterSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 550);
            this.Controls.Add(this.button_ChartShow);
            this.Controls.Add(this.endDateComboBox);
            this.Controls.Add(this.startDateComboBox);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.button_DBinsert);
            this.Controls.Add(this.button_Csv);
            this.Controls.Add(this.dataGridView_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoterSpeed";
            this.Text = "데이터입력및출력";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Main;
        private System.Windows.Forms.Button button_Csv;
        private System.Windows.Forms.Button button_DBinsert;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.ComboBox startDateComboBox;
        private System.Windows.Forms.ComboBox endDateComboBox;
        private System.Windows.Forms.Button button_ChartShow;
    }
}

