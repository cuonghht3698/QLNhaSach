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

namespace QLNhaSach.Layout.KhachHang
{
    public partial class FLichSuMuaHang : Form
    {
        private Connect cn;
        public FLichSuMuaHang()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FLichSuMuaHang_Load(object sender, EventArgs e)
        {
            getAll();
            DataGridViewButtonColumn xem = new DataGridViewButtonColumn();
            xem.HeaderText = "Xem";
            xem.Text = "Xem";
            xem.Width = 40;
            xem.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(xem);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Hủy đơn";
            delete.Text = "Hủy đơn";
            delete.Width = 40;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
        }

        private void getAll()
        {
            dataGridView1.DataSource = cn.getDataTable("select h.id, s.ten, h.noigiaohang, h.ngaydat,h.trangthai from hoadon h join chitiethoadon ct on h.id = ct.hoadonId join sach s on ct.sachId = s.id" +
                  " where h.khachhangId = " + Session.idUser + " group by h.id, s.ten, h.noigiaohang, h.ngaydat, h.trangthai order by h.id desc");

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                // xem don
                
                FGioHang F = new FGioHang(id);
                F.StartPosition = FormStartPosition.CenterParent;
                F.Show();
                
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                // huy don
                var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    HuyDon(id);
                    MessageBox.Show("Hủy đơn thành công !");
                    
                    getAll();

                }

            }
        }
        private void HuyDon(int id)
        {
            cn.ExecuteNonQuery("update hoadon set trangthai =N'" + TrangThai.DaHuy + "' where id = " + id);
        }
        private void openForm()
        {

        }
    }
}
