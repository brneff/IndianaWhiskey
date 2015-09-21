using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace IndianaWhiskey
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a valid username.");
                txtUsername.Focus();
                return;
            }
            else if (txtPassword.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a valid password.");
                txtPassword.Focus();
                return;
            }
            else
            {
                int UserID = 0;
                DB db = new DB();
                try
                {
                    db.AddParam("@Username", txtUsername.Text.Trim());
                    db.AddParam("@Password", BMan_Encryption.EncryptPassword(txtPassword.Text.Trim(), ConfigurationManager.AppSettings["EncKey"]));
                    DataTable dtUser = db.SQLResults("usp_Login");
                    if (dtUser.Rows.Count > 0)
                    {
                        UserID = Convert.ToInt32(dtUser.Rows[0]["UserID"]);
                    }
                }
                catch (Exception ex)
                {
                    Common.LogError(ex, "Login.btnLogin_Click");
                }
                finally
                {
                    db.CleanUp();
                }

                if (UserID > 0)
                {
                    Menu m = new Menu(UserID);
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login or Password invalid. Please try again.");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                    return;
                }
            }

        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(btnLogin, new EventArgs());
            return;
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(btnLogin, new EventArgs());
            return;
        }
    }
}
