using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAO
{
    public class Connection
    {
        public SqlConnection GetConnection { get; }
        public Connection()
        {
            GetConnection = new SqlConnection(Resources.sqlConnection);
        }
        public void OpenConnection()
        {
            try
            {
                GetConnection.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void CloseConnection()
        {
            GetConnection.Close();
        }
    }
}
