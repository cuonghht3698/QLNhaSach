using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace QLNhaSach.Business
{
    public class Connect
    {
        private string connString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
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

        public DataTable CreateOrUpdateSachProcedure(bool insert, int id, string ten, int soluong, int dongia, DateTime ngaynhap, string tacgia, string mota, int khoId, int nccId, int loaisachId, int nxbId, bool active, int giaban,string anh)
        {
            connect();
            SqlCommand cmd = conn.CreateCommand();
            // true là insert
            if (insert)
            {
                cmd.CommandText = "EXECUTE InsertSach " + "@ten,@soluong,@dongia,@ngaynhap,@tacgia,@mota,@khoId,@nccId,@loaisachId,@nxbId,@active,@giaban,@anh";
            }
            else
            {
                cmd.CommandText = "EXECUTE updateSach " + "@id,@ten,@soluong,@dongia,@ngaynhap,@tacgia,@mota,@khoId,@nccId,@loaisachId,@nxbId,@active,@giaban,@anh";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            }
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50).Value = ten;
            cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            cmd.Parameters.Add("@dongia", SqlDbType.Decimal).Value = dongia;
            cmd.Parameters.Add("@ngaynhap", SqlDbType.NVarChar, 50).Value = ngaynhap;
            cmd.Parameters.Add("@tacgia", SqlDbType.NVarChar, 50).Value = tacgia;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar, 50).Value = mota;
            cmd.Parameters.Add("@khoId", SqlDbType.Int).Value = khoId;
            cmd.Parameters.Add("@nccId", SqlDbType.Int).Value = nccId;
            cmd.Parameters.Add("@loaisachId", SqlDbType.Int).Value = loaisachId;
            cmd.Parameters.Add("@nxbId", SqlDbType.Int).Value = nxbId;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            cmd.Parameters.Add("@giaban", SqlDbType.Decimal).Value = giaban;
            cmd.Parameters.Add("@anh", SqlDbType.VarChar).Value = anh;
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
