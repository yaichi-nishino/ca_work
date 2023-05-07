using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject
{
    // ミニゲームの情報を保持するクラス
    class MiniGame
    {
        //**** 定数
        public static readonly int NAME_MAX_LEN = 32;
        public static readonly int EXE_FILE_MAX_LEN = 64;
        public static readonly int SCORE_MAX_POINT = 9999;
        public static readonly int NUM_OF_MINI_GAMES_IN_LAUNCHER = 6;

        //*****　メンバー変数
        private int id;             // 主キー
        private int position;       // 起動画面上での位置
        private string gameName;        // ゲーム名
        private string exeFile;     // 実行ファイル名

        //***** コンストラクタ
        //      DBから得られた値用
        //      idがアサインされていて、変な値も入っていない
        public MiniGame(int id, int position, string gameName,
                   string exeFile)
        {
            this.id = id;
            this.position = position;
            this.gameName = gameName;
            this.exeFile = exeFile;
        }

        //***** コピーコンストラクタ
        public MiniGame(MiniGame game)
        {
            this.id = game.Id;
            this.position = game.Position;
            this.gameName = game.GameName;
            this.exeFile = game.ExeFile;
        }

        //***** コンストラクタ
        //      DBへ保存するための情報用
        //      エラーチェックの場所を集約させたかったので、
        //      文字長や使えない文字の判定をここで行っている
        public MiniGame(int position, string gameName,
                   string exeFile)
        {
            this.id = 0;  // ダミー
            this.position = position;
            if (position < 0 || position > NUM_OF_MINI_GAMES_IN_LAUNCHER)
            {
                // 登録可能なゲーム数を制限しているため、
                // それ以上の値が指定されたらエラーにしている 
                // ユーザーが直に指定する値ではないので、
                // 基本的に、ここにくるのは、実装エラーの時だけ
                throw new ApplicationException("位置情報として指定された値が無効です"
                              +"（" + position + "）");
            }

            this.gameName = gameName;
            if (string.IsNullOrWhiteSpace(gameName))
            {
                throw new ApplicationException("空文字列や空白のみの名前は使用できません");
            }
            if (gameName.Length > NAME_MAX_LEN)
            {
                throw new ApplicationException("名前が長すぎます（" +
                            NAME_MAX_LEN + "文字以内）");
            }
            if (gameName.Contains('\'') || gameName.Contains('"') ||
                gameName.Contains(',') || gameName.Contains(';') ||
                gameName.Contains(':') || gameName.Contains('\\') ||
                gameName.Contains('/'))
            {
                throw new ApplicationException("名前に使用できない文字が含まれています");
            }

            this.exeFile = exeFile;
            if (string.IsNullOrWhiteSpace(exeFile))
            {
                throw new ApplicationException("実行ファイルの名前に、空文字列や空白のみの文字列は使用できません");
            }
            if (exeFile.Length > EXE_FILE_MAX_LEN)
            {
                throw new ApplicationException(
                            "実行ファイルの名前が長すぎます（" +
                            EXE_FILE_MAX_LEN + "文字以内）");
            }
            if (exeFile.Contains('\'') || exeFile.Contains('"') ||
                exeFile.Contains(',') || exeFile.Contains(';') ||
                exeFile.Contains(':') || exeFile.Contains('\\') ||
                exeFile.Contains('/'))
            {
                throw new ApplicationException(
                              "実行ファイルの名前に、使用できない文字が含まれています");
            }
            string[] s = exeFile.Split('.');
            if (s.Length != 2)
            {
                throw new ApplicationException(
                              "実行ファイル名にピリオドが複数含まれています");
            }
            if (string.Compare(s[1], "exe", true) != 0)
            {
                throw new ApplicationException(
                              "実行ファイル名には、プログラム（拡張子が”EXE”のファイル）のみ指定できます");
            }
        }

        //***** プロパティ -- ゲッターのみ定義
        public int Id { get { return id; } }
        public int Position { get { return position; } }
        public string GameName { get { return gameName; } }
        public string ExeFile { get { return exeFile; } }

        //***** テーブル作成用のSQL生成
        public static string ComposeCreateTableSql()
        {
            string sql = "CREATE TABLE mgame_table ";
            sql += "(";
                sql += "id INTEGER PRIMARY KEY AUTOINCREMENT,";
                sql += "position INTEGER,";
                sql += "gameName STRING,";
                sql += "exeFile STRING";
            sql += ");";
            return sql;
        }

        //***** 全データ取得用のSQL生成
        public static string ComposeSelectSql()
        {
            string sql = "SELECT id,position,gameName,exeFile ";
            sql += "FROM mgame_table ";
            sql += "ORDER BY position ASC;";
            return sql;
        }

        //***** 名前で検索するSQLの生成
        public static string ComposeSelectSql(string gameName)
        {
            string sql = "SELECT id,position,gameName,exeFile ";
            sql += "FROM mgame_table ";
            sql += "WHERE gameName='";
            sql += gameName;
            sql += "';";
            return sql;
        }

        //***** データ登録用のSQL生成
        public static string ComposeInsertSql(MiniGame game)
        {
            string sql = "INSERT INTO mgame_table ";
            sql += " (position,gameName,exeFile) VALUES(";
                sql += game.Position;
                sql += ",'";
                sql += game.GameName;
                sql += "','";
                sql += game.ExeFile;
            sql += "');";
            return sql;
        }

        //***** データ削除用のSQL生成
        public static string ComposeDeleteSql(int id)
        {
            string sql = "DELETE FROM mgame_table ";
            sql += "WHERE id=";
            sql += id;
            sql += ";";
            return sql;
        }
    }
}
