using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TangGiamLuong
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable TANGGIAM_LUONGNV_FIX(string manv, string tienbonus)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TANGGIAM_LUONGNV_FIX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrWhiteSpace(manv))
                    cmd.Parameters.Add(new SqlParameter("@MANV", manv));
                else
                    cmd.Parameters.Add(new SqlParameter("@MANV", DBNull.Value));
                float bonusNha;
                if (!string.IsNullOrWhiteSpace(tienbonus) && float.TryParse(tienbonus, out bonusNha))
                    cmd.Parameters.Add("@BONUSTIP", SqlDbType.Int).Value = tienbonus;
                else
                    cmd.Parameters.Add("@BONUSTIP", SqlDbType.Int).Value = DBNull.Value;
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
