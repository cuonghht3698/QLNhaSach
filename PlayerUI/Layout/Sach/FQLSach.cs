using PlayerUI;
using QLNhaSach.Business;
using QLNhaSach.Function;
using QLNhaSach.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout.Sach
{

    public partial class FQLSach : Form
    {
        private string ImageEmpty;
        private Connect cn;
        private SachService Ssach;
        private string ma;
        private string search = "";
        private int Sactive = 1;
        private int Skho = 0;
        private int Sncc = 0;
        private int Sloai = 0;
        private int Snxb = 0;
        private int PageSize = 10;
        private int PageIndex = 1;
        public FQLSach()
        {
            InitializeComponent();
            cn = new Connect();
            
        }

        public FQLSach(SachService _Ssach)
        {

            Ssach = _Ssach;
        }
        private void FQLSach_Load(object sender, EventArgs e)
        {
            cbPageSize.SelectedIndex = 1;
            BindGrid();
            addButtonDataGripview();
            datePickNgayNhap.CustomFormat = "dd/MM/yyyy";
            setDataCombo();
            checkActive.Checked = true;
            cbKho.SelectedIndex = 0;
            cbNCC.SelectedIndex = 0;
            cbNhaXuatBan.SelectedIndex = 0;
            cbLoaiSach.SelectedIndex = 0;
            cbHoatDong.SelectedIndex = 1; 
            ImageEmpty = PublicFunction.GetStringFromImage(ptbAnh.Image);
            ClearSearch();
        }
        private void BindGrid()
        {
            dataGridView1.DataSource = cn.callSachProcedure("getSach", search, Skho, Sncc, Sloai, Snxb, Sactive, PageIndex, PageSize);
            lbPageIndex.Text = PageIndex.ToString();

        }
        private void GetAllRow()
        {
            DataTable read = cn.getDataTable("select * from sach where id =" + ma);
            if (read.Rows.Count > 0)
            {

                txtMa.Text = read.Rows[0][0].ToString();
                txtTen.Text = read.Rows[0][1].ToString();
                txtSoLuong.Text = read.Rows[0][2].ToString();
                txtDonGia.Text = read.Rows[0][3].ToString();
                string ngaynhap = read.Rows[0][4].ToString();
                datePickNgayNhap.Value = ngaynhap != "" ? DateTime.Parse(ngaynhap) : DateTime.Now;
                txtTacGia.Text = read.Rows[0][5].ToString();
                txtMoTa.Text = read.Rows[0][6].ToString();
                checkActive.Text = read.Rows[0][11].ToString() == "True" ? "Hoạt động" : "Ngừng kinh doanh";
                checkActive.Checked = read.Rows[0][11].ToString() == "True" ? true : false;
                txtGiaBan.Text = read.Rows[0][12].ToString();
                txtDVT.Text = read.Rows[0][14].ToString();


            }
        }
        private void addButtonDataGripview()
        {
            dataGridView1.Columns[0].Width = 34;
            dataGridView1.Columns[1].Width = 44;
            dataGridView1.Columns[4].Width = 104;
            dataGridView1.Columns[10].Width = 50;

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.DefaultCellStyle.BackColor = Color.Red;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
            dataGridView1.Columns[11].Width = 50;

        }
        private void Delete(string ma)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    cn.ExecuteNonQuery("Delete sach where id =" + ma);
                    BindGrid();
                }
                catch
                {
                    DialogResult dr = MessageBox.Show("Sách đang lưu ở lịch sử ! Không thể xóa sách! ", "Thông báo" );
                    //if (dr == DialogResult.Yes)
                    //{
                    //    cn.ExecuteNonQuery("UPDATE sach active = false where id =" + ma);
                    //    BindGrid();
                    //}
                }

            }
        }

        // khóa ngoại
        private void setDataCombo()
        {
            DataTable tbKho = cn.getDataTable("select * from kho");
            if (tbKho.Rows.Count > 0)
            {
                foreach (DataRow item in tbKho.Rows)
                {
                    cbKho.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                    cbSearchKho.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                }
            }
            DataTable tbNcc = cn.getDataTable("select * from nhacungcap");
            if (tbNcc.Rows.Count > 0)
            {
                foreach (DataRow item in tbNcc.Rows)
                {
                    cbNCC.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                    cbSearchNCC.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                }
            }
            DataTable tbNxb = cn.getDataTable("select * from nhaxb");
            if (tbKho.Rows.Count > 0)
            {
                foreach (DataRow item in tbNxb.Rows)
                {
                    cbNhaXuatBan.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                    cbSearchNXB.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                }
            }
            DataTable tbLoai = cn.getDataTable("select * from loaisach");
            if (tbLoai.Rows.Count > 0)
            {
                foreach (DataRow item in tbLoai.Rows)
                {
                    cbLoaiSach.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                    cbSearchLoai.Items.Add(item[0].ToString() + "- " + item[1].ToString());
                }
            }
        }
        // end khóa ngoại



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                Delete(ma);

            }
            else if (e.RowIndex != -1)
            {
                ma = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string kho, ncc, nxb, loai;
                string anh = null;
                kho = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                ncc = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                loai = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                nxb = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                var dt = cn.getDataTable("select anh from sach where id =" + ma);
                if (dt.Rows.Count > 0)
                {
                    anh = dt.Rows[0][0].ToString();
                }

                //AUTO KHO
                if (String.IsNullOrEmpty(kho))
                {
                    cbKho.SelectedIndex = 0;
                }
                else
                {
                    cbKho.SelectedItem = kho;
                }

                //AUTO NCC
                if (String.IsNullOrEmpty(ncc))
                {
                    cbNCC.SelectedIndex = 0;
                }
                else
                {
                    cbNCC.SelectedItem = ncc;
                }

                //AUTO LOAI
                if (String.IsNullOrEmpty(loai))
                {
                    cbLoaiSach.SelectedIndex = 0;
                }
                else
                {
                    cbLoaiSach.SelectedItem = loai;
                }

                //AUTO NXB
                if (String.IsNullOrEmpty(nxb))
                {
                    cbNhaXuatBan.SelectedIndex = 0;
                }
                else
                {
                    cbNhaXuatBan.SelectedItem = nxb;
                }
                //AUTO anh
                if (String.IsNullOrEmpty(anh))
                {
                    ptbAnh.Image = PublicFunction.GetImageFromString(ImageEmpty);

                }
                else
                {
                    ptbAnh.Image = PublicFunction.GetImageFromString(anh);
                }
                GetAllRow();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cbHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sactive = cbHoatDong.SelectedIndex;
            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search = txtSearch.Text;
            BindGrid();
        }

        private void cbSearchNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Snxb = cbSearchNXB.SelectedIndex;
            BindGrid();
        }

        private void cbSearchLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sloai = cbSearchLoai.SelectedIndex;
            BindGrid();
        }

        private void cbSearchNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sncc = cbSearchNCC.SelectedIndex;
            BindGrid();
        }

        private void cbSearchKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skho = cbSearchKho.SelectedIndex;
            BindGrid();
        }

        private void ClearSearch()
        {
            cbSearchNXB.SelectedIndex = 0;
            cbSearchKho.SelectedIndex = 0;
            cbSearchNCC.SelectedIndex = 0;
            cbSearchLoai.SelectedIndex = 0;
            cbHoatDong.SelectedIndex = 1;
            BindGrid();
        }

        private void ptbAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    PictureBox1.Image = new Bitmap(dlg.FileName);
                    ptbAnh.Image = new Bitmap(dlg.FileName);
                }
            }
        }


        private void Insert(bool check)
        {
            try
            {
                string ten, tacgia, mota, anh, dvt;
                int id, soluong, dongia, khoId, nccId, loaisachId, nxbId, giaban;
                DateTime ngaynhap;
                bool active;
                id = String.IsNullOrEmpty(txtMa.Text) ? 0 : int.Parse(txtMa.Text);
                ten = txtTen.Text;
                tacgia = txtTacGia.Text;
                mota = txtMoTa.Text;
                dvt = txtDVT.Text;
                anh = !String.IsNullOrEmpty(ptbAnh.Image.ToString()) ? PublicFunction.GetStringFromImage(ptbAnh.Image) : "";
                soluong = Int32.Parse(txtSoLuong.Text);
                dongia = Int32.Parse(txtDonGia.Text);
                giaban = Int32.Parse(txtGiaBan.Text);
                ngaynhap = DateTime.Now;
                khoId = PublicFunction.GetIdFromCombobox(cbKho.SelectedItem.ToString());
                nccId = PublicFunction.GetIdFromCombobox(cbNCC.SelectedItem.ToString());
                loaisachId = PublicFunction.GetIdFromCombobox(cbLoaiSach.SelectedItem.ToString());
                nxbId = PublicFunction.GetIdFromCombobox(cbNhaXuatBan.SelectedItem.ToString());
                active = checkActive.Checked;
                if (check)
                {
                    cn.CreateOrUpdateSachProcedure(true, 0, ten, soluong, dongia, ngaynhap, tacgia, mota, khoId, nccId, loaisachId, nxbId, active, giaban, anh, dvt);
                    MessageBox.Show("Thêm sản phẩm thành công");
                }

                else
                {
                    cn.CreateOrUpdateSachProcedure(false, id, ten, soluong, dongia, ngaynhap, tacgia, mota, khoId, nccId, loaisachId, nxbId, active, giaban, anh, dvt);
                    MessageBox.Show("Sửa sản phẩm thành công");
                }
                        
                BindGrid();
            }
            catch
            {
                MessageBox.Show("Cách trường dữ liệu không đúng!", "Thông báo");
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {

            Insert(true);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Insert(false);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkActive_CheckedChanged(object sender, EventArgs e)
        {
            checkActive.Text = checkActive.Checked == true ? "Hoạt động" : "Ngừng kinh doanh";
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            FMain fm = new FMain();
            fm.button7_Click(this, EventArgs.Empty);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Int32.Parse(cbPageSize.SelectedItem.ToString());
            BindGrid();
            lbPageIndex.Text = PageIndex.ToString();

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (PageIndex == 1)
            {
                return;
            }
            PageIndex -= 1;
            lbPageIndex.Text = PageIndex.ToString();

            BindGrid();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            PageIndex += 1;
            lbPageIndex.Text = PageIndex.ToString();
            BindGrid();
        }
    }
}
