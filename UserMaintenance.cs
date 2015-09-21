using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace IndianaWhiskey
{
    public partial class UserMaintenance : Form
    {
        int UserID = 0;

        public UserMaintenance()
        {
            InitializeComponent();
        }

        public UserMaintenance(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu(UserID);
            m.Show();
            this.Hide();
        }

        private void UserMaintenance_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable dtUT = db.SQLResults("usp_UserTypeList");
            cboUserType.DataSource = dtUT;
            cboUserType.DisplayMember = "Description";
            cboUserType.ValueMember = "UserTypeID";
            db.CleanUp();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a first name.");
                txtFirstName.Focus();
                return;
            }
            else if (txtLastName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a last name.");
                txtLastName.Focus();
                return;
            }
            else if (txtUsername.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a username.");
                txtUsername.Focus();
                return;
            }
            else if (txtPassword.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a password.");
                txtPassword.Focus();
                return;
            }
            else if (txtPasswordConfirm.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please confirm your password.");
                txtPasswordConfirm.Focus();
                return;
            }
            else if (txtPassword.Text.Trim() != txtPasswordConfirm.Text.Trim())
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                txtPassword.Text = "";
                txtPasswordConfirm.Text = "";
                txtPassword.Focus();
                return;
            }
            else if (cboUserType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user type.");
                cboUserType.Focus();
                return;
            }
            else
            {
                UserID = 0;
                DB db = new DB();
                try
                {
                    db.AddParam("@FirstName", txtFirstName.Text.Trim());
                    db.AddParam("@LastName", txtLastName.Text.Trim());
                    db.AddParam("@Username", txtUsername.Text.Trim());
                    db.AddParam("@Password", BMan_Encryption.EncryptPassword(txtPassword.Text.Trim(), ConfigurationManager.AppSettings["EncKey"]));
                    db.AddParam("@UserTypeID", cboUserType.SelectedValue);
                    DataTable dtUser = db.SQLResults("usp_UserAdd");
                    if (dtUser.Rows.Count > 0)
                    {
                        UserID = Convert.ToInt32(dtUser.Rows[0]["UserID"]);
                    }
                }
                catch (Exception ex)
                {
                    Common.LogError(ex, "UserMaintenance.btnSave_Click");
                    UserID = 0;
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
                else if (UserID == -1)
                {
                    MessageBox.Show("Username already exists. Please enter a different one.");
                    txtUsername.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Error adding user. Please try again.");
                    return;
                }
            }
        }
    }
}
