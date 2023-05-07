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

namespace MiniGame5
{
    public partial class Form1 : Form
    {
        //***** 4種類のボタンの色に対応
        enum BtColor
        {
            Blue,
            Yellow,
            Red,
            Green
        }

        //***** メンバーデータ
        MiniGameParkLib.Recorder recorder;
        List<BtColor> plays;
        int numOfPlayAns;
        int score;
        Random rand;

        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            recorder = new MiniGameParkLib.Recorder();
            MgpMessageBox.SetBackgroundImage(null);
            rand = new Random();
            DisableAllColorButtons();
        }

        //** ゲームスタート時の初期化
        public void InitGame()
        {
            plays = new List<BtColor>();
            score = 0;
            numOfPlayAns = 0;
            recorder.Start();
        }

        //** 後始末
        private void FinishGame()
        {
            recorder.Stop(score);
            EnableAllColorButtons();
            startPb.Image = Properties.Resources.start_bt2;  // スタートボタン
            startPb.Enabled = true;
        }

        //***** 青ボタンクリック
        private void bluePb_Click(object sender, EventArgs e)
        {
            DisableAllColorButtons();
            FlushButton(BtColor.Blue, 400);
            CheckAndContinue(BtColor.Blue);
            EnableAllColorButtons();
        }

        //**** 赤ボタンクリック
        private void redPb_Click(object sender, EventArgs e)
        {
            DisableAllColorButtons(); 
            FlushButton(BtColor.Red, 400);
            CheckAndContinue(BtColor.Red);
            EnableAllColorButtons();
        }

        //**** 緑ボタンクリック
        private void greenPb_Click(object sender, EventArgs e)
        {
            DisableAllColorButtons(); 
            FlushButton(BtColor.Green, 400);
            CheckAndContinue(BtColor.Green);
            EnableAllColorButtons();
        }

        //**** 黄ボタンクリック
        private void yellowPb_Click(object sender, EventArgs e)
        {
            DisableAllColorButtons(); 
            FlushButton(BtColor.Yellow, 400);
            CheckAndContinue(BtColor.Yellow);
            EnableAllColorButtons();
        }

        //** 入力が正しいかチェックする全色共通メソッド
        private void CheckAndContinue(BtColor c)
        {
            if (plays[numOfPlayAns] == c)
            {
                // 正しい
                if (numOfPlayAns == plays.Count - 1)
                {
                    // 最後まで入力できた
                    score += 200;
                    
                    AddAndPlayData();  // 一個追加し、お手本再生
                    startPb.Image = Properties.Resources.input_bt;
                    numOfPlayAns = 0;

                }
                else
                {
                    // まだ入力する必要のあるものが存在
                    numOfPlayAns++;
                    score += 50;
                }
                Refresh();
                EnableAllColorButtons();
            }
            else
            {
                // 間違えてしまった
                string msg = plays.Count.ToString();
                msg += " 個中の ";
                msg += (numOfPlayAns + 1).ToString();
                msg += " つ目で間違えました.\r\nスコアは ";
                msg += score.ToString();
                msg += " 点です.";
                MgpMessageBox messageBox
                    = new MgpMessageBox(this,
                              msg,
                              "今回の結果",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                DialogResult res = messageBox.ShowDialog();
                FinishGame();
            }
        }

        //** カラーボタンを全て有効化
        private void EnableAllColorButtons()
        {
            bluePb.Enabled = true;
            redPb.Enabled = true;
            greenPb.Enabled = true;
            yellowPb.Enabled = true;
        }

        //** カラーボタンを全て無効化
        private void DisableAllColorButtons()
        {
            bluePb.Enabled = false;
            redPb.Enabled = false;
            greenPb.Enabled = false;
            yellowPb.Enabled = false;
        }


        //*** ボタンを光らせる
        //    クリックされた時と、再生の時に使われる
        private void FlushButton(BtColor col, int millSecond)
        {
            switch (col)
            {
                case BtColor.Blue:
                    bluePb.Image = Properties.Resources.bt_blue;
                    Refresh();
                    Task.Delay(millSecond).Wait();
                    Console.Beep(262, 500);
                    bluePb.Image = Properties.Resources.bt_blue_dark;
                    break;
                case BtColor.Red:
                    redPb.Image = Properties.Resources.bt_red;
                    Refresh();
                    Task.Delay(millSecond).Wait();
                    Console.Beep(294, 500);
                    redPb.Image = Properties.Resources.bt_red_dark;
                    break;
                case BtColor.Yellow:
                    yellowPb.Image = Properties.Resources.bt_yellow;
                    Refresh();
                    Task.Delay(millSecond).Wait();
                    Console.Beep(330, 500);
                    yellowPb.Image = Properties.Resources.bt_yellow_dark;
                    break;
                case BtColor.Green:
                    greenPb.Image = Properties.Resources.bt_green;
                    Refresh();
                    Task.Delay(millSecond).Wait();
                    Console.Beep(349, 500);
                    greenPb.Image = Properties.Resources.bt_green_dark;
                    break;            
            }
            Refresh();
        }


        //***** スタートボタンが押された
        private void startPb_Click(object sender, EventArgs e)
        {
            startPb.Enabled = false;
            InitGame();
            Task.Delay(1000).Wait();
            AddAndPlayData();  // 最初の一歩
            EnableAllColorButtons();
            startPb.Image = Properties.Resources.input_bt;  // 入力待ち
        }


        //** ボタンを一つ追加し、お手本として全再生
        private void AddAndPlayData()
        {
            BtColor nextCol;  // 次の色を決める
            switch (rand.Next(4))
            {
                case 0:
                    nextCol = BtColor.Blue;
                    break;
                case 1:
                    nextCol = BtColor.Red;
                    break;
                case 2:
                    nextCol = BtColor.Green;
                    break;
                case 3:
                default:
                    nextCol = BtColor.Yellow;
                    break;
            }
            plays.Add(nextCol);

            // お手本再生
            startPb.Image = Properties.Resources.watch_out_bt;
            Task.Delay(1500).Wait();
            foreach (BtColor c in plays)
            {
                FlushButton(c, 400);
            }
        }
    }
}
