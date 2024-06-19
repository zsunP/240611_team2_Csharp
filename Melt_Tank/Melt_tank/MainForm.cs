using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test1
{
    public partial class MoterSpeed : Form
    {
        private List<Data> records;
        private List<Data> filteredRecords;

        public MoterSpeed()
        {
            InitializeComponent();

            // 폼 로드 시 ComboBox 초기화
            InitializeDateComboBoxes();
        }

        // ComboBox 초기화 메서드
        private void InitializeDateComboBoxes()
        {
            // records가 로드되어 있다고 가정하고, 그 중에서 날짜 목록을 추출하여 ComboBox에 추가
            if (records != null && records.Count > 0)
            {
                // 중복을 제거한 날짜 목록 추출
                var dateList = records.Select(r => r.STD_DT.Date).Distinct().OrderBy(d => d).ToList();

                // ComboBox에 날짜 목록 추가
                foreach (var date in dateList)
                {
                    startDateComboBox.Items.Add(date.ToString("yyyy-MM-dd"));
                    endDateComboBox.Items.Add(date.ToString("yyyy-MM-dd"));
                }

                // 첫 번째 아이템 선택 (선택 사항)
                startDateComboBox.SelectedIndex = 0;
                endDateComboBox.SelectedIndex = endDateComboBox.Items.Count - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    records = ReadCsvFile(filePath);
                    dataGridView1.DataSource = records;

                    // CSV 파일 로드 후 ComboBox 업데이트
                    InitializeDateComboBoxes();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-MSVGK7N;Database=test;Integrated Security=True;";
            InsertDataIntoSqlServer(filteredRecords ?? records, connectionString);
        }

        private static List<Data> ReadCsvFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<Data>();
                return new List<Data>(records);
            }
        }

        public static void InsertDataIntoSqlServer(List<Data> records, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var record in records)
                {
                    string query = "INSERT INTO melting_tank (STD_DT, NUM, MELT_TEMP, MOTORSPEED, MELT_WEIGHT, INSP, TAG) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@p1", record.STD_DT);
                        command.Parameters.AddWithValue("@p2", record.NUM);
                        command.Parameters.AddWithValue("@p3", record.MELT_TEMP);
                        command.Parameters.AddWithValue("@p4", record.MOTORSPEED);
                        command.Parameters.AddWithValue("@p5", record.MELT_WEIGHT);
                        command.Parameters.AddWithValue("@p6", record.INSP);
                        command.Parameters.AddWithValue("@p7", record.TAG);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (records == null || records.Count == 0)
            {
                MessageBox.Show("CSV 파일을 먼저 로드하세요.");
                return;
            }


            DateTime startDate, endDate;

            if (!DateTime.TryParse(startDateComboBox.SelectedItem?.ToString(), out startDate))
            {
                MessageBox.Show("유효한 시작 날짜를 선택하세요.");
                return;
            }

            if (!DateTime.TryParse(endDateComboBox.SelectedItem?.ToString(), out endDate))
            {
                MessageBox.Show("유효한 종료 날짜를 선택하세요.");
                return;
            }

            // 시작 날짜보다 크거나 같고, 종료 날짜보다 작거나 같은 데이터 필터링
            filteredRecords = records.Where(record => record.STD_DT.Date >= startDate && record.STD_DT.Date <= endDate).ToList();
            dataGridView1.DataSource = filteredRecords;
        }

        private void Temp_Click_1(object sender, EventArgs e)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            Chart form2 = new Chart();
            form2.UpdateTempOneChart(filteredRecords);
            form2.UpdateTempTwoChart(filteredRecords);
            form2.ShowDialog();
        }
        private void Speed_Click(object sender, EventArgs e) //모터스피드
        {
            if (records == null || records.Count == 0)
            {
                MessageBox.Show("CSV 파일을 먼저 로드하세요.");
                return;
            }

            Form3 form3 = new Form3();
            form3.UpdateMotorSpeedChart(filteredRecords);
            form3.ShowDialog();
        }

        private void Weight_Click(object sender, EventArgs e) //Weight
        {
            if (records == null || records.Count == 0)
            {
                MessageBox.Show("CSV 파일을 먼저 로드하세요.");
                return;
            }

            Form4 form4 = new Form4();
          
            form4.ShowDialog();
        }

        private void Insp_Click(object sender, EventArgs e) //INSP
        {
            if (records == null || records.Count == 0)
            {
                MessageBox.Show("CSV 파일을 먼저 로드하세요.");
                return;
            }

            Form5 form5 = new Form5();
          
            form5.ShowDialog();
        }

       
    }
}
