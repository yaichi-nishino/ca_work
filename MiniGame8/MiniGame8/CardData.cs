using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MiniGame8
{
    //***** 番号付きのカードデータ
    class CardData
    {
        // メンバー変数
        private int number;
        private Image image;

        private static Random rand = null;

        // コンストラクタ
        private CardData(int number, Image image)
        {
            this.number = number;
            this.image = image;
        }
        // コピーコンストラクタ
        private CardData(CardData data)
        {
            this.number = data.Number;
            this.image = data.Image;
        }
        // ダミーのコンストラクタ
        private CardData()
        {
            this.number = -1;
            this.image = null;
        }

        // プロパティ
        public int Number
        {
            get
            {
                return number;
            }
        }
        public Image Image
        {
            get
            {
                return image;
            }
        }

        //***** 渡された画像の配列から、
        //      ランダムな番号を割り当てたカードを作成、
        //      まず、リストを作る。
        //      返す前に、リストの順番をシャッフルさせる。
        public static CardData[] CreateNewCardList(Image[] images)
        {
            CardData[] retVal = new CardData[images.Length];
            int[] order = CreateRandomArray(images.Length);
            for (int i = 0; i < order.Length; i++)
            {
                retVal[i] = new CardData(order[i], images[i]);  // ランダム番号づけ
            }
            return ShuffleCardList(retVal);  // さらにシャッフル
        }

        //***** 渡されたリストの中身をシャッフルする
        //      新しく作成されたリストを返す
        public static CardData[] ShuffleCardList(CardData[] oldList)
        {
            int[] order = CreateRandomArray(oldList.Length);
            CardData[] retVal = new CardData[oldList.Length];
            for (int i = 0; i < order.Length; i++)
            {
                retVal[order[i]] = new CardData(oldList[i]);
            }
            return retVal;
        }

        // ランダムな配列の作成
        //    0から指定された番号までの数字を
        //    ランダムに並べた配列を返す
        private static int[] CreateRandomArray(int num)
        {
            if (rand == null) rand = new Random();
            int[] retVal = new int[num];
            for (int i = 0; i < num; i++)
            {
                retVal[i] = -1;  // 初期化
            }
            int pos;
            for (int i = 0; i < num; i++)
            {
                pos = rand.Next(num);
                if (retVal[pos] == -1) retVal[pos] = i;
                else i--; // やりなおし
            }
            return retVal;
        }
    }
}
