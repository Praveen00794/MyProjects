using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjects.DAL
{
    public partial class MyprojectsDAL
    {
        private static System.Data.SqlClient.SqlConnection _SqlConn;
        public static System.Data.SqlClient.SqlConnection GetConnection
        {
            get
            {
                _SqlConn = new System.Data.SqlClient.SqlConnection();
                _SqlConn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["dbConnstreSmart"];
                if (_SqlConn.State == System.Data.ConnectionState.Closed)
                {
                    _SqlConn.Open();

                }
                return _SqlConn;
            }

        }
                public static void CloseConnection()
        {
            _SqlConn = new System.Data.SqlClient.SqlConnection();
            _SqlConn.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["dbConnstreSmart"];
            if (_SqlConn.State == System.Data.ConnectionState.Open)
            {
                _SqlConn.Close();
                _SqlConn.Dispose();
            }
            System.Data.SqlClient.SqlConnection.ClearPool(_SqlConn);
        }
    }
}
