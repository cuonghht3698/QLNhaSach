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
    public partial class FNhapSach : Form
    {
        private Connect cn;
        private int phieuId;
        private string trangthai = TrangThai.TaoPhieu;
        public FNhapSach()
        {
            InitializeComponent();
            cn = new Connect();
        }
        private void FNhapSach_Load(object sender, EventArgs e)
        {
            listSearch.Visible = false;
            getSachMau();
            CheckPhieu();
            getChiTietPhieu();
            addBtnDelete();
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            listSearch.Visible = true;
            Console.WriteLine(sender.ToString());
        }


        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            listSearch.Visible = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            listSearch.Visible = false;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            listSearch.Visible = false;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            listSearch.Visible = false;
        }



        private void getSachMau()
        {
            DataTable tb = cn.callSachMauProcedure(txtSearch.Text);
            if (tb.Rows.Count > 0)
            {
                //listSearch.Visible = true;
                listSearch.Items.Clear();
                foreach (DataRow item in tb.Rows)
                {
                    listSearch.Items.Add(item[0].ToString());
                }


            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getSachMau();
        }

        private void listSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(listSearch.SelectedItem.ToString()))
            {
                DataTable tb = cn.getDataTable("SELECT s.id,s.ten,s.dongia,s.dvt,l.ten FROM sach s left join loaisach l on s.loaisachId = l.id Where s.id=" + PublicFunction.GetIdFromCombobox(listSearch.SelectedItem.ToString()));
                if (tb.Rows.Count > 0)
                {
                    lbId.Text = tb.Rows[0][0].ToString();
                    lbten.Text = tb.Rows[0][1].ToString();
                    txtGiaNhap.Text = tb.Rows[0][2].ToString();
                    lbDVT.Text = tb.Rows[0][3].ToString();
                    lbloai.Text = tb.Rows[0][4].ToString();
                    listSearch.Visible = false;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int idSach, donGia, soLuong;
            idSach = Int32.Parse(lbId.Text);
            donGia = Int32.Parse(txtGiaNhap.Text);
            soLuong = Int32.Parse(txtSL.Text);
            TaoChiTietPhieu(idSach, soLuong, donGia);
            getChiTietPhieu();

        }
        // LAY PHIẾU ĐANG THAO TÁC
        private DataTable getPhieuDangTao()
        {
            string sql = "SELECT top 1 * from phieu where nhanvienId ="
                    + Session.idUser + " and trangthai =N'" + TrangThai.TaoPhieu + "' and loaiphieuId = 1";
            DataTable dt = cn.getDataTable(sql);
            return dt;
        }
        // TẠO PHIẾU MỚI
        private void TaoPhieuMoi(string mota)
        {
            cn.ExecuteNonQuery("insert into phieu (ngaytao,ngayketthuc,trangthai,nhanvienId,loaiphieuId,ghichu)" +
                " values ('" + DateTime.Now + "',NULL,N'" + trangthai + "'," + Session.idUser + ",1,N'" + mota + "')");
        }
        // TẠO CHI TIẾT PHIẾU THÊM SP
        private void TaoChiTietPhieu(int idSach, int sl, int dongia)
        {
            cn.ExecuteNonQuery("insert into chitietphieu (phieuId,sachId,soluong,dongia)" +
                " values (" + phieuId + "," + idSach + "," + sl + "," + dongia + ")");

        }

        // LAY THÔNG TIN CHI TIẾT PHIẾU ĐỔ VÀO DATATABLE
        private void getChiTietPhieu()
        {
            string sql = "SELECT ct.id as 'Mã',ct.sachId as 'Mã sách',s.ten as 'Tên', ls.ten as 'Loại',s.dvt as 'DVT',ct.soluong as 'Số lượng',ct.dongia as 'Đơn giá'" +
                "from chitietphieu ct join sach s on ct.sachId = s.id left join loaisach ls on s.loaisachId = ls.id where phieuId =" + phieuId;
            DataTable dt = cn.getDataTable(sql);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                int sl = 0;
                int tongtien = 0;
                foreach (DataRow item in dt.Rows)
                {
                    sl += Int32.Parse(item[5].ToString());
                    tongtien += Int32.Parse((Int32.Parse(item[5].ToString()) * Int32.Parse(item[6].ToString())).ToString());
                }
                lbSoLuong.Text = sl.ToString();
                lbtongtien.Text = tongtien.ToString();

            }

        }

        private void addBtnDelete()
        {
            dataGridView1.Columns[0].Width = 44;
            dataGridView1.Columns[1].Width = 44;

            dataGridView1.Columns[2].Width = 224;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.Width = 20;
            delete.DefaultCellStyle.BackColor = Color.Red;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
            dataGridView1.Columns[7].Width = 44;
        }
        // KIỂM TRA PHIẾU ĐÃ CÓ CHƯA CHƯA CÓ AUTO TẠO
        private void CheckPhieu()
        {
            if (!String.IsNullOrEmpty(Session.idUser.ToString()))
            {
                DataTable dt = getPhieuDangTao();
                if (dt.Rows.Count == 0)
                {
                    TaoPhieuMoi(txtGhiChu.Text);
                    var tb = getPhieuDangTao();
                    phieuId = Int32.Parse(tb.Rows[0][0].ToString());
                    Console.WriteLine(phieuId.ToString());
                }
                else
                {
                    phieuId = Int32.Parse(dt.Rows[0][0].ToString());
                    Console.WriteLine(phieuId.ToString());
                }
            }
        }


        // XÓA CHI TIẾT PHIẾU
        private void XoaChiTietPhieu(int mact)
        {
            cn.ExecuteNonQuery("DELETE chitietphieu where id =" + mact);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    XoaChiTietPhieu(id);
                    getChiTietPhieu();
                }

            }
            else if (e.RowIndex != -1)
            {
                lbId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                lbten.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                lbloai.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                lbDVT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSL.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtGiaNhap.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                lbtong.Text = (Int32.Parse(txtGiaNhap.Text) * Int32.Parse(txtSL.Text)).ToString();
            }
        }

    }
}
