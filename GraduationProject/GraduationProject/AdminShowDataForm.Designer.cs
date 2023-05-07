
namespace GraduationProject
{
    partial class AdminShowDataForm
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
            this.viewButton = new System.Windows.Forms.Button();
            this.graphButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(47, 217);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(146, 50);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "ビュー表示";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(209, 217);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(146, 50);
            this.graphButton.TabIndex = 0;
            this.graphButton.Text = "グラフ表示";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(47, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(461, 176);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "対象とする期間や、ミニゲームの種類、ユーザーなど、細かく条件を指定して、情報をみたい時は、『ビュー表示』を利用してください.\r\n\r\n『グラフ表示』では、指定できる" +
    "条件は少なくなりますが、今月多くプレイされているゲームなど、よく利用される情報をグラフで確認できます.";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(369, 217);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(146, 50);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AdminShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(559, 292);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.viewButton);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminShowDataForm";
            this.Text = "情報表示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button closeButton;
    }
}