using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameParkLib
{
    public partial class MgpMessageBox : Form
    { 
        //***** メンバーデータ
        MessageBoxButtons buttons;
        static private Color fColor = Color.Navy;
        static private Image backImage = Properties.Resources.lblue;

        //** 背景イメージをセット（一回呼べばOK）
        public static void SetBackgroundImage(Image img)
        {
            backImage = img;
            SetForeColor(Color.Black);  // 取り合えず
        }

        //** 文字色のセット（一回呼べばOK）
        public static void SetForeColor(Color c)
        {
            fColor = c;
        }

        //***** メッセージボックスっぽく表示するウィンドウ
        //      標準のものだとサイズが小さく、離れて表示されるため
        //      必要なもののみ自前化している
        protected MgpMessageBox()
        {
            InitializeComponent();
            this.MaximizeBox = false;   // 最大化ボタン
            this.MinimizeBox = false;   // 最小化ボタン
            this.ShowInTaskbar = false; // タスクバーに表示
            this.StartPosition = FormStartPosition.CenterParent;

            this.BackgroundImage = backImage;       // 背景色
            this.rightButton.ForeColor = fColor;    // ボタン文字色
            this.leftButton.ForeColor = fColor;     // ボタン文字色
            this.messageTb.ForeColor = fColor;      // メッセージ色
        }

        //***** メッセージのみの表示用
        public MgpMessageBox(Form ower, string text) : this()
        {
            this.Owner = Owner;
            this.messageTb.Text = text;  // メッセージ表示
            this.Text = "";    // ウィンドウのキャプション
            this.leftButton.Hide();
            this.rightButton.Text = "OK";
            this.buttons = MessageBoxButtons.OK;
            this.AcceptButton = rightButton;
            this.iconPb.Hide();
        }

        public MgpMessageBox(
                   Form ower,
                   string text,
                   string caption,
                   MessageBoxButtons buttons,
                   MessageBoxIcon icon) : this()
        {
            this.buttons = buttons;
            this.Owner = Owner; 
            this.messageTb.Text = text;  // メッセージ表示
            this.Text = caption;  // ウィンドウのキャプション

            switch (buttons)
            {
                case MessageBoxButtons.OKCancel:
                    this.leftButton.Text = "OK";
                    this.rightButton.Text = "キャンセル";
                    this.AcceptButton = leftButton;
                    break;
                case MessageBoxButtons.YesNo:
                    this.leftButton.Text = "Yes";
                    this.rightButton.Text = "No";
                    this.AcceptButton = leftButton;
                    break;
                case MessageBoxButtons.OK:
                default:
                    this.leftButton.Hide();  // 左側ボタンは非表示
                    this.rightButton.Text = "OK";
                    this.AcceptButton = rightButton;
                    break;
            }

            switch (icon)
            {
                case MessageBoxIcon.Error:
                    iconPb.Image = Properties.Resources.error;
                    break;
                case MessageBoxIcon.Information:
                    iconPb.Image = Properties.Resources.info;
                    break;

                case MessageBoxIcon.Question:
                    iconPb.Image = Properties.Resources.question;
                    break;
                case MessageBoxIcon.Warning:
                default:
                    iconPb.Image = Properties.Resources.warning;
                    break;
            }
        }


        //***** 左ボタンがクリックされた
        private void leftButton_Click(object sender, EventArgs e)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.Yes;
                    break;
                case MessageBoxButtons.OK:
                default:
                    this.DialogResult = DialogResult.None;
                    // 本来、ここには来ないはず
                    break;
            }
            Close();
        }

        //***** 右ボタンがクリックされた
        private void rightButton_Click(object sender, EventArgs e)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.No;
                    break;
                case MessageBoxButtons.OK:
                default:
                    this.DialogResult = DialogResult.OK;
                    break;
            }
            Close();
        }
    }
}
