
namespace GraduationProject
{
    partial class AdminShowDataViewForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gamesCheckdLb = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userNameTb = new System.Windows.Forms.TextBox();
            this.userListButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.playDataGridView = new System.Windows.Forms.DataGridView();
            this.playDataSet = new GraduationProject.PlayDataSet();
            this.playDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maxPtCondTb = new System.Windows.Forms.TextBox();
            this.minPtCondTb = new System.Windows.Forms.TextBox();
            this.maxUnitLabel = new System.Windows.Forms.Label();
            this.minUnitLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.minScCondTb = new System.Windows.Forms.TextBox();
            this.maxScCondTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(745, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "期間";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(829, 31);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 23);
            this.startDatePicker.TabIndex = 1;
            this.startDatePicker.Value = new System.DateTime(2022, 3, 3, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(1036, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "から";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(830, 70);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 23);
            this.endDatePicker.TabIndex = 2;
            this.endDatePicker.Value = new System.DateTime(2022, 4, 3, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1036, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "まで";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(745, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "ゲーム";
            // 
            // gamesCheckdLb
            // 
            this.gamesCheckdLb.FormattingEnabled = true;
            this.gamesCheckdLb.Location = new System.Drawing.Point(829, 115);
            this.gamesCheckdLb.Name = "gamesCheckdLb";
            this.gamesCheckdLb.Size = new System.Drawing.Size(228, 112);
            this.gamesCheckdLb.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(745, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "ユーザー";
            // 
            // userNameTb
            // 
            this.userNameTb.Location = new System.Drawing.Point(829, 246);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.Size = new System.Drawing.Size(147, 23);
            this.userNameTb.TabIndex = 7;
            // 
            // userListButton
            // 
            this.userListButton.Location = new System.Drawing.Point(996, 242);
            this.userListButton.Name = "userListButton";
            this.userListButton.Size = new System.Drawing.Size(73, 31);
            this.userListButton.TabIndex = 8;
            this.userListButton.Text = "一覧";
            this.userListButton.UseVisualStyleBackColor = true;
            this.userListButton.Click += new System.EventHandler(this.userListButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(795, 400);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(127, 53);
            this.displayButton.TabIndex = 9;
            this.displayButton.Text = "表示";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(951, 400);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(118, 53);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // playDataGridView
            // 
            this.playDataGridView.AllowUserToAddRows = false;
            this.playDataGridView.AllowUserToDeleteRows = false;
            this.playDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playDataGridView.Location = new System.Drawing.Point(21, 19);
            this.playDataGridView.Name = "playDataGridView";
            this.playDataGridView.ReadOnly = true;
            this.playDataGridView.RowHeadersWidth = 62;
            this.playDataGridView.RowTemplate.Height = 27;
            this.playDataGridView.Size = new System.Drawing.Size(701, 457);
            this.playDataGridView.TabIndex = 11;
            // 
            // playDataSet
            // 
            this.playDataSet.DataSetName = "PlayDataSet";
            this.playDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // playDataTableBindingSource
            // 
            this.playDataTableBindingSource.DataMember = "playDataTable";
            this.playDataTableBindingSource.DataSource = this.playDataSet;
            // 
            // maxPtCondTb
            // 
            this.maxPtCondTb.Location = new System.Drawing.Point(957, 295);
            this.maxPtCondTb.Name = "maxPtCondTb";
            this.maxPtCondTb.Size = new System.Drawing.Size(98, 23);
            this.maxPtCondTb.TabIndex = 17;
            // 
            // minPtCondTb
            // 
            this.minPtCondTb.Location = new System.Drawing.Point(829, 295);
            this.minPtCondTb.Name = "minPtCondTb";
            this.minPtCondTb.Size = new System.Drawing.Size(93, 23);
            this.minPtCondTb.TabIndex = 18;
            // 
            // maxUnitLabel
            // 
            this.maxUnitLabel.AutoSize = true;
            this.maxUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.maxUnitLabel.Location = new System.Drawing.Point(927, 298);
            this.maxUnitLabel.Name = "maxUnitLabel";
            this.maxUnitLabel.Size = new System.Drawing.Size(24, 16);
            this.maxUnitLabel.TabIndex = 15;
            this.maxUnitLabel.Text = "～";
            // 
            // minUnitLabel
            // 
            this.minUnitLabel.AutoSize = true;
            this.minUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.minUnitLabel.Location = new System.Drawing.Point(1061, 345);
            this.minUnitLabel.Name = "minUnitLabel";
            this.minUnitLabel.Size = new System.Drawing.Size(24, 16);
            this.minUnitLabel.TabIndex = 16;
            this.minUnitLabel.Text = "点";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(745, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "プレイ時間";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(745, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "スコア";
            // 
            // minScCondTb
            // 
            this.minScCondTb.Location = new System.Drawing.Point(829, 343);
            this.minScCondTb.Name = "minScCondTb";
            this.minScCondTb.Size = new System.Drawing.Size(93, 23);
            this.minScCondTb.TabIndex = 18;
            // 
            // maxScCondTb
            // 
            this.maxScCondTb.Location = new System.Drawing.Point(957, 342);
            this.maxScCondTb.Name = "maxScCondTb";
            this.maxScCondTb.Size = new System.Drawing.Size(100, 23);
            this.maxScCondTb.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(1061, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "秒";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(921, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 16);
            this.label9.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(927, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "～";
            // 
            // AdminShowDataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProject.Properties.Resources.lblue;
            this.ClientSize = new System.Drawing.Size(1105, 495);
            this.Controls.Add(this.maxScCondTb);
            this.Controls.Add(this.maxPtCondTb);
            this.Controls.Add(this.minScCondTb);
            this.Controls.Add(this.minPtCondTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maxUnitLabel);
            this.Controls.Add(this.minUnitLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.playDataGridView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.userListButton);
            this.Controls.Add(this.userNameTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gamesCheckdLb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminShowDataViewForm";
            this.Text = "データのビュー表示";
            ((System.ComponentModel.ISupportInitialize)(this.playDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox gamesCheckdLb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userNameTb;
        private System.Windows.Forms.Button userListButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView playDataGridView;
        private System.Windows.Forms.BindingSource playDataTableBindingSource;
        private PlayDataSet playDataSet;
        private System.Windows.Forms.TextBox maxPtCondTb;
        private System.Windows.Forms.TextBox minPtCondTb;
        private System.Windows.Forms.Label maxUnitLabel;
        private System.Windows.Forms.Label minUnitLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minScCondTb;
        private System.Windows.Forms.TextBox maxScCondTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}