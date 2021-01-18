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
    public partial class FDetailSach : Form
    {
        private Connect cn;
        private int id;
        private DataTable dataSach;
        private int soluong =1;
        private int IdHoaDon;
        private int sachId;
        private int dongGia;

        

        private int IdDangNhap = Session.idUser;
        public FDetailSach(int _id)
        {
            InitializeComponent();
            cn = new Connect();
            id = _id;
        }

        private void FSachKH_Load(object sender, EventArgs e)
        {
            getPage();
            CheckHoaDon();

        }

        private void getPage()
        {
            dataSach = cn.getSachKhProcedure(id, "", 1, 1, "", 0, 0);
            if (dataSach.Rows.Count > 0)
            {
                sachId = Int32.Parse(dataSach.Rows[0][1].ToString());
                lbTitle.Text = dataSach.Rows[0][2].ToString();
                lbNcc.Text = PublicFunction.GetNameFromCombobox(dataSach.Rows[0][8].ToString());
                lbNxb.Text = PublicFunction.GetNameFromCombobox(dataSach.Rows[0][10].ToString());
                lbMoTa.Text = dataSach.Rows[0][5].ToString();
                lbTacGia.Text = dataSach.Rows[0][6].ToString();
                lbGia.Text = dataSach.Rows[0][4].ToString() + " đồng";
                dongGia = Int32.Parse(dataSach.Rows[0][4].ToString());
                pictureBox1.Image = PublicFunction.GetImageFromString(dataSach.Rows[0][11].ToString());


            }
        }


        //check hoa don 
        private void CheckHoaDon()
        {
            var data = cn.getDataTable("select top 1 * from hoadon where khachhangId =" + Session.idUser + " and trangthai =N'" + TrangThai.TaoPhieu + "'");
            if (data.Rows.Count > 0)
            {
                IdHoaDon = Int32.Parse(data.Rows[0][0].ToString());
            }
            else
            {
                // khong co hoa dong nao
                cn.ExecuteNonQuery("insert into hoadon (khachhangId, nhanvienId,ngaydat,ngaygiaohang,noigiaohang,sdt,trangthai) values("
                    + IdDangNhap + ",NULL,NULL,NULL,NULL,NULL,N'" + TrangThai.TaoPhieu + "')");
            }
        }

        private void ThemSach()
        {
            cn.ExecuteNonQuery("insert into chitiethoadon (hoadonId,sachId,dongia,soluong) values(" + IdHoaDon + "," + sachId + "," + dongGia + "," + soluong + ")");
            MessageBox.Show("Thêm vào giỏ hàng thành công!","Thông báo!");
        }
        

            private void Button_Click(object sender, EventArgs e)
        {

        }


        private void FSachKH_ResizeEnd(object sender, EventArgs e)
        {


        }

        private void FSachKH_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void lbMoTa_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                soluong = Int32.Parse(txtSL.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Nhập số?", "Thông báo!");
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtSL.Text) > 1)
            {
                txtSL.Text = (Int32.Parse(txtSL.Text) - 1).ToString();
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            txtSL.Text = (Int32.Parse(txtSL.Text) + 1).ToString();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            CheckHoaDon();
            ThemSach();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
