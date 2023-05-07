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

namespace MiniGame1
{
    public partial class Form1 : Form
    {
        // メンバー
        // 固定値
        int TamaInitX = 20;     // タマの初期位置 X
        int TamaInitY = 100;    // タマの初期位置 Y
        int TamaRad = 32;       // タマ画像の半径
        int tamaWidth = 64;
        int tamaHeight = 64;
        int WindowWidth = 480;
        int WindowHeight = 320;

        // 変数
        //static Bitmap canvas = new Bitmap(480, 320);
        Bitmap canvas;
        Graphics gg;
        Font myFont = new Font("Showcard Gothic", 14);
        Font myFontBig = new Font("Showcard Gothic", 24);
        int remainTime;
        int highScore;

        Stack<Point> pathPos;    // 移動の軌跡 -- 今の方向への移動分のみ保持
        int hoseiX;             // クリック位置の弾画像原点からのズレ X
        int hoseiY;             // クリック位置の弾画像原点からのズレ Y             
        Point cPosInReturn;     // リリース後の弾の移動量

        bool isReleased;        // クリックが外れた -- 弾の慣性移動中
        bool isClicked;         // クリックされた -- 弾をドラッグ中
        bool hit;
        bool gameOvered;

        MiniGameParkLib.Recorder recorder;
        SoundPlayer soundPlayerFind;
        SoundPlayer soundPlayerClick;
        Random rand;


        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            recorder = new MiniGameParkLib.Recorder();
            soundPlayerFind = new SoundPlayer();
            soundPlayerClick = new SoundPlayer();
            soundPlayerFind.Stream = Properties.Resources.Find;  // 見つけた音
            soundPlayerClick.Stream = Properties.Resources.Card;  // クリック音
            rand = new Random();
            this.Width = WindowWidth;
            this.Height = WindowHeight;
            InitGame();
        }

        //*** 画面などの初期化
        private void InitGame()
        {
            canvas = new Bitmap(480, 320);
            gg = Graphics.FromImage(canvas);

            int targetPosX = rand.Next(64, WindowWidth - 64);  // お宝
            int targetPosY = rand.Next(64, WindowHeight - 64);
            cakePb.Location = new Point(targetPosX, targetPosY);

            tamaPb.Location = new Point(TamaInitX, TamaInitY);
            isClicked = false;
            isReleased = false;
            gameOvered = false;
            hit = false;
            remainTime = 9990;  // 減点方式

            cakePb.Hide();
            tamaPb.Hide();
            backPb.Hide();

            pathPos = new Stack<Point>();
            pathPos.Push(new Point(TamaInitX, TamaInitY));
            hoseiX = 0;
            hoseiY = 0;
            
            Invalidate();
            recorder.Start();
        }


        //***** フォームがクリックされた
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // ピクチャーボックスを被せることにしたので、
            // このハンドラは不要。消しておかしくなるのを避けるため、
            // とりあえず残している。
        }


        //***** マウスがコントロール内で移動
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // ピクチャーボックスを被せることにしたので、
            // このハンドラは不要。消しておかしくなるのを避けるため、
            // とりあえず残している。
        }

        //**** マウスがクリックされた
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // ピクチャーボックスを被せることにしたので、
            // このハンドラは不要。消しておかしくなるのを避けるため、
            // とりあえず残している。
        }

        //***** マウスボタンが離された時
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // ピクチャーボックスを被せることにしたので、
            // このハンドラは不要。消しておかしくなるのを避けるため、
            // とりあえず残している。
        }

        //** クリック音を出す内部メソッド
        private void ClickSoundPlay()
        {
            soundPlayerClick.Play();
        }

        //** お宝発見の時のサウンド
        private void FindSoundPlay()
        {
            soundPlayerFind.Play();
        }

        //** ゲームオーバーの時のサウンド
        private void GameOverSoundPlay()
        {
            //Console.Beep(262, 300); // ド
            //Console.Beep(294, 300); // レ
            //Console.Beep(330, 300); // ミ
            //Console.Beep(349, 300); // ファ
            //Console.Beep(392, 300); // ソ
            //Console.Beep(440, 300); // ラ
            //Console.Beep(494, 300); // シ
            //Console.Beep(523, 300); // ド
            Console.Beep(295, 300);
            Console.Beep(295, 600);
        }


        //***** 画面の再描画
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 終了判定
            if (gameOvered)
            {
                DisplayGameOver();
                FinishGame();
                return;
            }
            if (hit)
            {
                DisplayHit();
                FinishGame();
                return;
            }

            // 背景描画
            gg.DrawImage(backPb.Image, new Rectangle(0, 0, WindowWidth, WindowHeight));

            // タマをパスの最後の場所で描画
            Point lastPos = pathPos.Pop();
            int x = lastPos.X - hoseiX;
            int y = lastPos.Y - hoseiY;
            tamaPb.Location = lastPos;
            gg.DrawImage(tamaPb.Image, new Rectangle(x, y, tamaWidth, tamaHeight));
            pathPos.Push(new Point(lastPos.X, lastPos.Y));  // スタックに積みなおし

            //int score = (9990 - remainTime < 0) ? 0 : 9990 - remainTime;
            gg.DrawString("HIGH SCORE: " + highScore.ToString(),
                          myFont, Brushes.Blue, 15, 8);
            gg.DrawString("SCORE: 0" /* + score.ToString()*/,
                          myFont, Brushes.BlueViolet, 15, 25);

            basePb.Image = canvas;
        }


        //** ゲームオーバー画面の表示
        private void DisplayGameOver()
        {
            // 背景描画
            gg.DrawImage(backPb.Image, new Rectangle(0, 0, WindowWidth, WindowHeight));

            int score = remainTime;
            gg.DrawString("HIGH SCORE: " + highScore.ToString(),
                          myFont, Brushes.Blue, 15, 8);
            gg.DrawString("SCORE: " + score.ToString(),
                          myFont, Brushes.BlueViolet, 15, 25);
            gg.DrawString("GAME OVER, \r\nCLICK for NEW GAME. ",
                          myFontBig, Brushes.Red, 80, 220);
            basePb.Image = canvas;
        }

        //** クリア画面の表示
        private void DisplayHit()
        {
            // 背景描画
            gg.DrawImage(backPb.Image, new Rectangle(0, 0, WindowWidth, WindowHeight));
            gg.DrawImage(cakePb.Image, new Rectangle(cakePb.Location.X, 
                                                     cakePb.Location.Y, tamaWidth, tamaHeight));

            int score = remainTime;
            gg.DrawString("HIGH SCORE: " + highScore.ToString(),
                          myFont, Brushes.Blue, 15, 8);
            gg.DrawString("SCORE: " + score.ToString(),
                          myFont, Brushes.BlueViolet, 15, 25);
            gg.DrawString("GET IT !!　\r\nCLICK for NEW GAME. ",
                          myFontBig, Brushes.Red, 80, 220);
            basePb.Image = canvas;
        }

        //** 後処理
        private void FinishGame()
        {
            int score = remainTime;
            if (highScore < score) highScore = score;  // ハイスコア更新
            timer1.Stop();
            recorder.Stop(score);
        }


        //***** ベースのボックスがクリックされた
        private void basePb_Click(object sender, EventArgs e)
        {
        }


        //***** タマをドラッグしながらマウスの移動
        private void basePb_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked && e.Button == MouseButtons.Left) // ドラッグしている場合
            {
                Point cPos = basePb.PointToClient(Cursor.Position);
                Point newCpos = CheckPoint(cPos);
                pathPos.Push(newCpos);
                Invalidate();  // 再描画
            }
        }

        //** ウィンドウから出ないように押しとどめる
        private Point CheckPoint(Point p)
        {
            int x = p.X;
            if (p.X < 32) x = 32;
            if (p.X > Width - 32) x = Width - 32;
            int y = p.Y;
            if (p.Y < 32) y = 32;
            if (p.Y > Height - 32) y = Height - 32;
            return new Point(x, y);
        }


        //** 2点間の距離（の二乗）を求める
        private double GetDistance(Point fromPos, Point toPos)
        {
            int int1 = Math.Abs(fromPos.X - toPos.X);
            int int2 = Math.Abs(fromPos.Y - toPos.Y);
            double d = (double)((int1 * int1) + (int2 * int2));
            return d;
        }


        //***** マウスボタンアップ -- タマをリリース
        private void basePb_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isClicked) // クリックが離された直後のみ処理を継続
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                // リリース点チェック
                Point cPos = basePb.PointToClient(Cursor.Position);
                Point newCpos = CheckPoint(cPos);
                pathPos.Push(newCpos);  // 描画用に現在位置を追加

                // タイマーを開始し、たまを移動させる
                timer1.Start();
                isClicked = false;
                isReleased = true;
                cPosInReturn = new Point(-1, -1);  // nullの代わり
                Invalidate();
            }
        }


        //****** タイマーイベント -- リリースされたタマを動かす
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isReleased)
            {
                Point nextPos = pathPos.Pop();
                if (cPosInReturn.X == -1 && cPosInReturn.Y == -1)
                {
                    cPosInReturn = nextPos;
                }
                else
                {
                    cPosInReturn = nextPos;
                    double distForNext = GetDistance(cPosInReturn, nextPos);
                    if (distForNext > 200)
                    {
                        nextPos = new Point(
                            (cPosInReturn.X - nextPos.X) * 3 / 4,
                            (cPosInReturn.Y - nextPos.Y) * 3 / 4);
                        pathPos.Push(nextPos);
                    }
                    else if (distForNext > 100)
                    {
                        nextPos = new Point(
                            (cPosInReturn.X - nextPos.X) * 2 / 3,
                            (cPosInReturn.Y - nextPos.Y) * 2 / 3);
                        pathPos.Push(nextPos);
                    }
                    else if (distForNext > 50)
                    {
                        nextPos = new Point(
                            (cPosInReturn.X - nextPos.X) / 2,
                            (cPosInReturn.Y - nextPos.Y) / 2);
                        pathPos.Push(nextPos);
                    }
                }

                double distForCake = GetDistance(cPosInReturn, cakePb.Location);
                if (distForCake < TamaRad * TamaRad)
                {
                    hit = true;
                    FindSoundPlay();
                    if (remainTime < 8990) remainTime += 1000;
                }
                else
                {
                    hit = false;
                    remainTime -= 100;
                    if (remainTime < 0)  // 帰りつく前にゲームオーバー
                    {
                        remainTime = 0;
                        Invalidate();
                        gameOvered = true;
                        GameOverSoundPlay();
                    }
                    if (pathPos.Count ==0) // 見つける前に帰ってきた
                    {
                        remainTime = 0;
                        Invalidate();
                        gameOvered = true;
                        GameOverSoundPlay();
                    }
                }
            }
            Invalidate();
        }


        //**** マウスがクリックされた
        private void basePb_MouseClick(object sender, MouseEventArgs e)
        {
        }


        //**** マウスがクリックされた直後
        //     ドラッグしていると、Clickの方はあがってこないもよう
        private void basePb_MouseDown(object sender, MouseEventArgs e)
        {
            Point cPos = basePb.PointToClient(Cursor.Position);
            int x = cPos.X;
            int y = cPos.Y;
            if (x >= TamaInitX && x <= TamaInitX + tamaWidth)
            {
                if (y >= TamaInitY && y <= TamaInitY + tamaHeight)
                {
                    pathPos = new Stack<Point>();
                    pathPos.Push(cPos);
                    hoseiX = cPos.X - TamaInitX;  // タマとクリック位置のズレ
                    hoseiY = cPos.Y - TamaInitY;

                    isClicked = true;
                    isReleased = false;

                    ClickSoundPlay();
                    Invalidate();  // 再描画
                }
            } 
        }


        //***** ダブルクリックされたら、もう一回
        private void basePb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gameOvered || hit)
            {
                InitGame();
            }
        }
    }
}
