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

namespace MiniGame2
{
    public partial class Form1 : Form
    {
        //***** メンバー
        int score;
        int problemNo;
        int answer;         // valuesの合計値（正解）
        Stack<int> values;  // 問題として表示する数
        Random rand;
        SoundPlayer soundPlayerMaru;
        SoundPlayer soundPlayerClick;
        MiniGameParkLib.Recorder recorder;

        Status stat;        // 状態
        int countInStatus;  // 現在の状態のカウント

        // 状態の定義
        enum Status
        {
            FirstBoot,
            WaitStarting,  // 開始前・ゲーム終了後
            Questioning,   // 出題中
            Answering      // 回答中
        }

        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            
            pekePb.Hide(); // 不正解の時の画像
            yesPb.Hide();  // 正解の時の画像
            rand = new Random();
            recorder = new MiniGameParkLib.Recorder();
            soundPlayerMaru = new SoundPlayer();
            soundPlayerClick = new SoundPlayer();
            soundPlayerMaru.Stream = Properties.Resources.Find;  // 正解音
            soundPlayerClick.Stream = Properties.Resources.Card;  // クリック音
            MgpMessageBox.SetBackgroundImage(
                Properties.Resources.back_marble);

            InitGame(true);
        }


        //*** 初期化
        private void InitGame(bool isFirst)
        {
            score = 0;
            problemNo = 0;
            countInStatus = 0;

            values = new Stack<int>();
            answer = 0;
            for (int i = 0; i < 3; i++)
            {
                int val = rand.Next(1, 100);
                values.Push(val);
                answer += val;
            }

            if (isFirst)
            {
                stat = Status.FirstBoot;
            }
            else
            {
                stat = Status.WaitStarting;
                questionLb.Text = "";
                answerLb.Text = "";
                recorder.Start();
            }
            timer1.Start();  // タイマー開始
        }


        //***** 1の入力
        private void button1_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "1";
        }

        //***** 2の入力
        private void button2_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "2";
        }

        //***** 3の入力
        private void button3_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "3";
        }

        //***** 4の入力
        private void button4_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "4";
        }

        //***** 5の入力
        private void button5_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "5";
        }

        //***** 6の入力
        private void button6_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "6";
        }

        //***** 7の入力
        private void button7_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "7";
        }

        //***** 8の入力
        private void button8_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "8";
        }

        //***** 9の入力
        private void button9_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "9";
        }

        //***** 0の入力
        private void button10_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            answerLb.Text += "0";
        }

        //***** 一文字削除
        private void backButton_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            string s = "";
            for (int i = 0; i < answerLb.Text.Length-1; i++)
            {
                s += answerLb.Text.ToCharArray()[i];
            }
            answerLb.Text = s;
        }


        //***** エンターボタンクリック
        private void enterButton_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            if (stat != Status.Answering) timer1.Stop();  // タイマー中断

            int input;
            int.TryParse(answerLb.Text, out input);
            if (input == answer)
            {
                soundPlayerMaru.Play();
                yesPb.Visible = true;
                score += 1000;
                scoreLb.Text = score.ToString();
                scoreLb.Text += " 点";
                stat = Status.WaitStarting;
                countInStatus = 0;
                Task.Delay(1500).Wait();  // 余韻にひたる
                timer1.Start();  // タイマー再開
            }
            else 
            {
                BeepSoundPlay();
                timer1.Stop();
                pekePb.Visible = true;
                recorder.Stop(score);
                MgpMessageBox messageBox 
                    = new MgpMessageBox(this, 
                              "不正解です！\r\n正解は "
                              + answer.ToString() + " です\r\n"
                              + "新しいゲームを始めますか？",
                              "確認",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);
                DialogResult res = messageBox.ShowDialog();
                if (res == DialogResult.No) this.Close();
                InitGame(false);
            }
        }


        //***** タイマー
        private void timer1_Tick(object sender, EventArgs e)
        {
            countInStatus++;
            timer1.Stop();  // タイマー中断

            // ステータスにより挙動が異なる
            DialogResult res;
            MgpMessageBox messageBox;
            switch (stat)
            {
                case Status.FirstBoot:
                    messageBox
                        = new MgpMessageBox(
                                  this,
                                  "ゲームを始めますか？",
                                  "確認",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);
                    res = messageBox.ShowDialog();
                    if (res == DialogResult.No) this.Close();
                    stat = Status.WaitStarting;
                    recorder.Start();
                    break;
                
                case Status.WaitStarting:
                    yesPb.Hide();
                    pekePb.Hide();
                    answerLb.Text = "";
                    questionLb.Text = "";
                    stat = Status.Questioning;
                    break;

                case Status.Questioning:
                    if (values.Count > 0)  // まだ出題していない数あり
                    {
                        if (countInStatus > 3)  // 次の数字の表示
                        {
                            questionLb.Text = values.Pop().ToString();
                            if (values.Count == 0)
                            {
                                questionLb.Text += " では？";
                                stat = Status.Answering;
                                // 全数字が表示されたので解答まちに
                            }
                            else
                            {
                                questionLb.Text += " たす";
                                countInStatus = 0;  
                                // 次の数字を状態変えずに表示
                            }
                        }
                    }
                    else  // 次の問題へ
                    {
                        problemNo++;
                        if (problemNo < 5)  // 3つの数字を5問
                        {
                            values = new Stack<int>();  // 新しい問題を用意
                            answer = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                int val = rand.Next(1, 100);
                                values.Push(val);
                                answer += val;
                            }
                            questionLb.Text = values.Pop().ToString();  // 1つ目のみココで表示
                            questionLb.Text += " たす";
                            answerLb.Text = "";
                            stat = Status.Questioning;

                        }
                        else  // 5問クリア
                        {
                            recorder.Stop(score);
                            messageBox 
                                = new MgpMessageBox(
                                          this,
                                          "全問正解です！\r\n"
                                          + "新しいゲームを始めますか？",
                                          "確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                            res = messageBox.ShowDialog();
                            if (res == DialogResult.No) this.Close();
                            InitGame(false);
                            answerLb.Text = "";
                        }
                    }
                    break;

                case Status.Answering:  // 解答する場合はエンターが押される
                                        // ここにくるのは、タイムアップの時
                    if (countInStatus > 50) 
                    {
                        BeepSoundPlay();
                        recorder.Stop(score);
                        messageBox 
                            = new MgpMessageBox(
                                      this,
                                      "時間切れです！\r\n"
                                      + "新しいゲームを始めますか？",
                                      "確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                        res = messageBox.ShowDialog();
                        if (res == DialogResult.No) this.Close();
                        InitGame(false);
                    }
                    break;
            }

            timer1.Start();  // タイマー再開
        }

        //** 間違えたときの音
        private void BeepSoundPlay()
        {
            Console.Beep(295, 300);
            Console.Beep(295, 600);
        }


        //***** ロードメソッド
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
