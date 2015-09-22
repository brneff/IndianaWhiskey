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
    public partial class Mash : Form
    {
        int MinutesLeft, SecondsLeft;
        public Mash(int UserID)
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
                this.pageHeader1.SetHeader("Begin Mash", UserID, this.Width);
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

        private void btnBeginMash_Click(object sender, EventArgs e)
        {
            MinutesLeft = 44;
            SecondsLeft = 59;
            lblTimer.Text = MinutesLeft.ToString() + ":" + SecondsLeft.ToString();
            lblTimer.Visible = true;
            timerMash.Start();
        }

        private void timerMash_Tick(object sender, EventArgs e)
        {
            if (SecondsLeft == 0 && MinutesLeft == 0)
            {
                MessageBox.Show("Times up!");
                timerMash.Stop();
                lblTimer.Visible = false;
            }
            else if (SecondsLeft == 0)
            {
                MinutesLeft--;
                SecondsLeft = 49;
            }
            else
            {
                SecondsLeft--;
            }

            lblTimer.Text = MinutesLeft.ToString() + ":" + SecondsLeft.ToString();
        }
    }
}
