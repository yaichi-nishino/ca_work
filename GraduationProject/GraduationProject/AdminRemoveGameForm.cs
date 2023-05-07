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
    public partial class AdminRemoveGameForm : Form
    {
        //**** メンバーデータ
        List<MiniGame> games;

        //***** コンストラクタ
        public AdminRemoveGameForm()
        {
            InitializeComponent();
            games = Database.GetMiniGames();
            if (games != null && games.Count > 0)
            {
                foreach(MiniGame g in games)
                {
                    string s = "No." + (g.Position+1) + " " + g.GameName;
                    this.targetComboBox.Items.Add(s);
                }
            }
            else 
            {
                throw new ApplicationException("ミニゲームは登録されていません");
            }
            
        }

        //***** 削除ボタンがクリックされた
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (targetComboBox.Text == "")
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "対象が選択されていません",
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
                return;
            }
            try
            {
                // メニューには、No.XX という形式で表示されている
                // DB中のPositionと比較するためには、
                // No. を取り除き、XX の値を1つ減らす必要がある
                string[] s = targetComboBox.Text.Split('.');
                string[] s2 = s[1].Split(' ');
                int p = int.Parse(s2[0]) - 1;
                int targetId = -1;
                string targetName = s2[1];
                foreach (MiniGame g in games)
                {
                    if (g.Position == p)
                    {
                        targetId = g.Id;
                        break;
                    }
                }
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "ミニゲームの登録情報を削除すると、プレイデータも削除されます.\r\n"
                              + "本当に、よろしいですか？", "確認",
                              MessageBoxButtons.OKCancel,
                              MessageBoxIcon.Question);

                DialogResult dr = messageBox.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return;  // 中止（画面は閉じない）
                }

                Database.DeleteMiniGame(targetId);

                messageBox
                    = new MgpMessageBox(
                              this,
                              "ミニゲーム『" + targetName + "』の登録情報が削除されました.\r\n"
                              + "不要となった実行ファイル等は、別途、手作業で削除する必要があります",
                              "お知らせ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                messageBox.ShowDialog();
                Close();  // 正常終了
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
