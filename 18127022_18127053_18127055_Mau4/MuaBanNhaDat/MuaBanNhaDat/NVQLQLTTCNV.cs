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
    public partial class NVQLQLTTCNV : Form
    {
        public NVQLQLTTCNV()
        {
            InitializeComponent();
            lblUserInfo.Text = "Xin chào " + UserInfo.Name;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNvql.Text))
            {
                MessageBox.Show("Mã nhân viên quản lý không hợp lệ");
                return;
            }
            
            NVQLDataAccess da = new NVQLDataAccess();
            DataSet dataSet = da.QL_TATCANV_NVQL(txtMaNvql.Text, txtMaNv.Text, nbLuong.Value.ToString());
            dgvChuaCapNhat.DataSource = dataSet.Tables[0];
            dgvDaCapNhat.DataSource = dataSet.Tables[1];
            MessageBox.Show(da.ReturnMess);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new NVQLDashboard();
            form.Show();
            this.Close();
        }
    }
}
