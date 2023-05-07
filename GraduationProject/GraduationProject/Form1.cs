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
    public partial class Form1 : Form
    {
        bool userLogin;  // ユーザーがログイン中なら true
        List<MiniGame> games;
        //List<User> users = null;

        public Form1()
        {
            InitializeComponent();
            userLogin = false;
            ResetMiniGameButtons(null);  // ボタン無効に
        }

        //** ボタンやメニューなどのコントロールのリセット
        //       ユーザーのログイン状態とDBが作成済かどうかで、
        //       各コントロールの状態を変化させる
        private void ResetSwitchAndBoxes()
        {
            if (userLogin)  // ログイン中 
            {
                this.userNameTb.Enabled = false;  // ユーザー名変更不可
                this.logInOutButton.Enabled = true;
                this.logInOutButton.Text = "ログアウト";
                games = Database.GetMiniGames();
                this.ResetMiniGameButtons(games);
            }
            else // ログイン前
            {
                this.AdminMenuMenuItem.Enabled = true;  // 管理メニュー可
                this.logInOutButton.Text = "ログイン";
                this.userNameTb.Text = "";  // ユーザー名入力欄は空
                if (!Database.IsInstalled())
                {
                    // データベース未作成時は、ログインも不可
                    this.userNameTb.Enabled = false;  // ユーザー名入力不可
                    this.logInOutButton.Enabled = false;
                    games = null;
                    ResetMiniGameButtons(games);  // すべて無効に
                    //users = new List<User>();  // 空のリストをセット
                }
                else
                {
                    // 通常のケース
                    this.userNameTb.Enabled = true;  // ユーザー名入力可
                    this.logInOutButton.Enabled = true;  // ログイン可
                    games = Database.GetMiniGames();
                    //users = Database.GetUsers();
                    this.ResetMiniGameButtons(games);
                }
            }
        }

        //** ミニゲームボタンの状態変更
        private void ResetMiniGameButtons(List<MiniGame> games)
        {
            if (games == null || games.Count == 0)
            {
                // 全ゲームが未登録状態
                this.gameButton1.Enabled = false;
                this.gameButton1.Text = "未登録";
                this.gameButton2.Enabled = false;
                this.gameButton2.Text = "未登録";
                this.gameButton3.Enabled = false;
                this.gameButton3.Text = "未登録";
                this.gameButton4.Enabled = false;
                this.gameButton4.Text = "未登録";
                this.gameButton5.Enabled = false;
                this.gameButton5.Text = "未登録";
                this.gameButton6.Enabled = false;
                this.gameButton6.Text = "未登録";
            } 
            else
            {
                ResetMiniGameButtons(null);  // 初期化
                foreach (MiniGame g in games)
                {
                    if (g.Position == 0)
                    {
                        if (userLogin)
                            this.gameButton1.Enabled = true;
                        else
                            this.gameButton1.Enabled = false;
                        this.gameButton1.Text = g.GameName;
                    }
                    else if (g.Position == 1)
                    {
                        if (userLogin)
                            this.gameButton2.Enabled = true;
                        else
                            this.gameButton2.Enabled = false;
                        this.gameButton2.Text = g.GameName;
                    }
                    else if (g.Position == 2)
                    {
                        if (userLogin)
                            this.gameButton3.Enabled = true;
                        else
                            this.gameButton3.Enabled = false;
                        this.gameButton3.Text = g.GameName;
                    }
                    else if (g.Position == 3)
                    {
                        if (userLogin)
                            this.gameButton4.Enabled = true;
                        else
                            this.gameButton4.Enabled = false;
                        this.gameButton4.Text = g.GameName;
                    }
                    else if (g.Position == 4)
                    {
                        if (userLogin)
                            this.gameButton5.Enabled = true;
                        else
                            this.gameButton5.Enabled = false;
                        this.gameButton5.Text = g.GameName;
                    }
                    else if (g.Position == 5)
                    {
                        if (userLogin)
                            this.gameButton6.Enabled = true;
                        else
                            this.gameButton6.Enabled = false;
                        this.gameButton6.Text = g.GameName;
                    }
                }
            }
        }


        //***** メニューで管理メニューが選択された
        private void AdminMenuMenuItem_Click(object sender, EventArgs e)
        {
            if (userLogin)
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "ユーザーログイン中は管理メニューは使えません.",
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
                return;
            }
            try
            {
                if (Database.IsInstalled())  // DBが既にある場合
                {
                    //管理者メニュー画面を開く
                    Form fm = new AdminMenuForm();
                    fm.ShowDialog();
                    // 起動画面で変なことをされないよう
                    // ダイアログで開く

                }
                else  // DBが存在しない場合
                {
                    //データベース作成画面へ
                    Form fm = new AdminCreateDbForm();
                    fm.ShowDialog();
                    // 起動画面で変なことをされないよう
                    // ダイアログで開く
                }
                ResetSwitchAndBoxes();  // 起動画面の状態を更新
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
            }
        }


        //****** メニューで終了が選択された
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "終了して良いですか？", "確認",
                              MessageBoxButtons.OKCancel,
                              MessageBoxIcon.Question);
                DialogResult dr = messageBox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Close();  //終了
                }
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
            }
        }


        //****** ログイン・アウトボタンがクリックされた
        private void logInOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userLogin) // ログイン処理
                {
                    if (checkUserNameAndAddIfNeeded(userNameTb.Text))
                    {
                        userLogin = true;
                    }
                }
                else  // ログアウト処理
                {
                    userLogin = false;
                }
                ResetSwitchAndBoxes();
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
            }
        }


        //** ユーザー名チェックと必要なら登録
        private bool checkUserNameAndAddIfNeeded(string userName)
        {
            User user = new User(userName);  // 指定された値のチェックもここで行われる
            if (!Database.IsExistUser(userName))
            {
                // 未登録 = 新規ユーザー
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "指定されたユーザーは登録されていません. \r\n"
                              + "新しいユーザーとして登録しますか？",
                              "確認",
                              MessageBoxButtons.OKCancel,
                              MessageBoxIcon.Question);
                DialogResult dr = messageBox.ShowDialog();
                if (dr != DialogResult.OK)  // 登録しない
                {
                    return false;  // ユーザー存在せず、作成もしない
                }
                else  // 登録する
                {
                    Database.AddUser(user);
                    messageBox
                      = new MgpMessageBox(
                              this,
                              "ユーザー登録が完了しました.\r\n"
                              + "ミニゲームパークをお楽しみください.",
                              "お知らせ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                    messageBox.ShowDialog();
                }
                return true;  // 新規ユーザー作成完了
            }
            return true;  // 既存ユーザー存在
        }


        //***** ロード = 初期化処理
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetSwitchAndBoxes();
        }

        //** 指定された位置に登録されたミニゲームを実行する
        private void executeMiniGame(int position)
        {
            string exeName = "";
            string gameName = "";
            foreach (MiniGame g in games)
            {
                if (g.Position == position)
                {
                    exeName = g.ExeFile;
                    gameName = g.GameName;
                    break;
                }
            }
            if (gameName == "" || exeName == "")
            {
                throw new ApplicationException(
                              "未登録のゲームが指定されました（内部エラー）");
            }
            string f = System.Environment.CurrentDirectory;
            f += "\\";
            f += gameName;
            f += "\\";
            f += exeName;

            // 引数の準備
            string arg = "\"" + gameName + "\"";
            arg += " \"" + this.userNameTb.Text + "\"";

            // プロセス起動の準備
            System.Diagnostics.Process process 
                = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo 
                = new System.Diagnostics.ProcessStartInfo(f);

            string workDir = System.Environment.CurrentDirectory;
            workDir += "\\";
            workDir += gameName;  // 実行ディレクトリ

            startInfo.Arguments = arg;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.ErrorDialog = true;
            startInfo.ErrorDialogParentHandle = this.Handle;
            startInfo.WorkingDirectory = workDir;

            // ミニゲーム用のプロセス起動
            process.StartInfo = startInfo;
            process.Start();
        }


        //***** ミニゲーム１の実行
        private void gameButton1_Click(object sender, EventArgs e)
        {
            executeMiniGame(0);
        }

        //***** ミニゲーム２の実行
        private void gameButton2_Click(object sender, EventArgs e)
        {
            executeMiniGame(1);
        }

        //***** ミニゲーム３の実行
        private void gameButton3_Click(object sender, EventArgs e)
        {
            executeMiniGame(2);
        }

        //***** ミニゲーム４の実行
        private void gameButton4_Click(object sender, EventArgs e)
        {
            executeMiniGame(3);
        }

        //***** ミニゲーム５の実行
        private void gameButton5_Click(object sender, EventArgs e)
        {
            executeMiniGame(4);
        }

        //***** ミニゲーム６の実行
        private void gameButton6_Click(object sender, EventArgs e)
        {
            executeMiniGame(5);
        }

        // ユーザー名の入力が更新された -- 使っていない
        private void userNameTb_TextChanged(object sender, EventArgs e)
        {
            // 既存のユーザーでマッチするものがあれば候補として補完する
            //    入力を続けたい時と、補完する時の区別が難しいので、断念。
            //string currentInput = this.userNameTb.Text;
            //if (currentInput != null && currentInput != "")
            //{
            //    if (users != null && users.Count > 0)
            //    {
            //        User cand = users.Find(u => u.UserName.StartsWith(currentInput));
            //        if (cand != null) this.userNameTb.Text = cand.UserName;
            //    }
            //}
        }


        // 隠し操作 -- ユーザー名がうろ覚えになった時用
        //             入力欄をダブルクリックすると、ヒントが出る
        private void userNameTb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string msg = "";
            if (userNameTb.Text != null && userNameTb.Text != "")
            {
                string cond = "%" + userNameTb.Text + "%";
                List<User> cand = Database.GetUsers(cond);
                if (cand.Count > 0)
                {
                    msg += "あなたは、";
                    for (int i = 0; i < cand.Count; i++)
                    {
                        if (i > 3)
                        {
                            msg += "候補が多すぎて、表示し切れません。";
                            break;
                        }
                        if (i == 1) msg += "それとも、";
                        else if (i == 2) msg += "はたまた、";
                        else if (i == 3) msg += "もしかして、";
                        msg += "『" + cand[i].UserName + "』さんですか？ \r\n";
                    }
                }
                else
                {
                    msg += "似た名前のユーザーをみつけられませんでした。";
                }
            }
            else
            {
                msg += "入力値と似た名前のユーザーを、こっそり教えます。";
            }
            MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              msg, "情報",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            messageBox.ShowDialog();
        }
    }
}
