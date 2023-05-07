
namespace DrawAppl2
{
    partial class Pallet
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
            this.circleButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.penSizeBox = new System.Windows.Forms.TextBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.fillCheckBox = new System.Windows.Forms.CheckBox();
            this.curveButton = new System.Windows.Forms.Button();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // circleButton
            // 
            this.circleButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.circleButton.Location = new System.Drawing.Point(13, 13);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(60, 53);
            this.circleButton.TabIndex = 0;
            this.circleButton.Text = "まる";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.CircleButtonClicked);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rectangleButton.Location = new System.Drawing.Point(89, 13);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(60, 53);
            this.rectangleButton.TabIndex = 1;
            this.rectangleButton.Text = "しかく";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.RectangleButtonClicked);
            // 
            // lineButton
            // 
            this.lineButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lineButton.Location = new System.Drawing.Point(162, 13);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(60, 53);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "せん";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.LineButtonClicked);
            // 
            // penSizeBox
            // 
            this.penSizeBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.penSizeBox.Location = new System.Drawing.Point(387, 42);
            this.penSizeBox.Name = "penSizeBox";
            this.penSizeBox.Size = new System.Drawing.Size(53, 23);
            this.penSizeBox.TabIndex = 3;
            this.penSizeBox.Text = "3";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.colorButton.Location = new System.Drawing.Point(325, 16);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(31, 21);
            this.colorButton.TabIndex = 4;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.ColorButtonClicked);
            // 
            // fillCheckBox
            // 
            this.fillCheckBox.Checked = true;
            this.fillCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fillCheckBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fillCheckBox.Location = new System.Drawing.Point(404, 18);
            this.fillCheckBox.Name = "fillCheckBox";
            this.fillCheckBox.Size = new System.Drawing.Size(36, 19);
            this.fillCheckBox.TabIndex = 5;
            this.fillCheckBox.Text = "塗";
            this.fillCheckBox.UseVisualStyleBackColor = false;
            // 
            // curveButton
            // 
            this.curveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.curveButton.Location = new System.Drawing.Point(244, 13);
            this.curveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.curveButton.Name = "curveButton";
            this.curveButton.Size = new System.Drawing.Size(60, 53);
            this.curveButton.TabIndex = 6;
            this.curveButton.Text = "カーブ";
            this.curveButton.UseVisualStyleBackColor = true;
            this.curveButton.Click += new System.EventHandler(this.CurveButtonClicked);
            // 
            // colorButton2
            // 
            this.colorButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.colorButton2.Location = new System.Drawing.Point(357, 16);
            this.colorButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(31, 21);
            this.colorButton2.TabIndex = 7;
            this.colorButton2.UseVisualStyleBackColor = false;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(325, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "線の太さ";
            // 
            // Pallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 89);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorButton2);
            this.Controls.Add(this.curveButton);
            this.Controls.Add(this.fillCheckBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.penSizeBox);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.circleButton);
            this.Name = "Pallet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pallet";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.TextBox penSizeBox;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.CheckBox fillCheckBox;
        private System.Windows.Forms.Button curveButton;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.Label label1;
    }
}