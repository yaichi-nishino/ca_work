using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject
{
    // グラフの描画時に、DBから得た値を運ぶために利用する。
    // ラベルに相当する文字列と、それに対する数値が格納される。
    // 例えば、ユーザー名と、ハイスコアや平均プレイ時間など。
    // 数値は、整数の場合もあれば、浮動小数点数のこともある。
    // プレイ回数など、通常は、整数でも、全ユーザーの平均値では、
    // 浮動小数点数になってしまうため、コンストラクタで、
    // どちらの値かを保持しておき、取り出す時に、処理を切り替えている。
    public class GraphData
    {
        // 定数
        public static string PLAY_TIMES_LABEL = "プレイ回数";
        public static string HIGH_SCORE_LABEL = "ハイスコア";
        public static string AVG_SCORE_LABEL = "平均スコア";
        public static string LONGEST_PLAY_TERM_LABEL = "最長プレー時間";
        public static string AVG_PLAY_TERM_LABEL = "平均プレイ時間";
        public static string TOTAL_PLAY_TERM_LABEL = "総プレー時間";
        
        // タイプ（何のためのグラフデータか定義）
        public enum Type
        {
            PlayTimes = 0,
            HighScore,
            AvgScore,
            LongestPlayTerm,
            AvgPlayTerm,
            TotalPlayTerm
        }

        //*****　メンバー変数
        private Type type;          // 用途
        private string label;       // ラベル
        private bool isDoublle;     // 浮動小数点数なら true
        private int intValue;       // 整数値
        private double doubleValue; // 浮動小数点数


        //***** コンストラクタ（整数値用）
        public GraphData(string label, int intValue, Type type)
        {
            this.label = label;
            this.intValue = intValue;
            this.doubleValue = -1.0f;
            this.type = type;
            this.isDoublle = false;
        }


        //***** コンストラクタ（浮動小数点数用）
        public GraphData(string label, double doubleValue, Type type)
        {
            this.label = label;
            this.doubleValue = doubleValue;
            this.intValue = -1;
            this.type = type;
            this.isDoublle = true;
        }

        //***** プロパティ -- ゲッターのみ定義
        public Type GraphType { get { return type; } }
        public string Label { get { return label; } }
        public int IntValue { get { return intValue; } }
        public double DoubleValue { get { return doubleValue; } }
        public bool IsInteger { get { return !isDoublle; } }
        public bool IsDouble { get { return isDoublle; } }

        //***** タイプ変換用スタティックメソッド
        public static Type GetType(string arg)
        {
            Type retVal;
            switch (arg)
            {
                // caseには定数しか指定できないと
                // コンパイルエラーになったので、
                // 無理やりwhenを使った条件指定にしている
                case string s when(s == PLAY_TIMES_LABEL):
                    retVal = Type.PlayTimes;
                    break;
                case string s when (s == HIGH_SCORE_LABEL):
                    retVal = Type.HighScore;
                    break;
                case string s when (s == AVG_SCORE_LABEL):
                    retVal = Type.AvgScore;
                    break;
                case string s when (s == LONGEST_PLAY_TERM_LABEL):
                    retVal = Type.LongestPlayTerm;
                    break;
                case string s when (s == AVG_PLAY_TERM_LABEL):
                    retVal = Type.AvgPlayTerm;
                    break;
                case string s when (s == TOTAL_PLAY_TERM_LABEL):
                    retVal = Type.TotalPlayTerm;
                    break;
                case "":
                default:
                    throw new ApplicationException(
                                  "不明なタイプです（内部エラー）");
            }
            return retVal;
        }

        //***** タイプ変換用スタティックメソッド
        public static string GetTypeString(Type arg)
        {
            string retVal;
            switch (arg)
            {
                case Type.PlayTimes:
                    retVal = PLAY_TIMES_LABEL;
                    break;
                case Type.HighScore:
                    retVal = HIGH_SCORE_LABEL;
                    break;
                case Type.AvgScore:
                    retVal = AVG_SCORE_LABEL;
                    break;
                case Type.LongestPlayTerm:
                    retVal = LONGEST_PLAY_TERM_LABEL;
                    break;
                case Type.AvgPlayTerm:
                    retVal = AVG_PLAY_TERM_LABEL;
                    break;
                case Type.TotalPlayTerm:
                    retVal = TOTAL_PLAY_TERM_LABEL;
                    break;
                default:
                    throw new ApplicationException(
                                  "不明なタイプです（内部エラー）");
            }
            return retVal;
        }

        //***** 値が平均値かどうか調べる -- 平均値のみ小数点数だから
        public static bool IsAvalageType(Type type)
        {
            if (type == Type.AvgScore
                || type == Type.AvgPlayTerm) return true;
            return false;
        }
    }
}
