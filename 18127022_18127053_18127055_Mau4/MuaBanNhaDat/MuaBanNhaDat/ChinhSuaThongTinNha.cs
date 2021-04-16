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
    public partial class ChinhSuaThongTinNha : Form
    {
        ChinhSuaThongTinNhaDataAccess da = new ChinhSuaThongTinNhaDataAccess();
        public ChinhSuaThongTinNha()
        {
            InitializeComponent();
            lblUserInfo.Text = "Xin chào " + UserInfo.Name;
            dtNgayHetHan.Value = DateTime.Now;

            DataTable tblNha = da.Nha_GetAll();
            cbbMaNha.DataSource = tblNha;
            cbbMaNha.ValueMember = "MA_NHA";
            cbbMaNha.DisplayMember = "MA_NHA";

            DataTable tblLoaiNha = da.LoaiNha_GetAll();
            cbbLoaiNha.DataSource = tblLoaiNha;
            cbbLoaiNha.ValueMember = "MA_LN";
            cbbLoaiNha.DisplayMember = "TENLN";

            DataTable tblChiNhanh = da.ChiNhanh_GetAll();
            cbbChiNhanh.DataSource = tblChiNhanh;
            cbbChiNhanh.ValueMember = "MA_CN";
            cbbChiNhanh.DisplayMember = "MA_CN";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            da.chinhsua_loainha_ban((string)cbbMaNha.SelectedValue, (string)cbbLoaiNha.SelectedValue, txtTinhTrang.Text, Convert.ToInt32(nbGiaBan.Value), txtKhuVuc.Text, txtDuong.Text, txtQuan.Text, txtThanhPho.Text,
                dtNgayHetHan.Value, Convert.ToInt32(nbSoLuongPhong.Value), (string)cbbChiNhanh.SelectedValue);
            MessageBox.Show(da.ReturnMess);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new CNDashboard();
            form.Show();
            this.Close();
        }
    }
}
