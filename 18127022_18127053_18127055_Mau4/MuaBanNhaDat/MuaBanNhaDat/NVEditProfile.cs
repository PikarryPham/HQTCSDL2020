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
    public partial class NVEditProfile : Form
    {
        public NVEditProfile()
        {
            InitializeComponent();
            lblUserInfo.Text = "Xin chào " + UserInfo.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNv.Text))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ");
                return;
            }
            DateTime ngaySinh;
            bool checkNgaySinh = DateTime.TryParseExact(txtNgaySinh.Text, "yyyy/mm/dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out ngaySinh);
            if (!checkNgaySinh)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                return;
            }
            NVEditProfileDataAccess da = new NVEditProfileDataAccess();
            DataSet dataSet = da.CHINHSUA_PROFILENV(txtMaNv.Text, txtTenNhanVien.Text, txtSdt.Text, txtDiaChi.Text, ngaySinh);
            dataGridView1.DataSource = dataSet.Tables[0];
            MessageBox.Show(da.ReturnMess);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new NVDashboard();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void NVEditProfile_Load(object sender, EventArgs e)
        {
            //do nthing
        }
    }
}
