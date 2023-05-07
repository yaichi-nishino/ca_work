using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameParkLib;

namespace GraduationProject
{
    public partial class AdminShowDataGraphForm : Form
    {
        //***** メンバーデータ
        List<MiniGame> games;

        //***** コンストラクタ
        public AdminShowDataGraphForm()
        {
            InitializeComponent();

            // ミニゲームの確認
            games = Database.GetMiniGames();
            if (games == null || games.Count == 0)
                throw new ApplicationException("ミニゲームが登録されていません.");

            // 入力コントロールの初期化
            // 期間（デートピッカー）
            DateTime endDt = DateTime.Now;
            this.endDatePicker.Value = endDt;  // 今日
            DateTime startDt = new DateTime(endDt.Year, endDt.Month, endDt.Day);
            startDt = startDt.AddMonths(-1);
            this.startDatePicker.Value = startDt;  // 一か月前

            // ゲームの表示（ラジオボタン×２）
            this.totalButton.Text = "概要";
            this.totalButton.Checked = true;  // デフォルト
            this.partialButton.Text = "詳細";
            ChangeTargetCondControl(false);  // 概要選択時は対象入力不可

            // 表示する対象（コンボボックス）
            this.targetItemCb.Items.Add(GraphData.PLAY_TIMES_LABEL);
            this.targetItemCb.Items.Add(GraphData.HIGH_SCORE_LABEL);
            this.targetItemCb.Items.Add(GraphData.AVG_SCORE_LABEL);
            this.targetItemCb.Items.Add(GraphData.LONGEST_PLAY_TERM_LABEL);
            this.targetItemCb.Items.Add(GraphData.AVG_PLAY_TERM_LABEL);
            this.targetItemCb.Items.Add(GraphData.TOTAL_PLAY_TERM_LABEL);
            this.targetItemCb.SelectedIndex = 0;  // デフォルト

            this.minLessOrThanCb.Items.Add("以上");
            this.minLessOrThanCb.Items.Add("より大きい");
            this.minLessOrThanCb.SelectedIndex = 0;
            this.maxMoreOrThanCb.Items.Add("以下");
            this.maxMoreOrThanCb.Items.Add("より小さい");
            this.maxMoreOrThanCb.SelectedIndex = 0;
        }

        //** 対象の条件入力欄の有効・無効化
        private void ChangeTargetCondControl(bool enable)
        {
            if (enable)
            {
                this.targetItemCb.Enabled = true;
                this.minCondTb.Enabled = true;
                this.minLessOrThanCb.Enabled = true;
                this.maxCondTb.Enabled = true;
                this.maxMoreOrThanCb.Enabled = true;
            }
            else
            {
                this.targetItemCb.Enabled = false;
                this.minCondTb.Enabled = false;
                this.minLessOrThanCb.Enabled = false;
                this.maxCondTb.Enabled = false;
                this.maxMoreOrThanCb.Enabled = false;
            }
        }


        //***** 表示ボタンがクリックされた
        private void displayButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ed = this.endDatePicker.Value;
                DateTime edModified = new DateTime(ed.Year, ed.Month, ed.Day);
                edModified = edModified.AddDays(1);
                // DatePicker の返す値は0時0分なので、
                // 翌日の0時を期間の終わりとしないと、
                // 検索もれが出てしまうので、調整している。

                string st = targetItemCb.Text;
                GraphData.Type gtype = GraphData.GetType(st);
                Form f;
                if (this.totalButton.Checked)  // 概要 -- 項目固定
                {
                    f = new GraphForTotalGameForm(
                                this.startDatePicker.Value,
                                edModified);  
                }
                else // 詳細 -- 対象指定可能
                {
                    double minCond = AdminShowDataForm.ParseDoubleFromValue(minCondTb.Text);
                    double maxCond = AdminShowDataForm.ParseDoubleFromValue(maxCondTb.Text);
                    bool includeMin = (minLessOrThanCb.SelectedIndex == 0) ? true : false;
                    bool includeMax = (maxMoreOrThanCb.SelectedIndex == 0) ? true : false;
                    f = new GraphForPartialGameForm(
                                gtype,
                                this.startDatePicker.Value,
                                edModified,
                                minCond, includeMin,
                                maxCond, includeMax);
                }
                f.ShowDialog();
                f.Close();
            }
            catch (ApplicationException exception)
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              exception.Message,
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
                messageBox.Close();
            }
        }


        //***** 閉じるボタンがクリックされた
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //***** 詳細ボタンのチェックが変化 -- 対象の条件を有効・無効化
        private void partialButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.partialButton.Checked)
            {
                ChangeTargetCondControl(true);
            }
            else
            {
                ChangeTargetCondControl(false);
            }
        }

        //***** 対象の選択が変化 -- 単位のラベル表示も変化
        private void targetItemCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st = targetItemCb.Text;
            GraphData.Type gtype = GraphData.GetType(st);
            switch (gtype)
            {
                case GraphData.Type.AvgScore:
                case GraphData.Type.HighScore:
                    minUnitLabel.Text = "点";
                    maxUnitLabel.Text = "点";
                    break;
                case GraphData.Type.PlayTimes:
                    minUnitLabel.Text = "回";
                    maxUnitLabel.Text = "回";
                    break;
                case GraphData.Type.AvgPlayTerm:
                case GraphData.Type.LongestPlayTerm:
                case GraphData.Type.TotalPlayTerm:
                    minUnitLabel.Text = "秒";
                    maxUnitLabel.Text = "秒";
                    break;
            }
        }
    }
}
