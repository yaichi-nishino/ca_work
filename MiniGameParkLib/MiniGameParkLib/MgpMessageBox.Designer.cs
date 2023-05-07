
namespace MiniGameParkLib
{
    partial class MgpMessageBox
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
            this.iconPb = new System.Windows.Forms.PictureBox();
            this.messageTb = new System.Windows.Forms.TextBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconPb)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPb
            // 
            this.iconPb.BackColor = System.Drawing.Color.Transparent;
            this.iconPb.Location = new System.Drawing.Point(12, 24);
            this.iconPb.Name = "iconPb";
            this.iconPb.Size = new System.Drawing.Size(48, 48);
            this.iconPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPb.TabIndex = 0;
            this.iconPb.TabStop = false;
            // 
            // messageTb
            // 
            this.messageTb.BackColor = System.Drawing.Color.White;
            this.messageTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageTb.Enabled = false;
            this.messageTb.ForeColor = System.Drawing.Color.Navy;
            this.messageTb.Location = new System.Drawing.Point(82, 24);
            this.messageTb.Multiline = true;
            this.messageTb.Name = "messageTb";
            this.messageTb.ReadOnly = true;
            this.messageTb.Size = new System.Drawing.Size(282, 93);
            this.messageTb.TabIndex = 1;
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.leftButton.Location = new System.Drawing.Point(115, 133);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(113, 46);
            this.leftButton.TabIndex = 2;
            this.leftButton.Text = "buttonLeft";
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rightButton.Location = new System.Drawing.Point(251, 133);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(113, 46);
            this.rightButton.TabIndex = 2;
            this.rightButton.Text = "buttonRight";
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // MgpMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MiniGameParkLib.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(391, 196);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.messageTb);
            this.Controls.Add(this.iconPb);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MgpMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MgpMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.iconPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPb;
        private System.Windows.Forms.TextBox messageTb;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}