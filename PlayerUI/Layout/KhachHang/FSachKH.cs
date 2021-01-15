using QLNhaSach.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout.KhachHang
{
    public partial class FSachKH : Form
    {
        private Connect cn;
        private string ma;
        private string search = "";
        public FSachKH()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FSachKH_Load(object sender, EventArgs e)
        {
        }
        private void showSach()
        {
            string sql = "";
            cn.getDataTable(sql);
        }
        
    }
}
