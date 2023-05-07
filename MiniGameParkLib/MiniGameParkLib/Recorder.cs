using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniGameParkLib
{
    public class Recorder
    {
        //***** 定数
        static readonly int MAX_SCORE = 9999;
        static readonly string CSV_FILE_NAME = "mgpark.csv";

        //***** メンバーデータ
        string gameName;        // ゲーム名
        string userName;        // ユーザー名
        string startTime;       // スタート時間
        bool starting;          // 計測中ならtrue

        //***** コンストラクタ
        public Recorder()
        {
            string[] args = Environment.GetCommandLineArgs();
            // args[0]はコマンド = 実行ファイル名
            if (args != null && args.Length > 2)
            {
                gameName = args[1];
                userName = args[2];
            }
            else
            {
                gameName = "";
                userName = "";
            }
            starting = false;
        }

        //***** 利用開始 開始時刻セット
        public void Start()
        {
            startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            starting = true;
        }

        //***** 利用停止 終了時刻セット・CSVへ記録
        public void Stop(int score)
        {
            if (!starting) return;  // 開始前・停止後に呼ばれた
            if (gameName == "" || userName == "") return;  // 引数で必要な情報が渡ってきていない
            if (score > MAX_SCORE) score = MAX_SCORE;  // 最大値を制限

            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool append = true;
            using (StreamWriter file
                    = new StreamWriter(CSV_FILE_NAME, append))
            {
                string line = gameName;
                line += ",";
                line += userName;
                line += ",";
                line += startTime;
                line += ",";
                line += endTime;
                line += ",";
                line += score;
                file.WriteLine(line);
                file.Flush();
            }
            
            starting = false;  // 計測中じゃない = 停止中
            startTime = null;  // 誤動作防止のため
            //gameName = ""; -- 次のスタートに備えて、そのまま保持
            //userName = ""; -- 次のスタートに備えて、そのまま保持
        }
    }
}
