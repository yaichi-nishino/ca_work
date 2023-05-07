
namespace GraduationProject
{
    partial class UserListForm
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
            this.usersTb = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usersTb
            // 
            this.usersTb.Location = new System.Drawing.Point(19, 51);
            this.usersTb.Multiline = true;
            this.usersTb.Name = "usersTb";
            this.usersTb.ReadOnly = true;
            this.usersTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.usersTb.Size = new System.Drawing.Size(343, 293);
            this.usersTb.TabIndex = 0;
            this.usersTb.Text = "＜注意＞\r\nユーザー名は一部のみの指定も可能です.　なお、ユーザー名を指定すると、条件に適合するユーザーだけが対象になります.　すべてのユーザーを対象にしたい時に" +
    "は、入力しないでください.\r\n＝＝＝＝＝＝＝＝＝＝＝＝＝\r\n";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(247, 366);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(115, 44);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "登録されているユーザー";
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(399, 434);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.usersTb);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserListForm";
            this.Text = "ユーザー一覧";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usersTb;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
    }
}