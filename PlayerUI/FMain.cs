using QLNhaSach.Function;
using QLNhaSach.Layout;
using QLNhaSach.Layout.Sach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
            panelToolsSubMenu.Visible = false;
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FNhaXB());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FKho());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            openChildForm(new FLoaiSach());
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

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
           
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
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
          
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
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
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
        }


        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }
    }
}
