using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanNhaDat
{
    public partial class UC_Nha : UserControl
    {
        public string IdNha;
        public UC_Nha()
        {
            InitializeComponent();
        }

        public void SetInfo(string info)
        {
            lblProductInfo.Text = info;
        }
    }
}
