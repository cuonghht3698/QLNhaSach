using QLNhaSach.Business;
using QLNhaSach.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private DateTime dateto = DateTime.Now;
        private DateTime dateFrom = DateTime.Now;

        public QLNhapSach()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void QLNhapSach_Load(object sender, EventArgs e)
        {
            dateto = dateto.AddDays(-320);
            dateTimePicker1.Value = dateto;
            GetDanhSachNhapSach();

        }
        private void GetDanhSachNhapSach()
        {
            var data = cn.getDataTable("select s.id as 'Mã phiếu',s.ten as 'Tên',ct.soluong as 'Số lượng'" +
                ",ct.dongia as 'Đơn giá',p.ngaytao as 'Ngày tạo',p.trangthai as 'Trạng thái' from phieu p join loaiphieu l on p.loaiphieuId = l.id join chitietphieu ct on p.id = ct.phieuid join sach s on ct.sachId = s.id"
                + " where ('" + search + "' = '' or s.ten like N'%" + search + "%') and p.ngaytao >= '"+ PublicFunction.GetDate(dateto) + "' and p.ngaytao <= '" + PublicFunction.GetDate(dateFrom) + "'");
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].MinimumWidth = 400;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 150;

            label4.Text = "Thời gian nhập hàng từ " +  PublicFunction.CountDay(dateto,dateFrom) + " ngày trước.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search = textBox1.Text;
            GetDanhSachNhapSach();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateto = dateTimePicker1.Value.Date;
            GetDanhSachNhapSach();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateFrom = dateTimePicker2.Value.Date;
            GetDanhSachNhapSach();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
