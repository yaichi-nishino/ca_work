using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawAppl2
{
    public partial class Form1 : Form
    {
        //**** 説明****
        // テキストに載っているドローアプリを改良したもの
        // 主な変更点は、以下の通り
        //　・図形が消えないよう、描画用のデータを保持
        //　・手書きっぽい曲線を描くボタンをパレットに追加
        //　・塗りつぶしするか否かのオプションをパレットに追加
        //　・塗りつぶす際、2色の色を指定可能に
        //　・2色の異なる色が指定されている場合、グラデがかかる
        //　・下から上、右から左への描画時にも、長方形が描けるように対応
        //　・直前の変更を取り消すアンドゥ機能追加
        //　・すべての編集を取り消す機能を追加
        //　・アンドゥの取り消し機能を追加
        //　・編集内容を保存する機能を追加（実行ディレクトリ直下data.txt）
        //　・保存されたデータがあれば、起動時に読み込めるよう機能追加


        // **** メンバー ****
        Point startPos;      // 描画開始点 -- マウスクリックした場所
        Point endPos;        // 描画終了点 -- 描画時のマウスのいる場所
        List<Point> points;  // 曲線表示用の位置情報のリスト
        Pallet pallet;       // 描画する対象を指定するパレット（別フォーム）
        List<DrawFigure> figures;    // 描画された図形の情報を保存
        Stack<DrawFigure> erasedFigures;  // 削除された図形の情報を復活用に保存

        static readonly string SAVE_FILE_NAME = "data.txt";
            // 描画されている図形の情報を保存するファイル
            // ダイアログでファイル名を指定させることも可能だが、
            // 今回は、決め打ちしている


        // **** コンストラクタ ****
        public Form1()
        {
            InitializeComponent();  // その他の初期化は Load　の方で
        }


        // **** 画面描画時に呼ばれるメソッド ****
        private void DrawFigures(object sender, PaintEventArgs e)
        {
            // 描画を滑らかに
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 昔の画像の表示
            DrawOldFigures(e);

            // パレットから情報取得
            DrawFigure.Type type = pallet.GetFigureType();
            Color color = pallet.GetColor();
            Color color2 = pallet.GetColor2();
            int penSize = pallet.GetPenSize();
            bool filled = pallet.GetFillCheck();
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;

            // 作画中の図形を描く必要があるか、まずチェック
            if (type == DrawFigure.Type.Curve)
            {
                // 点が2か所以上記録されていなければ描画しない
                if (points == null || points.Count < 2) return;
            }
            else
            {
                // スタート位置と現在位置が等しい時は描画しない
                if (width == 0 && height == 0) return;
            }

            // タイプに応じて図形を描画する
            Brush brush = null;
            Pen pen = null;
            Point[] ptArray = null;
            if (type == DrawFigure.Type.Ellippse 
                || type == DrawFigure.Type.Rectangle)  // 円か長方形の場合
            {
                if (filled)  // 塗りつぶす場合
                {
                    brush = GetBrushInternal(startPos, endPos, color, color2);
                }
                else  // 輪郭のみの場合
                {
                    pen = new Pen(color, penSize);
                }
            }
            else if (type == DrawFigure.Type.Line)  // 直線を描画
            {
                if (filled)  // 塗りつぶす場合
                {
                    Brush tmp = GetBrushInternal(startPos, endPos, color, color2);
                    pen = new Pen(tmp, penSize);
                }
                else  // 輪郭のみの場合
                {
                    pen = new Pen(color, penSize);
                }
            }
            else if (type == DrawFigure.Type.Curve)  // 曲線を描画 -- 記録した点をカーブで繋ぐ
            {
                ptArray = points.ToArray();
                if (filled)  // 塗りつぶす場合
                {
                    Brush tmp = GetBrushInternal(startPos, endPos, color, color2);
                    pen = new Pen(tmp, penSize);
                }
                else  // 輪郭のみの場合
                {
                    pen = new Pen(color, penSize);
                }
            }
            // 実際の描画は共通メソッドで実施
            DrawSingleFigure(e, type, brush, pen, 
                             startPos.X, startPos.Y,
                             width, height, ptArray);
        }


        // **** 記録しておいた昔の図形を全て描画 ****
        private void DrawOldFigures(PaintEventArgs e)
        {
            if (figures.Count == 0) return;  // まだ何もない時は帰る
            foreach(DrawFigure fig in figures)
            {
                DrawSingleFigure(e, fig.type,
                                 fig.brush, fig.pen,
                                 fig.x, fig.y,
                                 fig.width, fig.height,
                                 fig.points);
            }
        }


        // **** １つの図形を描画する共通メソッド ****
        private void DrawSingleFigure(PaintEventArgs e,
                                      DrawFigure.Type type,
                                      Brush brush, Pen pen, 
                                      int x, int y, int width, int height, 
                                      Point[] points)
        {
            if (type == DrawFigure.Type.Ellippse)  // 円を描画
            {
                if (brush != null)
                {
                    e.Graphics.FillEllipse(brush, x, y, width, height);
                }
                else
                {
                    e.Graphics.DrawEllipse(pen, x, y, width, height);
                }
            }
            else if (type == DrawFigure.Type.Rectangle)  // 長方形を描画
            {
                if (brush != null)
                {
                    // 幅や高さがマイナスだと描画されないので、
                    // 無理やり、正の値になるよう変換している
                    // e.Graphics.FillRectangle(brush, x, y, width, height); <- 左上から左下にしか描けない
                    if (height < 0 && width > 0)
                        e.Graphics.FillRectangle(brush, x, y+height, width, (-1*height));
                    else if (height > 0 && width < 0)
                        e.Graphics.FillRectangle(brush, x+width, y, (-1*width), height);
                    else if (height < 0 && width < 0)
                        e.Graphics.FillRectangle(brush, x+width, y+height, (-1*width), (-1*height));
                    else
                        e.Graphics.FillRectangle(brush, x, y, width, height);
                }
                else
                {
                    //e.Graphics.DrawRectangle(pen, x, y, width, height); <- 左上から左下にしか描けない
                    if (height < 0 && width > 0)
                        e.Graphics.DrawRectangle(pen, x, y + height, width, (-1 * height));
                    else if (height > 0 && width < 0)
                        e.Graphics.DrawRectangle(pen, x + width, y, (-1 * width), height);
                    else if (height < 0 && width < 0)
                        e.Graphics.DrawRectangle(pen, x + width, y + height, (-1 * width), (-1 * height));
                    else
                        e.Graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
            else if (type == DrawFigure.Type.Line)  // 直線を描画
            {
                e.Graphics.DrawLine(pen, x, y, x+width, y+height);
                  // 直線の場合、終端の座標を渡す必要があるので、足し算
            }
            else if (type == DrawFigure.Type.Curve)  // 曲線を描画
            {
                if (points.Length >= 2)  // 1点のみのポイントは除外
                {
                    //Brush b = pen.Brush;  // TEST
                    //if (b is LinearGradientBrush)
                    //{
                    //    LinearGradientBrush lb = (LinearGradientBrush)b;
                    //    Point st = points[0];
                    //    Point ed = points[points.Length - 1];
                    //    Color[] cs = lb.LinearColors;
                    //    pen = new Pen(GetBrushInternal(st, ed, cs[0], cs[1]), pen.Width);
                    //}  // end of TEST
                    
                    e.Graphics.DrawCurve(pen, points);
                }
            }
        }


        // **** Brush を生成する内部メソッド ****
        private Brush GetBrushInternal(Point startPos, Point endPos,
                                       Color color1, Color color2)
        {
            Brush brush;
            if (color1 == color2)
            {
                brush = new SolidBrush(color1);
            }
            else
            {
                brush = new LinearGradientBrush(startPos, endPos,
                                                color1, color2);
            }
            return brush;
        }


        // **** マウスがクリックされた ****
        private void MousePressed(object sender, MouseEventArgs e)
        {
            // 始点座標を保存する
            startPos = new Point(e.X, e.Y);
            if (pallet.GetFigureType() == DrawFigure.Type.Curve)
            {   
                // 曲線用リストの初期化
                points = new List<Point>();
                points.Add(new Point(e.X, e.Y));
            }
            else
            {
                points = null;  // 曲線用リスト不要
            }
        }


        // **** マウスが離された時 ****
        //       -- 今、描いた図形の情報を再表示のため保持する
        private void MouseUpped(object sender, MouseEventArgs e)
        {
            int width = endPos.X - startPos.X;
            int height = endPos.Y - startPos.Y;
            if (width == 0 && height == 0) return;  // ポインタが動いていないので無視

            DrawFigure.Type type = pallet.GetFigureType();
            Color color = pallet.GetColor();
            Color color2 = pallet.GetColor2();
            int penSize = pallet.GetPenSize();
            bool filled = pallet.GetFillCheck();
            
            DrawFigure figure = null;
            if (type == DrawFigure.Type.Ellippse 
                || type == DrawFigure.Type.Rectangle)
            {
                if (filled)
                {
                    Brush brush = GetBrushInternal(startPos, endPos, color, color2);
                    figure = new DrawFigure(type, brush,
                                            startPos.X, startPos.Y,
                                            width, height);
                }
                else
                {
                    Pen pen = new Pen(color, penSize);
                    figure = new DrawFigure(type, pen,
                                            startPos.X, startPos.Y,
                                            width, height);
                }
            }
            else if (type == DrawFigure.Type.Line)
            {
                Pen pen;
                if (filled)
                {
                    Brush brush = GetBrushInternal(startPos, endPos, color, color2);
                    pen = new Pen(brush, penSize);
                }
                else
                {
                    pen = new Pen(color, penSize);
                }
                figure = new DrawFigure(type, pen,
                                        startPos.X, startPos.Y,
                                        width, height);
            }
            else if (type == DrawFigure.Type.Curve)
            {
                Pen pen;
                if (filled)
                {
                    Brush brush = GetBrushInternal(startPos, endPos, color, color2);
                    pen = new Pen(brush, penSize);
                }
                else
                {
                    pen = new Pen(color, penSize);

                }
                figure = new DrawFigure(type, pen, points);
            }

            // 描画情報をリストに格納・リドゥデータの除去
            if (figure != null) figures.Add(figure);
            if (erasedFigures.Count > 0)
            {
                while (erasedFigures.Count > 0) 
                {
                    DrawFigure df = erasedFigures.Pop();
                    // 空スタックにPopするとエラーになることに注意
                    df.Dispose();
                }
            }
            MaintainUndoMenu();  // アンドゥメニューのメンテ
        }


        // **** 終了メニューが選択された ****
        private void ExitMenuSelected(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show(
                "終了しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                this.Close();
            }
        }


        // **** すべて削除が選択された ****
        private void EraseAllMenuSelected(object sender, EventArgs e)
        {
            if (figures == null || figures.Count == 0) return;

            DialogResult dt = MessageBox.Show(
                "すべてなかった事にしますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dt == DialogResult.Yes)
            {
                foreach(DrawFigure df in figures)
                {
                    erasedFigures.Push(df);
                }
                figures.RemoveAll(fig => fig != null);
                points = null;
                startPos.X = 0;
                startPos.Y = 0;
                endPos.X = 0;
                endPos.Y = 0;
            }
            MaintainUndoMenu();
            Invalidate();
        }


        // **** ひとつだけ削除が選択された ****
        private void EraseOneMenuSelected(object sender, EventArgs e)
        {
            if (figures == null || figures.Count == 0) return;
            int position = figures.Count -1;  // 末尾
            if (position >= 0)
            {
                if (figures[position].type == DrawFigure.Type.Curve)
                {
                    points = null;
                }
                erasedFigures.Push(figures.ElementAt(position));
                figures.RemoveAt(position);
                startPos.X = 0;
                startPos.Y = 0;
                endPos.X = 0;
                endPos.Y = 0;
            }
            MaintainUndoMenu();
            Invalidate();
        }

        // Undoの時に呼ばれ、メニューの表示・非表示を切り替える
        private void MaintainUndoMenu()
        {
            if (figures == null || figures.Count == 0)
            {
                this.EraseOneMenuItem.Visible = false;
                this.EraseAllMenuItem.Visible = false;
            }
            else
            {
                this.EraseOneMenuItem.Visible = true;
                this.EraseAllMenuItem.Visible = true;
            }
            if (erasedFigures.Count > 0)
            {
                this.RedoOneMenuItem.Visible = true;
            }
            else
            {
                this.RedoOneMenuItem.Visible = false;
            }
        }

        // **** マウスが移動した ****
        private void MouseDragged(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // ドラッグしている場合
            {
                // 終点座標を更新する
                endPos = new Point(e.X, e.Y);

                // 曲線の場合ポイントを追加する
                if (pallet.GetFigureType() == DrawFigure.Type.Curve)
                {
                    points.Add(new Point(e.X, e.Y));
                }
                Invalidate();
            }
        }

        // **** 消すのはヤメが選択された ****
        private void RedoOneMenuSelected(object sender, EventArgs e)
        {
            if (erasedFigures != null && erasedFigures.Count > 0)
            {
                DrawFigure df = erasedFigures.Pop();
                figures.Add(df);

                MaintainUndoMenu();
                Invalidate();
            }
        }


        //***** 保存がクリックされた
        private void SaveToolMenu_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (System.IO.File.Exists(SAVE_FILE_NAME))
            {
                msg += "古い保存データが存在します.\r\n上書き";
                    // 古いデータがあるかどうかでメッセージを変える
            }
            msg += "保存しますか？";

            DialogResult dt = MessageBox.Show(
                msg,
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dt == DialogResult.Yes)
            {
                if (figures == null || figures.Count == 0)  // 空で上書き
                {
                    System.IO.File.Delete(SAVE_FILE_NAME);  // ファイル削除
                }
                else
                {
                    using (System.IO.StreamWriter file =
                           new System.IO.StreamWriter(SAVE_FILE_NAME, false)) // 上書き
                    {
                        foreach (DrawFigure df in figures)
                        {
                            file.WriteLine(df.ToRecordString());
                        }
                    }
                }
            }
        }


        //***** データファイルの読み込み
        private void ReadDataFile()
        {
            if (System.IO.File.Exists(SAVE_FILE_NAME))
            {
                DialogResult dt 
                    = MessageBox.Show(
                        "保存データがあります\r\n読み込みますか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (dt == DialogResult.Yes)
                {
                    using (System.IO.StreamReader file
                              = new System.IO.StreamReader(SAVE_FILE_NAME))
                    {
                        while (!file.EndOfStream)
                        {
                            string line = file.ReadLine();
                            DrawFigure df = DrawFigure.FromRecordString(line);
                            this.figures.Add(df);
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            points = null;
            figures = new List<DrawFigure>();
            ReadDataFile();
            erasedFigures = new Stack<DrawFigure>();
            MaintainUndoMenu();
            pallet = new Pallet();
            pallet.Show();
        }
    }
}
