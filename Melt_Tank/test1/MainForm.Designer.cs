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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Temp = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.startDateComboBox = new System.Windows.Forms.ComboBox();
            this.endDateComboBox = new System.Windows.Forms.ComboBox();
            this.Speed = new System.Windows.Forms.Button();
            this.Weight = new System.Windows.Forms.Button();
            this.Insp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(764, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(539, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "CSV Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(674, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 71);
            this.button2.TabIndex = 2;
            this.button2.Text = "DB Insert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Temp
            // 
            this.Temp.Location = new System.Drawing.Point(12, 379);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(103, 59);
            this.Temp.TabIndex = 3;
            this.Temp.Text = "온도";
            this.Temp.UseVisualStyleBackColor = true;
            this.Temp.Click += new System.EventHandler(this.Temp_Click_1);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(356, 334);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(73, 20);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "필터";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // startDateComboBox
            // 
            this.startDateComboBox.FormattingEnabled = true;
            this.startDateComboBox.Location = new System.Drawing.Point(12, 335);
            this.startDateComboBox.Name = "startDateComboBox";
            this.startDateComboBox.Size = new System.Drawing.Size(150, 20);
            this.startDateComboBox.TabIndex = 1;
            // 
            // endDateComboBox
            // 
            this.endDateComboBox.FormattingEnabled = true;
            this.endDateComboBox.Location = new System.Drawing.Point(182, 335);
            this.endDateComboBox.Name = "endDateComboBox";
            this.endDateComboBox.Size = new System.Drawing.Size(150, 20);
            this.endDateComboBox.TabIndex = 3;
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(136, 379);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(103, 59);
            this.Speed.TabIndex = 6;
            this.Speed.Text = "교반속도";
            this.Speed.UseVisualStyleBackColor = true;
            this.Speed.Click += new System.EventHandler(this.Speed_Click);
            // 
            // Weight
            // 
            this.Weight.Location = new System.Drawing.Point(258, 379);
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(103, 59);
            this.Weight.TabIndex = 7;
            this.Weight.Text = "내용중량";
            this.Weight.UseVisualStyleBackColor = true;
            this.Weight.Click += new System.EventHandler(this.Weight_Click);
            // 
            // Insp
            // 
            this.Insp.Location = new System.Drawing.Point(380, 379);
            this.Insp.Name = "Insp";
            this.Insp.Size = new System.Drawing.Size(103, 59);
            this.Insp.TabIndex = 8;
            this.Insp.Text = "수분함유량";
            this.Insp.UseVisualStyleBackColor = true;
            this.Insp.Click += new System.EventHandler(this.Insp_Click);
            // 
            // MoterSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Insp);
            this.Controls.Add(this.Weight);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.endDateComboBox);
            this.Controls.Add(this.startDateComboBox);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.Temp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MoterSpeed";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Temp;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.ComboBox startDateComboBox;
        private System.Windows.Forms.ComboBox endDateComboBox;
        private System.Windows.Forms.Button Speed;
        private System.Windows.Forms.Button Weight;
        private System.Windows.Forms.Button Insp;
    }
}

