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
    public partial class QUANLYTHONGTIN1NV : Form
    {
        public QUANLYTHONGTIN1NV()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form form = new NVQLDashboard();
            form.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CHUCNANGQUANLY1NV da = new CHUCNANGQUANLY1NV();
            da.chucnangquanly_select_LU2_FIX(txtMANV.Text, txtLuong.Text, txtSdt.Text, txtDchi.Text);
            txtMess.Text = da.ReturnMess;
        }
    }
}
