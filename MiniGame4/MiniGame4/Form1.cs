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


namespace MiniGame4
{
    public partial class Form1 : Form
    {
        //***** メンバー
        bool playing = false;  // プレイ中なら true
        int score;  // スコア
        int turn;  // 何番目のターンか
        int targetSecond; // ターゲット（秒）
        DateTime startTime;  // 開始時間
        int TURN_FOR_ONE_GAME = 3;  // 何ターンで1ゲームにするか
        int MAX_TARGET_SECONDS = 15;  // 最大秒数
        int MIN_TARGET_SECONDS = 5;  // 最小秒数

        Random rand;
        System.Media.SoundPlayer spClick;
        SoundPlayer spGoodResult;
        MiniGameParkLib.Recorder recorder;


        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            BackColor = Color.White;  // 背景色を白に
            rand = new Random();
            spClick = new SoundPlayer();
            spClick.Stream = Properties.Resources.Card;
            spGoodResult = new SoundPlayer();
            spGoodResult.Stream = Properties.Resources.Find;
            recorder = new MiniGameParkLib.Recorder();
            InitializeGame();
        }


        //***** ボタンがクリックされた
        private void mainPb_Click(object sender, EventArgs e)
        {
            if (!playing)  // プレイ中ではない
            {
                // ターンを開始する
                if (turn == 0)
                {
                    spClick.Play(); 
                    recorder.Start();
                }
                string msg = (turn+1).ToString();
                msg += " 回目の挑戦";
                messageTb.Text = msg;
                Task.Delay(1200).Wait();  // 間をとる
                
                targetSecond
                    = rand.Next(MIN_TARGET_SECONDS, MAX_TARGET_SECONDS);
                startTime = DateTime.Now;
                msg = targetSecond.ToString();
                msg += " 秒";
                messageTb.Font = new Font(messageTb.Font.FontFamily, 24);
                messageTb.Text = msg;

                startPb.Enabled = true;
                startPb.BackgroundImage = Properties.Resources.stop_libra;
                
                playing = true;
            }
            else // 停止
            {
                spClick.Play();

                playing = false;
                startPb.Enabled = false;
                startPb.BackgroundImage = Properties.Resources.pause_libra;
                DateTime endTime = DateTime.Now;
                TimeSpan term = endTime - startTime;
                double termSec = term.TotalMilliseconds / 1000;  // 測定された秒数
                double diffSec = Math.Abs(termSec - targetSecond);  // 目標値との差 = 誤差
                double rate = diffSec / targetSecond;  // 誤差が、目標値の何パーセントか
                messageTb.Font = new Font(messageTb.Font.FontFamily, 18);
                string msg = "差は ";
                msg += diffSec.ToString("0.##") + " 秒です。\r\n";
                switch (rate)
                {
                    case double r when r < 0.05d:
                        msg += "誤差 5% 内。\r\n完璧です！ いうことありません。";
                        score += 3000;
                        break;
                    case double r when r < 0.1d:
                        msg += "誤差 10% 内。\r\nお見事です！";
                        score += 2000;
                        break;
                    case double r when r < 0.2d:
                        msg += "誤差 20% 内です。\r\nさすが！";
                        score += 1000;
                        break;
                    case double r when r < 0.3d:
                        msg += "誤差 30% 内です。\r\nまあまあですね";
                        score += 500;
                        break;
                    case double r when r < 0.5d:
                        msg += "誤差 50% 内です。\r\n普通。。。？";
                        score += 300;
                        break;
                    case double r when r < 0.8d:
                        msg += "誤差 80% 内です。\r\nもうちょっと。。？";
                        score += 100;
                        break;
                    default:
                        msg += "誤差 80%超えました。\r\nもう少し頑張りませう。";
                        score += 10;
                        break;
                }
                messageTb.Text = msg;
                messageTb.Refresh();
                Task.Delay(1500).Wait();  // 間をとる
                
                turn++;
                if (turn < TURN_FOR_ONE_GAME)
                {
                    // 次のターンへ
                    mainPb_Click(sender, e);
                      // ちょっとトリッキーだけど、スタートボタンを
                      // 何回も押さなくても済むように、
                      // このメソッド2回で1ターンになるよう
                      // 再帰っぽく呼び出しをしている
                }
                else
                {
                    // ゲームエンド
                    msg = "今回のスコア ";
                    msg += score.ToString();
                    msg += " 点";
                    messageTb.Text = msg;
                    recorder.Stop(score);
                    InitializeGame();
                }
                
            }
        }



        //*** 初期化（ゲームごとに一回よばれる）
        void InitializeGame()
        {
            score = 0;
            turn = 0;
            startPb.Enabled = true;
            startPb.BackgroundImage = Properties.Resources.start_libra;
            messageTb.Text = "スタートを押すと、ゲームが始まります。\r\n";
            messageTb.Text += "指定された秒数が経過したと思ったら、\r\n";
            messageTb.Text += "ストップしてください。3回チャレンジできます。";
        }
    }
}
