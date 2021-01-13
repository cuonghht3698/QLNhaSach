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
    public partial class FKho : Form
    {
        private Connect cn;
        private string ma;
        public FKho()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FKho_Load(object sender, EventArgs e)
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
            string orderBy = " order by diachi";
            dataGridView1.DataSource = cn.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY diachi) as 'STT',id as 'Mã', ten as 'Tên', diachi as 'Địa chỉ' FROM kho" + where + orderBy);

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
                cn.ExecuteNonQuery("Delete kho where id =" + ma);
                BindGrid("");
                Clear();
            }
        }
        private void CreateOrUpdate(int check)
        {
            if (txtDiaChi.Text == "" || txtKho.Text == "" )
            {
                lbThongBao.ForeColor = Color.Red;
                lbThongBao.Text = "Cách mục không đúng định dạng";
            }
            // 0 la them 1 la sua
            else if (check == 0)
            {
                cn.ExecuteNonQuery("INSERT INTO kho (ten,diachi) VALUES (N'" + txtKho.Text + "',N'" + txtDiaChi.Text + "')");
                lbThongBao.ForeColor = Color.Green;
                lbThongBao.Text = "Thêm kho thành công";
                BindGrid("");
                Clear();
            }
            else if (check == 1)
            {
                if (!String.IsNullOrEmpty(ma))
                {
                    cn.ExecuteNonQuery("UPDATE kho SET ten = N'" + txtKho.Text + "',diachi = N'" + txtDiaChi.Text + "' WHERE id = " + ma);
                    lbThongBao.ForeColor = Color.Green;
                    lbThongBao.Text = "Sửa nhà cung cấp thành công";
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
            txtKho.Text = "";
            txtDiaChi.Text = "";
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
                txtKho.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
