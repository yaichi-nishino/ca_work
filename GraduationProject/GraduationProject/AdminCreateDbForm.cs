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
    public partial class AdminCreateDbForm : Form
    {
        public AdminCreateDbForm()
        {
            InitializeComponent();
        }

        // 実行ボタンが押された
        private void createDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                // DBファイルの作成
                Database.CreateDatabase();

                // テーブルの作成
                Database.CreateTables();

                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              "データベースが作成されました.\r\n"
                              + "次は、ミニゲームを登録してください.",
                              "お知らせ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                messageBox.ShowDialog();
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(
                    exception.Message, "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            this.Close();
        }

        // 中止ボタンが押された
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
