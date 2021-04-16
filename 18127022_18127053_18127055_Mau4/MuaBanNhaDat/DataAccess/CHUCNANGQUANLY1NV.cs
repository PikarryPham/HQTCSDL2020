using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CHUCNANGQUANLY1NV
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable chucnangquanly_select_LU2_FIX(string manv, string luong, string sdt, string dchinv)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("chucnangquanly_select_LU2_FIX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrWhiteSpace(manv))
                    cmd.Parameters.Add(new SqlParameter("@MANV", manv));
                else
                    cmd.Parameters.Add(new SqlParameter("@MANV", DBNull.Value));

               /*Tiền lương*/
                float bonusNha;
                if (!string.IsNullOrWhiteSpace(luong) && float.TryParse(luong, out bonusNha))
                    cmd.Parameters.Add("@LUONG", SqlDbType.Int).Value = luong;
                else
                    cmd.Parameters.Add("@LUONG", SqlDbType.Int).Value = DBNull.Value;

                if (!string.IsNullOrWhiteSpace(manv))
                    cmd.Parameters.Add(new SqlParameter("@SDT", manv));
                else
                    cmd.Parameters.Add(new SqlParameter("@SDT", DBNull.Value));

                if (!string.IsNullOrWhiteSpace(manv))
                    cmd.Parameters.Add(new SqlParameter("@DCHI_NV", manv));
                else
                    cmd.Parameters.Add(new SqlParameter("@DCHI_NV", DBNull.Value));

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
