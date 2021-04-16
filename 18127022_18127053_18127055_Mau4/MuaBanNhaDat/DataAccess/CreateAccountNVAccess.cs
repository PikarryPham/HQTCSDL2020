using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateAccountNVAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable CREATE_ACCOUNT_NV(string username, string pass, string ten, string sdt, string dchi, string ngaysinh, string cnlamviec, string cnquanly)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("CREATE_ACCOUNT_QLNHA_NV", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@USERNAME", username));
                command.Parameters.Add(new SqlParameter("@PASS", pass));
                command.Parameters.Add(new SqlParameter("@TEN", ten));
                command.Parameters.Add(new SqlParameter("@SDT", sdt));
                command.Parameters.Add(new SqlParameter("@DCHINV", dchi));
                //command.Parameters.Add(new SqlParameter("@NGAYSINH", ngaysinh));
                command.Parameters.Add(new SqlParameter("@NGAYSINH", ngaysinh)).Value = DateTime.Now.ToString();
                command.Parameters.Add(new SqlParameter("@CNLAMVIEC", cnlamviec));
                command.Parameters.Add(new SqlParameter("@CNQUANLY", cnquanly));

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
