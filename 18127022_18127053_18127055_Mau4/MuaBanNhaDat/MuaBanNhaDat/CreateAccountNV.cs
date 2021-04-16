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
    public partial class CreateAccountNV : Form
    {
        public CreateAccountNV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)x).Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản");
                        return;
                    }
                }
            }
            CreateAccountNVAccess c = new CreateAccountNVAccess();
            c.CREATE_ACCOUNT_NV(ten_text.Text, sdt_text.Text, dchi_text.Text, ngaysinh_text.Text, user_text.Text, password_text.Text, cnql_text.Text, cnlv_text.Text);
            MessageBox.Show(c.ReturnMess);
            if (c.ReturnCode == 0)
            {
                Form form = new FormLogin();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                this.Close();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.Show();
            this.Close();
        }
    }
}
