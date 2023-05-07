using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MiniGameParkLib;

namespace GraduationProject
{
    public partial class AdminUpdateDataForm : Form
    {
        //***** 定数
        static readonly string STATUS_NOT_YET = "未反映";
        static readonly string STATUS_NO_NEED = "反映不要";
        static readonly string STATUS_UPDATING = "更新中";
        static readonly string STATUS_DONE = "反映完了";

        //***** メンバーデータ
        List<MiniGame> games;
        bool[] existGames;  // ゲームに未反映のデータがあるか
        
        //***** コンストラクタ
        public AdminUpdateDataForm()
        {
            InitializeComponent();
            games = Database.GetMiniGames();
            if (games != null && games.Count > 0)
            {
                existGames = new bool[MiniGame.NUM_OF_MINI_GAMES_IN_LAUNCHER];
                for (int i = 0; i < MiniGame.NUM_OF_MINI_GAMES_IN_LAUNCHER; i++)
                {
                    existGames[i] = false;  // 初期化
                }

                foreach (MiniGame g in games)
                {
                    switch(g.Position)
                    {
                        case 0:
                            SetMiniGameInfo(gameTb1, g.GameName, 
                                ref existGames[0], gameStat1);
                            break;
                        case 1:
                            SetMiniGameInfo(gameTb2, g.GameName, 
                                ref existGames[1], gameStat2);
                            break;
                        case 2:
                            SetMiniGameInfo(gameTb3, g.GameName, 
                                ref existGames[2], gameStat3);
                            break;
                        case 3:
                            SetMiniGameInfo(gameTb4, g.GameName, 
                                ref existGames[3], gameStat4);
                            break;
                        case 4:
                            SetMiniGameInfo(gameTb5, g.GameName, 
                                ref existGames[4], gameStat5);
                            break;
                        case 5:
                            SetMiniGameInfo(gameTb6, g.GameName, 
                                ref existGames[5], gameStat6);
                            break;
                        default:
                            throw new ApplicationException(
                                "無効な位置情報が指定されました（内部エラー）");
                    }
                }
            }
            else
            {
                throw new ApplicationException("ミニゲームは登録されていません");
            }
        }

        //** 各ミニゲームの状態を表示するための共通メソッド
        private void SetMiniGameInfo(TextBox tb, 
                         string name, ref bool b, Label stat)
        {
            tb.Text = name;  // ゲーム名
            if (HasUpdateData(name))
            {
                b = true;
                stat.Text = STATUS_NOT_YET;
            }
            else
            {
                b = false;
                stat.Text = STATUS_NO_NEED;
            }
        }

        ////** 一つのミニゲームに対する反映処理
        //private void ReadCsvAndUpdateDB(string name)
        //{
        //    int gameId = games.Find(g => g.GameName == name).Id;
        //    int cntBefore = Database.CountPlayData(gameId);

        //    string fp = GetCsvFilePathName(name);
        //    int cnt = 0;
        //    using (StreamReader f = new StreamReader(fp))
        //    {
        //        while (!f.EndOfStream)
        //        {
        //            string line = f.ReadLine();
        //            string[] data = line.Split(',');
        //            if (data == null || data.Length < 4) continue;
        //            if (data[0] != name) continue;  // テスト用ファイル対策
        //            string gameName = data[0];      // ゲーム名
        //            string userName = data[1];      // ユーザー名
        //            string startTime = data[2];     // プレイ開始時間
        //            string endTime = data[3];       // プレイ終了時間
        //            int score = int.Parse(data[4]); //スコア
        //            PlayData oneData
        //                = new PlayData(gameName, userName,
        //                          DateTime.Parse(startTime),
        //                          DateTime.Parse(endTime),
        //                          score);
        //            Database.AddPlayData(oneData);  // 遅そう
        //            cnt++;
        //        }
        //    }
        //    // 正常に登録できたらファイルを削除する
        //    // データの個数の変化で、登録されたことを確認している
        //    int cntAfter = Database.CountPlayData(gameId);
        //    if (cntAfter - cntBefore != cnt) 
        //    {
        //        throw new ApplicationException(
        //            "登録されたデータの数が異なってます（内部エラー）");
        //        // エラーになった時、再開時の処理について、
        //        // 重複をチェックしていないため、どんどん同じデータが、
        //        // 溜まってしまう問題が生じる　--　積み残し課題
        //    }
        //    else
        //    {
        //        System.IO.File.Delete(fp);  // 登録されたデータは削除
        //    }
        //}

        //** 一つのミニゲームに対する反映処理 -- トランザクション版
        private void ReadCsvAndUpdateDB(string name)
        {
            int gameId = games.Find(g => g.GameName == name).Id;
            List<User> users = Database.GetUsers();
            int cntBefore = Database.CountPlayData(gameId);

            string fp = GetCsvFilePathName(name);
            int cnt = 0;
            using (StreamReader f = new StreamReader(fp))
            {
                List<PlayData> pd100 = null;
                while (!f.EndOfStream)
                {
                    if (cnt % 100 == 0)  // 100件ごとに登録する
                    {
                        pd100 = new List<PlayData>();
                    }
                    string line = f.ReadLine();
                    string[] data = line.Split(',');
                    if (data == null || data.Length < 4) continue;
                    if (data[0] != name) continue;  // テスト用ファイル対策
                    string gameName = data[0];      // ゲーム名
                    string userName = data[1];      // ユーザー名
                    string startTime = data[2];     // プレイ開始時間
                    string endTime = data[3];       // プレイ終了時間
                    int score = int.Parse(data[4]); //スコア
                    PlayData oneData
                        = new PlayData(gameName, userName,
                                  DateTime.Parse(startTime),
                                  DateTime.Parse(endTime),
                                  score);
                    pd100.Add(oneData);
                    if (cnt % 100 == 99) 
                        // 100おきにリストを作り直すので、その直前
                    {
                        Database.AddPlayDataMulti(pd100, games, users);
                        pd100 = null;
                    }
                    cnt++;
                }
                if (pd100 != null) // 端数の登録（cntはインクリメント済）
                {
                    Database.AddPlayDataMulti(pd100, games, users);
                    pd100 = null;
                }
            }
            // 正常に登録できたらファイルを削除する
            // データの個数の変化で、登録されたことを確認している
            int cntAfter = Database.CountPlayData(gameId);
            if (cntAfter - cntBefore != cnt)
            {
                throw new ApplicationException(
                    "登録されたデータの数が異なってます（内部エラー）");
                // エラーになった時、再開時の処理について、
                // 重複をチェックしていないため、どんどん同じデータが、
                // 溜まってしまう問題が生じる　--　積み残し課題
            }
            else
            {
                System.IO.File.Delete(fp);  // 登録されたデータは削除
            }
        }


        //** ゲーム名からCSVファイル名を求めるメソッド
        private string GetCsvFilePathName(string name)
        {
            string fp = System.Environment.CurrentDirectory;
            fp += "\\";
            fp += name;
            fp += "\\";
            fp += PlayData.CSV_FILE_NAME;
            return fp;
        }

        //** CSVファイルの有無チェック
        private bool HasUpdateData(string name)
        {
            string fp = GetCsvFilePathName(name);
            if (File.Exists(fp)) return true;
            else return false;
        }

        //***** 更新ボタンがクリックされた
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (existGames.All(b => b == false))
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "反映の必要なデータがありません",
                              "警告",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                messageBox.ShowDialog();
                updateButton.Enabled = false;
                return;
            }
            else
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "反映するデータが多いと、この処理には時間がかかります.\r\n" +
                              "よろしいですか？", "確認",
                              MessageBoxButtons.OKCancel,
                              MessageBoxIcon.Question);
                DialogResult dr = messageBox.ShowDialog();
                if (dr != DialogResult.OK) return;
            }

            try
            {
                closeButton.Enabled = false;  // 閉じるボタン無効化
                updateButton.Text = "更新処理中";  // ボタンの表示変更
                updateButton.Enabled = false;  // 更新ボタン無効化
                this.Invalidate();
                for (int i = 0; i < MiniGame.NUM_OF_MINI_GAMES_IN_LAUNCHER; i++)
                {
                    if (!existGames[i])
                    {
                        continue;
                        // CSVファイルデータが存在しないのでスキップ
                        // 未登録か、反映不要の時
                    }
                    else    // 反映が必要な場合
                    {
                        Label stat;
                        TextBox tb;
                        switch (i)
                        {
                            case 0:
                                stat = gameStat1;
                                tb = gameTb1;
                                break;
                            case 1:
                                stat = gameStat2;
                                tb = gameTb2;
                                break;
                            case 2:
                                stat = gameStat3;
                                tb = gameTb3;
                                break;
                            case 3:
                                stat = gameStat4;
                                tb = gameTb4;
                                break;
                            case 4:
                                stat = gameStat5;
                                tb = gameTb5;
                                break;
                            case 5:
                                stat = gameStat6;
                                tb = gameTb6;
                                break;
                            default:
                                throw new ApplicationException(
                                    "無効な位置情報が指定されました（内部エラー）");
                        }
                        // 反映開始
                        stat.Text = STATUS_UPDATING;
                        stat.Refresh(); // 何故かうまく更新されなかったので追加
                        ReadCsvAndUpdateDB(tb.Text);
                        stat.Text = STATUS_DONE;  // こっちは普通に更新される
                        stat.Refresh();  // 念のため
                        //this.Invalidate();
                    }
                }
                updateButton.Enabled = false;
                updateButton.Text = "更新完了";
            }
            catch(ApplicationException exception)
            {
                updateButton.Text = "更新失敗";
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              exception.Message,
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
            }
            finally
            {
                closeButton.Enabled = true;  // 閉じるボタン有効化
            }
        }

        // 閉じるボタンがクリックされた
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
