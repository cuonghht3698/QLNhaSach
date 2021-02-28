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

namespace QLNhaSach.Layout.Sach
{
    public partial class QLNhapSach : Form
    {
        private Connect cn;
        private string search = "";
        public QLNhapSach()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void QLNhapSach_Load(object sender, EventArgs e)
        {
            GetDanhSachNhapSach();
        }
        private void GetDanhSachNhapSach()
        {
            var data = cn.getDataTable("select s.id,s.ten,ct.soluong,ct.dongia,p.ngaytao,p.trangthai from phieu p join loaiphieu l on p.loaiphieuId = l.id join chitietphieu ct on p.id = ct.phieuid join sach s on ct.sachId = s.id"
                + " where ('" + search + "' = '' or s.ten like N'%" + search + "%')");
            dataGridView1.DataSource = data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search = textBox1.Text;
            GetDanhSachNhapSach();
        }
    }
}
