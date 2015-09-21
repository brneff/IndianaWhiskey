using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianaWhiskey
{
    public class DB
    {
        private SqlConnection _conn = null;
        private SqlCommand _comm = null;
        private SqlDataAdapter _da = null;
        private List<SqlParameter> _params = null;

        public DB()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DSN"].ConnectionString);
            _params = new List<SqlParameter>();
        }
        ~DB()
        {
            CloseConn();
        }

        private void OpenConn()
        {
            if (_conn == null)
                _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DSN"].ConnectionString);
            _conn.Open();
        }
        private void CloseConn()
        {
            if (_conn != null)
            {
                if (_conn.State != ConnectionState.Closed)
                    _conn.Close();
                _conn.Dispose();
            }
        }

        public void CleanUp()
        {
            CloseConn();
        }
        public void AddParam(string name, object val)
        {
            SqlParameter s = new SqlParameter(name, val);
            _params.Add(s);
        }
        public DataTable SQLResults(string strSQL)
        {
            return SQLResults(strSQL, true);
        }
        public DataTable SQLResults(string strSQL, bool isSP)
        {
            DataTable dtReturn = new DataTable();

            try
            {
                OpenConn();
                _comm = new SqlCommand(strSQL, _conn);
                if (isSP)
                    _comm.CommandType = CommandType.StoredProcedure;
                _comm.CommandTimeout = 300;
                if (_params != null)
                {
                    foreach (SqlParameter s in _params)
                    {
                        _comm.Parameters.Add(s);
                    }
                }
                _da = new SqlDataAdapter(_comm);
                _da.Fill(dtReturn);
            }
            catch (Exception ex)
            {
                Common.LogError(ex, "DB.SQLResults");
                dtReturn = null;
            }
            finally
            {
                CloseConn();
            }

            return dtReturn;
        }
    }
}
