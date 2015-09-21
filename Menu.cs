using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndianaWhiskey
{
    public partial class Menu : Form
    {
        private int _userID;
        public Menu(int UserID)
        {
            Size MinButtonSize = new System.Drawing.Size(290, 30);

            InitializeComponent();
            if (UserID <= 0)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                _userID = UserID;

                DB db = new DB();
                db.AddParam("@UserID", UserID);
                DataTable dtMenu = db.SQLResults("usp_MenuGet");

                foreach (DataRow dr in dtMenu.Rows)
                {
                    Button btn = new Button();
                    btn.AutoSize = true;
                    btn.BackColor = Color.Azure;
                    btn.MinimumSize = MinButtonSize;
                    btn.Text = dr["DisplayName"].ToString();
                    btn.Name = dr["MenuID"].ToString();
                    btn.Margin = new Padding(3,0,0,0);
                    btn.Click += new EventHandler(btnMenu_Click);

                    flpMenu.Controls.Add(btn);
                }
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.AddParam("@MenuID", ((Button)sender).Name);
            DataTable dt = db.SQLResults("usp_MenuGetByID");

            Assembly assembly = Assembly.Load("IndianaWhiskey");
            Type t = assembly.GetType("IndianaWhiskey." + dt.Rows[0]["FormName"].ToString());
            Form frmNext = (Form)Activator.CreateInstance(t, _userID);

            frmNext.Show(this);
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
