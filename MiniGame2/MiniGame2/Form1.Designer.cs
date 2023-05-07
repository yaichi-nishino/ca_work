
namespace MiniGame2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.answerLb = new System.Windows.Forms.Label();
            this.questionLb = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.yesPb = new System.Windows.Forms.PictureBox();
            this.pekePb = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scoreLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yesPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pekePb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "問題";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "答え";
            // 
            // answerLb
            // 
            this.answerLb.AutoSize = true;
            this.answerLb.BackColor = System.Drawing.Color.Transparent;
            this.answerLb.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.answerLb.Location = new System.Drawing.Point(178, 125);
            this.answerLb.Name = "answerLb";
            this.answerLb.Size = new System.Drawing.Size(419, 38);
            this.answerLb.TabIndex = 1;
            this.answerLb.Text = "数字を入力してエンター！";
            this.answerLb.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // questionLb
            // 
            this.questionLb.AutoSize = true;
            this.questionLb.BackColor = System.Drawing.Color.Transparent;
            this.questionLb.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.questionLb.Location = new System.Drawing.Point(178, 54);
            this.questionLb.Name = "questionLb";
            this.questionLb.Size = new System.Drawing.Size(409, 38);
            this.questionLb.TabIndex = 1;
            this.questionLb.Text = "表示される数の合計は？";
            // 
            // backButton
            // 
            this.backButton.BackgroundImage = global::MiniGame2.Properties.Resources.back;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Location = new System.Drawing.Point(362, 266);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(64, 64);
            this.backButton.TabIndex = 0;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.BackgroundImage = global::MiniGame2.Properties.Resources.num0;
            this.button10.Location = new System.Drawing.Point(292, 336);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(64, 64);
            this.button10.TabIndex = 0;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.BackgroundImage = global::MiniGame2.Properties.Resources.num9;
            this.button9.Location = new System.Drawing.Point(222, 336);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 64);
            this.button9.TabIndex = 0;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.BackgroundImage = global::MiniGame2.Properties.Resources.num5;
            this.button5.Location = new System.Drawing.Point(292, 266);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 64);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.BackgroundImage = global::MiniGame2.Properties.Resources.num8;
            this.button8.Location = new System.Drawing.Point(152, 336);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 64);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.BackgroundImage = global::MiniGame2.Properties.Resources.num4;
            this.button4.Location = new System.Drawing.Point(222, 266);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 64);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.BackgroundImage = global::MiniGame2.Properties.Resources.num7;
            this.button7.Location = new System.Drawing.Point(82, 336);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 64);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImage = global::MiniGame2.Properties.Resources.num3;
            this.button3.Location = new System.Drawing.Point(152, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 64);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.BackgroundImage = global::MiniGame2.Properties.Resources.num6;
            this.button6.Location = new System.Drawing.Point(12, 336);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 64);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = global::MiniGame2.Properties.Resources.num2;
            this.button2.Location = new System.Drawing.Point(82, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 64);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = global::MiniGame2.Properties.Resources.num1;
            this.button1.Location = new System.Drawing.Point(12, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // enterButton
            // 
            this.enterButton.BackgroundImage = global::MiniGame2.Properties.Resources.enter;
            this.enterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enterButton.Location = new System.Drawing.Point(432, 266);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(124, 124);
            this.enterButton.TabIndex = 2;
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // yesPb
            // 
            this.yesPb.BackColor = System.Drawing.Color.Transparent;
            this.yesPb.BackgroundImage = global::MiniGame2.Properties.Resources.maru;
            this.yesPb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.yesPb.Location = new System.Drawing.Point(12, 31);
            this.yesPb.Name = "yesPb";
            this.yesPb.Size = new System.Drawing.Size(597, 369);
            this.yesPb.TabIndex = 3;
            this.yesPb.TabStop = false;
            // 
            // pekePb
            // 
            this.pekePb.BackColor = System.Drawing.Color.Transparent;
            this.pekePb.BackgroundImage = global::MiniGame2.Properties.Resources.peke;
            this.pekePb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pekePb.Location = new System.Drawing.Point(12, 31);
            this.pekePb.Name = "pekePb";
            this.pekePb.Size = new System.Drawing.Size(597, 369);
            this.pekePb.TabIndex = 4;
            this.pekePb.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scoreLb
            // 
            this.scoreLb.AutoSize = true;
            this.scoreLb.BackColor = System.Drawing.Color.Transparent;
            this.scoreLb.Font = new System.Drawing.Font("MS UI Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scoreLb.Location = new System.Drawing.Point(442, 208);
            this.scoreLb.Name = "scoreLb";
            this.scoreLb.Size = new System.Drawing.Size(95, 38);
            this.scoreLb.TabIndex = 5;
            this.scoreLb.Text = "得点";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MiniGame2.Properties.Resources.back_marble;
            this.ClientSize = new System.Drawing.Size(621, 429);
            this.Controls.Add(this.yesPb);
            this.Controls.Add(this.pekePb);
            this.Controls.Add(this.answerLb);
            this.Controls.Add(this.scoreLb);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.questionLb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "足してナンボ？";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yesPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pekePb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label answerLb;
        private System.Windows.Forms.Label questionLb;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.PictureBox yesPb;
        private System.Windows.Forms.PictureBox pekePb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label scoreLb;
    }
}

