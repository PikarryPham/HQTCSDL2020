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
    public partial class NVDashboard : Form
    {
        public NVDashboard()
        {
            InitializeComponent();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            Form form = new NVEditProfile();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new ThongKeNhaBan();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.Show();
            this.Close();
        }
    }
}
