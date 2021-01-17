using QLNhaSach.Business;
using QLNhaSach.Function;
using QLNhaSach.Layout.Authent;
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

namespace QLNhaSach.Layout.NhanSu
{
    public partial class FQLNhanVien : Form
    {
        private Connect cn;
        private string sSearch;
        private string sRole;
        public FQLNhanVien()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FQLNhanVien_Load(object sender, EventArgs e)
        {
            cbQuyen.Items.Add(Role.admin);
            cbQuyen.Items.Add(Role.quanlykho);
            cbQuyen.Items.Add(Role.nhanvien);
            cbQuyen.Items.Add(Role.khachhang);
            cbQuyen.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;

            cbSearchChucVu.Items.Add("-- Lọc theo quyền");
            cbSearchChucVu.Items.Add(Role.admin);
            cbSearchChucVu.Items.Add(Role.quanlykho);
            cbSearchChucVu.Items.Add(Role.nhanvien);
            cbSearchChucVu.Items.Add(Role.khachhang);
            cbSearchChucVu.SelectedIndex = 0;
            getDataNhanVien();
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void getDataNhanVien()
        {
            sSearch = txtSearch.Text;
            sRole = cbSearchChucVu.SelectedItem.ToString();
            string where = "";
            if (!String.IsNullOrEmpty(sSearch))
            {
                where = " and ( ten like '%" + sSearch + "%')";
            }
            if (cbSearchChucVu.SelectedIndex != 0)
            {
                where = " and quyen like '%" + sRole + "%'";
            }
            DataTable tb = cn.getDataTable("select id,ten,ngaysinh,sdt,gioitinh,quequan,username,active,quyen from nhanvien where id !=" + Session.idUser + where);
            dataGridView1.DataSource = tb;
        }
        private void updateNhanVien()
        {
            string ten, sdt, quequan, username, quyen;
            int id;
            bool gioitinh, active;
            DateTime ngaysinh;
            id =int.Parse(txtMa.Text);
            ten = txtTen.Text;
            sdt = txtSdt.Text;
            quequan = txtQueQuan.Text;
            username = txtUsername.Text;
            quyen = cbQuyen.SelectedIndex !=0 ? cbQuyen.SelectedItem.ToString():"";
            gioitinh = PublicFunction.NamNuToTrueFalse(cbGioiTinh.SelectedItem.ToString());
            active = checkActive.Checked;
            ngaysinh = dateTimePicker1.Value;
            string sql = "update nhanvien set ten = N'" +ten+ "',ngaysinh = '"+ngaysinh +"',sdt = '"+sdt+"',gioitinh = '"+ gioitinh +"'" +
                ",quequan = N'"+quequan+"',username = '"+username+"',active = '"+active+"',quyen =N'"+quyen+"' where id = " + id;
            try
            {
                cn.ExecuteNonQuery(sql);
                getDataNhanVien();
            }
            catch (Exception)
            {

                MessageBox.Show("Kiểm tra lại thông tin","Thông báo!");
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            getDataNhanVien();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy(true);
            dk.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkActive.Text = checkActive.Checked == true ? "Hoạt động" : "Khóa";
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
                  
                }

            }
            else if (e.RowIndex != -1)
            {
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbGioiTinh.SelectedItem = PublicFunction.TrueFalseToNamNu(Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                txtQueQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                //txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                checkActive.Checked =Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                cbQuyen.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void cbSearchChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataNhanVien();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            updateNhanVien();
        }
    }
}
