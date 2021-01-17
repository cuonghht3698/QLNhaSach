using QLNhaSach.Function;
using QLNhaSach.Layout;
using QLNhaSach.Layout.Authent;
using QLNhaSach.Layout.NhanSu;
using QLNhaSach.Layout.Sach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            hideSubMenu();
        }

      
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
            panelToolsSubMenu.Visible = false;
        }
        private void SetTitle(string title)
        {
            lbTitle.Text = title;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new FNhaCC());
            //..
            //your codes
            //..
            this.Width = 1200;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FNhaXB());
            this.Width = 1200;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FKho());
            this.Width = 1200;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FLoaiSach());
            this.Width = 1200;
        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FQLSach());
            this.Width = 1350;
        }

        public void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FNhapSach());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FQLNhanVien());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FQLKhachHang());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
           
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
           
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Session.idUser = 0;
            Session.ten = "";
            Session.ngaysinh = "";
            Session.sdt = "";
            Session.quequan = "";
            Session.username = "";
            Session.quyen = "";
            Login l = new Login();
            this.Visible = false;
            l.Show();
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPlayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FMain_Load(object sender, EventArgs e)
        {
            lbName.Text = Session.ten;
            Login f = new Login();
            f.Hide();
        }


        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void panelChildForm_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
