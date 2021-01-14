using PlayerUI;
using QLNhaSach.Business;
using QLNhaSach.Function;
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

namespace QLNhaSach.Layout.Authent
{
    public partial class Login : Form
    {
        private bool LoginNhanVien = false;
        private Connect cn;
        public Login()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkGoToLoginAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginNhanVien = !LoginNhanVien;
            if (LoginNhanVien)
            {
                lbCheckNV.Text = "Chế độ quản trị viên";
                btnDangNhap.Text = "Đăng nhập quản trị";
                linkQuenMatKhau.Visible = false;
                LinkTaoTaiKhoan.Visible = false;
            }
            else
            {
                lbCheckNV.Text = "";
                btnDangNhap.Text = "Đăng nhập";

            }

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (LoginNhanVien)
            {
                LoginAdmin();
            }
            else
            {
                LoginKhachHang();
            }
        }

        private void LoginAdmin()
        {

            DataTable read =  cn.getDataTable("SELECT * FROM nhanvien WHERE username = '" + txtUser.Text + "' and passwordHash = '" + PublicFunction.EncodePassword(txtPassword.Text) + "'");
            if (read.Rows.Count >0)
            {
                Session.idUser = int.Parse(read.Rows[0][0].ToString());
                Session.ten = read.Rows[0][1].ToString();
                Session.ngaysinh = read.Rows[0][1].ToString();
                Session.sdt = read.Rows[0][1].ToString();
                Session.quequan = read.Rows[0][1].ToString();
                Session.phucap = read.Rows[0][1].ToString();
                Session.username = read.Rows[0][1].ToString();
                Session.luongcoban = read.Rows[0][1].ToString();

                FMain fMain = new FMain();
                
                fMain.ShowDialog();
                Close();
            }
            else
            {
                lbLoginFailed.Text = "Tài khoản hoặc mật khẩu không đúng !";
            }
        }
        private void LoginKhachHang()
        {
            DataTable read = cn.getDataTable("SELECT * FROM khachhang WHERE username = '" + txtUser.Text + "' and passwordHash = '" + PublicFunction.EncodePassword(txtPassword.Text) + "'");
            if (read.Rows.Count > 0)
            {
                MessageBox.Show("OK kh");
            }
            else
            {
                lbLoginFailed.Text = "Tài khoản hoặc mật khẩu không đúng !";
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (LoginNhanVien)
                {
                    LoginAdmin();
                }
                else
                {
                    LoginKhachHang();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {

        }
    }
}
