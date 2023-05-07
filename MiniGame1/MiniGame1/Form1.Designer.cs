
namespace MiniGame1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backPb = new System.Windows.Forms.PictureBox();
            this.cakePb = new System.Windows.Forms.PictureBox();
            this.tamaPb = new System.Windows.Forms.PictureBox();
            this.basePb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cakePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamaPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePb)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backPb
            // 
            this.backPb.Image = global::MiniGame1.Properties.Resources.back_suna;
            this.backPb.Location = new System.Drawing.Point(211, 190);
            this.backPb.Name = "backPb";
            this.backPb.Size = new System.Drawing.Size(225, 64);
            this.backPb.TabIndex = 3;
            this.backPb.TabStop = false;
            // 
            // cakePb
            // 
            this.cakePb.BackColor = System.Drawing.Color.Transparent;
            this.cakePb.Image = global::MiniGame1.Properties.Resources.cake;
            this.cakePb.Location = new System.Drawing.Point(122, 190);
            this.cakePb.Name = "cakePb";
            this.cakePb.Size = new System.Drawing.Size(64, 64);
            this.cakePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cakePb.TabIndex = 2;
            this.cakePb.TabStop = false;
            // 
            // tamaPb
            // 
            this.tamaPb.BackColor = System.Drawing.Color.Transparent;
            this.tamaPb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tamaPb.Image = global::MiniGame1.Properties.Resources.black_cat;
            this.tamaPb.Location = new System.Drawing.Point(25, 190);
            this.tamaPb.Name = "tamaPb";
            this.tamaPb.Size = new System.Drawing.Size(64, 64);
            this.tamaPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tamaPb.TabIndex = 0;
            this.tamaPb.TabStop = false;
            // 
            // basePb
            // 
            this.basePb.Location = new System.Drawing.Point(-11, -4);
            this.basePb.Name = "basePb";
            this.basePb.Size = new System.Drawing.Size(487, 288);
            this.basePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.basePb.TabIndex = 1;
            this.basePb.TabStop = false;
            this.basePb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.basePb_MouseClick);
            this.basePb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.basePb_MouseDoubleClick);
            this.basePb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.basePb_MouseDown);
            this.basePb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.basePb_MouseMove);
            this.basePb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.basePb_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.backPb);
            this.Controls.Add(this.cakePb);
            this.Controls.Add(this.tamaPb);
            this.Controls.Add(this.basePb);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ケーキはどこにゃ？";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.backPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cakePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tamaPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tamaPb;
        private System.Windows.Forms.PictureBox basePb;
        private System.Windows.Forms.PictureBox cakePb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox backPb;
    }
}

