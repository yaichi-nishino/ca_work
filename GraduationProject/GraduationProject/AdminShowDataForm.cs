using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGameParkLib;


namespace GraduationProject
{
    public partial class AdminShowDataForm : Form
    {
        public AdminShowDataForm()
        {
            InitializeComponent();
        }

        //** 表示用クラスで使われる共通メソッド
        public static double ParseDoubleFromValue(string val)
        {
            double retVal;
            if (val == null || val == "")
            {
                retVal = Double.NaN;
            }
            else
            {
                bool res = Double.TryParse(val, out retVal);
                if (!res) throw new ApplicationException(
                                  "数値として不適切な値（" + val 
                                  + "）が指定されています.");
            }
            return retVal;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminShowDataViewForm();
                f.ShowDialog();
                f.Close();
            }
            catch (ApplicationException exception)
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              exception.Message,
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
                messageBox.Close();
            }
        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new AdminShowDataGraphForm();
                f.ShowDialog();
                f.Close();
            }
            catch (ApplicationException exception)
            {
                MgpMessageBox messageBox
                    = new MgpMessageBox(
                              this,
                              exception.Message,
                              "エラー",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                messageBox.ShowDialog();
                messageBox.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
