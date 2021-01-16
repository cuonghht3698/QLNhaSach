using PlayerUI;
using QLNhaSach.Business;
using QLNhaSach.Function;
using QLNhaSach.Layout.KhachHang;
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
            DangKy dk = new DangKy();
            dk.Show();
        }

        private void linkGoToLoginAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginNhanVien = !LoginNhanVien;
            if (LoginNhanVien)
            {
                lbCheckNV.Text = "Chế độ quản trị viên";
                btnDangNhap.Text = "Đăng nhập";
                linkQuenMatKhau.Visible = false;
                LinkTaoTaiKhoan.Visible = false;
                txtUser.Text = "admin";
                txtPassword.Text = "admin";
            }
            else
            {
                lbCheckNV.Text = "";
                btnDangNhap.Text = "Đăng nhập";
                txtUser.Text = "cuong";
                txtPassword.Text = "cuong";
                linkQuenMatKhau.Visible = true;
                LinkTaoTaiKhoan.Visible = true;
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

            DataTable read =  cn.getDataTable("SELECT * FROM nhanvien WHERE username = '" + txtUser.Text + 
                "' and passwordHash = '" + PublicFunction.EncodePassword(txtPassword.Text) + "' and active = 'true'");
            if (read.Rows.Count >0)
            {
                Session.idUser = int.Parse(read.Rows[0][0].ToString());
                Session.ten = read.Rows[0][1].ToString();
                Session.ngaysinh = read.Rows[0][2].ToString();
                Session.sdt = read.Rows[0][3].ToString();
                Session.quequan = read.Rows[0][5].ToString();
                Session.username = read.Rows[0][6].ToString();
                Session.quyen = read.Rows[0][9].ToString();
                this.Hide();
                FMain fMain = new FMain();
                fMain.ShowDialog();
                
            }
            else
            {
                lbLoginFailed.Text = "Tài khoản hoặc mật khẩu không đúng !";
            }
        }
        private void LoginKhachHang()
        {
            DataTable read = cn.getDataTable("SELECT * FROM khachhang WHERE username = '" + txtUser.Text + 
                "' and passwordHash = '" + PublicFunction.EncodePassword(txtPassword.Text) + "' and active = 'true'");
            if (read.Rows.Count > 0)
            {
                Session.idUser = int.Parse(read.Rows[0][0].ToString());
                Session.ten = read.Rows[0][1].ToString();
                Session.ngaysinh = read.Rows[0][2].ToString();
                Session.sdt = read.Rows[0][3].ToString();
                Session.quequan = read.Rows[0][5].ToString();
                Session.username = read.Rows[0][6].ToString();
                this.Hide();
                FMainKH fMainKH = new FMainKH();
                fMainKH.ShowDialog();
                
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
            Console.WriteLine(Application.StartupPath);

        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
