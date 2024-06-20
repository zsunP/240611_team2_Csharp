using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test1
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        // 차트 업데이트 메서드
        public void UpdatePassFailChart(List<Data> filteredRecords)
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
            double ngPercent = Math.Round(((double)ngRecords.Count() / totalCount) * 100, 2);
            double okPercent = Math.Round(((double)okRecords.Count() / totalCount) * 100, 2);

            // 차트 초기화
            chart_OKNG.Series.Clear();
            Series series = chart_OKNG.Series.Add("MELT_TEMP");
            series.ChartType = SeriesChartType.Pie;

            // OK 데이터 추가 (파란색)
            DataPoint okPoint = series.Points.Add(okPercent);
            okPoint.Color = Color.Blue;
            okPoint.LegendText = $"OK {okPercent}%";

            // NG 데이터 추가 (빨간색)
            DataPoint ngPoint = series.Points.Add(ngPercent);
            ngPoint.Color = Color.Red;
            ngPoint.LegendText = $"NG {ngPercent}%";

            // 차트 타이틀 설정
            chart_OKNG.Titles.Clear();
            chart_OKNG.Titles.Add("기간에 따른 양품과 불량품 비율");

            // 범례 설정
            chart_OKNG.Legends.Clear();
            chart_OKNG.Legends.Add(new Legend("Legend"));
            chart_OKNG.Series["MELT_TEMP"].Legend = "Legend";

            // 차트 보여주기
            chart_OKNG.Visible = true;
        }

        public void UpdatePassFailbyDayChart(List<Data> filteredRecords)
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
            Chart_PassFail.Series.Clear();
            Chart_PassFail.ChartAreas.Clear();
            Chart_PassFail.ChartAreas.Add(new ChartArea());

            Series seriesOK = new Series("OK");
            Series seriesNG = new Series("NG");

            seriesOK.ChartType = SeriesChartType.Column;
            seriesNG.ChartType = SeriesChartType.Column;

            foreach (var dateCount in dateCounts)
            {
                seriesOK.Points.AddXY(dateCount.Key.ToShortDateString(), dateCount.Value.Item1);
                seriesNG.Points.AddXY(dateCount.Key.ToShortDateString(), dateCount.Value.Item2);
            }

            // OK는 파랑, NG는 빨강으로 설정
            seriesOK.Color = Color.Blue;
            seriesNG.Color = Color.Red;

            Chart_PassFail.Series.Add(seriesOK);
            Chart_PassFail.Series.Add(seriesNG);

            // 축 레이블 및 제목 설정
            Chart_PassFail.ChartAreas[0].AxisX.Interval = 1;
            Chart_PassFail.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // 라벨 각도 설정

            Chart_PassFail.Titles.Clear();
            Chart_PassFail.Titles.Add("날짜 별 OK와 NG의 개수");

            // 차트 보여주기
            Chart_PassFail.Visible = true;
        }

        public void UpdateMotorSpeedChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // NG와 OK를 구분하여 데이터 저장
            List<Data> ngData = filteredRecords.Where(record => record.TAG == "NG").ToList();
            List<Data> okData = filteredRecords.Where(record => record.TAG == "OK").ToList();

            // NUM을 기준으로 데이터 정렬
            ngData = ngData.OrderBy(record => record.NUM).ToList();
            okData = okData.OrderBy(record => record.NUM).ToList();

            // NUM 값 별로 평균값 구하기
            List<Data> ngAveragedData = AverageDataByNUM(ngData);
            List<Data> okAveragedData = AverageDataByNUM(okData);

            // 산점도 초기화
            chart_Mspeed.Series.Clear();
            chart_Mspeed.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Mspeed.ChartAreas.Add(chartArea);

            Series seriesNG = new Series("NG");
            Series seriesOK = new Series("OK");

            seriesNG.ChartType = SeriesChartType.Point;
            seriesOK.ChartType = SeriesChartType.Point;

            // NG 데이터 추가 (평균값 기준)
            foreach (var record in ngAveragedData)
            {
                seriesNG.Points.AddXY(record.NUM, record.MOTORSPEED);
            }

            // OK 데이터 추가 (평균값 기준)
            foreach (var record in okAveragedData)
            {
                seriesOK.Points.AddXY(record.NUM, record.MOTORSPEED);
            }

            // 색깔 지정
            seriesOK.Color = Color.Blue;
            seriesNG.Color = Color.Red;

            // 시리즈 추가
            chart_Mspeed.Series.Add(seriesNG);
            chart_Mspeed.Series.Add(seriesOK);

            // 축 설정
            chart_Mspeed.ChartAreas[0].AxisX.Interval = 1; // NUM이 정수형이므로 1 간격 설정
            chart_Mspeed.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정
            chart_Mspeed.ChartAreas[0].AxisX.Title = "NUM"; // X 축 제목 설정
            chart_Mspeed.ChartAreas[0].AxisY.Title = "Motor Speed"; // Y 축 제목 설정

            // 제목 설정
            chart_Mspeed.Titles.Clear();
            chart_Mspeed.Titles.Add("NUM 별 모터스피드 평균 (NG vs OK)");

            // 차트 보여주기
            chart_Mspeed.Visible = true;
        }

        // NUM 값을 기준으로 데이터를 평균 내어 반환하는 메서드
        private List<Data> AverageDataByNUM(List<Data> dataList)
        {
            var averagedData = new List<Data>();
            var groupedData = dataList.GroupBy(record => record.NUM);

            foreach (var group in groupedData)
            {
                double averageSpeed = group.Average(record => record.MOTORSPEED);
                // 여기에서 각 NUM 그룹의 최신 데이터를 사용하도록 수정할 수 있습니다.
                Data averagedRecord = new Data { NUM = group.Key, MOTORSPEED = averageSpeed };
                averagedData.Add(averagedRecord);
            }

            return averagedData;
        }




        public void UpdateMeltTempChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // NUM을 기준으로 OK와 NG 데이터 저장할 Dictionary
            Dictionary<int, List<double>> tempOKByNum = new Dictionary<int, List<double>>();
            Dictionary<int, List<double>> tempNGByNum = new Dictionary<int, List<double>>();

            // 데이터를 NUM 별로 구분하여 온도 데이터 추가
            foreach (var record in filteredRecords)
            {
                int num = record.NUM;

                if (record.TAG == "OK")
                {
                    if (!tempOKByNum.ContainsKey(num))
                    {
                        tempOKByNum[num] = new List<double>();
                    }
                    tempOKByNum[num].Add(record.MELT_TEMP);
                }
                else if (record.TAG == "NG")
                {
                    if (!tempNGByNum.ContainsKey(num))
                    {
                        tempNGByNum[num] = new List<double>();
                    }
                    tempNGByNum[num].Add(record.MELT_TEMP);
                }
            }

            // 차트 초기화
            chart_Temp.Series.Clear();
            chart_Temp.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Temp.ChartAreas.Add(chartArea);

            // 시리즈 생성 및 설정
            Series seriesOK = new Series("양품(OK) 온도 분포");
            Series seriesNG = new Series("불량(NG) 온도 분포");

            seriesOK.ChartType = SeriesChartType.FastPoint; // 양품은 산점도로 표시
            seriesNG.ChartType = SeriesChartType.FastPoint; // 불량은 산점도로 표시

            // 모든 NUM에 대해 데이터를 시리즈에 추가
            foreach (var num in tempOKByNum.Keys)
            {
                if (tempOKByNum.ContainsKey(num))
                {
                    foreach (var temp in tempOKByNum[num])
                    {
                        seriesOK.Points.AddXY(num, temp);
                    }
                }
            }

            foreach (var num in tempNGByNum.Keys)
            {
                if (tempNGByNum.ContainsKey(num))
                {
                    foreach (var temp in tempNGByNum[num])
                    {
                        seriesNG.Points.AddXY(num, temp);
                    }
                }
            }

            // 불량(NG) 시리즈의 마커 색상을 빨간색으로 설정
            seriesNG.MarkerColor = Color.Red;

            // 시리즈 추가
            chart_Temp.Series.Add(seriesOK);
            chart_Temp.Series.Add(seriesNG);

            // 축 설정
            chart_Temp.ChartAreas[0].AxisX.Interval = 1; // NUM이 정수형이므로 1 간격 설정
            chart_Temp.ChartAreas[0].AxisX.Title = "날짜순"; // X 축 제목 설정
            chart_Temp.ChartAreas[0].AxisY.Minimum = 0; // Y 축 최소값 설정
            chart_Temp.ChartAreas[0].AxisY.Maximum = 800; // Y 축 최대값 설정

            // 제목 설정
            chart_Temp.Titles.Clear();
            chart_Temp.Titles.Add("NUM 별 양품과 불량의 온도 산점도 비교");

            // 범례 설정
            chart_Temp.Legends.Clear();
            chart_Temp.Legends.Add(new Legend("Legend"));
            chart_Temp.Series["양품(OK) 온도 분포"].Legend = "Legend";
            chart_Temp.Series["불량(NG) 온도 분포"].Legend = "Legend";

            // 차트 보여주기
            chart_Temp.Visible = true;
        }







        //수분량출력
        public void UpdateMoistureContentChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // STD_DT 날짜 별 MOISTURE_CONTENT 통계를 저장할 Dictionary
            Dictionary<DateTime, MoistureContentStats> dateStats = new Dictionary<DateTime, MoistureContentStats>();

            // 데이터를 STD_DT 별로 그룹화하고 통계값 계산
            var groupedByDate = filteredRecords.GroupBy(record => record.STD_DT.Date);

            foreach (var group in groupedByDate)
            {
                DateTime date = group.Key;

                // 평균값 계산
                double avgMoisture = group.Average(record => record.INSP);

                // 중앙값 계산
                var sortedMoistures = group.OrderBy(record => record.INSP).Select(record => record.INSP).ToList();
                double medianMoisture = CalculateMedianInsp(sortedMoistures);

                // 최빈값 계산
                double modeMoisture = CalculateModeInsp(sortedMoistures);

                // STD_DT 별 통계 저장
                dateStats[date] = new MoistureContentStats
                {
                    AvgMoisture = avgMoisture,
                    MedianMoisture = medianMoisture,
                    ModeMoisture = modeMoisture
                };
            }

            // 차트 초기화
            chart_Insp.Series.Clear();
            chart_Insp.ChartAreas.Clear();
            chart_Insp.Titles.Clear();

            ChartArea chartArea = new ChartArea();
            chart_Insp.ChartAreas.Add(chartArea);

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
                MoistureContentStats stats = dateStat.Value;

                // 같은 날짜에 대해 서로 다른 시리즈에 값 추가
                seriesAvg.Points.AddXY(date.ToShortDateString(), stats.AvgMoisture);
                seriesMedian.Points.AddXY(date.ToShortDateString(), stats.MedianMoisture);
                seriesMode.Points.AddXY(date.ToShortDateString(), stats.ModeMoisture);
            }

            // 시리즈 추가
            chart_Insp.Series.Add(seriesAvg);
            chart_Insp.Series.Add(seriesMedian);
            chart_Insp.Series.Add(seriesMode);

            // 축 설정
            chart_Insp.ChartAreas[0].AxisX.Interval = 1;
            chart_Insp.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정

            // 제목 설정
            chart_Insp.Titles.Add("날짜 별 수분함유량 통계");

            // 차트 보여주기
            chart_Insp.Visible = true;
        }

        // 중앙값 계산 함수
        private double CalculateMedianInsp(List<float> sortedValues)
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
        private double CalculateModeInsp(List<float> values)
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

        //무게계산---------------
        public void UpdateMeltWeightChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // NUM을 기준으로 OK와 NG 데이터 저장할 Dictionary
            Dictionary<int, List<double>> weightOKByNum = new Dictionary<int, List<double>>();
            Dictionary<int, List<double>> weightNGByNum = new Dictionary<int, List<double>>();

            // 데이터를 NUM 별로 구분하여 중량 데이터 추가
            foreach (var record in filteredRecords)
            {
                int num = record.NUM;

                if (record.TAG == "OK")
                {
                    if (!weightOKByNum.ContainsKey(num))
                    {
                        weightOKByNum[num] = new List<double>();
                    }
                    weightOKByNum[num].Add(record.MELT_WEIGHT);
                }
                else if (record.TAG == "NG")
                {
                    if (!weightNGByNum.ContainsKey(num))
                    {
                        weightNGByNum[num] = new List<double>();
                    }
                    weightNGByNum[num].Add(record.MELT_WEIGHT);
                }
            }

            // 차트 초기화
            chart_Mweight.Series.Clear();
            chart_Mweight.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Mweight.ChartAreas.Add(chartArea);

            // 시리즈 생성 및 설정
            Series seriesOK = new Series("양품(OK) 중량 분포");
            Series seriesNG = new Series("불량(NG) 중량 분포");

            seriesOK.ChartType = SeriesChartType.FastPoint; // 양품은 산점도로 표시
            seriesNG.ChartType = SeriesChartType.FastPoint; // 불량은 산점도로 표시

            // 모든 NUM에 대해 데이터를 시리즈에 추가
            foreach (var num in weightOKByNum.Keys)
            {
                if (weightOKByNum.ContainsKey(num))
                {
                    foreach (var weight in weightOKByNum[num])
                    {
                        seriesOK.Points.AddXY(num, weight);
                    }
                }
            }

            foreach (var num in weightNGByNum.Keys)
            {
                if (weightNGByNum.ContainsKey(num))
                {
                    foreach (var weight in weightNGByNum[num])
                    {
                        seriesNG.Points.AddXY(num, weight);
                    }
                }
            }

            // 불량(NG) 시리즈의 마커 색상을 빨간색으로 설정
            seriesNG.MarkerColor = Color.Red;

            // 시리즈 추가
            chart_Mweight.Series.Add(seriesOK);
            chart_Mweight.Series.Add(seriesNG);

            // 축 설정
            chart_Mweight.ChartAreas[0].AxisX.Interval = 1; // NUM이 정수형이므로 1 간격 설정
            chart_Mweight.ChartAreas[0].AxisX.Title = "NUM"; // X 축 제목 설정
            chart_Mweight.ChartAreas[0].AxisY.Title = "내용 중량"; // Y 축 제목 설정

            // 제목 설정
            chart_Mweight.Titles.Clear();
            chart_Mweight.Titles.Add("NUM 별 양품과 불량의 중량 산점도 비교");

            // 범례 설정
            chart_Mweight.Legends.Clear();
            chart_Mweight.Legends.Add(new Legend("Legend"));
            chart_Mweight.Series["양품(OK) 중량 분포"].Legend = "Legend";
            chart_Mweight.Series["불량(NG) 중량 분포"].Legend = "Legend";

            // 차트 보여주기
            chart_Mweight.Visible = true;
        }

     
    }
}
