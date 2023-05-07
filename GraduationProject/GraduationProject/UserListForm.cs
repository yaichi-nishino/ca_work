using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraduationProject
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
            List<User> users = Database.GetUsers();
            if (users != null && users.Count > 0)
            {
                foreach(User u in users)
                {
                    this.usersTb.Text += "\r\n"; 
                    this.usersTb.Text += u.UserName;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
