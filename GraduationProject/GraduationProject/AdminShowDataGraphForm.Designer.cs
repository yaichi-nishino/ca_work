
namespace GraduationProject
{
    partial class AdminShowDataGraphForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.displayButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.targetItemCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.totalButton = new System.Windows.Forms.RadioButton();
            this.partialButton = new System.Windows.Forms.RadioButton();
            this.gameOptionPanel = new System.Windows.Forms.Panel();
            this.minUnitLabel = new System.Windows.Forms.Label();
            this.minCondTb = new System.Windows.Forms.TextBox();
            this.maxCondTb = new System.Windows.Forms.TextBox();
            this.maxUnitLabel = new System.Windows.Forms.Label();
            this.minLessOrThanCb = new System.Windows.Forms.ComboBox();
            this.maxMoreOrThanCb = new System.Windows.Forms.ComboBox();
            this.gameOptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(41, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "期間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(41, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "種別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(41, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "対象";
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(70, 299);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(119, 50);
            this.displayButton.TabIndex = 3;
            this.displayButton.Text = "表示";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(213, 299);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(119, 50);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // targetItemCb
            // 
            this.targetItemCb.FormattingEnabled = true;
            this.targetItemCb.Location = new System.Drawing.Point(132, 184);
            this.targetItemCb.Name = "targetItemCb";
            this.targetItemCb.Size = new System.Drawing.Size(159, 24);
            this.targetItemCb.TabIndex = 5;
            this.targetItemCb.SelectedIndexChanged += new System.EventHandler(this.targetItemCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(344, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "から";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(343, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "まで";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(132, 26);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 23);
            this.startDatePicker.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(132, 65);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 23);
            this.endDatePicker.TabIndex = 6;
            // 
            // totalButton
            // 
            this.totalButton.AutoSize = true;
            this.totalButton.Location = new System.Drawing.Point(20, 9);
            this.totalButton.Name = "totalButton";
            this.totalButton.Size = new System.Drawing.Size(58, 20);
            this.totalButton.TabIndex = 7;
            this.totalButton.TabStop = true;
            this.totalButton.Text = "概要";
            this.totalButton.UseVisualStyleBackColor = true;
            // 
            // partialButton
            // 
            this.partialButton.AutoSize = true;
            this.partialButton.Location = new System.Drawing.Point(20, 35);
            this.partialButton.Name = "partialButton";
            this.partialButton.Size = new System.Drawing.Size(58, 20);
            this.partialButton.TabIndex = 7;
            this.partialButton.TabStop = true;
            this.partialButton.Text = "詳細";
            this.partialButton.UseVisualStyleBackColor = true;
            this.partialButton.CheckedChanged += new System.EventHandler(this.partialButton_CheckedChanged);
            // 
            // gameOptionPanel
            // 
            this.gameOptionPanel.BackColor = System.Drawing.Color.Transparent;
            this.gameOptionPanel.Controls.Add(this.totalButton);
            this.gameOptionPanel.Controls.Add(this.partialButton);
            this.gameOptionPanel.Location = new System.Drawing.Point(132, 94);
            this.gameOptionPanel.Name = "gameOptionPanel";
            this.gameOptionPanel.Size = new System.Drawing.Size(100, 71);
            this.gameOptionPanel.TabIndex = 8;
            // 
            // minUnitLabel
            // 
            this.minUnitLabel.AutoSize = true;
            this.minUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.minUnitLabel.Location = new System.Drawing.Point(238, 221);
            this.minUnitLabel.Name = "minUnitLabel";
            this.minUnitLabel.Size = new System.Drawing.Size(24, 16);
            this.minUnitLabel.TabIndex = 9;
            this.minUnitLabel.Text = "点";
            // 
            // minCondTb
            // 
            this.minCondTb.Location = new System.Drawing.Point(132, 214);
            this.minCondTb.Name = "minCondTb";
            this.minCondTb.Size = new System.Drawing.Size(100, 23);
            this.minCondTb.TabIndex = 10;
            // 
            // maxCondTb
            // 
            this.maxCondTb.Location = new System.Drawing.Point(132, 243);
            this.maxCondTb.Name = "maxCondTb";
            this.maxCondTb.Size = new System.Drawing.Size(100, 23);
            this.maxCondTb.TabIndex = 10;
            // 
            // maxUnitLabel
            // 
            this.maxUnitLabel.AutoSize = true;
            this.maxUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.maxUnitLabel.Location = new System.Drawing.Point(238, 246);
            this.maxUnitLabel.Name = "maxUnitLabel";
            this.maxUnitLabel.Size = new System.Drawing.Size(24, 16);
            this.maxUnitLabel.TabIndex = 9;
            this.maxUnitLabel.Text = "点";
            // 
            // minLessOrThanCb
            // 
            this.minLessOrThanCb.FormattingEnabled = true;
            this.minLessOrThanCb.Location = new System.Drawing.Point(268, 214);
            this.minLessOrThanCb.Name = "minLessOrThanCb";
            this.minLessOrThanCb.Size = new System.Drawing.Size(108, 24);
            this.minLessOrThanCb.TabIndex = 11;
            // 
            // maxMoreOrThanCb
            // 
            this.maxMoreOrThanCb.FormattingEnabled = true;
            this.maxMoreOrThanCb.Location = new System.Drawing.Point(268, 243);
            this.maxMoreOrThanCb.Name = "maxMoreOrThanCb";
            this.maxMoreOrThanCb.Size = new System.Drawing.Size(108, 24);
            this.maxMoreOrThanCb.TabIndex = 11;
            // 
            // AdminShowDataGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(396, 373);
            this.Controls.Add(this.maxMoreOrThanCb);
            this.Controls.Add(this.minLessOrThanCb);
            this.Controls.Add(this.maxCondTb);
            this.Controls.Add(this.minCondTb);
            this.Controls.Add(this.maxUnitLabel);
            this.Controls.Add(this.minUnitLabel);
            this.Controls.Add(this.gameOptionPanel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.targetItemCb);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminShowDataGraphForm";
            this.Text = "データのグラフ表示";
            this.gameOptionPanel.ResumeLayout(false);
            this.gameOptionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox targetItemCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.RadioButton totalButton;
        private System.Windows.Forms.RadioButton partialButton;
        private System.Windows.Forms.Panel gameOptionPanel;
        private System.Windows.Forms.Label minUnitLabel;
        private System.Windows.Forms.TextBox minCondTb;
        private System.Windows.Forms.TextBox maxCondTb;
        private System.Windows.Forms.Label maxUnitLabel;
        private System.Windows.Forms.ComboBox minLessOrThanCb;
        private System.Windows.Forms.ComboBox maxMoreOrThanCb;
    }
}