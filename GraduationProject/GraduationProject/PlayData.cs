using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject
{
    // プレイデータの情報を保持するクラス
    //    ゲームとユーザーの名前を参照する必要があるので、
    //    このクラスではゲームとユーザーテーブルの定義も
    //    知っているものとして、実装している。
    //    検索用のビューに関するSQLも、このクラスで扱う。
    class PlayData
    {
        //**** 定数
        public static readonly string CSV_FILE_NAME = "mgpark.csv";
        public static readonly string DLL_FILE_NAME = "MiniGameParkLib.dll";

        //*****　メンバー変数
        private string gameName;        // ゲーム名
        private string userName;        // ユーザー名
        private DateTime startTime;     // プレイ開始時間
        private DateTime endTime;       // プレイ終了時間
        private int score;              // スコア


        //***** コンストラクタ
        //      ユーザー名とゲーム名は、DBに登録されたデータを
        //      元にしているので、エラーチェックはしていない
        public PlayData(string gameName, string userName,
                   DateTime startTime, DateTime endTime, int score)
        {
            this.gameName = gameName;
            this.userName = userName;
            this.startTime = startTime;
            this.endTime = endTime;
            this.score = score;
        }

        //***** プロパティ -- ゲッターのみ定義
        public string GameName { get { return gameName; } }
        public string UserName { get { return userName; } }
        public DateTime StartTime { get { return startTime; } }
        public DateTime EndTime { get { return endTime; } }
        public int Score { get { return score; } }


        //***** テーブル作成用のSQL生成
        public static string ComposeCreateTableSql()
        {
            string sql = "CREATE TABLE mgpdata_table ";
            sql += " (";
            sql += "gameId INTEGER,";
            sql += "userId INTEGER,";
            sql += "startTime DATE CHECK( startTime like '____-__-__ __:__:__'),";
            sql += "endTime DATE CHECK( endTime like '____-__-__ __:__:__'),";
            sql += "score INTEGER ";
            sql += ");";
            return sql;
        }

        //***** ビュー作成用のSQL生成
        public static string ComposeCreateViewSql()
        {
            string sql = "CREATE VIEW mgpdata_view";
            sql += " (gameName, userName, startTime, endTime, score) ";
            sql += "AS SELECT ";
            sql += "mgame_table.gameName,";
            sql += "mguser_table.userName,";
            sql += "mgpdata_table.startTime,";
            sql += "mgpdata_table.endTime,";
            sql += "mgpdata_table.score ";
            sql += "FROM mgpdata_table ";
            sql += "INNER JOIN mgame_table, mguser_table ";
            sql += "ON mgame_table.id = mgpdata_table.gameId ";
            sql += "AND mguser_table.id = mgpdata_table.userId;";
            return sql;
        }

        //***** データ登録用のSQL生成
        public static string ComposeInsertSql(PlayData data)
        {
            // IDを呼び出し側で求めてから追加する方式
            // こちらの方が、多分、早いけど、
            // SQLの機能を試すため、副問い合わせを使う方法に変更
            //string sql = "INSERT INTO mgpdata_table ";
            //sql += "(gameId,userId,startTime,endTime,score) VALUES(";
            //sql += data.GameId;
            //sql += ",";
            //sql += data.UserId;
            //sql += ",'";
            //sql += data.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            //sql += "','";
            //sql += data.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            //sql += "',";
            //sql += data.Score;
            //sql += ");";
            //return sql;

            string sql = "INSERT INTO mgpdata_table ";
            sql += " (gameId,userId,startTime,endTime,score) ";
            sql += "SELECT ";
                sql += "(SELECT id FROM mgame_table WHERE gameName='";
                sql += data.gameName;
                sql += "') AS gameId,";
                sql += "(SELECT id FROM mguser_table WHERE userName='";
                sql += data.userName;
                sql += "') AS userId,'";
                sql += data.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                sql += "' AS startTime,'";
                sql += data.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                sql += "' AS endTime,";
                sql += data.Score;
                sql += " AS score;";
            return sql;
        }

        //***** データ登録用のSQL生成 -- IDを指定するパターン
        //      福問い合わせの方法が遅すぎるので、IDを指定する方法を復活
        public static string ComposeInsertSqlById(
                                 PlayData data,
                                 List<MiniGame> games,
                                 List<User> users)
        {
            int gameId = games.Find(g => g.GameName == data.GameName).Id;
            int userId = users.Find(u => u.UserName == data.UserName).Id;
            
            string sql = "INSERT INTO  mgpdata_table ";
            sql += " (gameId,userId,startTime,endTime,score) VALUES(";
            sql += gameId;
            sql += ",";
            sql += userId;
            sql += ",'";
            sql += data.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            sql += "','";
            sql += data.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            sql += "',";
            sql += data.Score;
            sql += ");";
            return sql;
        }
            

        //***** データ削除用のSQL生成
            public static string ComposeDeleteSql(int gameId)
        {
            string sql = "DELETE FROM mgpdata_table ";
            sql += "WHERE gameId=";
            sql += gameId;
            sql += ";";
            return sql;
        }

        //***** 指定されたゲームのプレイデータ数を返すSQL生成
        public static string ComposeCountSql(int gameId)
        {
            string sql = "SELECT count(*) FROM mgpdata_table ";
            sql += "WHERE gameId=";
            sql += gameId;
            sql += ";";
            return sql;
        }

        //***** 指定されたプレイデータを返すSQL文の生成
        public static string ComposeSelectSql(DateTime startDate,
                                 DateTime endDate,
                                 List<MiniGame> games,
                                 string userName,
                                 double minPtCond, double maxPtCond,
                                 double minScCond, double maxScCond)
        {
            string st = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ed = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            string gcond = " (";
            bool isFirst = true;
            foreach(MiniGame g in games)
            {
                if (isFirst) isFirst = false;
                else gcond += " OR ";
                gcond += "gameName = '";
                gcond += g.GameName;
                gcond += "'";
            }
            gcond += ") ";

            string minMaxCond = ComposeMinMaxSelectCond(
                                    minPtCond, maxPtCond, 
                                    minScCond, maxScCond);

            string sql = "SELECT gameName,userName,";
            sql += "strftime('%Y-%m-%d %H:%M',startTime) AS playDate,";
            sql += "(strftime('%s', endTime) - strftime('%s', startTime)) AS playTerm,";
            sql += "score FROM mgpdata_view WHERE startTime >= '";
            sql += st;
            sql += "' AND endTime < '";
            sql += ed;
            sql += "' AND ";
            sql += gcond;
            if (userName != null && userName != "")
            {
                sql += "AND userName LIKE '%";
                sql += userName;
                sql += "%'";
            }
            if (minMaxCond != null)
            {
                sql += " AND " + minMaxCond;
            }
            sql += ";";
            return sql;
        }

        //** 値（playTerm・score）について、最小と最大値の条件を作成する
        private static string ComposeMinMaxSelectCond(
                                  double minPtCond, double maxPtCond,
                                  double minScCond, double maxScCond)
        {
            if ( Double.IsNaN(minPtCond) 
                 && Double.IsNaN(maxPtCond)
                 && Double.IsNaN(minScCond)
                 && Double.IsNaN(maxScCond) ) return null;

            string sql = "";
            bool hasPrevious = false;
            if (!Double.IsNaN(minPtCond))
            {
                sql += "playTerm >= ";
                sql += minPtCond.ToString();
                hasPrevious = true;
            }
            if (!Double.IsNaN(maxPtCond))
            {
                if (hasPrevious) sql += " AND ";
                sql += "playTerm <=";
                sql += maxPtCond.ToString();
                hasPrevious = true;
            }
            if (!Double.IsNaN(minScCond))
            {
                if (hasPrevious) sql += " AND ";
                sql += "score >=";
                sql += minScCond.ToString();
                hasPrevious = true;
            }
            if (!Double.IsNaN(maxScCond))
            {
                if (hasPrevious) sql += " AND ";
                sql += "score <=";
                sql += maxScCond.ToString();
                hasPrevious = true;
            }
            sql += " ";
            return sql;
        }


        //***** グラフ表示用の集約SQLの生成（トップＮ人）
        //          指定されたゲームについて、
        //          ユーザーでグルーピング、トップＮ人のデータを返す
        public static string ComposeAggregateSql(GraphData.Type gtype,
                                 DateTime startDate, DateTime endDate,
                                 string gameName, int maxUserNum,
                                 double minCond, bool includeMin,
                                 double maxCond, bool includeMax)
        {
            string st = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ed = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "SELECT userName,";
            switch (gtype)
            {
                case GraphData.Type.PlayTimes:
                    sql += "COUNT(*) AS value ";
                    break;
                case GraphData.Type.HighScore:
                    sql += "MAX(score) AS value ";
                    break;
                case GraphData.Type.AvgScore:
                    sql += "AVG(score) AS value ";
                    break;
                case GraphData.Type.LongestPlayTerm:
                    sql += "MAX(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.AvgPlayTerm:
                    sql += "AVG(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.TotalPlayTerm:
                    sql += "SUM(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                default:
                    throw new ApplicationException(
                                  "不明なタイプです（内部エラー）");
            }
            sql += "FROM mgpdata_view WHERE ";
            if (gameName != null && gameName != "")
            {
                sql += "gameName='";
                sql += gameName;
                sql += "' AND ";
            }
            sql += "startTime >= '";
            sql += st;
            sql += "' AND endTime < '";
            sql += ed;
            sql += "' GROUP BY userName ";
            string minMaxCond = ComposeMinMaxHavingCond( 
                                    minCond, includeMin, 
                                    maxCond, includeMax);
            if (minMaxCond != null)
            {
                sql += minMaxCond;  // HAVING で条件指定
            }
            sql += "ORDER BY value DESC ";
            sql += "LIMIT " + maxUserNum;
            sql += ";";
            return sql;
        }

        //** 値（value）について、最小と最大値の条件を作成する
        private static string ComposeMinMaxHavingCond(
                           double minCond, bool includeMin,
                           double maxCond, bool includeMax)
        {
            if (Double.IsNaN(minCond) && Double.IsNaN(maxCond)) return null;

            string sql = "HAVING ";
            if (!Double.IsNaN(minCond))
            {
                sql += "value >";
                if (includeMin) sql += "=";
                sql += minCond.ToString();
                if (!Double.IsNaN(maxCond)) sql += " AND ";
            }
            if (!Double.IsNaN(maxCond))
            {
                sql += "value <";
                if (includeMax) sql += "=";
                sql += maxCond.ToString();
            }
            sql += " ";
            return sql;
        }

        //***** グラフ表示用の集約SQLの生成
        //          指定されたゲームについて、
        //          ユーザー別に集計した結果を返す
        public static string ComposeAggregateSql(GraphData.Type gtype,
                                 DateTime startDate, DateTime endDate,
                                 string gameName,
                                 double minCond, bool includeMin,
                                 double maxCond, bool includeMax)
        {
            string st = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ed = endDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            string sql = "SELECT ";
            switch (gtype)
            {
                case GraphData.Type.PlayTimes:
                    sql += "COUNT(*) AS value ";
                    break;
                case GraphData.Type.HighScore:
                    sql += "MAX(score) AS value ";
                    break;
                case GraphData.Type.AvgScore:
                    sql += "AVG(score) AS value ";
                    break;
                case GraphData.Type.LongestPlayTerm:
                    sql += "MAX(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.AvgPlayTerm:
                    sql += "AVG(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.TotalPlayTerm:
                    sql += "SUM(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                default:
                    throw new ApplicationException(
                                  "不明なタイプです（内部エラー）");
            }
            sql += "FROM mgpdata_view WHERE ";
            if (gameName != null && gameName != "")
            {
                sql += "gameName='";
                sql += gameName;
                sql += "' AND ";
            }
            sql += "startTime >= '";
            sql += st;
            sql += "' AND endTime < '";
            sql += ed;
            sql += "' GROUP BY userName ";
            string minMaxCond = ComposeMinMaxHavingCond(
                                    minCond, includeMin,
                                    maxCond, includeMax);
            if (minMaxCond != null)
            {
                sql += minMaxCond;  // HAVING で条件指定
            }
            sql += "ORDER BY value DESC;";
            return sql;
        }


        //***** グラフ表示用の集約SQLの生成
        //          ゲーム別に集計した結果を返す
        public static string ComposeAggregateSql(GraphData.Type gtype,
                                 DateTime startDate, DateTime endDate)
        {
            string st = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ed = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "SELECT gameName,";
            switch (gtype)
            {
                case GraphData.Type.PlayTimes:
                    sql += "COUNT(*) AS value ";
                    break;
                case GraphData.Type.HighScore:
                    sql += "MAX(score) AS value ";
                    break;
                case GraphData.Type.AvgScore:
                    sql += "AVG(score) AS value ";
                    break;
                case GraphData.Type.LongestPlayTerm:
                    sql += "MAX(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.AvgPlayTerm:
                    sql += "AVG(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                case GraphData.Type.TotalPlayTerm:
                    sql += "SUM(strftime('%s',endTime)-strftime('%s',startTime)) AS value ";
                    break;
                default:
                    throw new ApplicationException(
                                  "不明なタイプです（内部エラー）");
            }
            sql += "FROM mgpdata_view WHERE ";
            sql += "startTime >= '";
            sql += st;
            sql += "' AND endTime < '";
            sql += ed;
            sql += "' GROUP BY gameName ";
            sql += "ORDER BY value DESC;";
            return sql;
        }
    }
}
