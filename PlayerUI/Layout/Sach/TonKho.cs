using QLNhaSach.Business;
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
    public partial class TonKho : Form
    {
        private readonly Connect cn;
        private string search;
        public TonKho()
        {
            InitializeComponent();
            cn = new Connect();
        }

        private void TonKho_Load(object sender, EventArgs e)
        {
            getTonKho();
        }

        private void getTonKho()
        {
            dataGridView1.DataSource = cn.getDataTable("select ROW_NUMBER() OVER(order by s.ten) as 'STT',s.id as 'Mã', " +
                "s.ten,s.soluong as 'Số lượng tồn',s.dongia as 'Giá nhập',s.giaban as 'Giá bán',k.ten as 'Kho' from sach s" +
                " join kho k on s.khoId = k.id where ('"+search+"' = '' or s.ten like N'%"+search+"%')");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search = textBox1.Text;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            getTonKho();
        }
    }
}
