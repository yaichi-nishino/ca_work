using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawAppl2
{
    public partial class Pallet : Form
    {
        // メンバー変数
        DrawFigure.Type figureType;
        
        // コンストラクタ
        public Pallet()
        {
            InitializeComponent();
            this.circleButton.Focus();
            figureType = DrawFigure.Type.Ellippse;
        }

        // 図形の種類の取得
        public DrawFigure.Type GetFigureType()
        {
            return figureType;
        }

        // ペンサイズの取得
        public int GetPenSize()
        {
            int size;
            if (int.TryParse(penSizeBox.Text, out size))
            {
                if (size >= 0) return size;
                else return 1;
            }
            else
            {
                return 1;
            }
        }

        // 図形の色の取得
        public Color GetColor()
        {
            return colorButton.BackColor;
        }

        public Color GetColor2()
        {
            return colorButton2.BackColor;
        }

        // 塗りつぶすか否か
        public bool GetFillCheck()
        {
            return fillCheckBox.Checked;
        }

        // 円ボタンがクリックされた
        private void CircleButtonClicked(object sender, EventArgs e)
        {
            figureType = DrawFigure.Type.Ellippse;
        }

        // 四角ボタンがクリックされた
        private void RectangleButtonClicked(object sender, EventArgs e)
        {
            figureType = DrawFigure.Type.Rectangle;
        }

        // 直線ボタンがクリックされた
        private void LineButtonClicked(object sender, EventArgs e)
        {
            figureType = DrawFigure.Type.Line;
        }

        // カラーボタンがクリックされた
        private void ColorButtonClicked(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択した色をボタンに設定する
                colorButton.BackColor = colorDialog.Color;
            }
        }

        // カーブボタンがクリックされた
        private void CurveButtonClicked(object sender, EventArgs e)
        {
            figureType = DrawFigure.Type.Curve;
        }

        // カラーボタン2がクリックされた -- グラデ用
        private void colorButton2Clicked(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択した色をボタンに設定する
                colorButton2.BackColor = colorDialog.Color;
            }
        }
    }
}
