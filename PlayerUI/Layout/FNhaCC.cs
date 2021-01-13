using QLNhaSach.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout
{
    public partial class FNhaCC : Form
    {
        private Connect cn;
        private string ma;
        public FNhaCC()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FNhaCC_Load(object sender, EventArgs e)
        {
            BindGrid("");
            addButtonDataGripview();
        }
        private void BindGrid(string ten)
        {
            string where = "";
            if (!String.IsNullOrEmpty(ten))
            {
                where = " where tenncc like '%" + ten + "%'";
            }
            string orderBy = " order by diachi";
            dataGridView1.DataSource = cn.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY tenncc) as 'STT',mancc as 'Mã', tenncc as 'Tên', diachi as 'Địa chỉ', sdt as 'SĐT', email as 'Email' FROM nhacungcap" + where + orderBy);

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
                cn.ExecuteNonQuery("Delete nhacungcap where mancc =" + ma);
                BindGrid("");
                Clear();
            }
        }
        private void CreateOrUpdate(int check)
        {
            if (txtDiaChi.Text == "" || txtEmail.Text == "" || txtNcc.Text == "" || txtSdt.Text == "")
            {
                lbThongBao.ForeColor = Color.Red;
                lbThongBao.Text = "Cách mục không đúng định dạng";
            }
            // 0 la them 1 la sua
            else if (check == 0)
            {
                cn.ExecuteNonQuery("INSERT INTO nhacungcap (tenncc,diachi,sdt,email) VALUES (N'" + txtNcc.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSdt.Text + "',N'" + txtEmail.Text + "')");
                lbThongBao.Text = "Thêm nhà cung cấp thành công";
                BindGrid("");
                Clear();
            }
            else if (check == 1)
            {
                cn.ExecuteNonQuery("UPDATE nhacungcap SET tenncc = N'" + txtNcc.Text + "',diachi = N'" + txtDiaChi.Text + "',sdt = N'" + txtSdt.Text + "',email = N'" + txtEmail.Text + "' WHERE mancc = " + ma);
                lbThongBao.Text = "Sửa nhà cung cấp thành công";
                BindGrid("");
                Clear();
            }
        }
        private void Clear()
        {
            ma = "";
            txtNcc.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindGrid(textBox1.Text);
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
            else if(e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNcc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

       
       

        private void button3_Click(object sender, EventArgs e)
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
