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

namespace QLNhaSach.Layout.Sach
{

    public partial class FQLSach : Form
    {
        private Connect cn;
        private string ma;
        private string search = "";
        private int Sactive = 0;
        private int Skho = 0;
        private int Sncc = 0;
        private int Sloai = 0;
        private int Snxb = 0;
        public FQLSach()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void FQLSach_Load(object sender, EventArgs e)
        {
            BindGrid();
            addButtonDataGripview();
            datePickNgayNhap.CustomFormat = "dd/MM/yyyy";
            setDataCombo();
            checkActive.Checked = true;
            ClearSearch();
        }
        private void BindGrid()
        {
            dataGridView1.DataSource = cn.callSachProcedure("getSach", search, Skho, Sncc, Sloai, Snxb, Sactive);

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
                checkActive.Text = read.Rows[0][12].ToString() == "True" ? "Hoạt động" : "Ngừng kinh doanh";
                checkActive.Checked = read.Rows[0][12].ToString() == "True" ? true : false;



            }
        }
        private void addButtonDataGripview()
        {
            dataGridView1.Columns[0].Width = 34;
            dataGridView1.Columns[1].Width = 34;
            dataGridView1.Columns[11].Width = 44;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.Width = 20;
            delete.DefaultCellStyle.BackColor = Color.Red;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
        }
        private void Delete(string ma)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cn.ExecuteNonQuery("Delete sach where id =" + ma);
                BindGrid();
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
                string kho, ncc, nxb, loai,anh;
                kho = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                ncc = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                loai = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                nxb = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                anh = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
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
                //AUTO NXB
                if (String.IsNullOrEmpty(anh))
                {
                    
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
            cbHoatDong.SelectedIndex = 0;
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
                    Console.WriteLine(PublicFunction.GetStringFromImage(ptbAnh.Image)); 
                }
            }
        }


        private void Insert(bool check)
        {
            string ten, tacgia, mota, anh;
            int id,soluong, dongia, khoId, nccId, loaisachId, nxbId;
            DateTime ngaynhap;
            bool active;
            id = int.Parse(txtMa.Text);
            ten = txtTen.Text;
            tacgia = txtTacGia.Text;
            mota = txtMoTa.Text;
            anh = ptbAnh.Image.ToString() != null ? PublicFunction.GetStringFromImage(ptbAnh.Image) : "";
            soluong = int.Parse(txtSoLuong.Text);
            dongia = int.Parse(txtDonGia.Text);
            ngaynhap = DateTime.Now;
            khoId = PublicFunction.GetIdFromCombobox(cbKho.SelectedItem.ToString());
            nccId = PublicFunction.GetIdFromCombobox(cbNCC.SelectedItem.ToString());
            loaisachId = PublicFunction.GetIdFromCombobox(cbLoaiSach.SelectedItem.ToString());
            nxbId = PublicFunction.GetIdFromCombobox(cbNhaXuatBan.SelectedItem.ToString());
            active = checkActive.Checked;
            if(check)
            cn.CreateOrUpdateSachProcedure(true,0,ten,soluong,dongia,ngaynhap,tacgia,mota,anh,khoId,nccId,loaisachId,nxbId,active);
            else
                cn.CreateOrUpdateSachProcedure(false, id, ten, soluong, dongia, ngaynhap, tacgia, mota, anh, khoId, nccId, loaisachId, nxbId, active);
            BindGrid();
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
    }
}
