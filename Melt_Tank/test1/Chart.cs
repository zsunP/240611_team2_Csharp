using System;
using System.Collections.Generic;
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
            chart_OKNG.Series.Clear();
            Series series = chart_OKNG.Series.Add("MELT_TEMP");
            series.ChartType = SeriesChartType.Pie;
            series.Points.AddXY($"OK{okPercent}%", okPercent);
            series.Points.AddXY($"NG{ngPercent}%", ngPercent);

            // 차트 타이틀 설정
            chart_OKNG.Titles.Clear();
            chart_OKNG.Titles.Add($"기간에 따른 양품과 불량품 비율");
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
                double modeSpeed = CalculateModeMspeed(sortedSpeeds);

                // STD_DT 별 통계 저장
                dateStats[date] = new MotorSpeedStats
                {
                    AvgSpeed = avgSpeed,
                    MedianSpeed = medianSpeed,
                    ModeSpeed = modeSpeed
                };
            }

            // 막대 그래프 데이터 설정
            chart_Mspeed.Series.Clear();
            chart_Mspeed.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Mspeed.ChartAreas.Add(chartArea);

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
            chart_Mspeed.Series.Add(seriesAvg);
            chart_Mspeed.Series.Add(seriesMedian);
            chart_Mspeed.Series.Add(seriesMode);

            // 축 설정
            chart_Mspeed.ChartAreas[0].AxisX.Interval = 1;
            chart_Mspeed.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정

            // 제목 설정
            chart_Mspeed.Titles.Clear();
            chart_Mspeed.Titles.Add("날짜 별 모터스피드 통계");

            // 차트 보여주기
            chart_Mspeed.Visible = true;
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
        private double CalculateModeMspeed(List<double> values)
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
        //온도 출력
        public void UpdateMeltTempChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // MELT_TEMP 온도 별 통계를 저장할 Dictionary
            Dictionary<DateTime, MeltTempStats> dateStats = new Dictionary<DateTime, MeltTempStats>();

            // 데이터를 날짜 별로 그룹화하고 통계값 계산
            var groupedByDate = filteredRecords.GroupBy(record => record.STD_DT.Date);

            foreach (var group in groupedByDate)
            {
                DateTime date = group.Key;

                // 최대값 계산
                double maxTemp = group.Max(record => record.MELT_TEMP);

                // 최소값 계산
                double minTemp = group.Min(record => record.MELT_TEMP);

                // 최빈값 계산
                double modeTemp = CalculateModeTemp(group.Select(record => record.MELT_TEMP).ToList());

                // 날짜 별 통계 저장
                dateStats[date] = new MeltTempStats
                {
                    MaxTemp = maxTemp,
                    MinTemp = minTemp,
                    ModeTemp = modeTemp
                };
            }

            // 차트 초기화
            chart_Temp.Series.Clear();
            chart_Temp.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Temp.ChartAreas.Add(chartArea);

            // 시리즈 생성 및 설정
            Series seriesMax = new Series("최대값");
            Series seriesMin = new Series("최소값");
            Series seriesMode = new Series("최빈값");

            seriesMax.ChartType = SeriesChartType.Column;
            seriesMin.ChartType = SeriesChartType.Column;
            seriesMode.ChartType = SeriesChartType.Column;

            // 각 시리즈에 데이터 추가
            foreach (var dateStat in dateStats)
            {
                DateTime date = dateStat.Key;
                MeltTempStats stats = dateStat.Value;

                // 같은 날짜에 대해 서로 다른 시리즈에 값 추가
                seriesMax.Points.AddXY(date.ToShortDateString(), stats.MaxTemp);
                seriesMin.Points.AddXY(date.ToShortDateString(), stats.MinTemp);
                seriesMode.Points.AddXY(date.ToShortDateString(), stats.ModeTemp);
            }

            // 시리즈 추가
            chart_Temp.Series.Add(seriesMax);
            chart_Temp.Series.Add(seriesMin);
            chart_Temp.Series.Add(seriesMode);

            // 축 설정
            chart_Temp.ChartAreas[0].AxisX.Interval = 1;
            chart_Temp.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정

            // 제목 설정
            chart_Temp.Titles.Clear();
            chart_Temp.Titles.Add("날짜 별 용융 온도 통계");

            // 차트 보여주기
            chart_Temp.Visible = true;
        }

        // 최빈값 계산 함수
        private double CalculateModeTemp(List<int> values)
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
        public void UpdateMeltWeightChart(List<Data> filteredRecords)
        {
            if (filteredRecords == null || filteredRecords.Count == 0)
            {
                MessageBox.Show("필터링된 데이터가 없습니다.");
                return;
            }

            // STD_DT 날짜 별 MELT_WEIGHT 통계를 저장할 Dictionary
            Dictionary<DateTime, MeltWeightStats> dateStats = new Dictionary<DateTime, MeltWeightStats>();

            // 데이터를 STD_DT 별로 그룹화하고 통계값 계산
            var groupedByDate = filteredRecords.GroupBy(record => record.STD_DT.Date);

            foreach (var group in groupedByDate)
            {
                DateTime date = group.Key;

                // 평균값 계산
                double avgWeight = group.Average(record => record.MELT_WEIGHT);

                // 중앙값 계산
                var sortedWeights = group.OrderBy(record => record.MELT_WEIGHT).Select(record => record.MELT_WEIGHT).ToList();
                double medianWeight = CalculateMedianWeight(sortedWeights);

                // 최빈값 계산
                double modeWeight = CalculateModeWeight(sortedWeights);

                // STD_DT 별 통계 저장
                dateStats[date] = new MeltWeightStats
                {
                    AvgWeight = avgWeight,
                    MedianWeight = medianWeight,
                    ModeWeight = modeWeight
                };
            }

            // 막대 그래프 데이터 설정
            chart_Mweight.Series.Clear();
            chart_Mweight.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chart_Mweight.ChartAreas.Add(chartArea);

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
                MeltWeightStats stats = dateStat.Value;

                // 같은 날짜에 대해 서로 다른 시리즈에 값 추가
                seriesAvg.Points.AddXY(date.ToShortDateString(), stats.AvgWeight);
                seriesMedian.Points.AddXY(date.ToShortDateString(), stats.MedianWeight);
                seriesMode.Points.AddXY(date.ToShortDateString(), stats.ModeWeight);
            }

            // 시리즈 추가
            chart_Mweight.Series.Add(seriesAvg);
            chart_Mweight.Series.Add(seriesMedian);
            chart_Mweight.Series.Add(seriesMode);

            // 축 설정
            chart_Mweight.ChartAreas[0].AxisX.Interval = 1;
            chart_Mweight.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X축 라벨 각도 설정

            // 제목 설정
            chart_Mweight.Titles.Clear();
            chart_Mweight.Titles.Add("날짜 별 내용중량 통계");

            // 차트 보여주기
            chart_Mweight.Visible = true;
        }

        // 중앙값 계산 함수
        private double CalculateMedianWeight(List<int> sortedValues)
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
        private double CalculateModeWeight(List<int> values)
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
