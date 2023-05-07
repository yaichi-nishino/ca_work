using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace GraduationProject
{
    //***** データベースを扱うクラス
    //      データベースから値を取得したり、
    //      データを格納するメソッドは、このクラスに
    //      集約させている。
    //      基本的には、各メソッド単位で、
    //      DBのオープン・クローズが行われる。
    //      メッセージボックスによる確認など、
    //      ユーザーとの対話は、このクラスでは行わず、
    //      呼び出し側で制御する。
    //      また、引数の細かなチェックは、コンテナクラスで行い、
    //      このクラスでは、nullチェック程度しか行わない。
    class Database
    {
        //***** メンバー
        private static readonly string DB_FILE_NAME = "mgpark.db";
        private static readonly string DB_CONNECT_STRING = "Data Source=mgpark.db;Version=3";

        private static SQLiteConnection con = null; // DB接続
        private static SQLiteCommand com;           // DB命令設定用
        private static SQLiteDataReader sdr;        // DBデータ読み出し用


        //***** DBが作成されているか
        public static bool IsInstalled()
        {
            return File.Exists(DB_FILE_NAME);
        }


        //***** DBファイルの作成
        public static void CreateDatabase()
        {
            if (IsInstalled())
            {
                throw new ApplicationException("既にデータベースが存在します.");
            }
            SQLiteConnection.CreateFile(DB_FILE_NAME);  // DB作成
        }


        //***** テーブルの作成
        public static void CreateTables()
        {
            string sql;  // SQL文記憶用
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            con.Open();  // Open
            try
            {
                // ミニゲーム用テーブル作成
                sql = MiniGame.ComposeCreateTableSql();
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();

                // ユーザー用テーブル作成
                sql = User.ComposeCreateTableSql();
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();

                // プレイデータ用テーブル作成
                sql = PlayData.ComposeCreateTableSql();
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();

                // プレイデータ参照用ビュー作成
                sql = PlayData.ComposeCreateViewSql();
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }


        //***** ユーザーの存在チェック
        public static bool IsExistUser(string userName)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            bool retVal = false;
            con.Open();  // Open
            try
            {
                string sql = User.ComposeSelectSql(userName);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    retVal = true;  // 同名ユーザーあり
                }
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return retVal;
        }


        //***** 指定された名前でユーザーを登録する
        public static void AddUser(User user)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            con.Open();  // Open
            try
            {
                string sql = User.ComposeInsertSql(user.UserName);
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }

        //***** 指定されたミニゲームを登録する
        public static void AddMiniGame(MiniGame game)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            con.Open();  // Open
            try
            {
                string sql = MiniGame.ComposeInsertSql(game);
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }

        //***** 指定されたプレイデータを登録する
        //         本当は複数のデータをまとめて登録できるよう
        //         データを配列かリストでもらった方が良いが、
        //         まずは、動作させることを優先、一つずつ登録している
        public static void AddPlayData(PlayData data)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            con.Open();  // Open
            try
            {
                string sql = PlayData.ComposeInsertSql(data);
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }

        //***** 指定されたプレイデータを登録する
        //         あまりにも単数版が遅いので複数版を追加
        public static void AddPlayDataMulti(
                               List<PlayData> dList,
                               List<MiniGame> gameList,
                               List<User> userList)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            SQLiteTransaction trans = null;
            con.Open();  // Open
            try
            {
                trans = con.BeginTransaction();
                foreach (PlayData data in dList)
                {
                    string sql = PlayData.ComposeInsertSqlById(data, gameList, userList);
                    com = new SQLiteCommand(sql, con);  // SQL定義
                    com.ExecuteNonQuery();  // SQL実行
                    com.Dispose();
                    com = null;
                }
                trans.Commit();
                trans = null;
            }
            finally
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }

        //***** 指定されたミニゲームを削除する
        //      そのゲームに関するプレイデータも削除される
        //      プレイデータは残し、検索可能にしても構わなかったが
        //      データを溜まりっぱなしにするのが気持ち悪いため
        //      削除することにした
        //      残す場合は、削除の手段を、別に考えなければならない
        public static void DeleteMiniGame(int id)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            con.Open();  // Open
            try
            {
                // ゲームデータの削除
                string sql = MiniGame.ComposeDeleteSql(id);
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();
                com = null;

                // プレイデータの削除
                sql = PlayData.ComposeDeleteSql(id);
                com = new SQLiteCommand(sql, con);  // SQL定義
                com.ExecuteNonQuery();  // SQL実行
                com.Dispose();
                com = null;
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
        }

        //***** ミニゲーム情報の取得
        public static List<MiniGame> GetMiniGames()
        {
            List<MiniGame> games = new List<MiniGame>();
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            con.Open();  // Open
            try
            {
                string sql = MiniGame.ComposeSelectSql();
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        int id = Convert.ToInt32(sdr["id"].ToString());
                        int position = Convert.ToInt32(sdr["position"].ToString());
                        string gameName = sdr["gameName"].ToString();
                        string exeFile = sdr["exeFile"].ToString();
                        games.Add(new MiniGame(id, position, gameName, exeFile));
                    }
                }
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return games;
        }

        //***** ユーザー一覧の取得
        public static List<User> GetUsers(string condition = null)
        {
            List<User> users = new List<User>();
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            con.Open();  // Open
            try
            {
                string sql = (condition == null) ?
                                 User.ComposeSelectSql():
                                 User.ComposeSelectLikeSql(condition);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        int id = Convert.ToInt32(sdr["id"].ToString());
                        string userName = sdr["userName"].ToString();
                        users.Add(new User(id, userName));
                    }
                }
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return users;
        }

        //***** プレイデータの個数の取得
        public static int CountPlayData(int gameId)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            int retVal = 0;
            con.Open();  // Open
            try
            {
                string sql = PlayData.ComposeCountSql(gameId);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        retVal = Convert.ToInt32(sdr["count(*)"].ToString());
                        break;
                    }
                }
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return retVal;
        }


        //***** ビュー形式での表示用・プレイデータの取得
        public static DataTable GetDataTable(
                        System.Windows.Forms.DataGridView dataGridView,
                        DateTime startDate,
                        DateTime endDate,
                        List<MiniGame> games,
                        string userName,
                        double minPtCond,
                        double maxPtCond,
                        double minScCond,
                        double maxScCond)
        {
            DataTable dt = new DataTable();
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            con.Open();  // Open
            try
            {
                DataRow row;  // 一行分のデータ用
                dt = new DataTable();  // データテーブル生成
                DataColumn c = dt.Columns.Add("ゲーム名", Type.GetType("System.String"));
                
                dt.Columns.Add("ユーザー名", Type.GetType("System.String"));
                dt.Columns.Add("プレイ日時", Type.GetType("System.String"));
                dt.Columns.Add("時間（秒）", Type.GetType("System.Int32"));
                dt.Columns.Add("スコア", Type.GetType("System.Int32"));

                string sql 
                    = PlayData.ComposeSelectSql(
                        startDate, endDate, games, userName,
                        minPtCond, maxPtCond,
                        minScCond, maxScCond);

                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        row = dt.NewRow();  // 新しい行(レコード)追加
                        row["ゲーム名"] = sdr["gameName"].ToString();
                        row["ユーザー名"] = sdr["userName"].ToString();
                        row["プレイ日時"] = sdr["playDate"].ToString();
                        row["時間（秒）"] = Convert.ToInt32(sdr["playTerm"].ToString());
                        row["スコア"] = Convert.ToInt32(sdr["score"].ToString());
                        dt.Rows.Add(row);  // データセットに行データを追加
                    }
                }
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return dt;
        }


        //***** グラフ表示用のデータ取得 -- ユーザー名＋値
        public static List<GraphData> GetGraphData(
                          GraphData.Type gtype,
                          DateTime startDate,
                          DateTime endDate,
                          string gameName,
                          int maxUserNum,
                          double minCond, bool includeMin,
                          double maxCond, bool includeMax)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            string sql;
            List<GraphData> retVal = new List<GraphData>();
            con.Open();  // Open
            try
            {
                // トップユーザーの情報取得
                sql = PlayData.ComposeAggregateSql(
                          gtype, startDate, endDate, 
                          gameName, maxUserNum,
                          minCond, includeMin,
                          maxCond, includeMax);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        string userName = sdr["userName"].ToString();
                        GraphData oneData;
                        if (GraphData.IsAvalageType(gtype))
                        {
                            double v = Convert.ToDouble(sdr["value"].ToString());
                            oneData = new GraphData(userName, v, gtype);
                        }
                        else
                        {
                            int v = Convert.ToInt32(sdr["value"].ToString());
                            oneData = new GraphData(userName, v, gtype);
                        }
                        retVal.Add(oneData);
                    }
                }
                sdr.Close();
                sdr = null;

                // 全ユーザーを対象にした平均値もつける
                //    同じようなSQLを2回実行しているので、効率がよくないが、
                //    平均を出すかどうか、オプションにする可能性もあるので、
                //    処理を分けている。あまり遅いようなら、変更する。
                sql = PlayData.ComposeAggregateSql(
                          gtype, startDate, endDate, gameName,
                          minCond, includeMin,
                          maxCond, includeMax);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    double sumDoble = 0.0f;
                    int sumInt = 0;
                    int numOfData = 0;
                    while (sdr.Read())  // 取得データから一行読み込み
                    {
                        numOfData++;
                        if (GraphData.IsAvalageType(gtype))
                        {
                            sumDoble += Convert.ToDouble(sdr["value"].ToString());
                        }
                        else
                        {
                            sumInt += Convert.ToInt32(sdr["value"].ToString());
                        }
                    }
                    if (numOfData > 0)
                    {
                        double avgVal;
                        if (GraphData.IsAvalageType(gtype))
                        {
                            avgVal = sumDoble / ((double)numOfData);
                        }
                        else
                        {
                            avgVal = ((double)sumInt) / ((double)numOfData);
                        }
                        retVal.Add(new GraphData("全ユーザーの平均", avgVal, gtype));
                    }
                    else
                    {
                        retVal.Add(new GraphData("", 0.0f, gtype));  // ここには来ないはず
                    }
                }
                sdr.Close();
                sdr = null;
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return retVal;
        }


        //***** グラフ表示用のデータ取得 -- ゲーム名＋値
        public static List<GraphData> GetGraphData(
                          GraphData.Type gtype,
                          DateTime startDate,
                          DateTime endDate)
        {
            con = new SQLiteConnection(DB_CONNECT_STRING);
            com = null;
            sdr = null;
            string sql;
            List<GraphData> retVal = new List<GraphData>();
            con.Open();  // Open
            try
            {
                // DBから情報取得
                sql = PlayData.ComposeAggregateSql(
                          gtype, startDate, endDate);
                com = new SQLiteCommand(sql, con);
                sdr = com.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())  // 取得データから一行ずつ読み込み
                    {
                        string gameName = sdr["gameName"].ToString();
                        GraphData oneData;
                        if (GraphData.IsAvalageType(gtype))
                        {
                            double v = Convert.ToDouble(sdr["value"].ToString());
                            oneData = new GraphData(gameName, v, gtype);
                        }
                        else
                        {
                            int v = Convert.ToInt32(sdr["value"].ToString());
                            oneData = new GraphData(gameName, v, gtype);
                        }
                        retVal.Add(oneData);
                    }
                }
                sdr.Close();
                sdr = null;
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                    sdr = null;
                }
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                con.Close();  // Close
                con = null;
            }
            return retVal;
        }
    }
}
