using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.Business
{
    public class Connect
    {
        private string connString = "Server=DESKTOP-BJJNCTC;Database=NStienphong;Integrated Security=true;";
        private SqlConnection conn;
        public Connect()
        {
            conn = new SqlConnection(connString);
        }

        public void connect()

        {
            if (conn == null)

                conn = new SqlConnection(connString);

            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }

        // đóng kết nối

        public void disconnect()

        {

            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();

        }
        // trả về một DataTable .
        public DataTable getDataTable(string sql)

        {

            connect();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            disconnect();

            return dt;

        }

        public void ExecuteNonQuery(string sql)

        {

            connect();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            disconnect();

        }

        // trả về DataReader

        public SqlDataReader getDataReader(string sql)

        {

            connect();

            SqlCommand com = new SqlCommand(sql, conn);

            SqlDataReader dr = com.ExecuteReader();
            return dr;
            
        }
    }
}
