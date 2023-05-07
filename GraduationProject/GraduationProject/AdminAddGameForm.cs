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
    public partial class AdminAddGameForm : Form
    {
        //***** メンバーデータ
        private string selectedFilePath;  // 選択されたファイルのフルパス名
        private List<MiniGame> games;

        //***** コンストラクタ
        public AdminAddGameForm()
        {
            InitializeComponent();

            games = Database.GetMiniGames();
            for (int i = 0; i < MiniGame.NUM_OF_MINI_GAMES_IN_LAUNCHER; i++)
            {
                if (games.All(g => g.Position != i)) // 使われていない位置を探す
                {
                    string s = "No." + (i+1);
                    this.positionCb.Items.Add(s);
                }
            }
            if (this.positionCb.Items.Count == 0)
                throw new ApplicationException("ミニゲームを登録する場所がありません");
        }

        //***** 選択のボタンがクリックされた
        private void exeFileSelectButton_Click(object sender, EventArgs e)
        {
            // ファイル選択用ダイアログの準備
            OpenFileDialog ofDialog = new OpenFileDialog();
            try
            {
                ofDialog.InitialDirectory =
                System.Environment.CurrentDirectory;  // デフォルト
                ofDialog.Title = "実行ファイルの選択";  // タイトル

                // ダイアログを開き、ファイル選択してもらう
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofDialog.FileName;  // フルパス
                    this.exeFileNameTb.Text = ofDialog.SafeFileName;  // ファイル名のみ
                    string[] ar = exeFileNameTb.Text.Split('.');
                    if (this.gameNameTb.Text == "")
                    {
                        this.gameNameTb.Text = ar[0];  // ゲーム名のデフォルト
                    }
                }
                else
                {
                    this.selectedFilePath = "";
                    this.exeFileNameTb.Text = "";
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
            finally
            {
                // オブジェクトを破棄する
                ofDialog.Dispose();
            }
        }

        //***** 登録ボタンがクリックされた
        private void addButton_Click(object sender, EventArgs e)
        {
            bool fileCreated = false;
            try
            {
                // 同じ値が登録されていないかチェック
                if (!games.All(g => g.GameName != gameNameTb.Text))
                {
                    throw new ApplicationException(
                                  "同じ名前のゲームが既に登録されています");
                }
                if (selectedFilePath == null || selectedFilePath == "")
                {
                    throw new ApplicationException(
                                  "実行ファイルが選択されていません");
                }
                if (positionCb.Text == "")
                {
                    throw new ApplicationException(
                                  "ゲームを登録する位置を指定してください");
                }
                string[] s = positionCb.Text.Split('.');
                int p = int.Parse(s[1]) - 1;
                MiniGame newGame 
                    = new MiniGame(p, gameNameTb.Text,
                              exeFileNameTb.Text);

                // 実行ファイルのコピー
                string f = System.Environment.CurrentDirectory;
                f += "\\";
                f += gameNameTb.Text;
                System.IO.Directory.CreateDirectory(f);
                fileCreated = true;
                f += "\\";
                f += exeFileNameTb.Text;
                System.IO.File.Copy(selectedFilePath, f, false);

                // CSV記録用のDLLファイルのコピー
                string srcDll = System.Environment.CurrentDirectory;
                srcDll += "\\";
                srcDll += PlayData.DLL_FILE_NAME;
                string destDll = System.Environment.CurrentDirectory;
                destDll += "\\";
                destDll += gameNameTb.Text;
                destDll += "\\";
                destDll += PlayData.DLL_FILE_NAME;
                System.IO.File.Copy(srcDll, destDll, true);

                // DBへの登録作業
                Database.AddMiniGame(newGame);

                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "ミニゲーム『" 
                              + gameNameTb.Text + 
                              "』が登録されました",
                              "お知らせ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                messageBox.ShowDialog();

                Close();  // 正常終了
            }
            catch (ApplicationException exception)
            {
                if (fileCreated)
                {
                    MgpMessageBox messageBox
                        = new MgpMessageBox(
                                  this,
                                  "エラー： " +
                                  exception.Message +
                                  "注意： ファイルがコピーされているので削除してください.",
                                  "エラー",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    messageBox.ShowDialog();                        
                }
                else
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
        }

        //***** 中止ボタンがクリックされた
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
