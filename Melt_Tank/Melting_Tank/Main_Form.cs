using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Melting_Tank
{
    public partial class Mainform : Form
    {

        public Mainform()
        {
            InitializeComponent();
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            try
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = selectedFolderPath; // FolderBrowserDialog에서 선택한 폴더로 초기 디렉토리 설정
                openFileDialog.Multiselect = true; // 다중 파일 선택 가능하도록 설정

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 사용자가 선택한 파일들의 경로를 가져옵니다.
                    string[] selectedFiles = openFileDialog.FileNames;
                    textBox_file.Text = string.Join(Environment.NewLine, selectedFiles);


                }
            }
            catch (Exception ex)
            {
                // 예외가 발생한 경우 사용자에게 메시지를 표시합니다.
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
            }




        }

        private void button_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath;

                try
                {
                    // 선택된 폴더의 내용을 사용자에게 표시하거나, 폴더 내 파일 목록을 얻어올 수 있습니다.
                    textBox_folder.Text = selectedFolderPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
                }
            }
        }

     

        private void chart_Click(object sender, EventArgs e)
        {
            Form_Chart form_chart = new Form_Chart();
            form_chart.Show();
        }
      
        private void button_viewall_Click(object sender, EventArgs e)
        {
            DataManager.Load();
            dataGridView_Main.DataSource = null;
            if (DataManager.datas.Count > 0)
            {
                dataGridView_Main.DataSource = DataManager.datas;
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

            if (comboBox_FilterM.SelectedItem != null)
            {

                DataManager.Load(comboBox_FilterM, dateTimePicker_Main, textBox_Startindex, textBox_Endindex);
                dataGridView_Main.DataSource = null;
                if (DataManager.datas.Count > 0)
                {
                    dataGridView_Main.DataSource = DataManager.datas;
                }

            }
            else {

                MessageBox.Show("검색주제를 정해주세요");
            }

          



        }

       
    }
}
