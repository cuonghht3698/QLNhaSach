using QLNhaSach.Business;
using QLNhaSach.Function;
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
    public partial class QuanLySachDaBan : Form
    {
        private readonly Connect cn;
        private int Id = 0;
        private DateTime ngayTu;
        private DateTime ngayDen;
        private string trangthai;
        public QuanLySachDaBan()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void QuanLySachDaBan_Load(object sender, EventArgs e)
        {
            ngayTu = DateTime.Now.AddDays(-7);
            ngayDen = DateTime.Now;
            getSachDaBan();
            comboBox1.Items.Add(TrangThai.GiaoHang);
            comboBox1.Items.Add(TrangThai.HoanThanh);
            comboBox1.SelectedIndex = 1;
        }

        private void getSachDaBan()
        {
            string sql = "SELECT h.id as 'Mã',h.khachhangId as 'Mã khách hàng', nv.ten as 'Tên NV'," +
                "h.ngaydat as 'Ngày đặt',h.ngaygiaohang as 'Ngày giao',h.noigiaohang as 'Nơi giao',h.sdt as 'SDT', h.trangthai as 'Trạng thái' " +
                "FROM hoadon h left join nhanvien nv on h.nhanvienId = nv.id  where h.ngaydat >='" + PublicFunction.GetDate(ngayTu) + "' and h.ngaydat <='" + PublicFunction.GetDate(ngayDen) + 
                "' and (" + Id +" = 0 or h.id = " + Id+") and h.trangthai = N'" + trangthai +  "'";
            dataGridView1.DataSource = cn.getDataTable(sql);
            dataGridView1.Columns[0].Width = 80;
            label6.Text = "Khoảng " + PublicFunction.CountDay(ngayTu, ngayDen) + " ngày trước.";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                trangthai = "";
            }
            else
            {
                trangthai = comboBox1.SelectedItem.ToString();
            }
            getSachDaBan();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                Id = result;
             
            }
            else
            {
                Id = 0;
                //not an int
            }
            getSachDaBan();
        }
        private void getChiTiet(int id,string ngaydat)
        {
            string sql = "SELECT ct.hoadonId as 'Mã hóa đơn', s.id as 'Mã sách',s.ten as 'Tên sách',ct.dongia as 'Đơn giá',ct.soluong as 'Số lượng' FROM chitiethoadon ct join sach s on ct.sachId = s.id where hoadonId =" + id;
            var data = cn.getDataTable(sql);
            dataGridView2.DataSource = data;
            if (data.Rows.Count > 0)
            {
                int tongtien = 0;
                foreach (DataRow item in data.Rows)
                {
                    tongtien += Int32.Parse(item[3].ToString()) * Int32.Parse(item[4].ToString());
                }
                
                lbTongTien.Text = tongtien.ToString() + " Đồng.";
                lbNgayDat.Text = ngaydat;
            }

            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 80;



        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string ngaydat = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                lbThongTin.Text = "Mã hóa đơn : " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                getChiTiet(id,ngaydat);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void datePickTu_ValueChanged(object sender, EventArgs e)
        {
            ngayTu = datePickTu.Value;

            getSachDaBan();
        }

        private void datePickDen_ValueChanged(object sender, EventArgs e)
        {
            ngayDen = datePickDen.Value;

            getSachDaBan();
        }
    }
}
