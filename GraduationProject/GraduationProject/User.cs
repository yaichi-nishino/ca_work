using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject
{
    // ユーザーの情報を保持するクラス
    class User
    {
        //**** 定数
        public static readonly int NAME_MAX_LEN = 32;

        //*****　メンバー変数
        private int id;             // 主キー
        private string userName;    // ユーザー名

        //***** コンストラクタ
        //      DBから読み込んだデータ保持用
        //      値のチェックは格納時に行われており、
        //      許される値しか入っていないはず
        public User(int id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }

        //***** コンストラクタ
        //      DBへ保存するための情報用
        //      エラーチェックの場所を集約させたかったので、
        //      文字長や使えない文字の判定をここで行っている
        public User(string userName)
        {
            this.id = 0;  // ダミー
            this.userName = userName;
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ApplicationException("空文字列や空白のみの名前は使用できません");
            }
            if (userName.Length > NAME_MAX_LEN)
            {
                throw new ApplicationException("名前が長すぎます（" +
                            NAME_MAX_LEN + "文字以内）");
            }
            if (userName.Contains('\'') || userName.Contains('"') ||
                userName.Contains(',') || userName.Contains(';') ||
                userName.Contains(':') || userName.Contains('\\') ||
                userName.Contains('/') )
            {
                throw new ApplicationException("名前に使用できない文字が含まれています");
            }
        }

        //***** プロパティ -- ゲッターのみ定義
        public int Id { get { return id; } }
        public string UserName { get { return userName; } }

        //***** テーブル作成用のSQL生成
        public static string ComposeCreateTableSql()
        {
            string sql = "CREATE TABLE mguser_table ";
            sql += " (id INTEGER PRIMARY KEY AUTOINCREMENT,";
            sql += "userName STRING);";
            return sql;
        }

        //***** 名前で検索するSQLの生成
        public static string ComposeSelectSql(string userName)
        {
            string sql = "SELECT id,userName FROM mguser_table ";
            sql += "WHERE userName='";
            sql += userName;
            sql += "';";
            return sql;
        }

        //***** 名前で検索するSQLの生成
        public static string ComposeSelectLikeSql(string userName)
        {
            string sql = "SELECT id,userName FROM mguser_table ";
            sql += "WHERE userName LIKE '";
            sql += userName;
            sql += "';";
            return sql;
        }

        //***** 全データ取得用のSQL生成
        public static string ComposeSelectSql()
        {
            string sql = "SELECT id,userName FROM mguser_table;";
            return sql;
        }

        //***** データ登録用のSQL生成
        public static string ComposeInsertSql(string userName)
        {
            string sql = "INSERT INTO mguser_table ";
            sql += " (userName) VALUES('";
            sql += userName;
            sql += "');";
            return sql;
        }
    }
}
