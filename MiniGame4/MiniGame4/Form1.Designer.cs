
namespace MiniGame4
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
            this.messageTb = new System.Windows.Forms.TextBox();
            this.startPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startPb)).BeginInit();
            this.SuspendLayout();
            // 
            // messageTb
            // 
            this.messageTb.BackColor = System.Drawing.Color.White;
            this.messageTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageTb.Enabled = false;
            this.messageTb.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.messageTb.ForeColor = System.Drawing.Color.Navy;
            this.messageTb.Location = new System.Drawing.Point(33, 17);
            this.messageTb.Margin = new System.Windows.Forms.Padding(4);
            this.messageTb.Multiline = true;
            this.messageTb.Name = "messageTb";
            this.messageTb.Size = new System.Drawing.Size(433, 106);
            this.messageTb.TabIndex = 0;
            // 
            // startPb
            // 
            this.startPb.BackgroundImage = global::MiniGame4.Properties.Resources.start_libra;
            this.startPb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startPb.Location = new System.Drawing.Point(164, 145);
            this.startPb.Name = "startPb";
            this.startPb.Size = new System.Drawing.Size(180, 80);
            this.startPb.TabIndex = 1;
            this.startPb.TabStop = false;
            this.startPb.Click += new System.EventHandler(this.mainPb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.startPb);
            this.Controls.Add(this.messageTb);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "何秒たったカナ？";
            ((System.ComponentModel.ISupportInitialize)(this.startPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTb;
        private System.Windows.Forms.PictureBox startPb;
    }
}

