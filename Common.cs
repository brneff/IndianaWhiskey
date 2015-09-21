using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace IndianaWhiskey
{
    public static class Common
    {
        public static void LogError(Exception ex, string functionName)
        {
            LogError(ex, functionName, 0);
        }
        public static void LogError(Exception ex, string functionName, int UserID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DSN"].ConnectionString);
            SqlCommand sqlComm = new SqlCommand("usp_ErrorLogAdd", sqlConn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@ErrorMessage", ex.Message);
            sqlComm.Parameters.AddWithValue("@Location", functionName);
            if (UserID > 0)
                sqlComm.Parameters.AddWithValue("@UserID", UserID);
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlComm.Dispose();
            sqlConn.Close();
            sqlConn.Dispose();
        }

        public static List<SqlParameter> parmList(string name, string value)
        {
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter(name, value));
            return lst;
        }

        public static List<SqlParameter> parmList(string name1, string value1, string name2, string value2)
        {
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter(name1, value1));
            lst.Add(new SqlParameter(name2, value2));
            return lst;
        }

        public static List<SqlParameter> parmList(string name1, string value1, string name2, string value2, string name3, string value3)
        {
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter(name1, value1));
            lst.Add(new SqlParameter(name2, value2));
            lst.Add(new SqlParameter(name3, value3));
            return lst;
        }

        public static void PopulateComboBox(string storedProc, ComboBox cbo, string colName, string colValue, List<SqlParameter> lstParams, BindingContext bindingContext)
        {
            if (cbo != null)
            {
                DB db = new DB();
                if (lstParams != null)
                {
                    foreach (SqlParameter p in lstParams)
                    {
                        db.AddParam(p.ParameterName, p.Value);
                    }
                }

                DataTable dt = db.SQLResults(storedProc);
                cbo.DataSource = dt;
                cbo.DisplayMember = colName;
                cbo.ValueMember = colValue;
                cbo.BindingContext = bindingContext;
            }
        }
    }
}
