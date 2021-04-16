using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ThongKeNhaBanDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataSet THONGKE_FIX(string maNv, string quan, string thanhPho)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("THONGKE_FIX", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MANV", maNv));
                if (!string.IsNullOrWhiteSpace(quan))
                    command.Parameters.Add(new SqlParameter("@QUAN", quan));
                else
                    command.Parameters.Add(new SqlParameter("@QUAN", DBNull.Value));
                if (!string.IsNullOrWhiteSpace(thanhPho))
                    command.Parameters.Add(new SqlParameter("@TPHO", thanhPho));
                else
                    command.Parameters.Add(new SqlParameter("@TPHO", DBNull.Value));

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = command.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = command.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataSet);

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
            return dataSet;
        }

        public DataTable LoaiNha_GetAll()
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from LOAINHA", con);
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(tbl);
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

        public DataTable Nha_GetAll()
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from NHA", con);
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(tbl);
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

        public DataTable ChiNhanh_GetAll()
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from CHINHANH", con);
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(tbl);
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
