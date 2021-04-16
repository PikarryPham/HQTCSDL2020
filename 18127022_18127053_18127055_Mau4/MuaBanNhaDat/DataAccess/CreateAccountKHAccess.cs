using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateAccountKHAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable CREATE_ACCOUNT_KH(string ten, string sdt, string tchi, string dchi, string user, string pass, string cnhanh)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("CREATE_ACCOUNT_QLNHA_KH", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@USERNAME", user));
                command.Parameters.Add(new SqlParameter("@PASS", pass));
                command.Parameters.Add(new SqlParameter("@TEN", ten));
                command.Parameters.Add(new SqlParameter("@SDT", sdt));
                command.Parameters.Add(new SqlParameter("@TIEUCHIKH", tchi));
                command.Parameters.Add(new SqlParameter("@DCHIKH", dchi));
                command.Parameters.Add(new SqlParameter("@CHINHANHTHUOCVE", cnhanh));

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = command.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = command.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                ReturnCode = Convert.ToInt32(param_RETURNCODE.Value.ToString());
                ReturnMess = param_RETURNMESSAGE.Value.ToString();
            }
            catch (Exception ex)
            {
                ReturnCode = 500;
                ReturnMess = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return tbl;
        }
    }
}
