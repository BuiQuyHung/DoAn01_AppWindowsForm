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
    public class DAL_NhanVien : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách NhanVien ra ngoài màn hình
        public DataTable getNhanVien()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from NhanVien", _con);
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
            string sql = "Select count(*) from NhanVien where MaNhanVien='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themNV(NhanVien nv)
        {
            string ngay = string.Format("{0}/{1}/{2}", nv.NgaySinh.Year, nv.NgaySinh.Month, nv.NgaySinh.Day);
            string sql = "Insert into NhanVien values('" + nv.MaNV + "',N'" + nv.TenNV + "',N'" + nv.GioiTinh + "',N'" + nv.DiaChi + "',N'" + nv.DienThoai + "','" + ngay + "')";

            thucthisql(sql);
            return true;
        }
        public bool suaNV(NhanVien nv)
        {
            string ngay = string.Format("{0}/{1}/{2}", nv.NgaySinh.Year, nv.NgaySinh.Month, nv.NgaySinh.Day);
            string sql = "Update NhanVien set TenNhanVien=N'" + nv.TenNV + "', GioiTinh=N'" + nv.GioiTinh + "', DiaChi=N'" + nv.DiaChi + "', DienThoai=N'" + nv.DienThoai + "' ,NgaySinh='" + ngay + "' where MaNhanVien='" + nv.MaNV + "'";

            thucthisql(sql);
            return true;
        }
        public bool xoaNV(string ma)
        {
            string sql = "Delete from NhanVien where MaNhanVien='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TKMa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhanVien where MaNhanVien like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable TKTen(string ten)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhanVien where TenNhanVien like N'%" + ten + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
