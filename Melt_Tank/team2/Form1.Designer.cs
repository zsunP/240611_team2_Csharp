namespace team2
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartView = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터베이스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DBInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.분석ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.보기ToolStripMenuItem,
            this.데이터베이스ToolStripMenuItem,
            this.분석ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpen});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(180, 22);
            this.FileOpen.Text = "열기";
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChartView});
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.보기ToolStripMenuItem.Text = "보기";
            // 
            // ChartView
            // 
            this.ChartView.Name = "ChartView";
            this.ChartView.Size = new System.Drawing.Size(180, 22);
            this.ChartView.Text = "차트보기";
            // 
            // 데이터베이스ToolStripMenuItem
            // 
            this.데이터베이스ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DBInsert});
            this.데이터베이스ToolStripMenuItem.Name = "데이터베이스ToolStripMenuItem";
            this.데이터베이스ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.데이터베이스ToolStripMenuItem.Text = "데이터베이스";
            // 
            // DBInsert
            // 
            this.DBInsert.Name = "DBInsert";
            this.DBInsert.Size = new System.Drawing.Size(180, 22);
            this.DBInsert.Text = "데이터베이스연결";
            // 
            // 분석ToolStripMenuItem
            // 
            this.분석ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintLog});
            this.분석ToolStripMenuItem.Name = "분석ToolStripMenuItem";
            this.분석ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.분석ToolStripMenuItem.Text = "분석";
            // 
            // PrintLog
            // 
            this.PrintLog.Name = "PrintLog";
            this.PrintLog.Size = new System.Drawing.Size(180, 22);
            this.PrintLog.Text = "프린트로그";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileOpen;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChartView;
        private System.Windows.Forms.ToolStripMenuItem 데이터베이스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DBInsert;
        private System.Windows.Forms.ToolStripMenuItem 분석ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintLog;
    }
}

