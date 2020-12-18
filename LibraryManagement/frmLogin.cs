using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        LoginDal _loginDal = new LoginDal();
        
        int loginId;
        private void btnLoginLogin_Click(object sender, EventArgs e)
        {
            bool checkLoginInformation = _loginDal.CheckLogin(tbxLoginUserName.Text, tbxLoginPassword.Text);

            if (checkLoginInformation)
            {
                loginId = _loginDal.GetUserIdByUserName(tbxLoginUserName.Text);
                frmMain frmmain = new frmMain(loginId);
                frmmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
        }
    }
}