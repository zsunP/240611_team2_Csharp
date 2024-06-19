namespace Melting_Tank
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.groupBox_menu = new System.Windows.Forms.GroupBox();
            this.button_DB_update = new System.Windows.Forms.Button();
            this.label_setEnd = new System.Windows.Forms.Label();
            this.label_setStart = new System.Windows.Forms.Label();
            this.textBox_Endindex = new System.Windows.Forms.TextBox();
            this.label_INDEX = new System.Windows.Forms.Label();
            this.textBox_Startindex = new System.Windows.Forms.TextBox();
            this.comboBox_FilterM = new System.Windows.Forms.ComboBox();
            this.label_searchfilterM = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.dateTimePicker_Main = new System.Windows.Forms.DateTimePicker();
            this.button_viewall = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.Button();
            this.button_folder = new System.Windows.Forms.Button();
            this.button_file = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.foldersearch = new System.Windows.Forms.Label();
            this.filesearch = new System.Windows.Forms.Label();
            this.groupBox_gridview = new System.Windows.Forms.GroupBox();
            this.dataGridView_Main = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_DB_delete = new System.Windows.Forms.Button();
            this.groupBox_menu.SuspendLayout();
            this.groupBox_gridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_menu
            // 
            this.groupBox_menu.Controls.Add(this.button_DB_update);
            this.groupBox_menu.Controls.Add(this.label_setEnd);
            this.groupBox_menu.Controls.Add(this.label_setStart);
            this.groupBox_menu.Controls.Add(this.textBox_Endindex);
            this.groupBox_menu.Controls.Add(this.label_INDEX);
            this.groupBox_menu.Controls.Add(this.textBox_Startindex);
            this.groupBox_menu.Controls.Add(this.comboBox_FilterM);
            this.groupBox_menu.Controls.Add(this.label_searchfilterM);
            this.groupBox_menu.Controls.Add(this.button_Search);
            this.groupBox_menu.Controls.Add(this.dateTimePicker_Main);
            this.groupBox_menu.Controls.Add(this.button_viewall);
            this.groupBox_menu.Controls.Add(this.chart);
            this.groupBox_menu.Controls.Add(this.button_folder);
            this.groupBox_menu.Controls.Add(this.button_file);
            this.groupBox_menu.Controls.Add(this.textBox_folder);
            this.groupBox_menu.Controls.Add(this.textBox_file);
            this.groupBox_menu.Controls.Add(this.foldersearch);
            this.groupBox_menu.Controls.Add(this.filesearch);
            this.groupBox_menu.Location = new System.Drawing.Point(1, 31);
            this.groupBox_menu.Name = "groupBox_menu";
            this.groupBox_menu.Size = new System.Drawing.Size(1095, 227);
            this.groupBox_menu.TabIndex = 0;
            this.groupBox_menu.TabStop = false;
            // 
            // button_DB_update
            // 
            this.button_DB_update.Location = new System.Drawing.Point(488, 20);
            this.button_DB_update.Name = "button_DB_update";
            this.button_DB_update.Size = new System.Drawing.Size(75, 23);
            this.button_DB_update.TabIndex = 4;
            this.button_DB_update.Text = "DB저장";
            this.button_DB_update.UseVisualStyleBackColor = true;
            // 
            // label_setEnd
            // 
            this.label_setEnd.AutoSize = true;
            this.label_setEnd.Location = new System.Drawing.Point(328, 87);
            this.label_setEnd.Name = "label_setEnd";
            this.label_setEnd.Size = new System.Drawing.Size(60, 13);
            this.label_setEnd.TabIndex = 60;
            this.label_setEnd.Text = "끝[END]";
            // 
            // label_setStart
            // 
            this.label_setStart.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label_setStart.AutoSize = true;
            this.label_setStart.Location = new System.Drawing.Point(101, 88);
            this.label_setStart.Name = "label_setStart";
            this.label_setStart.Size = new System.Drawing.Size(69, 13);
            this.label_setStart.TabIndex = 59;
            this.label_setStart.Text = "시작(TAG)";
            // 
            // textBox_Endindex
            // 
            this.textBox_Endindex.Location = new System.Drawing.Point(392, 83);
            this.textBox_Endindex.Name = "textBox_Endindex";
            this.textBox_Endindex.Size = new System.Drawing.Size(139, 22);
            this.textBox_Endindex.TabIndex = 58;
            // 
            // label_INDEX
            // 
            this.label_INDEX.AutoSize = true;
            this.label_INDEX.Location = new System.Drawing.Point(39, 88);
            this.label_INDEX.Name = "label_INDEX";
            this.label_INDEX.Size = new System.Drawing.Size(59, 13);
            this.label_INDEX.TabIndex = 57;
            this.label_INDEX.Text = "출력범위";
            // 
            // textBox_Startindex
            // 
            this.textBox_Startindex.Location = new System.Drawing.Point(176, 83);
            this.textBox_Startindex.Name = "textBox_Startindex";
            this.textBox_Startindex.Size = new System.Drawing.Size(139, 22);
            this.textBox_Startindex.TabIndex = 56;
            // 
            // comboBox_FilterM
            // 
            this.comboBox_FilterM.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBox_FilterM.FormattingEnabled = true;
            this.comboBox_FilterM.Items.AddRange(new object[] {
            "STD_DT",
            "NUM",
            "MELT_TEMP",
            "MOTORSPEED",
            "MELT_WEIGHT",
            "INSP",
            "TAG"});
            this.comboBox_FilterM.Location = new System.Drawing.Point(123, 57);
            this.comboBox_FilterM.Name = "comboBox_FilterM";
            this.comboBox_FilterM.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FilterM.TabIndex = 55;
            // 
            // label_searchfilterM
            // 
            this.label_searchfilterM.AutoSize = true;
            this.label_searchfilterM.Location = new System.Drawing.Point(39, 60);
            this.label_searchfilterM.Name = "label_searchfilterM";
            this.label_searchfilterM.Size = new System.Drawing.Size(59, 13);
            this.label_searchfilterM.TabIndex = 54;
            this.label_searchfilterM.Text = "검색항목";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(587, 56);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 53;
            this.button_Search.Text = "조회";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dateTimePicker_Main
            // 
            this.dateTimePicker_Main.Location = new System.Drawing.Point(260, 57);
            this.dateTimePicker_Main.Name = "dateTimePicker_Main";
            this.dateTimePicker_Main.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_Main.TabIndex = 50;
            this.dateTimePicker_Main.Value = new System.DateTime(2020, 3, 4, 0, 0, 0, 0);
            // 
            // button_viewall
            // 
            this.button_viewall.Location = new System.Drawing.Point(503, 55);
            this.button_viewall.Name = "button_viewall";
            this.button_viewall.Size = new System.Drawing.Size(75, 23);
            this.button_viewall.TabIndex = 12;
            this.button_viewall.Text = "전체조회";
            this.button_viewall.UseVisualStyleBackColor = true;
            this.button_viewall.Click += new System.EventHandler(this.button_viewall_Click);
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(949, 165);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(133, 39);
            this.chart.TabIndex = 6;
            this.chart.Text = "차트보기";
            this.chart.UseVisualStyleBackColor = true;
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(968, 16);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(75, 23);
            this.button_folder.TabIndex = 5;
            this.button_folder.Text = "폴더찾기";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(392, 19);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(75, 23);
            this.button_file.TabIndex = 4;
            this.button_file.Text = "파일찾기";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(710, 17);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(235, 22);
            this.textBox_folder.TabIndex = 3;
            // 
            // textBox_file
            // 
            this.textBox_file.Location = new System.Drawing.Point(134, 21);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(235, 22);
            this.textBox_file.TabIndex = 2;
            // 
            // foldersearch
            // 
            this.foldersearch.AutoSize = true;
            this.foldersearch.Location = new System.Drawing.Point(616, 22);
            this.foldersearch.Name = "foldersearch";
            this.foldersearch.Size = new System.Drawing.Size(72, 13);
            this.foldersearch.TabIndex = 1;
            this.foldersearch.Text = "폴더로찾기";
            // 
            // filesearch
            // 
            this.filesearch.AutoSize = true;
            this.filesearch.Location = new System.Drawing.Point(39, 30);
            this.filesearch.Name = "filesearch";
            this.filesearch.Size = new System.Drawing.Size(72, 13);
            this.filesearch.TabIndex = 0;
            this.filesearch.Text = "파일로찾기";
            // 
            // groupBox_gridview
            // 
            this.groupBox_gridview.Controls.Add(this.dataGridView_Main);
            this.groupBox_gridview.Location = new System.Drawing.Point(13, 279);
            this.groupBox_gridview.Name = "groupBox_gridview";
            this.groupBox_gridview.Size = new System.Drawing.Size(1031, 395);
            this.groupBox_gridview.TabIndex = 0;
            this.groupBox_gridview.TabStop = false;
            // 
            // dataGridView_Main
            // 
            this.dataGridView_Main.AllowUserToAddRows = false;
            this.dataGridView_Main.AllowUserToDeleteRows = false;
            this.dataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main.Location = new System.Drawing.Point(51, 13);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.ReadOnly = true;
            this.dataGridView_Main.RowTemplate.Height = 23;
            this.dataGridView_Main.Size = new System.Drawing.Size(882, 382);
            this.dataGridView_Main.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1122, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // button_DB_delete
            // 
            this.button_DB_delete.Location = new System.Drawing.Point(997, 252);
            this.button_DB_delete.Name = "button_DB_delete";
            this.button_DB_delete.Size = new System.Drawing.Size(75, 23);
            this.button_DB_delete.TabIndex = 5;
            this.button_DB_delete.Text = "DB삭제";
            this.button_DB_delete.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 686);
            this.Controls.Add(this.button_DB_delete);
            this.Controls.Add(this.groupBox_gridview);
            this.Controls.Add(this.groupBox_menu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "품질관리프로그램";
            this.groupBox_menu.ResumeLayout(false);
            this.groupBox_menu.PerformLayout();
            this.groupBox_gridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_menu;
        private System.Windows.Forms.GroupBox groupBox_gridview;
        private System.Windows.Forms.DataGridView dataGridView_Main;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.Label foldersearch;
        private System.Windows.Forms.Label filesearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.Button chart;
        private System.Windows.Forms.Button button_viewall;
        private System.Windows.Forms.Button button_DB_update;
        private System.Windows.Forms.Button button_DB_delete;
        private System.Windows.Forms.ComboBox comboBox_FilterM;
        private System.Windows.Forms.Label label_searchfilterM;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Main;
        private System.Windows.Forms.Label label_INDEX;
        private System.Windows.Forms.TextBox textBox_Startindex;
        private System.Windows.Forms.TextBox textBox_Endindex;
        private System.Windows.Forms.Label label_setStart;
        private System.Windows.Forms.Label label_setEnd;
    }
}

