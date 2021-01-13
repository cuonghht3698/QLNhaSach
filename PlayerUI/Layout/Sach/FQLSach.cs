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

        }
        private void BindGrid(string ten)
        {
            string where = "";
            if (!String.IsNullOrEmpty(ten))
            {
                where = " where tenloai like '%" + ten + "%'";
            }
            string orderBy = " order by tenloai";
            dataGridView1.DataSource = cn.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY tenloai) as 'STT',mahang as 'Mã', tenloai as 'Tên', mota as 'Mô tả' FROM loaimathang" + where + orderBy);

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
            BindGrid(textBox1.Text);
        }
    }
}
