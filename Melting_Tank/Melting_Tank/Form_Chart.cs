using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Melting_Tank
{
    public partial class Form_Chart : Form
    {
        private Random random = new Random();
        private double minTemperature = 30.0;
        private double maxTemperature = 38.0;
        public Form_Chart()
        {
            InitializeComponent();

           

            //원그래프생성
            int goodCount = 415;
            int failCount = 185;

            // 기존 차트 컨트롤에 원 그래프 추가
            Series pieSeries = new Series();
            pieSeries.ChartType = SeriesChartType.Pie; // 원 그래프로 설정
            pieSeries["PieLabelStyle"] = "Outside"; // 라벨을 그래프 바깥에 표시
            pieSeries["PieLineColor"] = "Black"; // 라벨 선 색상 설정

            // 원 그래프에 데이터 포인트 추가
            pieSeries.Points.Add(goodCount); // 파란색 "Good"
            pieSeries.Points[0].LegendText = "Good"; // 범례 텍스트 설정

            pieSeries.Points.Add(failCount); // 빨간색 "Fail"
            pieSeries.Points[1].LegendText = "Fail"; // 범례 텍스트 설정
            pieSeries.Points[1].Color = Color.Red; // 빨간색으로 설정


            chart_PassFail.Series.Clear();
            chart_PassFail.Series.Add(pieSeries);

            // 차트 영역 설정 (원 그래프가 기존 차트와 겹치지 않도록)
            ChartArea chartAreas = new ChartArea();
            chart_PassFail.ChartAreas.Clear();
            chart_PassFail.ChartAreas.Add(chartAreas);
            chartAreas.Position = new ElementPosition(0, 0, 30, 100); // 왼쪽 30% 차트 영역에 원 그래프 표시
            chartAreas.AxisX.Enabled = AxisEnabled.False; // X축 비활성화
            chartAreas.AxisY.Enabled = AxisEnabled.False; // Y축 비활성화

            // 그래프 갱신
            chart_PassFail.DataBind();


        }
        private void FormChart_Load(object sender, EventArgs e)
        {
            // 차트 초기화
            InitializeChart();
        }

        private void InitializeChart()
        {
            // 차트 설정
            chart_no1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chart_no1.ChartAreas.Add(chartArea);

            // 온도 라인 차트 설정
            Series temperatureSeries = new Series("Temperature");
            temperatureSeries.ChartType = SeriesChartType.Line;
            temperatureSeries.ChartArea = "MainArea";
            chart_no1.Series.Add(temperatureSeries);

            // 실패 여부 산점도 설정
            Series failureSeries = new Series("Failure");
            failureSeries.ChartType = SeriesChartType.Point;
            failureSeries.ChartArea = "MainArea";
            chart_no1.Series.Add(failureSeries);
            failureSeries.Color = Color.Red;


            // 데이터 생성 및 추가

            // 전체 데이터 포인트 수 설정 (예시에서는 총 1000개)
            int totalPoints = 15000;

            // 온도 범위 설정 (30도부터 39도까지)
            double temperatureStart = 300.0;
            double temperatureEnd = 800.0;

            for (double temperature = temperatureStart; temperature <= temperatureEnd; temperature++)
            {
                // 랜덤하게 표본 수 설정 (1에서 1500 사이)
                int sampleCount = random.Next(1, (totalPoints / 8) + 1);

                // 랜덤하게 실패 횟수 설정
                int failureCount = (int)(sampleCount * 0.2); // 실패 확률이 20%라고 가정

                // 온도 라인 차트에 데이터 추가
                temperatureSeries.Points.AddXY(temperature, sampleCount);

                // 실패일 경우 산점도에 데이터 추가
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(temperature, sampleCount); // X축: 온도, Y축: 표본 수
                dataPoint.MarkerSize = failureCount/20; // 버블 크기 설정
                failureSeries.Points.Add(dataPoint);
            }


            //failureSeries.MarkerSize = 10;
            failureSeries.MarkerStyle = MarkerStyle.Circle;
            // 차트 축 설정
            chartArea.AxisX.Title = "Temperature";
            chartArea.AxisY.Title = "Data Point";
            chartArea.AxisY.Minimum = 1; // Y 축 최소값 설정
            chartArea.AxisY.Maximum = 2500; // Y 축 최대값 설정




        }

    

    


    private void timer1_Tick(object sender, EventArgs e)
        {
            label_Time.Text = DateTime.Now.ToString();
        }

        private void button_Temp_Click(object sender, EventArgs e)
        {

        }

        private void button_Min_Click(object sender, EventArgs e)
        {
            chart_no1.Series.Clear();
            InitializeChart();
        }
    }
}
