using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DrawAppl2
{
    public class DrawFigure
    {
        // 図形タイプ
        public enum Type
        {
            Ellippse,   // 円（楕円）
            Rectangle,  // 長方形
            Line,       // 直線
            Curve,      // 曲線
            None,
        }
        
        // メンバーデータ
        public DrawFigure.Type type;
        public Pen pen;
        public Brush brush;
        public int x;
        public int y;
        public int width;
        public int height;
        public Point[] points;

        // 図形タイプを文字列に
        public static string TypeToString(Type type)
        {
            switch(type)
            {
                case Type.Ellippse:
                    return "Ellipse";
                case Type.Rectangle:
                    return "Rectangle";
                case Type.Line:
                    return "Line";
                case Type.Curve:
                    return "Curve";
                case Type.None:
                default:
                    return "None";
            }
        }

        // 文字列を図形タイプに
        public static Type StringToType(string str)
        {
            switch (str)
            {
                case "Ellipse":
                    return Type.Ellippse;
                case "Rectangle":
                    return Type.Rectangle;
                case "Line":
                    return Type.Line;
                case "Curve":
                    return Type.Curve;
                case "None":
                default:
                    return Type.None;
            }
        }

        // ペンを使う図形用のコンストラクタ
        public DrawFigure(DrawFigure.Type type, 
                   Pen pen, int x, int y, 
                   int width, int height)
        {
            this.type = type;
            this.pen = pen;
            this.brush = null;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.points = null;
        }

        //*** ブラシを使う図形用コンストラクター
        public DrawFigure(DrawFigure.Type type, 
                   Brush brush, int x, int y, 
                   int width, int height)
        {
            this.type = type;
            this.pen = null;
            this.brush = brush;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.points = null;
        }

        //*** カーブ用のコンストラクタ
        public DrawFigure(DrawFigure.Type type, 
                   Pen pen, List<Point> points)
        {
            this.type = type;
            this.pen = pen;
            this.brush = null;
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.points = points.ToArray();
        }


        // ファイルへの保存用
        public string ToRecordString()
        {
            string retVal = TypeToString(type);  // タイプ
              // カンマ区切りが入れ子になると面倒、
              // 格納する値が数値のみなので、カンマ→コロン→ピリオドで、
              // 値を区切ることにしている

            retVal += ",";
            if (pen != null)  // ペン
            {
                if (pen.Brush != null)  // グラデ用と単色用とで、データの持ち方が異なる
                {
                    if (pen.Brush is LinearGradientBrush) // グラデ
                    {
                        LinearGradientBrush lgb = (LinearGradientBrush)pen.Brush;
                        Color c1 = lgb.LinearColors[0];
                        Color c2 = lgb.LinearColors[1];
                        float x = lgb.Rectangle.X;
                        float y = lgb.Rectangle.Y;
                        float width = lgb.Rectangle.Width;
                        float height = lgb.Rectangle.Height;
                        retVal += c1.ToArgb().ToString();
                        retVal += ":";
                        retVal += c2.ToArgb().ToString();
                        retVal += ":";
                        retVal += x.ToString();
                        retVal += ":";
                        retVal += y.ToString();
                        retVal += ":";
                        retVal += width.ToString();
                        retVal += ":";
                        retVal += height.ToString();
                        // 値の区切りとしてコロンを使用
                    }
                    else if (pen.Brush is SolidBrush) // 単色 -- 普通のペンと同じ
                    {
                        SolidBrush psb = (SolidBrush)pen.Brush;
                        retVal += psb.Color.ToArgb().ToString();
                    }
                }
                else
                {
                    retVal += pen.Color.ToArgb().ToString();  // 色
                }
                retVal += ":";
                retVal += pen.Width;  // 幅
            }

            retVal += ",";
            if (brush != null) // ブラシ
            {
                if (brush is LinearGradientBrush) // グラデ
                {
                    LinearGradientBrush b = (LinearGradientBrush)brush;
                    Color c1 = b.LinearColors[0];
                    Color c2 = b.LinearColors[1];
                    float x = b.Rectangle.X;
                    float y = b.Rectangle.Y;
                    float width = b.Rectangle.Width;
                    float height = b.Rectangle.Height;
                    retVal += c1.ToArgb().ToString();
                    retVal += ":";
                    retVal += c2.ToArgb().ToString();
                    retVal += ":";
                    retVal += x.ToString();
                    retVal += ":";
                    retVal += y.ToString();
                    retVal += ":";
                    retVal += width.ToString();
                    retVal += ":";
                    retVal += height.ToString();
                        // 値の区切りとしてコロンを使用
                }
                else if (brush is SolidBrush) // 単色
                {
                    SolidBrush b = (SolidBrush)brush;
                    retVal += b.Color.ToArgb().ToString();
                }
            }

            // 座標
            retVal += ",";
            retVal += x.ToString();
            retVal += ",";
            retVal += y.ToString();
            retVal += ",";
            retVal += width.ToString();
            retVal += ",";
            retVal += height.ToString();

            // 座標リスト
            retVal += ",";
            if (points != null && points.Length > 0)
            {
                bool isFirst = true;
                foreach (Point pt in points)
                {
                    if (!isFirst) retVal += ":";  // 座標の区切りはコロン
                    else isFirst = false;

                    retVal += pt.X.ToString();
                    retVal += ".";  
                        // XとYの境目はピリオドを使う
                    retVal += pt.Y.ToString();
                }
            }
            return retVal;
        }


        //***** ファイルからの復元用
        public static DrawFigure FromRecordString(string str)
        {
            string[] ss = str.Split(',');
            DrawFigure.Type type = StringToType(ss[0]);  // タイプ

            Pen pen = null;
            if (ss[1] != null && ss[1] != "")  // ペン
            {
                string[] ssp = ss[1].Split(':');  // 内側の値はコロン区切り
                if (ssp.Length > 2)
                {
                    // グラデ用
                    Color pbc1 = Color.FromArgb(int.Parse(ssp[0]));
                    Color pbc2 = Color.FromArgb(int.Parse(ssp[1]));
                    int pbx = (int)float.Parse(ssp[2]);
                    int pby = (int)float.Parse(ssp[3]);
                    int pbwidth = (int)float.Parse(ssp[4]);
                    int pbheight = (int)float.Parse(ssp[5]);
                    int ppenSize = (int)(float.Parse(ssp[6]));

                    LinearGradientBrush pb
                        = new LinearGradientBrush(new Point(pbx, pby),
                                                  new Point(pbx+pbwidth, pby+pbheight),
                                                  pbc1, pbc2);
                    pen = new Pen(pb, ppenSize);
                }
                else 
                {
                    // 単色
                    Color c = Color.FromArgb(int.Parse(ssp[0]));
                    int penSize = (int)(float.Parse(ssp[1]));
                    pen = new Pen(c, penSize);
                }
            }

            Brush brush = null;
            if (ss[2] != null && ss[2] != "")  // ブラシ
            {
                string[] ssb = ss[2].Split(':');  // 内側の値はコロン区切り
                if (ssb.Length > 2)  // グラデ
                {
                    Color c1 = Color.FromArgb(int.Parse(ssb[0]));
                    Color c2 = Color.FromArgb(int.Parse(ssb[1]));
                    float bx = float.Parse(ssb[2]);
                    float by = float.Parse(ssb[3]);
                    float bwidth = float.Parse(ssb[4]);
                    float bheight = float.Parse(ssb[5]);

                    brush = new LinearGradientBrush(
                                    new Point((int)bx, (int)by),
                                    new Point((int)(bx+bwidth), (int)(by+bheight)),
                                    c1, c2);
                }
                else
                {
                    Color c = Color.FromArgb(int.Parse(ss[2]));
                    brush = new SolidBrush(c);
                }
            }

            int x = int.Parse(ss[3]);
            int y = int.Parse(ss[4]);
            int width = int.Parse(ss[5]);
            int height = int.Parse(ss[6]);

            List<Point> points = null;
            if (ss[7] != null && ss[7] != "")  // 座標リスト
            {
                string[] pts = ss[7].Split(':');  // 内側の区切りはコロン
                for (int i = 0; i < pts.Length; i++)
                {
                    string[] val = pts[i].Split('.');  // xとyの区切りはピリオド
                    Point pt 
                        = new Point(int.Parse(val[0]),
                                    int.Parse(val[1]));
                    if (points == null) points = new List<Point>(); 
                    points.Add(pt);
                }
            }

            DrawFigure retVal;
            if (points != null)
                retVal = new DrawFigure(type, pen, points);
            else if (pen != null)
                retVal = new DrawFigure(type, pen, x, y, width, height);
            else
                retVal = new DrawFigure(type, brush, x, y, width, height);
            return retVal;
        }


        //***** 後始末
        public void Dispose()
        {
            if (pen != null) pen.Dispose();
            if (brush != null) brush.Dispose();
        }
    }
}
