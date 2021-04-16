using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanNhaDat
{
    public partial class ThongKeNhaBan : Form
    {
        ThongKeNhaBanDataAccess da = new ThongKeNhaBanDataAccess();
        public ThongKeNhaBan()
        {
            InitializeComponent();
            lblUserInfo.Text =  UserInfo.Name;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new NVDashboard();
            form.Show();
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            panelProductList.Controls.Clear();
            DataSet dataSet = da.THONGKE_FIX(txtMaNhanVien.Text, txtQuan.Text, txtThanhPho.Text);

            if (da.ReturnCode != 0)
            {
                MessageBox.Show(da.ReturnMess);
                return;
            }
            DataTable tblDanhSach = dataSet.Tables[0];
            for (int i = 0; i < tblDanhSach.Rows.Count; i++)
            {
                UC_Nha uc = new UC_Nha();
                StringBuilder sb = new StringBuilder();
                sb.Append("Mã nhà: " + tblDanhSach.Rows[i]["MA_NHA"] + Environment.NewLine);
                sb.Append("SL Phòng: " + Convert.ToInt32(tblDanhSach.Rows[i]["SLPHONG"]).ToString("#,##") + Environment.NewLine);
                sb.Append("View: " + tblDanhSach.Rows[i]["VIEW_NHA"] + Environment.NewLine);
                sb.Append("NV phụ trách: " + tblDanhSach.Rows[i]["NVPT"] + Environment.NewLine);
                sb.Append("Mã chi nhánh: " + tblDanhSach.Rows[i]["MA_CN"] + Environment.NewLine);
                sb.Append("Mã chủ nhà: " + tblDanhSach.Rows[i]["MA_CNHA"] + Environment.NewLine);
                sb.Append("Loại nhà: " + tblDanhSach.Rows[i]["TENLN"] + Environment.NewLine);
                if (tblDanhSach.Rows[i]["TRANGTHAI"].ToString().Equals("0"))
                    sb.Append("Trạng thái: Chưa bán" + Environment.NewLine);
                else
                    sb.Append("Trạng thái: Đã bán" + Environment.NewLine);
                sb.Append("Ngày đăng: " + DateTime.Parse(tblDanhSach.Rows[i]["NGAYDANG"].ToString()).ToString("dd/MM/yyyy") + Environment.NewLine);
                uc.SetInfo(sb.ToString());
                panelProductList.Controls.Add(uc);
            }

            lblNhanVienPhuTrach.Text = dataSet.Tables[1].Rows[0][0].ToString();
            lblChiNhanh.Text = dataSet.Tables[1].Rows[0][2].ToString();
            lblNgayBaoCao.Text = DateTime.Parse(dataSet.Tables[1].Rows[0][1].ToString()).ToString("dd/MM/yyyy");

            dgvThongKe3Thang.DataSource = dataSet.Tables[2];

            lblTongNhaDaBan.Text = dataSet.Tables[3].Rows[0][0].ToString();
            lblTongNhaChuaBan.Text = dataSet.Tables[4].Rows[0][0].ToString();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            //DTHING
        }
    }
}
