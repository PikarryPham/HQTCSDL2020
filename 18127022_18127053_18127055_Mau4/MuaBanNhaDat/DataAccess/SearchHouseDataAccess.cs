using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SearchHouseDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }
        public string ReturnSLNha { get; set; }

        public DataTable TIMNHATHEOGIA(string gianha)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TRAN_TIMKIEMTIEUCHI_NB1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int intGiaNha;
                if (!string.IsNullOrWhiteSpace(gianha) && int.TryParse(gianha, out intGiaNha))
                    cmd.Parameters.Add("@GIABAN", SqlDbType.Int).Value = gianha;
                else
                    cmd.Parameters.Add("@GIABAN", SqlDbType.Int).Value = DBNull.Value;
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
