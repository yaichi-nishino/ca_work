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

namespace MiniGame3
{
    public partial class Form1 : Form
    {
        //***** メンバー変数
        CardStatus[] statList;  // 各位置のカードの状態を保持
        CardType[] typeList;    // 各位置のカードのタイプを保持
        int score;
        int numOfMiss;          // ミスした回数
        int numOfCards = 8;     // カードの枚数
        Random rand;
        Recorder recorder;
        SoundPlayer soundPlayerMatched;
        SoundPlayer soundPlayerClick;

        enum CardStatus
        {
            Back,           // 裏
            Face,           // 表（ペアになっているか不明）
            FaceMatched     // 表（ペアになっている）
        }
        enum CardType
        { 
            None,           // 未定
            Hana,           // 花
            Lion,           // ライオン
            Usa,            // うさぎ
            Sakana          // 魚
        }

        //***** コンストラクタ
        public Form1()
        {
            InitializeComponent();
            numOfMiss = 0;
            score = 0;
            statList = new CardStatus[numOfCards];
            typeList = new CardType[numOfCards];

            MgpMessageBox.SetBackgroundImage(
                Properties.Resources.back_sky);
            rand = new Random();
            recorder = new Recorder();
            soundPlayerMatched = new SoundPlayer();
            soundPlayerClick = new SoundPlayer();
            soundPlayerMatched.Stream = Properties.Resources.Find;  // 見つけた音
            soundPlayerClick.Stream = Properties.Resources.Card;  // クリック音

            recorder.Start();
            InitializeGame();
        }

        //*** ゲームの初期化
        //    カードのシャッフルも、ここで行われる
        private void InitializeGame()
        {
            for (int i = 0; i < numOfCards; i++)
            {
                statList[i] = CardStatus.Back;
                typeList[i] = CardType.None;
            }
            cardPb1.Image = Properties.Resources.sun_rbow;
            cardPb2.Image = Properties.Resources.sun_rbow;
            cardPb3.Image = Properties.Resources.sun_rbow;
            cardPb4.Image = Properties.Resources.sun_rbow;
            cardPb5.Image = Properties.Resources.sun_rbow;
            cardPb6.Image = Properties.Resources.sun_rbow;
            cardPb7.Image = Properties.Resources.sun_rbow;
            cardPb8.Image = Properties.Resources.sun_rbow;

            SetTwoCardTypeAtRandom(CardType.Hana);
            SetTwoCardTypeAtRandom(CardType.Sakana);
            SetTwoCardTypeAtRandom(CardType.Lion);
            SetTwoCardTypeAtRandom(CardType.Usa);

            EnableAllCardClick();
            this.numOfMiss = 0;  // ミス回数クリア
        }

        ////** カードをクリックできなくする
        //private void DisableAllCardClick()
        //{
        //    cardPb1.Enabled = false;
        //    cardPb2.Enabled = false;
        //    cardPb3.Enabled = false;
        //    cardPb4.Enabled = false;
        //    cardPb5.Enabled = false;
        //    cardPb6.Enabled = false;
        //    cardPb7.Enabled = false;
        //    cardPb8.Enabled = false;
        //}

        //** カードをクリックできるようにする
        private void EnableAllCardClick()
        {
            cardPb1.Enabled = true;
            cardPb2.Enabled = true;
            cardPb3.Enabled = true;
            cardPb4.Enabled = true;
            cardPb5.Enabled = true;
            cardPb6.Enabled = true;
            cardPb7.Enabled = true;
            cardPb8.Enabled = true;
        }

        //** 指定されたタイプで２箇所を埋める
        private void SetTwoCardTypeAtRandom(CardType t)
        {
            bool found = false;
            while (true)
            {
                int p = rand.Next(8);
                if (typeList[p] == CardType.None)
                {
                    typeList[p] = t;
                    if (found) break;
                    else found = true;
                }
            }
        }

        //***** カードがクリックされた
        private void cardPb1_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 0;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb2_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 1;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb3_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 2;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb4_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 3;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb5_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 4;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb6_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 5;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb7_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 6;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //***** カードがクリックされた
        private void cardPb8_Click(object sender, EventArgs e)
        {
            soundPlayerClick.Play();
            int myNum = 7;
            FaceUpOneCard(myNum);
            CheckFinishOrNot(myNum);
        }

        //** 終了判定
        private void CheckFinishOrNot(int myNum)
        {
            if (statList[myNum] == CardStatus.FaceMatched)
            {
                // 終了判定
                bool finished = true;
                foreach (CardStatus s in statList)
                {
                    if (s == CardStatus.Back)
                    {
                        finished = false;
                        break;
                    }
                }
                if (finished)
                {
                    soundPlayerMatched.Play();
                    //await SleepAsync(1000);
                    Task.Delay(1000).Wait();
                    score += 1000;
                    DisplayCards();
                    InitializeGame();
                }
            }
        }

        //async Task SleepAsync(int milliseconds)
        //{
        //    await Task.Delay(milliseconds);
        //}


        //*** ひっくり返したカードの判定
        private void FaceUpOneCard(int myNum)
        //async private void FaceUpOneCard(int myNum)
        {
            int faceUpCardPosition = -1;  // 既に表のカードがあるか？
            for (int i = 0; i < numOfCards; i++)
            {
                if (statList[i] == CardStatus.Face)
                {
                    faceUpCardPosition = i;
                    break;
                }
            }

            // まず、カードを返した状態を表示する
            statList[myNum] = CardStatus.Face;
            DisplayCards();

            // ペアのない表向きカードがあるかどうかで切り替え
            CardType myType = typeList[myNum];
            if (faceUpCardPosition >= 0)
            {  // 表のカードあり
                if (myType == typeList[faceUpCardPosition])
                {
                    // 同じ絵柄のものがきた
                    statList[faceUpCardPosition] = CardStatus.FaceMatched;
                    statList[myNum] = CardStatus.FaceMatched;
                    score += 200;
                }
                else
                {
                    // 別のものを引いてしまった
                    statList[faceUpCardPosition] = CardStatus.Back;
                    statList[myNum] = CardStatus.Back;
                    numOfMiss++;
                    if (numOfMiss > 2)
                    {
                        // ミス三回目
                        recorder.Stop(score);
                        Console.Beep(295, 300);
                        Console.Beep(295, 600);
                        MgpMessageBox messageBox
                            = new MgpMessageBox(
                                      this,
                                      "ミスが3回になりました.\r\n" +
                                      "もう一度プレイしますか？",
                                      "確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                        DialogResult dr = messageBox.ShowDialog();
                        if (dr == DialogResult.Yes)
                        {
                            score = 0;
                            numOfMiss = 0;
                            recorder.Start();
                            InitializeGame();
                        }
                        else
                        {
                            this.Close();  // 終了
                        }
                    }
                    else
                    {
                        Console.Beep(295, 600);
                        Task.Delay(1800).Wait();  // ミスしたことがわかるよう停止
                        //await SleepAsync(2000);
                    }
                }
            }
            else // 表のカードなし
            {
                // 一枚目のカード
                statList[myNum] = CardStatus.Face;
            }
            DisplayCards();
        }


        //*** 状態の値に従ってイメージを切り替える
        private void DisplayCards() 
        {
            for (int i = 0; i < numOfCards; i++)
            {
                PictureBox pb = getPb(i);
                switch(statList[i])
                {
                    case CardStatus.Back:
                        pb.Image = Properties.Resources.sun_rbow;
                        pb.Enabled = true;
                        break;
                    case CardStatus.Face:
                        pb.Image = getImage(typeList[i]);
                        pb.Enabled = false;
                        break;
                    case CardStatus.FaceMatched:
                        pb.Image = getImage(typeList[i]);
                        pb.Enabled = false;
                        break;
                }
                pb.Refresh();
            }
            scoreLb.Text = score.ToString();
        }

        //** 位置に対応したカード用のピクチャボックスを返す
        private PictureBox getPb(int pos)
        {
            switch (pos)
            {
                case 0:
                    return cardPb1;
                case 1:
                    return cardPb2;
                case 2:
                    return cardPb3;
                case 3:
                    return cardPb4;
                case 4:
                    return cardPb5;
                case 5:
                    return cardPb6;
                case 6:
                    return cardPb7;
                case 7:
                    return cardPb8;
                default:
                    return null;
            }
        }

        //** タイプに応じて表示するイメージを返す
        private Image getImage(CardType type)
        {
            switch (type)
            {
                case CardType.Hana:
                    return Properties.Resources.card_hana;
                case CardType.Lion:
                    return Properties.Resources.card_lion;
                case CardType.Sakana:
                    return Properties.Resources.card_sakana;
                case CardType.Usa:
                    return Properties.Resources.card_usa;
                default:
                    return null;
            }
        }

        ////***** リスタートボタンが押された
        //private void restartBt_Click(object sender, EventArgs e)
        //{
        //    score = 0;
        //    numOfMiss = 0;
        //    InitializeGame();
        //}
    }
}
