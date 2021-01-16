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

namespace QLNhaSach.Layout
{
    public partial class FLoaiSach : Form
    {
        private Connect cn;
        private string ma;
        public FLoaiSach()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FLoaiSach_Load(object sender, EventArgs e)
        {
            BindGrid("");
            addButtonDataGripview();
        }
        private void BindGrid(string ten)
        {
            string where = "";
            if (!String.IsNullOrEmpty(ten))
            {
                where = " where ten like '%" + ten + "%'";
            }
            string orderBy = " order by ten";
            dataGridView1.DataSource = cn.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY ten) as 'STT',id as 'Mã', ten as 'Tên', mota as 'Mô tả' FROM loaisach" + where + orderBy);

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
                cn.ExecuteNonQuery("Delete loaisach where id =" + ma);
                BindGrid("");
                Clear();
            }
        }
        private void CreateOrUpdate(int check)
        {
            if (txtMoTa.Text == "" || txtTenLoai.Text == "")
            {
                lbThongBao.ForeColor = Color.Red;
                lbThongBao.Text = "Cách mục không đúng định dạng";
            }
            // 0 la them 1 la sua
            else if (check == 0)
            {
                cn.ExecuteNonQuery("INSERT INTO loaisach (ten,mota) VALUES (N'" + txtTenLoai.Text + "',N'" + txtMoTa.Text + "')");
                lbThongBao.ForeColor = Color.Green;
                lbThongBao.Text = "Thêm loại sách thành công";
                BindGrid("");
                Clear();
            }
            else if (check == 1)
            {
                if (!String.IsNullOrEmpty(ma))
                {
                    cn.ExecuteNonQuery("UPDATE loaisach SET ten = N'" + txtTenLoai.Text + "',mota = N'" + txtMoTa.Text + "' WHERE id = " + ma);
                    lbThongBao.ForeColor = Color.Green;
                    lbThongBao.Text = "Sửa loại sách thành công";
                    BindGrid("");
                    Clear();
                }
                else
                {
                    lbThongBao.ForeColor = Color.Red;
                    lbThongBao.Text = "Bạn chưa chọn mục để sửa!";
                }
            }
        }

        private void Clear()
        {
            ma = "";
            txtTenLoai.Text = "";
            txtMoTa.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindGrid(textBox1.Text);
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
                txtTenLoai.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMoTa.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CreateOrUpdate(0);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CreateOrUpdate(1);
        }
    }
}
