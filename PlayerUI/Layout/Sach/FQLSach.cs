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

    public partial class FQLSach : Form
    {
        private Connect cn;
        private string ma;
        public FQLSach()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FQLSach_Load(object sender, EventArgs e)
        {
            BindGrid("''");
            addButtonDataGripview();
            datePickNgayNhap.CustomFormat = "dd/MM/yyyy";
            setDataCombo();
        }
        private void BindGrid(string ten)
        {
            string where = "";
            where = " where ( " + ten + " = '' or s.ten like N'%" + ten + "%')";
            string orderBy = " order by loai.ten,s.active";

            dataGridView1.DataSource = cn.getDataTable("select ROW_NUMBER() OVER (ORDER BY loai.ten) as STT,s.id as 'Mã', s.ten as 'Tên'," +
                " s.soluong as 'SL' , s.dongia  as 'Đơn giá', s.tacgia  as 'Tác giả', s.anh  as 'Ảnh',k.ten  as 'Kho',ncc.ten  as 'NCC'," +
                "loai.ten  as 'Loại', nxb.ten  as 'NXB', s.active as 'Hoạt động' from sach s left join kho k on s.khoId = k.id " +
                "left join nhacungcap ncc on s.nccId = ncc.id left join loaisach loai on s.loaisachId = loai.id left join nhaxb nxb on s.nxbId = nxb.id" + where + orderBy);

        }
        private void GetAllRow()
        {
            DataTable read = cn.getDataTable("select * from sach where id =" + ma);
            if (read.Rows.Count > 0)
            {

                txtMa.Text = read.Rows[0][0].ToString();
                txtTen.Text = read.Rows[0][1].ToString();
                txtSoLuong.Text = read.Rows[0][2].ToString();
                txtDonGia.Text = read.Rows[0][3].ToString();
                string ngaynhap = read.Rows[0][4].ToString();
                datePickNgayNhap.Value = ngaynhap!=""? DateTime.Parse(ngaynhap):DateTime.Now;
                txtTacGia.Text = read.Rows[0][5].ToString();
                txtMoTa.Text = read.Rows[0][6].ToString();
                checkActive.Text = read.Rows[0][12].ToString() == "True" ? "Hoạt động" : "Ngừng kinh doanh";
                checkActive.Checked = read.Rows[0][12].ToString() == "True" ? true : false;

                Console.WriteLine(read.Rows[0][12].ToString());
            }
        }
        private void addButtonDataGripview()
        {
            dataGridView1.Columns[0].Width = 34;
            dataGridView1.Columns[1].Width = 34;
            dataGridView1.Columns[11].Width = 34;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.Width = 20;
            delete.DefaultCellStyle.BackColor = Color.Red;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
        }
        private void Delete(string ma)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cn.ExecuteNonQuery("Delete sach where id =" + ma);
                BindGrid("");
            }
        }

        // khóa ngoại
        private void setDataCombo()
        {
            DataTable tbKho = cn.getDataTable("select * from kho");
            if(tbKho.Rows.Count > 0)
            {
                foreach (DataRow item in tbKho.Rows)
                {
                    cbKho.Items.Add(item[1].ToString());
                    cbSearchKho.Items.Add(item[1].ToString());
                }
            }
            DataTable tbNcc = cn.getDataTable("select * from nhacungcap");
            if (tbNcc.Rows.Count > 0)
            {
                foreach (DataRow item in tbNcc.Rows)
                {
                    cbNCC.Items.Add(item[1].ToString());
                    cbSearchNCC.Items.Add(item[1].ToString());
                }
            }
            DataTable tbNxb = cn.getDataTable("select * from nhaxb");
            if (tbKho.Rows.Count > 0)
            {
                foreach (DataRow item in tbNxb.Rows)
                {
                    cbNhaXuatBan.Items.Add(item[1].ToString());
                    cbSearchNXB.Items.Add(item[1].ToString());
                }
            }
            DataTable tbLoai = cn.getDataTable("select * from loaisach");
            if (tbLoai.Rows.Count > 0)
            {
                foreach (DataRow item in tbLoai.Rows)
                {
                    cbLoaiSach.Items.Add(item[1].ToString());
                    cbSearchLoai.Items.Add(item[1].ToString());
                }
            }
        }
        // end khóa ngoại


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                Delete(ma);

            }
            else if (e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                GetAllRow();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
