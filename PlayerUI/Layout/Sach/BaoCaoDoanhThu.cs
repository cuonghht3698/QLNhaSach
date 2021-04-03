using QLNhaSach.Business;
using QLNhaSach.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.Layout.Sach
{
    public partial class BaoCaoDoanhThu : Form
    {
        private readonly Connect cn;
        private DateTime dateto = DateTime.Now;
        private DateTime dateFrom = DateTime.Now;
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dateto = dateto.AddDays(-6);
            dateTimePicker1.Value = dateto;
            getBaoCao();
        }
        private DataTable data;
        private void getBaoCao()
        {
             data = cn.getDataTable("SELECT  ct.sachId,s.ten, sum(ct.soluong) as 'Số lượng bán'," +
                " sum(ct.soluong * ct.dongia) as 'Tổng thu' FROM hoadon h  join chitiethoadon ct on ct.hoadonId = h.id " +
                "join sach s on s.id = ct.sachId where trangthai = N'Hoàn thành' " +
                " and h.ngaygiaohang >= '" + PublicFunction.GetDate(dateto) + "' and h.ngaygiaohang <= '" + PublicFunction.GetDate(dateFrom) + "' group by ct.sachId,s.ten");
            dataGridView1.DataSource = data;
            int tong = 0;
            int sl = 0;

            foreach (DataRow item in data.Rows)
            {
                tong += Int32.Parse(item[3].ToString());
                sl += Int32.Parse(item[2].ToString());

            }
            lbTong.Text = tong.ToString() + " Đồng";
            lbSL.Text = sl.ToString();
            label2.Text =  "Từ ngày " + dateto.ToShortDateString() + " đến " + dateFrom.ToShortDateString() + " (" +  PublicFunction.CountDay(dateto, dateFrom) + " ngày )";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateto = dateTimePicker1.Value.Date;
            getBaoCao();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateto = dateTimePicker1.Value.Date;
            getBaoCao();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var product = new DataTable();
            product.Columns.Add("tenhang", typeof(string));
            product.Columns.Add("soluong", typeof(int));
            product.Columns.Add("dongia", typeof(int));
            product.Rows.Add("Kỷ thuật lập trình C#", 5, 55000);
            product.Rows.Add("Cơ sở dữ liệu và thuật toán", 3, 15000);
            product.Rows.Add("Giáo trình Photoshop", 20, 65000);
            product.Rows.Add("Triết học", 7, 15000);
            product.Rows.Add("Lập trình mạng Cisco", 2, 21000);
            product.Rows.Add("Làm chủ Microsoft Office 2019", 3, 89000);
            product.Rows.Add("Lập trình hướng đối tượng JAVA", 1, 150000);
            product.Rows.Add("Giáo trình Android/IOS", 8, 90000);
            product.TableName = "productdetails";

            var info = new DataTable();
            info.Columns.Add("tencuahang");
            info.Columns.Add("diachi");
            info.Columns.Add("tenkhachhang");
            info.Columns.Add("diachikhachhang");
            info.Columns.Add("ngaythang");
            info.Columns.Add("dienthoai");
            info.Rows.Add("NHÀ SÁCH TIN HỌC VB.NET", "Địa chỉ: 05/27 Trung Thành, Quảng Thành, Châu Đức, BRVT", "Tên khách hàng: Nguyễn Thảo", "Địa chỉ: Biên Hòa - Đồng Nai", "Biên Hòa, Ngày 02 tháng 12 năm 2020", "Điện thoại: 0933.913.122");
            info.TableName = "info";
            var ds = new DataSet();
            ds.Tables.Add(product);
            ds.Tables.Add(info);
            ExportExcel.FillReport("invoice.xlsx", "template.xlsx", ds, new string[] { "{", "}" });
            Process.Start("invoice.xlsx");
            //var ds = new DataSet();
            //ds.Tables.Add(data);
            //ExportExcel.FillReport("demo1.xlsx", "demo.xlsx", ds, new string[] { "{", "}" });
            //Process.Start("invoice.xlsx");
        }
    }
}
