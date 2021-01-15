using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.Services
{
    public class SachService
    {
        private string connString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        private SqlConnection conn;
        private SachService()
        {
            conn = new SqlConnection(connString);
        }
        private void connect()

        {
            if (conn == null)

                conn = new SqlConnection(connString);

            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }

        // đóng kết nối

        private void disconnect()

        {

            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();

        }

        public DataTable getAnh(int ma)
        {
            connect();

            SqlDataAdapter da = new SqlDataAdapter("select top 1 * from DMAnh where SachId =" + ma, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            disconnect();

            return dt;
        }
    }
}
