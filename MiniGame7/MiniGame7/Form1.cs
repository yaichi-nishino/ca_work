using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MiniGameParkLib;

namespace MiniGame7
{
    
    public partial class Form1 : Form
    {
        //****** メンバーフィールド
        static readonly int MAX_NUM = 36;
        static readonly int TIME_LIMIT = 60;
        static readonly int MINUS_SEC_FOR_FAIL = 10;

        int[] numOrder;     // シャッフルされたナンバーリスト
        Image[] numImages;  // 番号に対応する画像
        Random rand;        // 乱数生成器
        int nextNum;        // 次にクリックする番号
        int score;          // スコア
        int remainSec;      // 残り時間
        SoundPlayer spTch;
        SoundPlayer spClear;
        Recorder recorder;

        public Form1()
        {
            InitializeComponent();

            MgpMessageBox.SetBackgroundImage(
                Properties.Resources.back_wood);
            recorder = new Recorder();
            rand = new Random();
            spTch = new SoundPlayer();
            spTch.Stream = Properties.Resources.Card;
            spClear = new SoundPlayer();
            spClear.Stream = Properties.Resources.Find;

            numImages = new Image[MAX_NUM];
            numImages[0] = Properties.Resources.num01;
            numImages[1] = Properties.Resources.num02;
            numImages[2] = Properties.Resources.num03;
            numImages[3] = Properties.Resources.num04;
            numImages[4] = Properties.Resources.num05;
            numImages[5] = Properties.Resources.num06;
            numImages[6] = Properties.Resources.num07;
            numImages[7] = Properties.Resources.num08;
            numImages[8] = Properties.Resources.num09;
            numImages[9] = Properties.Resources.num10;
            numImages[10] = Properties.Resources.num11;
            numImages[11] = Properties.Resources.num12;
            numImages[12] = Properties.Resources.num13;
            numImages[13] = Properties.Resources.num14;
            numImages[14] = Properties.Resources.num15;
            numImages[15] = Properties.Resources.num16;
            numImages[16] = Properties.Resources.num17;
            numImages[17] = Properties.Resources.num18;
            numImages[18] = Properties.Resources.num19;
            numImages[19] = Properties.Resources.num20;
            numImages[20] = Properties.Resources.num21;
            numImages[21] = Properties.Resources.num22;
            numImages[22] = Properties.Resources.num23;
            numImages[23] = Properties.Resources.num24;
            numImages[24] = Properties.Resources.num25;
            numImages[25] = Properties.Resources.num26;
            numImages[26] = Properties.Resources.num27;
            numImages[27] = Properties.Resources.num28;
            numImages[28] = Properties.Resources.num29;
            numImages[29] = Properties.Resources.num30;
            numImages[30] = Properties.Resources.num31;
            numImages[31] = Properties.Resources.num32;
            numImages[32] = Properties.Resources.num33;
            numImages[33] = Properties.Resources.num34;
            numImages[34] = Properties.Resources.num35;
            numImages[35] = Properties.Resources.num36;
            
            DisableAllNumberBts();  // スタートまでボタン無効
        }


        //** ナンバーリストの初期化
        private void InitialeNumOrder()
        {
            if (numOrder == null)
                numOrder = new int[MAX_NUM];
            for(int i = 0; i < MAX_NUM; i++)
            {
                numOrder[i] = -1;  // 未設定
            }
        }

        //** 全ボタンをクリック可能に
        private void EnableAllNumberBts()
        {
            ChangeNumberBtsEnable(true);
        }

        //** 全ボタンをクリック不可に
        private void DisableAllNumberBts()
        {
            ChangeNumberBtsEnable(false);
        }

        //** 全ボタンの使用可否を変更
        private void ChangeNumberBtsEnable(bool value)
        {
            numPb00.Enabled = value;
            numPb01.Enabled = value;
            numPb02.Enabled = value;
            numPb03.Enabled = value;
            numPb04.Enabled = value;
            numPb05.Enabled = value;
            numPb06.Enabled = value;
            numPb07.Enabled = value;
            numPb08.Enabled = value;
            numPb09.Enabled = value;
            numPb10.Enabled = value;
            numPb11.Enabled = value;
            numPb12.Enabled = value;
            numPb13.Enabled = value;
            numPb14.Enabled = value;
            numPb15.Enabled = value;
            numPb16.Enabled = value;
            numPb17.Enabled = value;
            numPb18.Enabled = value;
            numPb19.Enabled = value;
            numPb20.Enabled = value;
            numPb21.Enabled = value;
            numPb22.Enabled = value;
            numPb23.Enabled = value;
            numPb24.Enabled = value;
            numPb25.Enabled = value;
            numPb26.Enabled = value;
            numPb27.Enabled = value;
            numPb28.Enabled = value;
            numPb29.Enabled = value;
            numPb30.Enabled = value;
            numPb31.Enabled = value;
            numPb32.Enabled = value;
            numPb33.Enabled = value;
            numPb34.Enabled = value;
            numPb35.Enabled = value;
        }

        private void ResetNumberBtsColor()
        {
            numPb00.BackColor = Color.White;
            numPb01.BackColor = Color.White;
            numPb02.BackColor = Color.White;
            numPb03.BackColor = Color.White;
            numPb04.BackColor = Color.White;
            numPb05.BackColor = Color.White;
            numPb06.BackColor = Color.White;
            numPb07.BackColor = Color.White;
            numPb08.BackColor = Color.White;
            numPb09.BackColor = Color.White;
            numPb10.BackColor = Color.White;
            numPb11.BackColor = Color.White;
            numPb12.BackColor = Color.White;
            numPb13.BackColor = Color.White;
            numPb14.BackColor = Color.White;
            numPb15.BackColor = Color.White;
            numPb16.BackColor = Color.White;
            numPb17.BackColor = Color.White;
            numPb18.BackColor = Color.White;
            numPb19.BackColor = Color.White;
            numPb20.BackColor = Color.White;
            numPb21.BackColor = Color.White;
            numPb22.BackColor = Color.White;
            numPb23.BackColor = Color.White;
            numPb24.BackColor = Color.White;
            numPb25.BackColor = Color.White;
            numPb26.BackColor = Color.White;
            numPb27.BackColor = Color.White;
            numPb28.BackColor = Color.White;
            numPb29.BackColor = Color.White;
            numPb30.BackColor = Color.White;
            numPb31.BackColor = Color.White;
            numPb32.BackColor = Color.White;
            numPb33.BackColor = Color.White;
            numPb34.BackColor = Color.White;
            numPb35.BackColor = Color.White;
        }

        //** 全ボタンのイメージを変更
        private void ChangeNumberBtsImages(int[] order)
        {
            numPb00.Image = numImages[order[0]];
            numPb01.Image = numImages[order[1]];
            numPb02.Image = numImages[order[2]];
            numPb03.Image = numImages[order[3]];
            numPb04.Image = numImages[order[4]];
            numPb05.Image = numImages[order[5]];
            numPb06.Image = numImages[order[6]];
            numPb07.Image = numImages[order[7]];
            numPb08.Image = numImages[order[8]];
            numPb09.Image = numImages[order[9]];
            numPb10.Image = numImages[order[10]];
            numPb11.Image = numImages[order[11]];
            numPb12.Image = numImages[order[12]];
            numPb13.Image = numImages[order[13]];
            numPb14.Image = numImages[order[14]];
            numPb15.Image = numImages[order[15]];
            numPb16.Image = numImages[order[16]];
            numPb17.Image = numImages[order[17]];
            numPb18.Image = numImages[order[18]];
            numPb19.Image = numImages[order[19]];
            numPb20.Image = numImages[order[20]];
            numPb21.Image = numImages[order[21]];
            numPb22.Image = numImages[order[22]];
            numPb23.Image = numImages[order[23]];
            numPb24.Image = numImages[order[24]];
            numPb25.Image = numImages[order[25]];
            numPb26.Image = numImages[order[26]];
            numPb27.Image = numImages[order[27]];
            numPb28.Image = numImages[order[28]];
            numPb29.Image = numImages[order[29]];
            numPb30.Image = numImages[order[30]];
            numPb31.Image = numImages[order[31]];
            numPb32.Image = numImages[order[32]];
            numPb33.Image = numImages[order[33]];
            numPb34.Image = numImages[order[34]];
            numPb35.Image = numImages[order[35]];
        }

        //** 得点と残り時間の描画
        private void WriteScoreAndTime()
        {
            string msg = "残り ";
            if (remainSec >= 0)
                msg += remainSec.ToString();
            else
                msg += "0";
            msg += " 秒";
            timeLabel.Text = msg;

            msg = score.ToString();
            msg += " 点";
            scoreLabel.Text = msg;
        }


        //***** スタートボタンがクリックされた時
        private void startPb_Click(object sender, EventArgs e)
        {
            // 番号のシャッフル
            InitialeNumOrder();  // 初期化
            for (int i = 0; i < MAX_NUM; i++)
            {
                int pos = rand.Next(MAX_NUM);
                if (numOrder[pos] < 0)
                {
                    numOrder[pos] = i;
                }
                else
                {
                    i--;  // やり直し
                }
            }

            // ボタンのイメージを張り替え
            ChangeNumberBtsImages(numOrder);
            EnableAllNumberBts();  // クリック可能
            ResetNumberBtsColor();  // 背景色変更

            // スコアと制限時間の初期化
            score = 0;
            remainSec = TIME_LIMIT;
            WriteScoreAndTime();

            // プレイ開始 -- タイマースタート
            startPb.Enabled = false;
            nextNum = 0;  // 0からスタート
            recorder.Start();
            timer1.Start();
        }


        //** 間違えた時のビープ音
        private void BeepForFail()
        {
            Console.Beep(295, 300);
            Console.Beep(295, 600);
        }

        //** タイムアップ時のビープ音
        private void BeepForTimeUp()
        {
            Console.Beep(295, 300);
            Console.Beep(295, 300);
            Console.Beep(295, 1000);
        }


        //** ボタンがクリックされた時の共通メソッド
        private void NumPbClickCommon(int myNum, PictureBox myPb)        {
            // タイマー中断
            timer1.Stop();

            // 正解かどうかチェック
            if (numOrder[myNum] == nextNum)
            {
                // クリック音・背景色変更・スコア加算
                spTch.Play();
                myPb.BackColor = Color.Transparent;  // 背景透明化
                myPb.Enabled = false;  // クリック不可
                score += 100;
                nextNum++;  
                    // 完了チェックはタイマーで
            }
            else
            {
                // ミス音・残り時間減
                BeepForFail();
                remainSec -= MINUS_SEC_FOR_FAIL;
                    // 時間切れのチェックはタイマーで
            }
            WriteScoreAndTime();

            // タイマー再開
            timer1.Start();
        }

        private void numPb00_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(0, numPb00);
        }

        private void numPb01_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(1, numPb01);
        }

        private void numPb02_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(2, numPb02);
        }

        private void numPb03_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(3, numPb03);
        }

        private void numPb04_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(4, numPb04);
        }

        private void numPb05_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(5, numPb05);
        }

        private void numPb06_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(6, numPb06);
        }

        private void numPb07_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(7, numPb07);
        }

        private void numPb08_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(8, numPb08);
        }

        private void numPb09_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(9, numPb09);
        }

        private void numPb10_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(10, numPb10);
        }

        private void numPb11_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(11, numPb11);
        }

        private void numPb12_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(12, numPb12);
        }

        private void numPb13_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(13, numPb13);
        }

        private void numPb14_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(14, numPb14);
        }

        private void numPb15_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(15, numPb15);
        }

        private void numPb16_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(16, numPb16);
        }

        private void numPb17_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(17, numPb17);
        }

        private void numPb18_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(18, numPb18);
        }

        private void numPb19_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(19, numPb19);
        }

        private void numPb20_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(20, numPb20);
        }

        private void numPb21_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(21, numPb21);
        }

        private void numPb22_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(22, numPb22);
        }

        private void numPb23_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(23, numPb23);
        }

        private void numPb24_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(24, numPb24);
        }

        private void numPb25_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(25, numPb25);
        }

        private void numPb26_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(26, numPb26);
        }

        private void numPb27_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(27, numPb27);
        }

        private void numPb28_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(28, numPb28);
        }

        private void numPb29_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(29, numPb29);
        }

        private void numPb30_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(30, numPb30);
        }

        private void numPb31_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(31, numPb31);
        }

        private void numPb32_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(32, numPb32);
        }

        private void numPb33_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(33, numPb33);
        }

        private void numPb34_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(34, numPb34);
        }

        private void numPb35_Click(object sender, EventArgs e)
        {
            NumPbClickCommon(35, numPb35);
        }


        // タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            remainSec -= 1;  // 1秒経過
            WriteScoreAndTime();  // スコア・時間表示
            if (remainSec < 0)
            {
                // 時間切れ
                timer1.Stop();
                recorder.Stop(score);
                BeepForTimeUp();
                DisableAllNumberBts();
                startPb.Enabled = true;
                
                MgpMessageBox mbox
                        = new MgpMessageBox(
                                  this, 
                                  "残念、時間ぎれです。");
                mbox.Show();
            }
            else
            {
                // 完了チェック
                if (nextNum >= MAX_NUM)
                {
                    timer1.Stop();
                    spClear.Play();
                    score += remainSec * 100;  // 残り秒数でボーナス
                    WriteScoreAndTime();
                    recorder.Stop(score);
                    DisableAllNumberBts();
                    startPb.Enabled = true;
                    
                    MgpMessageBox mbox
                        = new MgpMessageBox(
                                  this, 
                                  "おめでとうございます。\r\n"
                                  + "完成です。");
                    mbox.Show();
                }
            }
        }
    }
}
