﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DangThongTinNhaDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable INSERT_HOUSE_BAN_CHUNHA_FIX(string loaiNha, string tinhTrang, int giaBan, string khuVuc, string duong, string quan, string thanhPho, DateTime ngayHetHan,
            string dieuKien, int soLuongPhong, string chiNhanh)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("INSERT_HOUSE_BAN_CHUNHA_FIX", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LOAINHA", loaiNha));
                command.Parameters.Add(new SqlParameter("@TINHTRANG", tinhTrang));
                command.Parameters.Add(new SqlParameter("@GIABAN", giaBan));
                command.Parameters.Add(new SqlParameter("@KHUVUC", khuVuc));
                command.Parameters.Add(new SqlParameter("@DUONG", duong));
                command.Parameters.Add(new SqlParameter("@QUAN", quan));
                command.Parameters.Add(new SqlParameter("@TPHO", thanhPho));
                command.Parameters.Add(new SqlParameter("@NGAYHETHAN", ngayHetHan));
                command.Parameters.Add(new SqlParameter("@SLPHONG", soLuongPhong));
                command.Parameters.Add(new SqlParameter("@CHINHANHDK", chiNhanh));
                command.Parameters.Add(new SqlParameter("@DIEUKIENCHUNHA", dieuKien));

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
