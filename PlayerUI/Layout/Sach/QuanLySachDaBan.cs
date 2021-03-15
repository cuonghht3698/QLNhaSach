﻿using QLNhaSach.Business;
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
    public partial class QuanLySachDaBan : Form
    {
        private readonly Connect cn;
        private int Id = 0;

        private string trangthai;
        public QuanLySachDaBan()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void QuanLySachDaBan_Load(object sender, EventArgs e)
        {
            getSachDaBan();
            comboBox1.Items.Add(TrangThai.GiaoHang);
            comboBox1.Items.Add(TrangThai.HoanThanh);
            comboBox1.SelectedIndex = 1;
        }

        private void getSachDaBan()
        {
            string sql = "SELECT * FROM hoadon where (" + Id +" = 0 or id = " + Id+") and trangthai = N'" + trangthai +  "'";
            dataGridView1.DataSource = cn.getDataTable(sql);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                trangthai = "";
            }
            else
            {
                trangthai = comboBox1.SelectedItem.ToString();
            }
            getSachDaBan();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                Id = result;
             
            }
            else
            {
                Id = 0;
                //not an int
            }
            getSachDaBan();
        }
        private void getChiTiet(int id,string ngaydat)
        {
            string sql = "SELECT ct.id,ct.dongia,ct.soluong,s.id as 'Mã sách',s.ten as 'Tên sách' FROM chitiethoadon ct join sach s on ct.sachId = s.id where hoadonId =" + id;
            var data = cn.getDataTable(sql);
            dataGridView2.DataSource = data;
            if (data.Rows.Count > 0)
            {
                int tongtien = 0;
                foreach (DataRow item in data.Rows)
                {
                    tongtien += Int32.Parse(item[1].ToString());
                }
                lbTongTien.Text = tongtien.ToString() + " Đồng.";
                lbNgayDat.Text = ngaydat;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string ngaydat = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                getChiTiet(id,ngaydat);
            }
        }
    }
}
