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

        public DataTable CreateSachProcedure(string ten, int soluong, int dongia, DateTime ngaynhap, string tacgia, string mota, string anh, int khoId, int nccId, int loaisachId, int nxbId, bool active)
        {
            connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE InsertSach " + "@ten,@soluong,@dongia,@ngaynhap,@tacgia,@mota,@anh,@khoId,@nccId,@loaisachId,@nxbId,@active";
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50).Value = ten;
            cmd.Parameters.Add("@soluong", SqlDbType.NVarChar, 50).Value = soluong;
            cmd.Parameters.Add("@dongia", SqlDbType.NVarChar, 50).Value = dongia;
            cmd.Parameters.Add("@ngaynhap", SqlDbType.NVarChar, 50).Value = ngaynhap;
            cmd.Parameters.Add("@tacgia", SqlDbType.NVarChar, 50).Value = tacgia;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 50).Value = mota;
            cmd.Parameters.Add("@anh", SqlDbType.VarChar).Value = anh;
            cmd.Parameters.Add("@khoId", SqlDbType.NVarChar, 50).Value = khoId;
            cmd.Parameters.Add("@nccId", SqlDbType.NVarChar, 50).Value = nccId;
            cmd.Parameters.Add("@loaisachId", SqlDbType.NVarChar, 50).Value = loaisachId;
            cmd.Parameters.Add("@nxbId", SqlDbType.NVarChar, 50).Value = nxbId;
            cmd.Parameters.Add("@active", SqlDbType.NVarChar, 50).Value = active;

            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            return tb;
        }
        public DataTable callSachProcedure(string proc, string search, int kho, int ncc, int loai, int nxb, int active)
        {
            connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXECUTE " + proc + " @search,@kho,@ncc,@loai,@nxb,@active";
            cmd.Parameters.Add("@search", SqlDbType.NVarChar, 50).Value = search;
            cmd.Parameters.Add("@kho", SqlDbType.Int, 10).Value = kho;
            cmd.Parameters.Add("@ncc", SqlDbType.Int).Value = ncc;
            cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
            cmd.Parameters.Add("@nxb", SqlDbType.Int).Value = nxb;
            cmd.Parameters.Add("@active", SqlDbType.Int).Value = active;
            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            return tb;
        }
    }
}
