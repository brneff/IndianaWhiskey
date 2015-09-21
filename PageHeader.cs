using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndianaWhiskey
{
    public partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            InitializeComponent();
        }

        public void SetHeader(string PageTitle, int UserID, int formWidth)
        {
            lblPageHeader.Text = PageTitle;
            lblUsername.Text = "Logged in as: " + GetUserName(UserID);
            lblPageHeader.Dock = DockStyle.Fill;
            this.Width = formWidth - 5;
        }

        private string GetUserName(int userID)
        {
            string strUserName = "";

            DB db = new DB();
            db.AddParam("@UserID", userID);
            DataTable dt = db.SQLResults("usp_UserNameGet");
            if (dt.Rows.Count >= 1 && dt.Rows[0]["UserName"] != null && dt.Rows[0]["UserName"] != DBNull.Value)
                strUserName = dt.Rows[0]["UserName"].ToString();
            db.CleanUp();

            return strUserName;
        }
    }
}
