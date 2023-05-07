
namespace GraduationProject
{
    partial class AdminMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showInfoButton = new System.Windows.Forms.Button();
            this.updateDataButton = new System.Windows.Forms.Button();
            this.addGameButton = new System.Windows.Forms.Button();
            this.removeGameButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showInfoButton
            // 
            this.showInfoButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.showInfoButton.Location = new System.Drawing.Point(30, 27);
            this.showInfoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showInfoButton.Name = "showInfoButton";
            this.showInfoButton.Size = new System.Drawing.Size(243, 72);
            this.showInfoButton.TabIndex = 0;
            this.showInfoButton.Text = "情報表示";
            this.showInfoButton.UseVisualStyleBackColor = true;
            this.showInfoButton.Click += new System.EventHandler(this.showInfoButton_Click);
            // 
            // updateDataButton
            // 
            this.updateDataButton.Location = new System.Drawing.Point(30, 122);
            this.updateDataButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(243, 72);
            this.updateDataButton.TabIndex = 0;
            this.updateDataButton.Text = "データ更新";
            this.updateDataButton.UseVisualStyleBackColor = true;
            this.updateDataButton.Click += new System.EventHandler(this.updateDataButton_Click);
            // 
            // addGameButton
            // 
            this.addGameButton.BackColor = System.Drawing.SystemColors.Control;
            this.addGameButton.Location = new System.Drawing.Point(30, 225);
            this.addGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Size = new System.Drawing.Size(243, 72);
            this.addGameButton.TabIndex = 0;
            this.addGameButton.Text = "ミニゲーム登録";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // removeGameButton
            // 
            this.removeGameButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeGameButton.Location = new System.Drawing.Point(30, 330);
            this.removeGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.removeGameButton.Name = "removeGameButton";
            this.removeGameButton.Size = new System.Drawing.Size(243, 72);
            this.removeGameButton.TabIndex = 0;
            this.removeGameButton.Text = "ミニゲーム削除";
            this.removeGameButton.UseVisualStyleBackColor = true;
            this.removeGameButton.Click += new System.EventHandler(this.removeGameButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.Location = new System.Drawing.Point(30, 434);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(243, 72);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AdminMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(320, 550);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.removeGameButton);
            this.Controls.Add(this.addGameButton);
            this.Controls.Add(this.updateDataButton);
            this.Controls.Add(this.showInfoButton);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminMenuForm";
            this.Text = "管理メニュー";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showInfoButton;
        private System.Windows.Forms.Button updateDataButton;
        private System.Windows.Forms.Button addGameButton;
        private System.Windows.Forms.Button removeGameButton;
        private System.Windows.Forms.Button closeButton;
    }
}