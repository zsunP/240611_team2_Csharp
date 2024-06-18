using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // 차트 업데이트 메서드
        public void UpdateTempOneChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // OK와 NG를 분류
            var okRecords = filteredRecords.Where(record => record.TAG == "OK");
            var ngRecords = filteredRecords.Where(record => record.TAG == "NG");

            // OK와 NG의 평균 MELT_TEMP 계산
            double okAvgTemp = okRecords.Any() ? okRecords.Average(record => record.MELT_TEMP) : 0;
            double ngAvgTemp = ngRecords.Any() ? ngRecords.Average(record => record.MELT_TEMP) : 0;

            // 전체 데이터 수
            int totalCount = okRecords.Count() + ngRecords.Count();

            // 전체 데이터가 없는 경우 처리
            if (totalCount == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // OK와 NG의 평균 온도에 따른 퍼센트 계산
            double okPercent = Math.Round((okAvgTemp / (okAvgTemp + ngAvgTemp)) * 100, 2);
            double ngPercent = Math.Round((ngAvgTemp / (okAvgTemp + ngAvgTemp)) * 100, 2);

            // 디버깅 메시지
            MessageBox.Show($"OK 평균 온도: {okAvgTemp}, NG 평균 온도: {ngAvgTemp}\nOK: {okPercent}%\nNG: {ngPercent}%");

            // 차트 데이터 설정
            chart1.Series.Clear();
            Series series = chart1.Series.Add("MELT_TEMP");
            series.ChartType = SeriesChartType.Pie;
            series.Points.AddXY($"OK{okPercent}%", okPercent);
            series.Points.AddXY($"NG{ngPercent}%", ngPercent);

            // 차트 타이틀 설정
            chart1.Titles.Clear();
            chart1.Titles.Add($"기간에 따른 양품과 불량품 비율");
        }

        public void UpdateTempTwoChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // STD_DT 별 OK와 NG의 개수를 저장할 Dictionary
            Dictionary<DateTime, Tuple<int, int>> dateCounts = new Dictionary<DateTime, Tuple<int, int>>();

            // 데이터를 STD_DT 별로 그룹화하고 OK와 NG의 개수를 계산
            foreach (var record in filteredRecords)
            {
                DateTime stdDt = record.STD_DT.Date; // 날짜만 사용하기 위해 시간 부분 제거
                if (!dateCounts.ContainsKey(stdDt))
                {
                    dateCounts[stdDt] = new Tuple<int, int>(0, 0);
                }

                if (record.TAG == "OK")
                {
                    dateCounts[stdDt] = new Tuple<int, int>(dateCounts[stdDt].Item1 + 1, dateCounts[stdDt].Item2);
                }
                else if (record.TAG == "NG")
                {
                    dateCounts[stdDt] = new Tuple<int, int>(dateCounts[stdDt].Item1, dateCounts[stdDt].Item2 + 1);
                }
            }

            // 막대 그래프 데이터 설정
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.ChartAreas.Add(new ChartArea());

            Series seriesOK = new Series("OK");
            Series seriesNG = new Series("NG");

            seriesOK.ChartType = SeriesChartType.Column;
            seriesNG.ChartType = SeriesChartType.Column;

            foreach (var dateCount in dateCounts)
            {
                seriesOK.Points.AddXY(dateCount.Key.ToShortDateString(), dateCount.Value.Item1);
                seriesNG.Points.AddXY(dateCount.Key.ToShortDateString(), dateCount.Value.Item2);
            }

            chart2.Series.Add(seriesOK);
            chart2.Series.Add(seriesNG);

            // 축 레이블 및 제목 설정
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // 라벨 각도 설정

            chart2.Titles.Clear();
            chart2.Titles.Add("날짜 별 OK와 NG의 개수");

            // 차트 보여주기
            chart2.Visible = true;
        }
    } 
}
