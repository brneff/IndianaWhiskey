using System;
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
    public partial class Base : Form
    {
        public Base(int UserID)
        {
            InitializeComponent();
            if (UserID <= 0)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                this.pageHeader1.SetHeader("Base Page", UserID, this.Width);
                PopulateControls();
            }
        }

        protected void PopulateControls()
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
