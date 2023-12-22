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
    public class DAL_HangHoa : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách HangHoa ra ngoài màn hình
        public DataTable getHangHoa()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from HangHoa", _con);
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
            string sql = "Select count(*) from HangHoa where MaHang='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themSP(HangHoa sp)
        {
            string sql = "Insert into HangHoa values('" + sp.MaSP + "',N'" + sp.TenSP + "',N'" + sp.MaDM + "',N'" + sp.SoLuong + "',N'" + sp.GhiChu + "')";

            thucthisql(sql);
            return true;
        }
        public bool suaSP(HangHoa sp)
        {
            string sql = "Update HangHoa set TenHang=N'" + sp.TenSP + "', MaDanhMuc=N'" + sp.MaDM + "', SoLuong=N'" + sp.SoLuong + "', GhiCHu=N'" + sp.GhiChu + "' where MaHang='" + sp.MaSP + "'";

            thucthisql(sql);
            return true;
        }
        public bool xoaSP(string ma)
        {
            string sql = "Delete from HangHoa where MaHang='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TKMa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HangHoa where MaHang like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable TKTen(string ten)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HangHoa where TenHang like N'%" + ten + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable SoLuongHangHoa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select SoLuong from HangHoa where MaHang like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
