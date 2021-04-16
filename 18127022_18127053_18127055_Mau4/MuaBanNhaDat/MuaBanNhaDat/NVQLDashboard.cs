using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanNhaDat
{
    public partial class NVQLDashboard : Form
    {
        public NVQLDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new NVQLQLTTCNV();
            form.Show();
            this.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.Show();
            this.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form form = new TANGGIAMLUONGCHONV();
            form.Show();
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form form = new QUANLYTHONGTIN1NV();
            form.Show();
            this.Close();
        }
    }
}
