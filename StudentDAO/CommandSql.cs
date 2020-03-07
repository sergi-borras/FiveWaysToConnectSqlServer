using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAO
{
    public class CommandSql
    {
        public SqlCommand Command { get; private set; }
        public CommandSql(string query, Connection connection)
        {
            Command = new SqlCommand(query, connection.GetConnection);
        }
    }
}
