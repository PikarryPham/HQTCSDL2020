using DataAccess;
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
    public partial class CreateAccountOption : Form
    {
        public CreateAccountOption()
        {
            InitializeComponent();
        }

        private void nv_btn_Click(object sender, EventArgs e)
        {
            Form form = new CreateAccountNV();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void kh_btn_Click(object sender, EventArgs e)
        {
            Form form = new CreateAccountKH();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void cn_btn_Click(object sender, EventArgs e)
        {
            Form form = new CreateAccountCN();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.Show();
            this.Close();
        }
    }
}
