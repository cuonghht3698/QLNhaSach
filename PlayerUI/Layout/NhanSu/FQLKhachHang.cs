using QLNhaSach.Business;
using QLNhaSach.Function;
using QLNhaSach.Layout.Authent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout.NhanSu
{
    public partial class FQLKhachHang : Form
    {
        private Connect cn;
        private string sSearch;
        private bool sTrangThai;
        private bool checkDoiMK = false;
        public FQLKhachHang()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FQLKhachHang_Load(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 1;
            getDataKhachHang();

        }
        private void getDataKhachHang()
        {
            sSearch = txtSearch.Text;
            string where = "";
            where = " where ('" + sSearch + "' = '' or ten like '%" + sSearch + "%')";

            if (cbTrangThai.SelectedIndex != 0)
            {
                where += " and active = '" + sTrangThai + "'";
            }
            DataTable tb = cn.getDataTable("select id,ten,ngaysinh,sdt,gioitinh,quequan,username,active from khachhang " + where);
            dataGridView1.DataSource = tb;
        }
        private void updateKhachHang()
        {
            string ten, sdt, quequan, username;
            int id;
            bool gioitinh, active;
            DateTime ngaysinh;
            id = int.Parse(txtMa.Text);
            ten = txtTen.Text;
            sdt = txtSdt.Text;
            quequan = txtQueQuan.Text;
            username = txtUsername.Text;
            gioitinh = PublicFunction.NamNuToTrueFalse(cbGioiTinh.SelectedItem.ToString());
            active = checkActive.Checked;
            ngaysinh = dateTimePicker1.Value;
            string sql = "update khachhang set ten = N'" + ten + "',ngaysinh = '" + ngaysinh + "',sdt = '" + sdt + "',gioitinh = '" + gioitinh + "'" +
                ",quequan = N'" + quequan + "',username = '" + username + "',active = '" + active + "' where id = " + id;
            try
            {
                cn.ExecuteNonQuery(sql);
                getDataKhachHang();
            }
            catch (Exception)
            {

                MessageBox.Show("Kiểm tra lại thông tin", "Thông báo!");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
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
                checkActive.Checked = Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            sTrangThai = cbTrangThai.SelectedIndex == 1 ? true : false;
            getDataKhachHang();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getDataKhachHang();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            updateKhachHang();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            checkDoiMK = !checkDoiMK;
            checkDOiPass();

        }

        private void checkDOiPass() {
            if (checkDoiMK)
            {
                txtPassword.Enabled = true;
                btnOkDoi.Visible = true;
                btnDoiMatKhau.Text = "Hủy";
            }
            else
            {
                txtPassword.Enabled = false;
                btnOkDoi.Visible = false;
                btnDoiMatKhau.Text = "Đổi mật khẩu";

            }
        }
        private void DoiMatKhau()
        {
            if (!String.IsNullOrEmpty(txtMa.Text) )
            {
                if( txtPassword.Text.Length < 5)
                {
                    MessageBox.Show("Mật khẩu quá ngắn", "Thông báo!");
                }
                else
                {
                    string sql = "update khachhang set passwordHash = '" + PublicFunction.EncodePassword(txtPassword.Text) + "' where id =" + Int32.Parse(txtMa.Text);
                    cn.ExecuteNonQuery(sql);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo!");
                    checkDoiMK = false;
                    checkDOiPass();
                }   
            }
            
        }
        private void btnOkDoi_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }
    }
}
