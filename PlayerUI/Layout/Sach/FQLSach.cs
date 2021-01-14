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
        }
        private void BindGrid(string ten)
        {
            string where = "";
                where = " where ( "+ ten+ " = '' or s.ten like N'%" + ten+ "%')";
            string orderBy = " order by loai.ten";

            dataGridView1.DataSource = cn.getDataTable("select ROW_NUMBER() OVER (ORDER BY loai.ten) as STT,s.id as 'Mã', s.ten as 'Tên'," +
                " s.soluong as 'SL' , s.dongia  as 'Đơn giá', s.tacgia  as 'Tác giả', s.anh  as 'Ảnh',k.ten  as 'Kho',ncc.ten  as 'NCC'," +
                "loai.ten  as 'Loại', nxb.ten  as 'NXB', s.active  as 'Hoạt động' from sach s left join kho k on s.khoId = k.id " +
                "join nhacungcap ncc on s.nccId = ncc.id join loaisach loai on s.loaisachId = loai.id join nhaxb nxb on s.nxbId = nxb.id " + where + orderBy);
            
        }
        private void GetAllRow()
        {
            DataTable read = cn.getDataTable("select * from sach where id ="+ ma);
            if (read.Rows.Count > 0)
            {
                txtId.Text = read.Rows[0][1].ToString();

            }
        }
        private void addButtonDataGripview()
        {
            dataGridView1.Columns[0].Width = 44;
            dataGridView1.Columns[1].Width = 44;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.Width = 40;
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
                cn.ExecuteNonQuery("Delete loaimathang where maloai =" + ma);
                BindGrid("");
            }
        }

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
                ma = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Delete(ma);

            }
            else if (e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                GetAllRow();
            }
        }
    }
}
