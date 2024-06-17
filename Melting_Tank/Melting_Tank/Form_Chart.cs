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
        public Form_Chart()
        {
            InitializeComponent();
            chart_no1.Location = new Point(12, 232);
            chart_no1.Size = new Size(760, 360);


            Random random = new Random();
            double[] lineData = new double[220];
            double[] barData = new double[45]; // 랜덤한 위치에서 막대그래프 데이터 생성
            for (int i = 0; i < lineData.Length; i++)
            {
                lineData[i] = random.NextDouble() * 100; // 0부터 100 사이의 랜덤 값 생성
            }
            for (int i = 0; i < barData.Length; i++)
            {
                barData[i] = random.NextDouble() * 100; // 0부터 100 사이의 랜덤 값 생성
            }

            // 기존 차트 컨트롤에 라인 그래프 추가
            Series lineSeries = new Series();
            lineSeries.ChartType = SeriesChartType.Line; // 라인 그래프로 설정
            lineSeries.Color = Color.Blue; // 라인 그래프 색상 설정
            lineSeries.BorderWidth = 2; // 라인 그래프 두께 설정
            chart_no1.Series.Add(lineSeries); // 기존 차트 컨트롤에 라인 시리즈 추가

            // 라인 그래프 데이터 포인트 추가
            for (int i = 0; i < lineData.Length; i++)
            {
                lineSeries.Points.AddXY(i, lineData[i]);
            }

            // 기존 차트 컨트롤에 막대 그래프 추가
            Series barSeries = new Series();
            barSeries.ChartType = SeriesChartType.Column; // 막대 그래프로 설정
            barSeries.Color = Color.Red; // 막대 그래프 색상 설정
            barSeries.BorderWidth = 2; // 막대 그래프 두께 설정
            chart_no1.Series.Add(barSeries); // 기존 차트 컨트롤에 막대 시리즈 추가

            // 막대 그래프 데이터 포인트 추가
            for (int i = 0; i < barData.Length; i++)
            {
                barSeries.Points.AddXY(random.Next(lineData.Length), barData[i]); // 랜덤 위치에 막대 그래프 추가
            }

            // 차트 영역 설정
            ChartArea chartArea = new ChartArea();
           
            chart_no1.ChartAreas.Add(chartArea);
            chart_no1.ChartAreas[0].AxisX.Minimum = 0;
            chart_no1.ChartAreas[0].AxisX.Maximum = lineData.Length - 1; // X 축 범위 설정
            chart_no1.ChartAreas[0].AxisY.Minimum = 0;
            chart_no1.ChartAreas[0].AxisY.Maximum = 100; // Y 축 범위 설정

           

            // 축 라벨 설정
            chart_no1.ChartAreas[0].AxisX.Title = "Index";
            chart_no1.ChartAreas[0].AxisY.Title = "Value";

            // 그래프 갱신
            chart_no1.Dock = DockStyle.Fill;
            chart_no1.DataBind();

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



        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Time.Text = DateTime.Now.ToString();
        }

        private void button_Temp_Click(object sender, EventArgs e)
        {

        }
    }
}
