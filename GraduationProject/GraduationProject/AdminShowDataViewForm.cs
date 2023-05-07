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
    public partial class AdminShowDataViewForm : Form
    {
        //***** メンバーデータ
        List<MiniGame> games;

        //***** コンストラクタ
        public AdminShowDataViewForm()
        {
            InitializeComponent();

            // 入力コントロールの初期化
            // 期間
            DateTime endDt = DateTime.Now;
            this.endDatePicker.Value = endDt;  // 今日
            DateTime startDt = new DateTime(endDt.Year, endDt.Month, endDt.Day);
            startDt = startDt.AddMonths(-1);
            this.startDatePicker.Value = startDt;  // 一か月前

            // ミニゲームの選択
            games = Database.GetMiniGames();
            if (games == null || games.Count == 0)
            {
                throw new ApplicationException("ミニゲームが登録されていません.");
            }
            for (int i = 0; i < games.Count; i++)
            {
                this.gamesCheckdLb.Items.Add(games[i].GameName);
                this.gamesCheckdLb.SetItemChecked(i, true);
            }

            // ユーザー名
            this.userNameTb.Text = "";

            // スコアとプレイ時間
            this.minPtCondTb.Text = "";
            this.maxPtCondTb.Text = "";
            this.minScCondTb.Text = "";
            this.maxScCondTb.Text = "";
        }


        //***** 表示ボタンのクリック
        private void displayButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<MiniGame> targetGames = new List<MiniGame>();
                for (int i = 0; i < this.gamesCheckdLb.Items.Count; i++)
                {
                    if (this.gamesCheckdLb.GetItemChecked(i))
                    {
                        targetGames.Add(new MiniGame(games[i]));
                    }
                }
                if (targetGames.Count == 0) throw new ApplicationException("対象ゲームが選択されていません");

                DateTime ed = this.endDatePicker.Value;
                DateTime edModified = new DateTime(ed.Year,ed.Month,ed.Day);
                edModified = edModified.AddDays(1);
                    // DatePicker の返す値は0時0分なので、
                    // 翌日の0時を期間の終わりとしないと、
                    // 検索もれが出てしまうので、調整している

                double minPtCond = AdminShowDataForm.ParseDoubleFromValue(minPtCondTb.Text);
                double maxPtCond = AdminShowDataForm.ParseDoubleFromValue(maxPtCondTb.Text);
                double minScCond = AdminShowDataForm.ParseDoubleFromValue(minScCondTb.Text);
                double maxScCond = AdminShowDataForm.ParseDoubleFromValue(maxScCondTb.Text);

                DataTable dt = Database.GetDataTable(
                                   playDataGridView,
                                   startDatePicker.Value,
                                   edModified, 
                                   targetGames, 
                                   userNameTb.Text,
                                   minPtCond,
                                   maxPtCond,
                                   minScCond,
                                   maxScCond);

                playDataGridView.DataSource = dt;
                playDataGridView.ReadOnly = true;  // データビュー編集:不可
                playDataGridView.AllowUserToAddRows = false;  // データビュー追加:不可
                playDataGridView.AllowUserToDeleteRows = false;  // データビュー削除:不可

                // 表示幅や表示位置の調整
                //playDataGridView.AutoResizeColumns(
                //    DataGridViewAutoSizeColumnsMode.AllCells); 
                playDataGridView.Columns["ゲーム名"].Width = 200;
                playDataGridView.Columns["ユーザー名"].Width = 160;
                playDataGridView.Columns["プレイ日時"].Width = 140;
                playDataGridView.Columns["時間（秒）"].Width = 100;
                playDataGridView.Columns["時間（秒）"]
                    .DefaultCellStyle.Alignment
                      = DataGridViewContentAlignment.MiddleRight;  // 右詰め
                playDataGridView.Columns["スコア"].Width = 80;
                playDataGridView.Columns["スコア"]
                    .DefaultCellStyle.Alignment
                      = DataGridViewContentAlignment.MiddleRight;  // 右詰め
                playDataGridView.RowHeadersVisible = false;  // 行頭のヘッダー非表示
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
                messageBox.Show();
            }
        }


        //***** 閉じるボタンクリック
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //***** ユーザー一覧ボタンクリック
        private void userListButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new UserListForm();
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
                messageBox.Show();
            }
        }
    }
}
