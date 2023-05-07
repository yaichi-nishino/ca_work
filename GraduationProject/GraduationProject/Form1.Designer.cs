
namespace GraduationProject
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainMenuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMenuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameButton1 = new System.Windows.Forms.Button();
            this.gameButton2 = new System.Windows.Forms.Button();
            this.gameButton3 = new System.Windows.Forms.Button();
            this.gameButton4 = new System.Windows.Forms.Button();
            this.gameButton5 = new System.Windows.Forms.Button();
            this.gameButton6 = new System.Windows.Forms.Button();
            this.userNameTb = new System.Windows.Forms.TextBox();
            this.logInOutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(656, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenuMenuItem
            // 
            this.MainMenuMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminMenuMenuItem,
            this.ExitMenuItem});
            this.MainMenuMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.MainMenuMenuItem.Name = "MainMenuMenuItem";
            this.MainMenuMenuItem.Size = new System.Drawing.Size(65, 25);
            this.MainMenuMenuItem.Text = "メニュー";
            // 
            // AdminMenuMenuItem
            // 
            this.AdminMenuMenuItem.Name = "AdminMenuMenuItem";
            this.AdminMenuMenuItem.Size = new System.Drawing.Size(155, 26);
            this.AdminMenuMenuItem.Text = "管理メニュー";
            this.AdminMenuMenuItem.Click += new System.EventHandler(this.AdminMenuMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(155, 26);
            this.ExitMenuItem.Text = "終了";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // gameButton1
            // 
            this.gameButton1.Location = new System.Drawing.Point(65, 62);
            this.gameButton1.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton1.Name = "gameButton1";
            this.gameButton1.Size = new System.Drawing.Size(147, 115);
            this.gameButton1.TabIndex = 1;
            this.gameButton1.Text = "ゲーム１";
            this.gameButton1.UseVisualStyleBackColor = true;
            this.gameButton1.Click += new System.EventHandler(this.gameButton1_Click);
            // 
            // gameButton2
            // 
            this.gameButton2.Location = new System.Drawing.Point(243, 62);
            this.gameButton2.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton2.Name = "gameButton2";
            this.gameButton2.Size = new System.Drawing.Size(147, 115);
            this.gameButton2.TabIndex = 1;
            this.gameButton2.Text = "ゲーム２";
            this.gameButton2.UseVisualStyleBackColor = true;
            this.gameButton2.Click += new System.EventHandler(this.gameButton2_Click);
            // 
            // gameButton3
            // 
            this.gameButton3.Location = new System.Drawing.Point(425, 62);
            this.gameButton3.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton3.Name = "gameButton3";
            this.gameButton3.Size = new System.Drawing.Size(147, 115);
            this.gameButton3.TabIndex = 1;
            this.gameButton3.Text = "ゲーム３";
            this.gameButton3.UseVisualStyleBackColor = true;
            this.gameButton3.Click += new System.EventHandler(this.gameButton3_Click);
            // 
            // gameButton4
            // 
            this.gameButton4.Location = new System.Drawing.Point(65, 204);
            this.gameButton4.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton4.Name = "gameButton4";
            this.gameButton4.Size = new System.Drawing.Size(147, 115);
            this.gameButton4.TabIndex = 1;
            this.gameButton4.Text = "ゲーム４";
            this.gameButton4.UseVisualStyleBackColor = true;
            this.gameButton4.Click += new System.EventHandler(this.gameButton4_Click);
            // 
            // gameButton5
            // 
            this.gameButton5.Location = new System.Drawing.Point(243, 204);
            this.gameButton5.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton5.Name = "gameButton5";
            this.gameButton5.Size = new System.Drawing.Size(147, 115);
            this.gameButton5.TabIndex = 1;
            this.gameButton5.Text = "ゲーム５";
            this.gameButton5.UseVisualStyleBackColor = true;
            this.gameButton5.Click += new System.EventHandler(this.gameButton5_Click);
            // 
            // gameButton6
            // 
            this.gameButton6.Location = new System.Drawing.Point(425, 204);
            this.gameButton6.Margin = new System.Windows.Forms.Padding(4);
            this.gameButton6.Name = "gameButton6";
            this.gameButton6.Size = new System.Drawing.Size(147, 115);
            this.gameButton6.TabIndex = 1;
            this.gameButton6.Text = "ゲーム６";
            this.gameButton6.UseVisualStyleBackColor = true;
            this.gameButton6.Click += new System.EventHandler(this.gameButton6_Click);
            // 
            // userNameTb
            // 
            this.userNameTb.ForeColor = System.Drawing.Color.Navy;
            this.userNameTb.Location = new System.Drawing.Point(110, 362);
            this.userNameTb.Margin = new System.Windows.Forms.Padding(4);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.Size = new System.Drawing.Size(210, 23);
            this.userNameTb.TabIndex = 2;
            this.userNameTb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.userNameTb_MouseDoubleClick);
            // 
            // logInOutButton
            // 
            this.logInOutButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logInOutButton.Location = new System.Drawing.Point(361, 354);
            this.logInOutButton.Margin = new System.Windows.Forms.Padding(4);
            this.logInOutButton.Name = "logInOutButton";
            this.logInOutButton.Size = new System.Drawing.Size(178, 31);
            this.logInOutButton.TabIndex = 3;
            this.logInOutButton.Text = "ログイン";
            this.logInOutButton.UseVisualStyleBackColor = true;
            this.logInOutButton.Click += new System.EventHandler(this.logInOutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "No.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "No.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "No.3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "No.4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "No.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "No.6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(656, 444);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logInOutButton);
            this.Controls.Add(this.userNameTb);
            this.Controls.Add(this.gameButton6);
            this.Controls.Add(this.gameButton5);
            this.Controls.Add(this.gameButton3);
            this.Controls.Add(this.gameButton4);
            this.Controls.Add(this.gameButton2);
            this.Controls.Add(this.gameButton1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ミニゲームパーク";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMenuMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.Button gameButton1;
        private System.Windows.Forms.Button gameButton2;
        private System.Windows.Forms.Button gameButton3;
        private System.Windows.Forms.Button gameButton4;
        private System.Windows.Forms.Button gameButton5;
        private System.Windows.Forms.Button gameButton6;
        private System.Windows.Forms.TextBox userNameTb;
        private System.Windows.Forms.Button logInOutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

