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

        private void getBaoCao()
        {
            var data = cn.getDataTable("SELECT  ct.sachId,s.ten, sum(ct.soluong) as 'Số lượng bán'," +
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
    }
}
