﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NVEditProfileDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataSet CHINHSUA_PROFILENV(string maNv, string tenNv, string sdt, string diaChi, DateTime ngaySinh)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("CHINHSUA_PROFILENV", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MANV", maNv));
                command.Parameters.Add(new SqlParameter("@TENNV", tenNv));
                command.Parameters.Add(new SqlParameter("@SDT", sdt));
                command.Parameters.Add(new SqlParameter("@DCHI", diaChi));
                command.Parameters.Add(new SqlParameter("@DOB", ngaySinh));

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
    }
}
