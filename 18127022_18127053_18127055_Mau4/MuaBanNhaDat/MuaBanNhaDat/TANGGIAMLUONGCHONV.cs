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
    public partial class TANGGIAMLUONGCHONV : Form
    {
        public TANGGIAMLUONGCHONV()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form form = new NVQLDashboard();
            form.Show();
            this.Close();
        }

        private void Capnhat_btn_Click(object sender, EventArgs e)
        {
            TangGiamLuong da = new TangGiamLuong();
            da.TANGGIAM_LUONGNV_FIX(txtMANV.Text, bonustxt.Text);
            updateluong.Text = da.ReturnMess;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            //dthing
        }
    }
}
