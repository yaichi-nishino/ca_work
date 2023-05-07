
namespace GraduationProject
{
    partial class AdminAddGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exeFileNameTb = new System.Windows.Forms.TextBox();
            this.gameNameTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.positionCb = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exeFileSelectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "実行ファイル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ゲーム名";
            // 
            // exeFileNameTb
            // 
            this.exeFileNameTb.Enabled = false;
            this.exeFileNameTb.Location = new System.Drawing.Point(169, 22);
            this.exeFileNameTb.Name = "exeFileNameTb";
            this.exeFileNameTb.Size = new System.Drawing.Size(121, 31);
            this.exeFileNameTb.TabIndex = 2;
            // 
            // gameNameTb
            // 
            this.gameNameTb.Location = new System.Drawing.Point(169, 80);
            this.gameNameTb.Name = "gameNameTb";
            this.gameNameTb.Size = new System.Drawing.Size(121, 31);
            this.gameNameTb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(32, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "登録位置";
            // 
            // positionCb
            // 
            this.positionCb.FormattingEnabled = true;
            this.positionCb.Location = new System.Drawing.Point(169, 139);
            this.positionCb.Name = "positionCb";
            this.positionCb.Size = new System.Drawing.Size(121, 32);
            this.positionCb.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(98, 199);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 40);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "登録";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(243, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(97, 40);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "中止";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exeFileSelectButton
            // 
            this.exeFileSelectButton.Location = new System.Drawing.Point(315, 22);
            this.exeFileSelectButton.Name = "exeFileSelectButton";
            this.exeFileSelectButton.Size = new System.Drawing.Size(85, 32);
            this.exeFileSelectButton.TabIndex = 9;
            this.exeFileSelectButton.Text = "選択";
            this.exeFileSelectButton.UseVisualStyleBackColor = true;
            this.exeFileSelectButton.Click += new System.EventHandler(this.exeFileSelectButton_Click);
            // 
            // AdminAddGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(433, 274);
            this.Controls.Add(this.exeFileSelectButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.positionCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gameNameTb);
            this.Controls.Add(this.exeFileNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminAddGameForm";
            this.Text = "ミニゲーム追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox exeFileNameTb;
        private System.Windows.Forms.TextBox gameNameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox positionCb;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exeFileSelectButton;
    }
}