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

namespace MiniGame8
{
    public partial class Form1 : Form
    {
        //** 表示メッセージ  -- 使っていない
        private readonly static string[] sequencialMsg =
        {
            "START ボタンを押して\r\n"       // 0  
                + "ゲーム開始！\r\n"
                + "\r\n"
                + "まず記憶タイム\r\n"
                + "制限時間内にカードの\r\n"
                + "絵柄と番号を記憶！\r\n"
                + "\r\n"
                + "次に、回答タイム\r\n"
                + "記憶力を頼りに、カードを\r\n"
                + "番号順にクリックしてね♪\r\n",

            "ゲーム開始です\r\n",            // 1
            "記憶タイム終了まで\r\n"         // 2
                + "あと 10 秒です",
            "あと 9 秒です\r\n",             // 3
            "あと 8 秒です\r\n",             // 4
            "あと 7 秒です\r\n",             // 5
            "あと 6 秒です\r\n",             // 6
            "あと 5 秒\r\n",                 // 7
            "あと 4 秒\r\n",                 // 8
            "3 秒\r\n",                      // 9
            "2 秒\r\n",                      // 10
            "1 秒\r\n",                      // 11
            "タイムアップ！\r\n",            // 12
            "番号順にカードをクリック\r\n",  // 13
        };

        //** カードの背の模様
        private static readonly Image cardBackImage = Properties.Resources.sun_rbow;

        //** カードの表の画像
        private static readonly Image[] cardImages =
        {
            Properties.Resources.card_aquerius,
            Properties.Resources.card_gemini,
            Properties.Resources.card_goat,
            Properties.Resources.card_pisces,
            Properties.Resources.card_scorpion,
            Properties.Resources.card_virgo,
        };

        // インスタンス変数
        private int msgCnt = 0;  // メッセージカウンター
        private CardData[] cardList;
        private int currentAnsNum = 0;  // 何番目の回答をしているか
        private int[] answer = null;  // ユーザーがクリックした順番を保持
        private int score = 0;
        private MiniGameParkLib.Recorder recorder;
        private SoundPlayer playerClick;
        private SoundPlayer playerClear;


        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            recorder = new MiniGameParkLib.Recorder();
            playerClear = new SoundPlayer();
            playerClear.Stream = Properties.Resources.Find;
            playerClick = new SoundPlayer();
            playerClick.Stream = Properties.Resources.Card;
            
            InitGame();
            this.lbMessage.Text = "START で開始";
        }


        // ゲーム情報の初期化
        private void InitGame()
        {
            msgCnt = 0;
            this.lbMessage.Text = "";     // 最初は何も表示しない
            this.btStart.Enabled = true;  // スタートボタンのみ有効
            this.btStart.Image = Properties.Resources.bt_start;

            this.pbNum0.Enabled = false;
            this.pbNum1.Enabled = false;
            this.pbNum2.Enabled = false;
            this.pbNum3.Enabled = false;
            this.pbNum4.Enabled = false;
            this.pbNum5.Enabled = false;
            this.pbNum0.Image = cardBackImage;
            this.pbNum1.Image = cardBackImage;
            this.pbNum2.Image = cardBackImage;
            this.pbNum3.Image = cardBackImage;
            this.pbNum4.Image = cardBackImage;
            this.pbNum5.Image = cardBackImage;

            this.lbNum0.Text = "番号";
            this.lbNum1.Text = "番号";
            this.lbNum2.Text = "番号";
            this.lbNum3.Text = "番号";
            this.lbNum4.Text = "番号";
            this.lbNum5.Text = "番号";

            cardList = null;
            //score = 0; -- カードが少なく、低得点になるので、累計にしてみた
        }


        //***** スタートボタンがクリックされた
        private void btStart_Click(object sender, EventArgs e)
        {
            // リスタート時のことも考え、状態を初期化
            InitGame();
            recorder.Start();

            // カードをシャッフル
            cardList = CardData.CreateNewCardList(cardImages);
            bool withNumber = true;
            DrawCardList(withNumber);

            this.btStart.Enabled = false;  // スタートボタン無効
            this.btStart.Image = Properties.Resources.bt_playing;
            this.lbMessage.Text = "記憶タイム";
            memTimer.Start();
        }

        //** カードリストの表示 -- 記憶タイム開始時 + 回答タイム開始時
        private void DrawCardList(bool withNumber)
        {
            this.pbNum0.Image = cardList[0].Image;
            if (withNumber) 
                this.lbNum0.Text = (cardList[0].Number + 1).ToString() + "番";
            else this.lbNum0.Text = "番号";

            this.pbNum1.Image = cardList[1].Image;
            if (withNumber)
                this.lbNum1.Text = (cardList[1].Number + 1).ToString() + "番";
            else this.lbNum1.Text = "番号";

            this.pbNum2.Image = cardList[2].Image;
            if (withNumber)
                this.lbNum2.Text = (cardList[2].Number + 1).ToString() + "番";
            else this.lbNum2.Text = "番号";

            this.pbNum3.Image = cardList[3].Image;
            if (withNumber)
                this.lbNum3.Text = (cardList[3].Number + 1).ToString() + "番";
            else this.lbNum3.Text = "番号";

            this.pbNum4.Image = cardList[4].Image;
            if (withNumber)
                this.lbNum4.Text = (cardList[4].Number + 1).ToString() + "番";
            else this.lbNum4.Text = "番号";

            this.pbNum5.Image = cardList[5].Image;
            if (withNumber)
                this.lbNum5.Text = (cardList[5].Number + 1).ToString() + "番";
            else this.lbNum5.Text = "番号";

            Invalidate();
        }


        //** 回答準備 -- 記憶タイム終了後に呼ばれる
        private void InitAnswer()
        {
            currentAnsNum = 0;  // 何番目の回答をしているか
            answer = new int[cardImages.Length];
            for (int i= 0; i < answer.Length; i++)
            {
                answer[i] = -1;  // 念のため初期化
            }
            this.lbMessage.Text = "回答タイム";

            this.pbNum0.Enabled = true;
            this.pbNum1.Enabled = true;
            this.pbNum2.Enabled = true;
            this.pbNum3.Enabled = true;
            this.pbNum4.Enabled = true;
            this.pbNum5.Enabled = true;
 
            this.lbNum0.Text = "未選択";
            this.lbNum1.Text = "未選択";
            this.lbNum2.Text = "未選択";
            this.lbNum3.Text = "未選択";
            this.lbNum4.Text = "未選択";
            this.lbNum5.Text = "未選択";

            this.lbMessage.Text = "番号順にクリック！";
        }


        //***** 回答 -- 位置0のカード
        private void pbNum0_Click(object sender, EventArgs e)
        {
            PbClickInternal(0, lbNum0, pbNum0);
        }

        //***** 回答 -- 位置1のカード
        private void pbNum1_Click(object sender, EventArgs e)
        {
            PbClickInternal(1, lbNum1, pbNum1);
        }

        //***** 回答 -- 位置2のカード
        private void pbNum2_Click(object sender, EventArgs e)
        {
            PbClickInternal(2, lbNum2, pbNum2);
        }

        //***** 回答 -- 位置3のカード
        private void pbNum3_Click(object sender, EventArgs e)
        {
            PbClickInternal(3, lbNum3, pbNum3);
        }

        //***** 回答 -- 位置4のカード
        private void pbNum4_Click(object sender, EventArgs e)
        {
            PbClickInternal(4, lbNum4, pbNum4);
        }

        //***** 回答 -- 位置5のカード
        private void pbNum5_Click(object sender, EventArgs e)
        {
            PbClickInternal(5, lbNum5, pbNum5);
        }

        //** 各ピクチャーボックスがクリックされた時、
        //   共通に利用される内部メソッド。
        private void PbClickInternal(int n, Label lb, PictureBox pb)
        {
            playerClick.Play();
            int tmpI = currentAnsNum + 1;
            lb.Text = tmpI.ToString() + "番";
            answer[n] = currentAnsNum;  // 何番目に押されたボタンか
            pb.Enabled = false;

            // 終了チェック
            CheckAnswerAndShowResult();  // currentAnsNumはこの中で更新される
        }


        //** 終了チェック
        private void CheckAnswerAndShowResult()
        {
            // 回答が済んでいるかチェック
            if (answer.All(i => i != -1))
            {
                bool failed = false;  // 一つでも間違っていたら失敗
                if (!CheckAnsInternal(0, lbNum0, pbNum0)) failed = true;
                if (!CheckAnsInternal(1, lbNum1, pbNum1)) failed = true;
                if (!CheckAnsInternal(2, lbNum2, pbNum2)) failed = true;
                if (!CheckAnsInternal(3, lbNum3, pbNum3)) failed = true;
                if (!CheckAnsInternal(4, lbNum4, pbNum4)) failed = true;
                if (!CheckAnsInternal(5, lbNum5, pbNum5)) failed = true;
                Invalidate();

                // 結果表示
                if (failed)
                {
                    Console.Beep(295, 300);
                    Console.Beep(295, 600);
                    lbMessage.Text = "残念...";
                    pbCount.Image = Properties.Resources.peke;
                }
                else
                {
                    playerClear.Play();
                    lbMessage.Text = "お見事！";
                    score += 500;
                    pbCount.Image = Properties.Resources.maru;
                }
                recorder.Stop(score);

                this.btStart.Enabled = true;
                this.btStart.Image = Properties.Resources.bt_start;
                    // 結果の表示は、そのままにして、スタートボタンを有効に
            }
            else // 未回答のカードが残っている
            {
                currentAnsNum++;  // 次の番号のカード選択へ
            }
        }


        //** 答え合わせで呼ばれる内部メソッド
        //   各カードのチェックで共通利用される
        private bool CheckAnsInternal(int n, Label lb, PictureBox pb)
        {
            bool ok;
            if (answer[n] == cardList[n].Number)
            {
                // 正解
                lb.Text += " ○";
                score += 100;
                ok = true;
            }
            else
            {
                // 不正解
                lb.Text += " ×";
                ok = false;
                pb.Image = cardBackImage;
            }
            lb.Refresh();
            pb.Refresh();
              // 6番目のクリックで、番号の表示が変わらないことがあったため、
              // 無理やり、リフレッシュしている。気持ち悪いけど、対処療法。
            return ok;
        }


        //***** 記憶タイムで使われるタイマー
        private void memTimer_Tick(object sender, EventArgs e)
        {
            msgCnt++;
            if (msgCnt <= 10) {
                switch(msgCnt)
                {
                    case 1:
                        pbCount.Image = Properties.Resources.num9;
                        break;
                    case 2:
                        pbCount.Image = Properties.Resources.num8;
                        break;
                    case 3:
                        pbCount.Image = Properties.Resources.num7;
                        break;
                    case 4:
                        pbCount.Image = Properties.Resources.num6;
                        break;
                    case 5:
                        pbCount.Image = Properties.Resources.num5;
                        break;
                    case 6:
                        pbCount.Image = Properties.Resources.num4;
                        break;
                    case 7:
                        pbCount.Image = Properties.Resources.num3;
                        break;
                    case 8:
                        pbCount.Image = Properties.Resources.num2;
                        break;
                    case 9:
                        pbCount.Image = Properties.Resources.num1;
                        break;
                    case 10:
                        pbCount.Image = Properties.Resources.num0;
                        break;
                }
            }
            else
            {
                // タイムアップ -- タイマーを停止、回答開始
                memTimer.Stop();

                this.cardList = CardData.ShuffleCardList(cardList);
                bool withNum = false;
                DrawCardList(withNum);

                InitAnswer();
            }
        }
    }
}
