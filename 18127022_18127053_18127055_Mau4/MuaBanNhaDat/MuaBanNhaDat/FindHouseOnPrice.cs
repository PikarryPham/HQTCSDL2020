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
    public partial class FindHouseOnPrice : Form
    {
        public FindHouseOnPrice()
        {
            InitializeComponent();
            LoadData();
        }

        private void tim_btn_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            panelProductList.Controls.Clear();
            SearchHouseDataAccess sh = new SearchHouseDataAccess();
            DataTable tbl = sh.TIMNHATHEOGIA(gianha_text.Text);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                UC_Nha uc = new UC_Nha();
                uc.IdNha = tbl.Rows[i]["MA_NHA"].ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append("Tên chủ nhà: " + tbl.Rows[i]["CHUNHA"] + Environment.NewLine);
                sb.Append("SL Phòng: " + Convert.ToInt32(tbl.Rows[i]["SLPHONG"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Giá bán: " + Convert.ToInt32(tbl.Rows[i]["GIABAN"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Ngày hết hạn: " + DateTime.Parse(tbl.Rows[i]["NGAYHETHAN"].ToString()).ToString("dd/MM/yyyy") + Environment.NewLine);
                sb.Append("Ngày đăng: " + DateTime.Parse(tbl.Rows[i]["NGAYDANG"].ToString()).ToString("dd/MM/yyyy") + Environment.NewLine);
                uc.SetInfo(sb.ToString());
                panelProductList.Controls.Add(uc);
            }
            thongbao_label.Text = tbl.Rows.Count.ToString();

            if (sh.ReturnCode == 1)
            {
                error_label.Text = sh.ReturnMess;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form form = new KHDashboard();
            form.Show();
            this.Close();
        }
    }
}
