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
    public partial class AdminMenuForm : Form
    {
        //***** コンストラクタ
        public AdminMenuForm()
        {
            InitializeComponent();
        }

        //***** 情報表示がクリックされた
        private void showInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminShowDataForm();
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
            }
        }

        //***** データ更新がクリックされた
        private void updateDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminUpdateDataForm();
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
            }
        }

        //***** ミニゲーム追加がクリックされた
        private void addGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminAddGameForm();
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
            }
        }

        //***** ミニゲーム削除がクリックされた
        private void removeGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminRemoveGameForm();
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
            }
        }

        //***** 閉じるボタンがクリックされた
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
