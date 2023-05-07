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

namespace GraduationProject
{
    public partial class GraphForTotalGameForm : Form
    {
        //***** メンバーデータ
        private DateTime startDate;
        private DateTime endDate;

        //***** コンストラクタ（引数なし）
        public GraphForTotalGameForm()
        {
            InitializeComponent();
        }

        //***** コンストラクタ（引数あり）
        public GraphForTotalGameForm(
                   DateTime startDate,
                   DateTime endDate) : this()
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        //***** クローズボタンがクリックされた
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //***** 画面のロード
        private void GraphForTotalGameForm_Load(object sender, EventArgs e)
        {
            
            //ShowTotalGameChart();  // 全ゲーム対象・指定された内容

            // 各グラフの表示
            ShowPlayTimesChart();  // ゲーム別プレイ回数
            ShowTotalPlayTermChart();  // ゲーム別総プレイ時間
            ShowScoreChart();  // ゲーム別スコア（最高・平均）
            ShowPlayTermChart();  // ゲーム別プレイ時間（最長・平均）
        }

        //**** ゲーム別プレイ回数 -- 円グラフ
        private void ShowPlayTimesChart()
        {
            ShowPieChart(GraphData.Type.PlayTimes,
                this.playTimesChart);
        }

        //**** ゲーム別総プレイ時間 -- 円グラフ
        private void ShowTotalPlayTermChart()
        {
            ShowPieChart(GraphData.Type.TotalPlayTerm,
                this.totalPlayTermChart);
        }

        //** 指定された対象について円グラフを表示
        private void ShowPieChart(GraphData.Type gtype, Chart chart)
        {
            // DBから値を取得
            List<GraphData> data
                = Database.GetGraphData(gtype, startDate, endDate);

            // 合計値の算出
            double total = 0.0;
            foreach (GraphData d in data)
            {
                if (d.IsInteger)
                    total += (double)(d.IntValue);
                else
                    total += d.DoubleValue;
            }

            // チャートの準備
            chart.Series.Clear();  // 掃除
            string legend = GraphData.GetTypeString(gtype);
            chart.Series.Add(legend);
            chart.Titles.Add(legend);
            chart.Series[legend].ChartType 
                = SeriesChartType.Pie; // 円グラフ
            chart.Series[legend].IsVisibleInLegend = true; // 凡例表示
            //chart.Series[legend].LegendText = legend;

            // チャートにデータをプロット
            for (int n = 0; n < data.Count; n++)
            {
                GraphData gdata = data[n];
                double rate;
                if (gdata.IsInteger)
                    rate = (gdata.IntValue / total) * 100.0;
                else
                {
                    rate = (gdata.DoubleValue / total) * 100.0;
                }
                // 小数点以下２桁まで表示
                if (rate < 0.01d)
                {
                    rate = 0.01d;  // 切り捨てられるのも忍びないので最小値に
                }
                string tmp = rate.ToString("#.##");
                double tmpd = double.Parse(tmp);
                DataPoint dp = new DataPoint(tmpd, tmpd);

                dp.IsValueShownAsLabel = true;  // 値を表示
                dp.LegendText = gdata.Label;
                chart.Series[legend].Points.Add(dp);
            }
        }

        //**** ゲーム別スコア（最高・平均） -- 複合グラフ
        private void ShowScoreChart()
        {
            ShowDuplexChart("スコア（最高・平均）",
                GraphData.Type.AvgScore,
                GraphData.Type.HighScore,
                this.scoreChart);
        }

        //**** ゲーム別プレイ時間（最長・平均） -- 複合グラフ
        private void ShowPlayTermChart()
        {
            ShowDuplexChart("プレイ時間（最長・平均）",
                GraphData.Type.AvgPlayTerm,
                GraphData.Type.LongestPlayTerm,
                this.playTermChart);
        }

        //** 2つのシリーズを表示する
        //   1つめを棒グラフ、2つ目を折れ線グラフで表示する
        private void ShowDuplexChart(string chartTitle,
                         GraphData.Type gtype1,
                         GraphData.Type gtype2, Chart chart)
        {

            // DBから値を取得
            List<GraphData> data1
                = Database.GetGraphData(gtype1, startDate, endDate);
            List<GraphData> data2
                = Database.GetGraphData(gtype2, startDate, endDate);
            string legend1 = GraphData.GetTypeString(gtype1);
            string legend2 = GraphData.GetTypeString(gtype2);


            // チャートの準備
            chart.Series.Clear();  // 掃除
            chart.Titles.Add(chartTitle);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;  // 目盛り非表示
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;  // 目盛り非表示

            chart.Series.Add(legend1);
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].IsVisibleInLegend = false; // 凡例非表示
            chart.Series[0].LegendText = legend1;

            chart.Series.Add(legend2);
            chart.Series[1].ChartType = SeriesChartType.Line; // 折れ線グラフ
            chart.Series[1].IsVisibleInLegend = false; // 凡例非表示
            chart.Series[1].LegendText = legend2;
            chart.Series[1].BorderWidth = 3;  // ちょっと線太め

            // チャートにデータ1をプロット
            for (int n = 0; n < data1.Count; n++)
            {
                GraphData gdata1 = data1[n];
                DataPoint dp1 = new DataPoint();
                if (gdata1.IsInteger)
                    dp1.SetValueXY(n, gdata1.IntValue);
                else
                {
                    // 小数点以下２桁まで表示
                    if (gdata1.DoubleValue < 0.01d)
                        dp1.SetValueXY(n, 0.01d);
                    else
                    {
                        string tmp = gdata1.DoubleValue.ToString("#.##");
                        dp1.SetValueXY(n, double.Parse(tmp));
                    }
                }
                dp1.IsValueShownAsLabel = true;  // 値を表示
                dp1.AxisLabel = gdata1.Label;
                chart.Series[0].Points.Add(dp1);
            }

            // チャートにデータ2をプロット
            for (int n = 0; n < data2.Count; n++)
            {
                GraphData gdata2 = data2.Find(d => d.Label == data1[n].Label);
                DataPoint dp2 = new DataPoint();
                if (gdata2.IsInteger)
                    dp2.SetValueXY(n, gdata2.IntValue);
                else
                {
                    // 小数点以下２桁まで表示
                    if (gdata2.DoubleValue < 0.01d)
                        dp2.SetValueXY(n, 0.01d);
                    else
                    {
                        string tmp = gdata2.DoubleValue.ToString("#.##");
                        dp2.SetValueXY(n, double.Parse(tmp));
                    }
                }
                dp2.IsValueShownAsLabel = true;  // 値を表示
                dp2.AxisLabel = gdata2.Label;
                chart.Series[1].Points.Add(dp2);
            }
        }
    }
}
