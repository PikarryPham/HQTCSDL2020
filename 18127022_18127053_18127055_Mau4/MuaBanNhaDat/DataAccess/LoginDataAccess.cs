using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoginDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable LoginKH(string username, string password)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_LOGIN_KH_QLNHA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USERNAME", SqlDbType.Char).Value = username;
                cmd.Parameters.Add("@PASS", SqlDbType.NVarChar).Value = password;

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = cmd.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = cmd.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tbl);

                //cmd.ExecuteNonQuery();

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

        public DataTable LoginCN(string username, string password)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_LOGIN_CN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USERNAME", SqlDbType.Char).Value = username;
                cmd.Parameters.Add("@PASS", SqlDbType.NVarChar).Value = password;

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = cmd.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = cmd.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tbl);

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

        public DataTable LoginNV(string username, string password)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_LOGIN_NHANVIEN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USERNAME", SqlDbType.Char).Value = username;
                cmd.Parameters.Add("@PASS", SqlDbType.NVarChar).Value = password;

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = cmd.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = cmd.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tbl);

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
