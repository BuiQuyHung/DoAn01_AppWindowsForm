using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_ChiTietHoaDonNhap : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getCTHDNhap()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDNhap", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        void thucthisql(string sql)
        {
            _con.Open();
            cmd = new SqlCommand(sql,_con);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from ChiTietHDNhap where MaCTHDNhap='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            cthdn.ThanhTien = cthdn.SoLuong * cthdn.DonGia;
            string sql = "Insert into ChiTietHDNhap values('" + cthdn.MaCTHDNhap + "',N'" + cthdn.MaHDNhap + "',N'" + cthdn.MaHang + "','" + cthdn.SoLuong + "',N'" + cthdn.DonGia + "',N'" + cthdn.ThanhTien + "')";
            thucthisql(sql);
            return true;
        }
        public bool suaChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            cthdn.ThanhTien = cthdn.SoLuong * cthdn.DonGia;
            string sql = "Update ChiTietHDNhap set MaHDNhap=N'" + cthdn.MaHDNhap + "',MaHang=N'" + cthdn.MaHang + "', SoLuong='" + cthdn.SoLuong + "', DonGia='" + cthdn.DonGia + "', ThanhTien='" + cthdn.ThanhTien + "' where MaCTHDNhap='" + cthdn.MaCTHDNhap + "'";
            thucthisql(sql);
            return true;
        }
        public bool xoaChiTietHoaDonNhap(string ma)
        {
            string sql = "Delete from ChiTietHDNhap where MaCTHDNhap='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable timkiemChiTietHoaDonNhapTheoMaCTHDNhap(string macthdb)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDNhap where MaCTHDNhap like N'%" + macthdb + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable timkiemChiTietHoaDonNhapTheoMaHDNhap(string mahdb)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDNhap where MaHDNhap like N'%" + mahdb + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable loadcbbMaHDNhap_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonNhap", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable loadcbbMaHang_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HangHoa", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable SoLuongHang(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select MaHang,SoLuong from ChiTietHDNhap where MaCTHDNhap like N'%" + ma + "%'", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public bool SuaSP(string sl, string ma)
        {

            string sql = "Update HangHoa set SoLuong=N'" + sl + "' where MaHang='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
