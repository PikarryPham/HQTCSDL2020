using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataConnection
    {
            public static SqlConnection GetSqlConnection()
            {
                string connectionString = @"Data Source=.;Initial Catalog=QLBAN_THUENHA;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                return con;
            }
    }
}
