
namespace MiniGame5
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
            this.bluePb = new System.Windows.Forms.PictureBox();
            this.redPb = new System.Windows.Forms.PictureBox();
            this.greenPb = new System.Windows.Forms.PictureBox();
            this.yellowPb = new System.Windows.Forms.PictureBox();
            this.startPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bluePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPb)).BeginInit();
            this.SuspendLayout();
            // 
            // bluePb
            // 
            this.bluePb.BackColor = System.Drawing.Color.Transparent;
            this.bluePb.Image = global::MiniGame5.Properties.Resources.bt_blue_dark;
            this.bluePb.Location = new System.Drawing.Point(12, 12);
            this.bluePb.Name = "bluePb";
            this.bluePb.Size = new System.Drawing.Size(192, 83);
            this.bluePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bluePb.TabIndex = 0;
            this.bluePb.TabStop = false;
            this.bluePb.Click += new System.EventHandler(this.bluePb_Click);
            // 
            // redPb
            // 
            this.redPb.BackColor = System.Drawing.Color.Transparent;
            this.redPb.Image = global::MiniGame5.Properties.Resources.bt_red_dark;
            this.redPb.Location = new System.Drawing.Point(225, 12);
            this.redPb.Name = "redPb";
            this.redPb.Size = new System.Drawing.Size(192, 83);
            this.redPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redPb.TabIndex = 0;
            this.redPb.TabStop = false;
            this.redPb.Click += new System.EventHandler(this.redPb_Click);
            // 
            // greenPb
            // 
            this.greenPb.BackColor = System.Drawing.Color.Transparent;
            this.greenPb.Image = global::MiniGame5.Properties.Resources.bt_green_dark;
            this.greenPb.Location = new System.Drawing.Point(12, 110);
            this.greenPb.Name = "greenPb";
            this.greenPb.Size = new System.Drawing.Size(192, 83);
            this.greenPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenPb.TabIndex = 0;
            this.greenPb.TabStop = false;
            this.greenPb.Click += new System.EventHandler(this.greenPb_Click);
            // 
            // yellowPb
            // 
            this.yellowPb.BackColor = System.Drawing.Color.Transparent;
            this.yellowPb.Image = global::MiniGame5.Properties.Resources.bt_yellow_dark;
            this.yellowPb.Location = new System.Drawing.Point(225, 110);
            this.yellowPb.Name = "yellowPb";
            this.yellowPb.Size = new System.Drawing.Size(192, 83);
            this.yellowPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yellowPb.TabIndex = 0;
            this.yellowPb.TabStop = false;
            this.yellowPb.Click += new System.EventHandler(this.yellowPb_Click);
            // 
            // startPb
            // 
            this.startPb.Image = global::MiniGame5.Properties.Resources.start_bt2;
            this.startPb.Location = new System.Drawing.Point(149, 209);
            this.startPb.Name = "startPb";
            this.startPb.Size = new System.Drawing.Size(128, 64);
            this.startPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.startPb.TabIndex = 1;
            this.startPb.TabStop = false;
            this.startPb.Click += new System.EventHandler(this.startPb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 287);
            this.Controls.Add(this.startPb);
            this.Controls.Add(this.yellowPb);
            this.Controls.Add(this.greenPb);
            this.Controls.Add(this.redPb);
            this.Controls.Add(this.bluePb);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "記憶の限界に挑戦";
            ((System.ComponentModel.ISupportInitialize)(this.bluePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bluePb;
        private System.Windows.Forms.PictureBox redPb;
        private System.Windows.Forms.PictureBox greenPb;
        private System.Windows.Forms.PictureBox yellowPb;
        private System.Windows.Forms.PictureBox startPb;
    }
}

