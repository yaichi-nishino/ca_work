
namespace DrawAppl2
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
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EraseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraseAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraseOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenu,
            this.EraseMenuItem,
            this.SaveToolMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(43, 22);
            this.ExitMenu.Text = "終了";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenuSelected);
            // 
            // EraseMenuItem
            // 
            this.EraseMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EraseAllMenuItem,
            this.EraseOneMenuItem,
            this.RedoOneMenuItem});
            this.EraseMenuItem.Name = "EraseMenuItem";
            this.EraseMenuItem.Size = new System.Drawing.Size(41, 22);
            this.EraseMenuItem.Text = "消す";
            // 
            // EraseAllMenuItem
            // 
            this.EraseAllMenuItem.Name = "EraseAllMenuItem";
            this.EraseAllMenuItem.Size = new System.Drawing.Size(134, 22);
            this.EraseAllMenuItem.Text = "全部";
            this.EraseAllMenuItem.Click += new System.EventHandler(this.EraseAllMenuSelected);
            // 
            // EraseOneMenuItem
            // 
            this.EraseOneMenuItem.Name = "EraseOneMenuItem";
            this.EraseOneMenuItem.Size = new System.Drawing.Size(134, 22);
            this.EraseOneMenuItem.Text = "ひとつだけ";
            this.EraseOneMenuItem.Click += new System.EventHandler(this.EraseOneMenuSelected);
            // 
            // RedoOneMenuItem
            // 
            this.RedoOneMenuItem.Name = "RedoOneMenuItem";
            this.RedoOneMenuItem.Size = new System.Drawing.Size(134, 22);
            this.RedoOneMenuItem.Text = "消すのはヤメ";
            this.RedoOneMenuItem.Click += new System.EventHandler(this.RedoOneMenuSelected);
            // 
            // SaveToolMenu
            // 
            this.SaveToolMenu.Name = "SaveToolMenu";
            this.SaveToolMenu.Size = new System.Drawing.Size(43, 22);
            this.SaveToolMenu.Text = "保存";
            this.SaveToolMenu.Click += new System.EventHandler(this.SaveToolMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 349);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ドローアプリ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawFigures);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseDragged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpped);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem EraseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraseAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraseOneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoOneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolMenu;
    }
}

