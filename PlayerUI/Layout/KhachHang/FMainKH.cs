using FontAwesome.Sharp;
using QLNhaSach.Business;
using QLNhaSach.Function;
using QLNhaSach.Layout.Authent;
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

namespace QLNhaSach.Layout.KhachHang
{
    public partial class FMainKH : Form
    {
        private Connect cn;
        private DataTable dataSach;
        private string ma;
        private string search = "";
        private int PageIndex = 1;
        private int PageSize = 30;
        private string theloai = "";
        private int giabanTu = 0;
        private int giabanDen = 0;
        private int total = 0;



        private bool checkPageSach = true;
        private int WidthForm;
        private int HeightForm;
        public FMainKH()
        {
            InitializeComponent();
            cn = new Connect();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FMainKH_Load(object sender, EventArgs e)
        {
            GenSLoaiSach();
            cbSLoaiSach.Items.Add("-- Thể loại");
            getTheLoai();
            // gen
            WidthForm = this.Width;
            HeightForm = this.Height;
            WidthForm = panelChildForm.Width;
            HeightForm = panelChildForm.Height;
            getPage();
            lbXinchao.Text = Session.ten;

            cbSLoaiSach.SelectedIndex = 0;
            cbSPerPage.SelectedIndex = 1;
            checkCart();
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
        private void getPage()
        {
            dataSach = cn.getSachKhProcedure(0, search, PageIndex, PageSize, theloai, giabanTu, giabanDen, out int total);
            this.total = total;
            lbTong.Text = total.ToString();
            //lbPageIndex.Text = PageIndex.ToString() + " / " + (total / PageIndex).ToString();
            RefeshPage();
        }

        private void RefeshPage()
        {
            int id, luotxem;
            string ten, anh, mota, gia;
            checkPageSach = true;
            w = 0;
            h = 20;
            count = 0;
            panelSearh.Visible = true;
            WidthForm = panelChildForm.Width;
            HeightForm = panelChildForm.Height;
            panelChildForm.Controls.Clear();
            if (dataSach.Rows.Count > 0)
            {
                foreach (DataRow item in dataSach.Rows)
                {
                    id = int.Parse(item[1].ToString());
                    ten = item[2].ToString();
                    anh = item[11].ToString();
                    mota = item[5].ToString();
                    gia = item[4].ToString();
                    luotxem = Int32.Parse(item[13].ToString());
                    addSp(id, ten, anh, mota, gia, luotxem);
                }
            }
        }



        private int w = 0;
        private int h = 20;
        private int count = 0;

        private void addSp(int id, string Sten, string anh, string Smota, string Sgia, int Sluotxem)
        {

            // kiem tra panel
            // location
            w = (panelMau.Width + 10) * count;

            if (panelChildForm.Width < w + 270)
            {
                w = 0;
                count = 0;
                h += panelMau.Height + 20;
            }
            count++;
            Panel panel = new Panel();
            PictureBox pictureBox = new PictureBox();
            IconButton button = new IconButton();
            Label ten = new Label();
            Label mota = new Label();
            Label gia = new Label();
            Label luotxem = new Label();


            //Panel
            panel.BackColor = panelMau.BackColor;
            panel.Location = new Point(20 + w, h);
            panel.Size = panelMau.Size;
            panel.Cursor = Cursors.Hand;
            panel.BorderStyle = panelMau.BorderStyle;
            panel.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };

            //button
            button.Text = btnDatMau.Text;
            button.Location = btnDatMau.Location;
            button.Size = btnDatMau.Size;
            button.ForeColor = btnDatMau.ForeColor;
            button.IconChar = btnDatMau.IconChar;
            button.ImageAlign = btnDatMau.ImageAlign;
            button.IconColor = btnDatMau.IconColor;
            button.IconFont = btnDatMau.IconFont;
            button.TextImageRelation = btnDatMau.TextImageRelation;
            button.IconSize = btnDatMau.IconSize;
            btnDatMau.TextAlign = btnDatMau.TextAlign;
            button.Click += (object sender, EventArgs e) =>
            {
                AddToCart(id, Int32.Parse(Sgia));
            };
            panel.Controls.Add(button);
            // anh
            pictureBox.SizeMode = picMau.SizeMode;
            pictureBox.Location = picMau.Location;
            pictureBox.Size = picMau.Size;
            pictureBox.Image = PublicFunction.GetImageFromString(anh);
            pictureBox.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(pictureBox);
            //ten
            ten.Text = "Tên   : " + Sten;
            ten.Location = labelTenMau.Location;
            ten.AutoSize = labelTenMau.AutoSize;
            ten.Font = labelTenMau.Font;
            ten.Size = labelTenMau.Size;
            ten.ForeColor = labelTenMau.ForeColor;
            panel.Controls.Add(ten);
            ten.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
             //gia
            gia.Text = "Giá : " + Sgia;
            gia.Location = labelGiaMau.Location;
            gia.Font = labelGiaMau.Font;
            gia.BackColor = labelGiaMau.BackColor;

            gia.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(gia);
            //luotxem
            luotxem.Text = "Lượt xem : " + Sluotxem;
            luotxem.Location = labelView.Location;
            luotxem.Font = labelView.Font;
            luotxem.BackColor = labelView.BackColor;
            luotxem.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(luotxem);


            // add 
            panelChildForm.Controls.Add(panel);


        }

        private void getTheLoai()
        {
            var data = cn.getDataTable("select * from loaisach");
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    cbSLoaiSach.Items.Add(item[1].ToString());

                }
            }
        }
        int idHoaDon = 0;
        private void checkCart()
        {

            var data = cn.getDataTable("select top 1 * from hoadon where khachhangId =" + Session.idUser + " and trangthai =N'" + TrangThai.TaoPhieu + "'");
            if (data.Rows.Count > 0)
            {
                idHoaDon = Int32.Parse(data.Rows[0][0].ToString());
            }
            else
            {
                // khong co hoa don nao
                cn.ExecuteNonQuery("insert into hoadon (khachhangId, nhanvienId,ngaydat,ngaygiaohang,noigiaohang,sdt,trangthai) values("
                    + Session.idUser + ",NULL,NULL,NULL,NULL,NULL,N'" + TrangThai.TaoPhieu + "')");
                var data1 = cn.getDataTable("select top 1 * from hoadon where khachhangId =" + Session.idUser + " and trangthai =N'" + TrangThai.TaoPhieu + "'");
                if (data1.Rows.Count > 0)
                {
                    idHoaDon = Int32.Parse(data1.Rows[0][0].ToString());
                }
            }
        }

        private void AddToCart(int id ,int dongia)
        {
            cn.ExecuteNonQuery("insert into chitiethoadon (hoadonId,sachId,dongia,soluong) values(" + idHoaDon + "," + id + "," + dongia + ",1)");
            MessageBox.Show("Thêm vào giỏ hàng thành công!", "Thông báo!");
        }
        private void goToDetail(int id)
        {

            checkPageSach = false;
            panelSearh.Visible = false;
            UpdateView(id);
            openChildForm(new FDetailSach(id));
        }

        private void UpdateView(int id)
        {
            cn.ExecuteNonQuery("update sach set luotxem = luotxem + 1 where id = " + id);
        }
        private void FMainKH_ResizeEnd(object sender, EventArgs e)
        {
            if (checkPageSach)
            {
                WidthForm = panelChildForm.Width;
                HeightForm = panelChildForm.Height;
                panelChildForm.Controls.Clear();
                RefeshPage();
            }

        }

        private void btnOpenSach_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
           
            WidthForm = panelChildForm.Width;
            HeightForm = panelChildForm.Height;
            panelChildForm.Controls.Clear();
            RefeshPage();
            checkCart();
            panel5.Visible = true;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {

        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            if (checkPageSach)
            {
               
                WidthForm = panelChildForm.Width;
                HeightForm = panelChildForm.Height;
                panelChildForm.Controls.Clear();
                RefeshPage();
            }

        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSSearh_TextChanged(object sender, EventArgs e)
        {
            search = txtSSearh.Text;
            getPage();
        }

        private void cbSLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            theloai = cbSLoaiSach.SelectedIndex == 0 ? "" : cbSLoaiSach.SelectedItem.ToString();
            getPage();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                giabanTu = Int32.Parse(txtSGiaTu.Text);
                getPage();
            }
            catch
            {

            }

        }

        private void txtSGiaDen_TextChanged(object sender, EventArgs e)
        {

            try
            {
                giabanDen = Int32.Parse(txtSGiaDen.Text);
                getPage();
            }
            catch
            {

            }

        }

        private void cbSPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Int32.Parse(cbSPerPage.SelectedItem.ToString());
            getPage();

        }
        private void GenSLoaiSach()
        {
            var data = cn.getDataTable("select * from loaisach");
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    IconButton icon = new IconButton();
                    icon.Size = btnSLoaiMau.Size;
                    icon.BackColor = btnSLoaiMau.BackColor;
                    icon.Dock = btnSLoaiMau.Dock;
                    icon.ForeColor = btnSLoaiMau.ForeColor;
                    icon.Text = item[1].ToString();
                    icon.Click += (object sender, EventArgs e) =>
                      {
                          theloai = item[1].ToString();
                          getPage();
                      };
                    panel5.Controls.Add(icon);
                }
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Session.idUser = 0;
            Session.ten = "";
            Session.ngaysinh = "";
            Session.sdt = "";
            Session.quequan = "";
            Session.username = "";
            Session.quyen = "";

            Login lg = new Login();
            lg.Show();
            this.Visible = false;
        }

        private bool check = false;
        private void iconButton8_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;

            check = !check;
            panelDetaiHoaDon.Visible = check;
        }

        private void btnShowHoaDon_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;

            checkPageSach = false;
            panelSearh.Visible = false;
            openChildForm(new FLichSuMuaHang());

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;

            checkPageSach = false;
            panelSearh.Visible = false;
            openChildForm(new FGioHang());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;

            checkPageSach = false;
            panelSearh.Visible = false;
            openChildForm(new FQLTaiKhoan());
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            openChildForm(new FQLTaiKhoan());
        }

        private void btnSLoaiMau_Click(object sender, EventArgs e)
        {
            theloai = "";
            getPage();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;

            getPage();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (PageIndex == 1)
            {
                return;
            }
            PageIndex -= 1;

            getPage();
        }

        private void iconButton9_Click_1(object sender, EventArgs e)
        {
            PageIndex += 1;

            getPage();
        }
    }
}
