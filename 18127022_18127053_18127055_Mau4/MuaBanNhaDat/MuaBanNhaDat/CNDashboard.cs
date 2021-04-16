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
    public partial class CNDashboard : Form
    {
        public CNDashboard()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form form = new ChinhSuaThongTinNha();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new DangThongTinNha();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.Show();
            this.Close();
        }
    }
}
