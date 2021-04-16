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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void dangnhap_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pass_text.Text) || string.IsNullOrEmpty(user_text.Text))
            {
                lblStatus.Text = "Vui lòng nhập đầy đủ thông tin đăng nhập";
                return;
            }
            if (!khachhang_radio.Checked && !nhanvien_radio.Checked && !chunha_radio.Checked && !nvql_radio.Checked)
            {
                lblStatus.Text = "Vui lòng chọn loại tài khoản đăng nhập";
                return;
            }
            if (khachhang_radio.Checked)
            {
                LoginDataAccess da = new LoginDataAccess();
                DataTable tbl = da.LoginKH(user_text.Text, pass_text.Text);
                if (da.ReturnCode == 0)
                {
                    Form form = new KHDashboard();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Close();
                }
                else
                    lblStatus.Text = da.ReturnMess;
                return;
            }
            if (nhanvien_radio.Checked)
            {
                LoginDataAccess da = new LoginDataAccess();
                DataTable tbl = da.LoginNV(user_text.Text, pass_text.Text);
                if (da.ReturnCode == 0)
                {
                    Form form = new NVDashboard();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Close();
                }
                else
                    lblStatus.Text = da.ReturnMess;
                return;
            }

            if (nvql_radio.Checked)
            {
                LoginDataAccess da = new LoginDataAccess();
                DataTable tbl = da.LoginNV(user_text.Text, pass_text.Text);
                if (da.ReturnCode == 0)
                {
                    lblStatus.Text = "NV Login successfully";
                    Form form = new NVQLDashboard();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Close();
                }
                else
                    lblStatus.Text = da.ReturnMess;
                return;
            }

            if (chunha_radio.Checked)
            {
                LoginDataAccess da = new LoginDataAccess();
                DataTable tbl = da.LoginCN(user_text.Text, pass_text.Text);
                if (da.ReturnCode == 0)
                {
                    lblStatus.Text = "NV Login successfully";
                    Form form = new CNDashboard();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Close();
                }
                else
                    lblStatus.Text = da.ReturnMess;
                return;
            }
            
        }
        private void ttk_btn_Click(object sender, EventArgs e)
        {
            Form form = new CreateAccountOption();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            //this.Close();
        }

    }
}
