using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_KhachHang : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách KhachHang ra ngoài màn hình
        public DataTable getKhachHang()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from KhachHang", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        void thucthisql(string sql)
        {
            _con.Open();
            cmd = new SqlCommand(sql, _con);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from KhachHang where MaKhach='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themKH(KhachHang kh)
        {
            string sql = "Insert into KhachHang values('" + kh.MaKH + "',N'" + kh.TenKH + "',N'" + kh.DiaChi + "',N'" + kh.DienThoai + "')";

            thucthisql(sql);
            return true;
        }
        public bool suaKH(KhachHang kh)
        {
            string sql = "Update KhachHang set TenKhach=N'" + kh.TenKH + "', DiaChi=N'" + kh.DiaChi + "', DienThoai=N'" + kh.DienThoai + "' where MaKhach='" + kh.MaKH + "'";

            thucthisql(sql);
            return true;
        }
        public bool xoaKH(string ma)
        {
            string sql = "Delete from KhachHang where MaKhach='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TKMa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from KhachHang where MaKhach like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable TKTen(string ten)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from KhachHang where TenKhach like N'%" + ten + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
