using QLNhaSach.Business;
using QLNhaSach.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout.KhachHang
{
    public partial class FGioHang : Form
    {
        private Connect cn;
        private int thanhtien = 0;
        private int IdHoaDong;
        private DataTable dataHoaDon;
        private int FindId = 0;
        private string TrangThaiHD;
        public FGioHang()
        {
            InitializeComponent();
            cn = new Connect();
            btnHuy.Visible = false;
            btnTiepNhan.Visible = false;
        }
        public FGioHang(int v)
        {
            InitializeComponent();
            cn = new Connect();
            FindId = v;
            btnDatHang.Visible = false;
            btnMuaThem.Visible = false;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            btnTiepNhan.Visible = true;


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FGioHang_Load(object sender, EventArgs e)
        {
            getGioHang();
            txtDiaChi.Text = Session.quequan;
            txtSDT.Text = Session.sdt;

        }
        private DataTable TruyVan()
        {
            string trang = "";
            if (FindId == 0)
            {
                trang = TrangThai.TaoPhieu;
            }

            return cn.getDataTable("select s.ten,ct.dongia,ct.soluong,s.anh,ct.id,(ct.soluong * ct.dongia) as 'ThanhTien', h.id,h.trangthai from hoadon h join chitiethoadon ct on h.id = ct.hoadonId join sach s on ct.sachId = s.id" +
                " where ("+FindId+" != 0 or h.khachhangId = " + Session.idUser + ") and ('" + trang + "' = '' or h.trangthai = N'" + trang + "') and (" + FindId + " = 0 or h.id = " + FindId + ")" );
        }

        private void getGioHang()
        {
            dataHoaDon = TruyVan();
            if (dataHoaDon.Rows.Count > 0)
            {
                panelEmpty.Visible = false;
                lbTrangThaiHD.Text = dataHoaDon.Rows[0][7].ToString();
                IdHoaDong = Int32.Parse(dataHoaDon.Rows[0][6].ToString());
                panelParent.Controls.Clear();
                foreach (DataRow item in dataHoaDon.Rows)
                {
                    thanhtien += Int32.Parse(item[5].ToString());

                    addRow(item);
                }
                lbTongTien.Text = thanhtien.ToString();
                lbTongTienChu.Text = "( " + PublicFunction.ChuyenSo(thanhtien.ToString()) + " đồng )";

            }
            else
            {
                
                panelParent.Controls.Clear();
                panelParent.Controls.Add(panelEmpty);
                panelEmpty.Visible = true;

            }
        }

        private void UpdateTienChu()
        {
            var data = TruyVan();
            thanhtien = 0;
            foreach (DataRow item in data.Rows)
            {
                thanhtien += Int32.Parse(item[5].ToString());

            }
            lbTongTien.Text = thanhtien.ToString();
            lbTongTienChu.Text = "( " + PublicFunction.ChuyenSo(thanhtien.ToString()) + " đồng )";
        }
        private void addRow(DataRow item)
        {

            Panel panel = new Panel();
            Panel line = new Panel();

            PictureBox pictureBox = new PictureBox();
            Label lbTen = new Label();
            Label lbDonGia = new Label();
            Label lbThanhTienTitle = new Label();

            Label lbThanhTien = new Label();
            Button btnGiamSL = new Button();
            Button btnTangSL = new Button();
            Button btnDelete = new Button();
            TextBox txtsL = new TextBox();

            // panel 
            panel.BackColor = Color.FromArgb(224, 224, 224);
            panel.Dock = DockStyle.Top;

            panel.Size = new Size(658, 144);
            panelParent.Controls.Add(panel);

            // panel line
            line.Size = new Size(658, 12);
            line.Dock = DockStyle.Bottom;
            line.BackColor = Color.White;
            panel.Controls.Add(line);

            // btn xoa
            btnDelete.Text = "X";
            if (FindId != 0)
                btnDelete.Enabled = false;
            btnDelete.Font = new Font(Font.FontFamily, 22);
            btnDelete.Location = new Point(9, 10);
            btnDelete.Size = new Size(64, 116);
            btnDelete.Click += (object sender, EventArgs e) =>
            {
                Delete(Int32.Parse(item[4].ToString()));
            };
            panel.Controls.Add(btnDelete);
            // anh sach
            pictureBox.Size = new Size(115, 121);
            pictureBox.Location = new Point(79, 6);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = PublicFunction.GetImageFromString(item[3].ToString());
            panel.Controls.Add(pictureBox);

            // lb tên
            lbTen.Text = item[0].ToString();
            lbTen.Location = new Point(235, 24);
            lbTen.Font = new Font(Font.FontFamily, 12);
            panel.Controls.Add(lbTen);
            // lb dongia giá
            //lbDonGia.Font = new Font(Font.FontFamily, 12);
            lbDonGia.Text = (item[1].ToString() + " đồng");
            lbDonGia.Location = new Point(235, 87);
            panel.Controls.Add(lbDonGia);
            // btn giam
            btnGiamSL.Text = "-";
            btnGiamSL.Size = new Size(33, 25);
            if (FindId != 0)
                btnGiamSL.Enabled = false;
            btnGiamSL.Location = new Point(491, 22);
            btnGiamSL.BackColor = Color.Red;
            btnGiamSL.Click += (object sender, EventArgs e) =>
            {
                GiamSoSach(item[4].ToString(), Int32.Parse(item[4].ToString()), Int32.Parse(item[1].ToString()));
            };
            panel.Controls.Add(btnGiamSL);

            // txt số lượng
            txtsL.Text = item[2].ToString();
            txtsL.Name = "txt" + item[4].ToString();
            txtsL.Location = new Point(530, 22);
            txtsL.Size = new Size(46, 25);
            if (FindId != 0)
                txtsL.ReadOnly = true;
            txtsL.TextAlign = HorizontalAlignment.Center;
            txtsL.Font = new Font(Font.FontFamily, 12);
            txtsL.TextChanged += (object sender, EventArgs e) =>
            {
                EditSL(item[4].ToString(), Int32.Parse(item[4].ToString()), Int32.Parse(item[1].ToString()));
            };
            panel.Controls.Add(txtsL);

            // btn tang
            btnTangSL.Text = "+";
            btnTangSL.Size = new Size(33, 25);
            btnTangSL.Location = new Point(582, 22);
            if (FindId != 0)
                btnTangSL.Enabled = false;
            btnTangSL.BackColor = Color.Green;
            btnTangSL.Click += (object sender, EventArgs e) =>
            {
                TangSlSach(item[4].ToString(), Int32.Parse(item[4].ToString()), Int32.Parse(item[1].ToString()));
            };
            panel.Controls.Add(btnTangSL);

            // lb thanh  tiền  tilte
            lbThanhTienTitle.Text = "Thành tiền";
            lbThanhTienTitle.Location = new Point(514, 59);
            panel.Controls.Add(lbThanhTienTitle);

            // lb thanh  tiền 
            lbThanhTien.Text = (Int32.Parse(item[1].ToString()) * Int32.Parse(item[2].ToString())).ToString();
            lbThanhTien.Name = "txttien" + Int32.Parse(item[4].ToString());
            lbThanhTien.Location = new Point(527, 90);
            panel.Controls.Add(lbThanhTien);


        }

        private void EditSL(string nameTxt, int id, int dg)
        {
            TextBox ctn = (TextBox)this.Controls.Find("txt" + nameTxt, true)[0];
            if (!String.IsNullOrEmpty(ctn.Text))
            {
                Label lb = (Label)this.Controls.Find("txttien" + nameTxt, true)[0];
                int a = Int32.Parse(ctn.Text);
                lb.Text = (a * dg).ToString();
                updateSl(id, a);
                UpdateTienChu();
            }


        }

        private void Delete(int id)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                    "Cảnh báo!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cn.ExecuteNonQuery("DELETE chitiethoadon where id =" + id);
                getGioHang();
                UpdateTienChu();
                

            }
        }

        private void updateSl(int id, int sl)
        {
            cn.ExecuteNonQuery("UPDATE chitiethoadon set soluong =" + sl + " where id =" + id);
        }

        private void TangSlSach(string nameTxt, int id, int dg)
        {
            TextBox ctn = (TextBox)this.Controls.Find("txt" + nameTxt, true)[0];
            Label lb = (Label)this.Controls.Find("txttien" + nameTxt, true)[0];
            int a = Int32.Parse(ctn.Text) + 1;
            ctn.Text = a.ToString();
            lb.Text = (a * dg).ToString();
            updateSl(id, a);
            UpdateTienChu();
        }

        private void GiamSoSach(string nameTxt, int id, int dg)
        {
            TextBox ctn = (TextBox)this.Controls.Find("txt" + nameTxt, true)[0];
            Label lb = (Label)this.Controls.Find("txttien" + nameTxt, true)[0];
            if (Int32.Parse(ctn.Text) > 1)
            {
                int a = Int32.Parse(ctn.Text) - 1;
                ctn.Text = a.ToString();
                lb.Text = (a * dg).ToString();
                updateSl(id, a);
                UpdateTienChu();

            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void datHang()
        {
            try
            {
                DateTime ngaydat = DateTime.Now;
                cn.ExecuteNonQuery("UPDATE hoadon set noigiaohang = N'" + txtDiaChi.Text + "', sdt = '" + txtSDT.Text + "', ngaydat = '" + ngaydat.ToString() + "', trangthai =N'Chờ duyệt' where id =" + IdHoaDong);
                MessageBox.Show("Đặt hàng thành công! Chúng tôi sẽ liên hệ với bạn!", "Thông báo");
                panelParent.Controls.Clear();

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void HuyDon()
        {
            var confirmResult = MessageBox.Show("Bạn có muốn từ chối đơn hàng ??",
                                    "Cảnh báo!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cn.ExecuteNonQuery("update hoadon set trangthai =N'" + TrangThai.DaHuy + "' where id = " + FindId);
                getGioHang();
                UpdateTienChu();


            }
        }
        private void GiaoHang()
        {
            cn.ExecuteNonQuery("update hoadon set nhanvienId = " + Session.idUser+ ", ngaygiaohang = '" + DateTime.Now + "', trangthai =N'" + TrangThai.GiaoHang + "' where id = " + FindId);
            MessageBox.Show("Tiếp nhận đơn hàng thành công??");
           getGioHang();
            UpdateTienChu();

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            datHang();
            getGioHang();
        }

        private void lbTongTien_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HuyDon();
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            GiaoHang();
        }
    }
}
