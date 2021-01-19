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
        private int pageIndex = 1;
        private int pageSize = 30;
        private string theloai = "";
        private int giabanTu = 0;
        private int giabanDen = 0;



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
            cbSLoaiSach.Items.Add("-- Thể loại");
            getTheLoai();
            // gen
            WidthForm = this.Width;
            HeightForm = this.Height;
            width = 20;
            height = 30;
            dem = 0;
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
            dataSach = cn.getSachKhProcedure(0, search, pageIndex, pageSize, theloai, giabanTu, giabanDen);
            RefeshPage();
        }

        private void RefeshPage()
        {
            int id, luotxem;
            string ten, anh, mota, gia;
            checkPageSach = true;
            width = 20;
            height = 30;
            dem = 0;
            panelNext.Visible = true;
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
                    luotxem = 0;
                    addSp(id, ten, anh, mota, gia, luotxem);
                }
            }
        }



        private int width = 20;
        private int height = 30;
        private int dem = 0;

        private void addSp(int id, string Sten, string anh, string Smota, string Sgia, int Sluotxem)
        {

            // kiem tra panel
            dem += 1;

            if (width + 100 < WidthForm / 1.4)
            {
                if (dem > 1)
                    width += 200;
            }
            else
            {
                height += 280;
                width = 20;
            }
            Panel panel = new Panel();
            PictureBox pictureBox = new PictureBox();
            IconButton button = new IconButton();
            Label ten = new Label();
            Label mota = new Label();
            Label gia = new Label();
            Label luotxem = new Label();


            //Panel
            panel.BackColor = Color.FromArgb(255, 192, 192);
            panel.Location = new Point(20 + (width), height);
            panel.Size = new Size(159, 255);
            panel.Cursor = Cursors.Hand;
            panel.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };

            //button
            button.Text = "Đặt";
            button.Location = new Point(69, 136);
            button.Size = new Size(77, 28);
            button.Tag = "hihi";
            button.ForeColor = Color.Blue;
            button.IconChar = IconChar.CartPlus;
            button.IconColor = Color.Green;
            button.IconFont = IconFont.Auto;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.IconSize = 25;
            button.Click += (object sender, EventArgs e) =>
            {
                AddToCart(id, Int32.Parse(Sgia));
            };
            panel.Controls.Add(button);
            // anh
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(13, 15);
            pictureBox.Size = new Size(133, 115);
            pictureBox.Image = PublicFunction.GetImageFromString(anh);
            pictureBox.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(pictureBox);
            //ten
            ten.Text = "Tên   : " + Sten;
            ten.Location = new Point(10, 162);
            panel.Controls.Add(ten);
            ten.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            //mota
            mota.Text = "Mô tả : " + Smota;
            mota.Location = new Point(10, 185);
            mota.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(mota);
            //gia
            gia.Text = "Giá : " + Sgia;
            gia.Location = new Point(10, 206);
            gia.Click += (object sender, EventArgs e) =>
            {
                goToDetail(id);
            };
            panel.Controls.Add(gia);
            //luotxem
            luotxem.Text = "Lượt xem : " + Sluotxem;
            luotxem.Location = new Point(10, 232);
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
            panelNext.Visible = false;
            panelSearh.Visible = false;
            openChildForm(new FDetailSach(id));
        }
        private void FMainKH_ResizeEnd(object sender, EventArgs e)
        {
            if (checkPageSach)
            {
                width = 20;
                height = 30;
                dem = 0;
                WidthForm = panelChildForm.Width;
                HeightForm = panelChildForm.Height;
                panelChildForm.Controls.Clear();
                RefeshPage();
            }

        }

        private void btnOpenSach_Click(object sender, EventArgs e)
        {
            width = 20;
            height = 30;
            dem = 0;
            WidthForm = panelChildForm.Width;
            HeightForm = panelChildForm.Height;
            panelChildForm.Controls.Clear();
            RefeshPage();
            checkCart(); 
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
                width = 20;
                height = 30;
                dem = 0;
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
            pageSize = Int32.Parse(cbSPerPage.SelectedItem.ToString());
            getPage();

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
            check = !check;
            panelDetaiHoaDon.Visible = check;
        }

        private void btnShowHoaDon_Click(object sender, EventArgs e)
        {
            checkPageSach = false;
            panelNext.Visible = false;
            panelSearh.Visible = false;
            openChildForm(new FLichSuMuaHang());

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            checkPageSach = false;
            panelNext.Visible = false;
            panelSearh.Visible = false;
            openChildForm(new FGioHang());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            checkPageSach = false;
            panelNext.Visible = false;
            panelSearh.Visible = false;
            openChildForm(new FQLTaiKhoan());
        }
    }
}
