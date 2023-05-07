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
    public partial class GraphForPartialGameForm : Form
    {
        //***** メンバーデータ
        private GraphData.Type gtype;
        private DateTime startDate;
        private DateTime endDate;
        private double minCond;
        private bool includeMin;
        private double maxCond;
        private bool includeMax;
        
        //***** コンストラクタ（引数なし）
        public GraphForPartialGameForm()
        {
            InitializeComponent();
        }

        //***** コンストラクタ（引数あり）
        public GraphForPartialGameForm(
                   GraphData.Type gtype, 
                   DateTime startDate, 
                   DateTime endDate,
                   double minCond, bool includeMin,
                   double maxCond, bool includeMax) : this()
        {
            this.gtype = gtype;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minCond = minCond;
            this.includeMin = includeMin;
            this.maxCond = maxCond;
            this.includeMax = includeMax;
        }

        //***** クローズボタンがクリックされた
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //***** 画面のロード
        private void GraphForPartialGameForm_Load(object sender, EventArgs e)
        {
            // ゲームリストの取得
            //    ここにくるまでに未登録はエラー
            //    1個以上のゲームが登録されているものとして処理可
            List<MiniGame> games = Database.GetMiniGames();

            // 全ミニゲームについてグラフ表示（No.1～6）
            for (int i = 0; 
                 i < MiniGame.NUM_OF_MINI_GAMES_IN_LAUNCHER; 
                 i++)
            {
                Chart gameChart = null;
                switch (i)
                {
                    case 0:
                        gameChart = gameChart1;
                        break;
                    case 1:
                        gameChart = gameChart2;
                        break;
                    case 2:
                        gameChart = gameChart3;
                        break;
                    case 3:
                        gameChart = gameChart4;
                        break;
                    case 4:
                        gameChart = gameChart5;
                        break;
                    case 5:
                        gameChart = gameChart6;
                        break;
                }

                MiniGame game = games.Find(g => g.Position == i);
                if (game != null)  // ゲームが登録されている
                {  
                    // DBから値を取得
                    int maxUserNum = 5;  // トップ何人までか
                    string gameName = game.GameName;
                    List<GraphData> data
                        = Database.GetGraphData(
                            gtype, startDate, endDate,
                            gameName, maxUserNum,
                            minCond, includeMin,
                            maxCond, includeMax);

                    // チャートの準備
                    gameChart.Series.Clear();  // 掃除
                    string legend = GraphData.GetTypeString(gtype);
                    gameChart.Series.Add(legend);
                    gameChart.Titles.Add(gameName + "の" + legend);
                    //gameChart.Series[legend].ChartType = SeriesChartType.Column;
                    gameChart.Series[legend].ChartType = SeriesChartType.Bar; // 棒グラフ（横）
                    gameChart.Series[legend].IsVisibleInLegend = false; // 凡例非表示
                    gameChart.Series[legend].LegendText = legend;
                    gameChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;  // 目盛り非表示
                    gameChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;  // 目盛り非表示
                    
                    // チャートにデータをプロット
                    for (int n = 0; n < data.Count; n++)
                    {
                        GraphData gdata = data[data.Count-n-1];  // 横棒グラフは逆順に表示されてしまう
                        //GraphData gdata = data[n]; -- 縦棒グラフ
                        DataPoint dp = new DataPoint();
                        if (gdata.IsInteger)
                            dp.SetValueXY(n, gdata.IntValue);
                        else
                        {
                            // 小数点以下２桁まで表示
                            if (gdata.DoubleValue < 0.01d)
                                dp.SetValueXY(n, 0.01d);
                            else
                            {
                                string tmp = gdata.DoubleValue.ToString("#.##");
                                dp.SetValueXY(n, double.Parse(tmp));
                            }
                        }
                        dp.IsValueShownAsLabel = true;  // 値を表示
                        dp.AxisLabel = gdata.Label;
                        gameChart.Series[legend].Points.Add(dp);
                    }
                }
                else // ゲームは未登録
                {
                    gameChart.Series.Clear();  // 掃除
                    string legend = GraphData.GetTypeString(gtype);
                    //gameChart.Series.Add(legend);
                    gameChart.Titles.Add("未登録");
                    gameChart.Enabled = false;
                }
            }

            // 全ゲーム対象にデータ表示
            ShowTotalGameChart();
        }


        //**** 全ゲーム対象に指定されたタイプのデータを表示
        private void ShowTotalGameChart()
        {
            // DBから値を取得
            int maxUserNum = 5;  // トップ何人までか
            List<GraphData> data
                = Database.GetGraphData(gtype, startDate,
                      endDate, "", maxUserNum,
                      minCond, includeMin, maxCond, includeMax);

            // チャートの準備
            totalGameChart.Series.Clear();  // 掃除
            string legend = GraphData.GetTypeString(gtype);
            totalGameChart.Series.Add(legend);
            totalGameChart.Titles.Add("全ゲーム対象・" + legend);
            //totalGameChart.Series[legend].ChartType = SeriesChartType.Column; // 棒グラフ（縦）
            totalGameChart.Series[legend].ChartType = SeriesChartType.Bar; // 棒グラフ（横）
            totalGameChart.Series[legend].IsVisibleInLegend = false; // 凡例非表示
            totalGameChart.Series[legend].LegendText = legend;
            totalGameChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;  // 目盛り非表示
            totalGameChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;  // 目盛り非表示

            // チャートにデータをプロット
            for (int n = 0; n < data.Count; n++)
            {
                GraphData gdata = data[data.Count - n - 1];  // 横棒グラフは逆順に表示されてしまう
                //GraphData gdata = data[n]; // 縦棒グラフ
                DataPoint dp = new DataPoint();
                if (gdata.IsInteger)
                    dp.SetValueXY(n, gdata.IntValue);
                else
                {
                    // 小数点以下２桁まで表示
                    if (gdata.DoubleValue < 0.01d)
                        dp.SetValueXY(n, 0.01d);
                    else
                    {
                        string tmp = gdata.DoubleValue.ToString("#.##");
                        dp.SetValueXY(n, double.Parse(tmp));
                    }
                }
                dp.IsValueShownAsLabel = true;  // 値を表示
                dp.AxisLabel = gdata.Label;
                totalGameChart.Series[legend].Points.Add(dp);
            }
        }
    }
}
