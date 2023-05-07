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

namespace MiniGame6
{
    public partial class Form1 : Form
    {
        //***** メンバーデータ
        static Bitmap canvas = new Bitmap(480, 640);
        Graphics gg = Graphics.FromImage(canvas);
        Random rand = new Random();
        SoundPlayer sounPlayer;
        SoundPlayer sounPlayer2;
        MiniGameParkLib.Recorder recorder;

        int PW, PH;  // おけ（=キャッチする器）の幅と高さ
        Point Cpos;  // カーソル座標

        int[] itemX = new int[12];  // アイテム = 落下物
        int[] itemY = new int[12];
        ItemType[] itemTypes = new ItemType[12];
        PictureBox[] itemPbs = new PictureBox[12];
        int RR;  // アイテムの半径

        long score;
        int failedCounter;  // 失敗回数
        Font myFont = new Font("Ink free", 16);

        enum ItemType
        {
            SushiSalmon,    // サーモン
            SushiEbi,       // 海老
            SushiIkura,     // いくら
            SushiTemaki,    // 手巻き寿司
            SushiTamago,    // タマゴ
            Gomi,           // ゴミ
            Cake            // ケーキ
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sounPlayer = new SoundPlayer();
            sounPlayer.Stream = Properties.Resources.Card;
            sounPlayer2 = new SoundPlayer();
            sounPlayer2.Stream = Properties.Resources.Find;

            sushiBonusPb.Hide();
            sushiEbiPb.Hide();
            sushiEbiPb2.Hide();
            sushiGomiPb.Hide();
            sushiIkuraPb.Hide();
            sushiIkuraPb2.Hide();
            sushiOkePb.Hide();
            sushiSalmonPb.Hide();
            sushiSalmonPb2.Hide();
            sushiTamagoPb.Hide();
            sushiTamagoPb2.Hide();
            sushiTemakiPb.Hide();
            sushiTemakiPb2.Hide();
            backImagePb.Hide();

            itemTypes[0] = ItemType.Cake;
            itemTypes[1] = ItemType.Gomi;
            itemTypes[2] = ItemType.SushiEbi;
            itemTypes[3] = ItemType.SushiEbi;
            itemTypes[4] = ItemType.SushiIkura;
            itemTypes[5] = ItemType.SushiIkura;
            itemTypes[6] = ItemType.SushiSalmon;
            itemTypes[7] = ItemType.SushiSalmon;
            itemTypes[8] = ItemType.SushiTamago;
            itemTypes[9] = ItemType.SushiTamago;
            itemTypes[10] = ItemType.SushiTemaki;
            itemTypes[11] = ItemType.SushiTemaki;

            itemPbs[0] = sushiBonusPb;
            itemPbs[1] = sushiGomiPb;
            itemPbs[2] = sushiEbiPb;
            itemPbs[3] = sushiEbiPb2;
            itemPbs[4] = sushiIkuraPb;
            itemPbs[5] = sushiIkuraPb2;
            itemPbs[6] = sushiSalmonPb;
            itemPbs[7] = sushiSalmonPb2;
            itemPbs[8] = sushiTamagoPb;
            itemPbs[9] = sushiTamagoPb2;
            itemPbs[10] = sushiTemakiPb;
            itemPbs[11] = sushiTemakiPb2;

            PW = 128;   // 寿司桶の幅
            PH = 64;    // 寿司桶の高さ
            RR = 64 / 2;  // アイテムの半径
            recorder = new MiniGameParkLib.Recorder();
            MgpMessageBox.SetBackgroundImage(
                Properties.Resources.back_wood_tate);

            initGame();
        }

        //**** 初期化メソッド
        private void initGame()
        {
            for (int i = 0; i < 12; i++)  // アイテムを初期配置
            {
                itemX[i] = rand.Next(15, 420);
                itemY[i] = rand.Next(10, 640) - 640;
                                // 隠れたところからスタート
            }
            score = 0;
            failedCounter = 0;
            recorder.Start();
            timer1.Start();
        }

        //** タイプから画像イメージを求める
        private Image GetImageFromType(ItemType itype)
        {
            Image retVal;
            switch (itype)
            {
                case ItemType.Cake:
                    retVal = Properties.Resources.cake;
                    break;
                case ItemType.Gomi:
                    retVal = Properties.Resources.gomi;
                    break;
                case ItemType.SushiEbi:
                    retVal = Properties.Resources.sushi_ebi;
                    break;
                case ItemType.SushiIkura:
                    retVal = Properties.Resources.sushi_ikura;
                    break;
                case ItemType.SushiSalmon:
                    retVal = Properties.Resources.sushi_sarmon;
                    break;
                case ItemType.SushiTamago:
                    retVal = Properties.Resources.sushi_tamago;
                    break;
                case ItemType.SushiTemaki:
                default:
                    retVal = Properties.Resources.sushi_temaki;
                    break;
            }
            return retVal;
        }

        //***** タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            // まずは背景画像をセット
            gg.DrawImage(backImagePb.Image, new Rectangle(0, 0, 480, 640));

            // オケの移動  -- カーソル位置から現在地を割り出す
            Cpos = PointToClient(Cursor.Position);
            if (Cpos.X < 10)  //左側のはみ出し防止
            {
                Cpos.X = 10;
            }
            if (Cpos.X > Width - PW - 5)  // 右側のはみ出し防止
            {
                Cpos.X = Width - PW - 5;
            }
            if (Cpos.Y < 0)  // 上側のはみ出し防止
            {
                Cpos.Y = 0;
            }
            if (Cpos.Y > Height - PH - 10)  // 下側のはみ出し防止
            {
                Cpos.Y = Height - PH - 10;
            }
            gg.DrawImage(sushiOkePb.Image,
                new Rectangle(Cpos.X, Cpos.Y, PW, PH));

            // アイテムの移動（落下）
            for (int i = 0; i < 12; i++)
            {
                PictureBox pb = itemPbs[i];
                pb.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);  // 90度回転
                
                itemY[i] += 7;  // 落下速度

                gg.DrawImage(pb.Image,
                    new Rectangle(itemX[i], itemY[i], RR * 2, RR * 2));

                // キャッチ判定
                if ( (itemX[i] >= Cpos.X - 5 && itemX[i] <= Cpos.X + PW)
                    && (itemY[i] >= Cpos.Y - PH - 10 && itemY[i] <= Cpos.Y))
                {
                    itemX[i] = rand.Next(15, 420);
                    itemY[i] = rand.Next(10, 640) - 640;

                    if (itemTypes[i] == ItemType.Cake)
                    {
                        sounPlayer2.Play(); 
                        score += 300;
                    }
                    else if (itemTypes[i]== ItemType.Gomi)
                    {
                        Console.Beep(295, 600); 
                        score -= 100;
                    }
                    else
                    {
                        sounPlayer.Play(); 
                        score += 10;
                    }
                }
                else if(itemY[i] > basePb.Height)  // 受け損なった
                {
                    if (itemTypes[i] == ItemType.Gomi) score += 300;
                    else failedCounter++;
                    if (failedCounter >= 3)
                    {
                        timer1.Stop();
                        recorder.Stop((int)score);
                        Console.Beep(295, 300);
                        Console.Beep(295, 600);
                        MgpMessageBox messageBox
                            = new MgpMessageBox(
                                      this,
                                      "たくさん受け損ないましたね.\r\n" +
                                      "もったいないです.\r\n" +
                                      "もう一度トライしますか？", "確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                        DialogResult dr = messageBox.ShowDialog();
                        if (dr != DialogResult.Yes) Close();  // 終了
                        initGame();  // 再ゲーム
                    }
                    itemX[i] = rand.Next(15, 420);
                    itemY[i] = rand.Next(10, 640) - 640;
                }
            }
            
            gg.DrawString("SCORE: " + score.ToString(),
                          myFont, Brushes.White, 20, 30);
            gg.DrawString("FAILED: " + failedCounter.ToString(),
                          myFont, Brushes.White, 20, 60);
            basePb.Image = canvas;
        }

        public Form1()
        {
            InitializeComponent();
        }


    }
}
