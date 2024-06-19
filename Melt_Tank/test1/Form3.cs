using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void UpdateMotorSpeedChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // STD_DT 날짜 별 MOTORSPEED 통계를 저장할 Dictionary
            Dictionary<DateTime, MotorSpeedStats> dateStats = new Dictionary<DateTime, MotorSpeedStats>();

            // 데이터를 STD_DT 별로 그룹화하고 통계값 계산
            var groupedByDate = filteredRecords.GroupBy(record => record.STD_DT.Date);

            foreach (var group in groupedByDate)
            {
                DateTime date = group.Key;

                // 평균값 계산
                double avgSpeed = group.Average(record => record.MOTORSPEED);

                // 중앙값 계산
                var sortedSpeeds = group.OrderBy(record => record.MOTORSPEED).Select(record => record.MOTORSPEED).ToList();
                double medianSpeed = CalculateMedian(sortedSpeeds);

                // 최빈값 계산
                double modeSpeed = CalculateMode(sortedSpeeds);

                // STD_DT 별 통계 저장
                dateStats[date] = new MotorSpeedStats
                {
                    AvgSpeed = avgSpeed,
                    MedianSpeed = medianSpeed,
                    ModeSpeed = modeSpeed
                };
            }

            // 막대 그래프 데이터 설정
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            Series seriesAvg = new Series("평균값");
            Series seriesMedian = new Series("중앙값");
            Series seriesMode = new Series("최빈값");

            seriesAvg.ChartType = SeriesChartType.Column;
            seriesMedian.ChartType = SeriesChartType.Column;
            seriesMode.ChartType = SeriesChartType.Column;

            // 각 시리즈에 데이터 추가
            foreach (var dateStat in dateStats)
            {
                DateTime date = dateStat.Key;
                MotorSpeedStats stats = dateStat.Value;

                // 같은 날짜에 대해 서로 다른 시리즈에 값 추가
                seriesAvg.Points.AddXY(date.ToShortDateString(), stats.AvgSpeed);
                seriesMedian.Points.AddXY(date.ToShortDateString(), stats.MedianSpeed);
                seriesMode.Points.AddXY(date.ToShortDateString(), stats.ModeSpeed);
            }

            // 시리즈 추가
            chart1.Series.Add(seriesAvg);
            chart1.Series.Add(seriesMedian);
            chart1.Series.Add(seriesMode);

            // 축 설정
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정

            // 제목 설정
            chart1.Titles.Clear();
            chart1.Titles.Add("날짜 별 모터스피드 통계");

            // 차트 보여주기
            chart1.Visible = true;
        }

        // 중앙값 계산 함수
        private double CalculateMedian(List<double> sortedValues)
        {
            int count = sortedValues.Count;
            if (count % 2 == 0)
            {
                // 짝수개인 경우 중앙에 있는 두 값의 평균
                int midIndex = count / 2;
                return (sortedValues[midIndex - 1] + sortedValues[midIndex]) / 2.0;
            }
            else
            {
                // 홀수개인 경우 중앙값
                return sortedValues[count / 2];
            }
        }

        // 최빈값 계산 함수
        private double CalculateMode(List<double> values)
        {
            // 빈도를 저장할 Dictionary
            Dictionary<double, int> frequencyMap = new Dictionary<double, int>();

            // 빈도 맵 생성
            foreach (double value in values)
            {
                if (frequencyMap.ContainsKey(value))
                {
                    frequencyMap[value]++;
                }
                else
                {
                    frequencyMap[value] = 1;
                }
            }

            // 최빈값 찾기
            double modeValue = double.MinValue;
            int maxFrequency = 0;

            foreach (var pair in frequencyMap)
            {
                if (pair.Value > maxFrequency)
                {
                    maxFrequency = pair.Value;
                    modeValue = pair.Key;
                }
            }

            return modeValue;
        }
    }
 }
