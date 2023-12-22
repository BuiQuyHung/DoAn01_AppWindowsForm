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
    public class DAL_ChiTietHoaDonBan : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getCTHDBan()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDBan", _con);
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
            string sql = "Select count(*) from ChiTietHDBan where MaCTHDBan='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            cthdb.ThanhTien = cthdb.SoLuong * cthdb.DonGia;
            string sql = "Insert into ChiTietHDBan values('" + cthdb.MaCTHDBan + "',N'" + cthdb.MaHDBan + "',N'" + cthdb.MaHang + "','" + cthdb.SoLuong + "',N'" + cthdb.DonGia + "',N'" + cthdb.ThanhTien + "')";
            thucthisql(sql);
            return true;
        }
        public bool suaChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            cthdb.ThanhTien = cthdb.SoLuong * cthdb.DonGia;
            string sql = "Update ChiTietHDBan set MaHDBan=N'" + cthdb.MaHDBan + "',MaHang=N'" + cthdb.MaHang + "', SoLuong='" + cthdb.SoLuong + "', DonGia='" + cthdb.DonGia + "', ThanhTien='" + cthdb.ThanhTien + "' where MaCTHDBan='" + cthdb.MaCTHDBan + "'";
            thucthisql(sql);
            return true;
        }
        public bool xoaChiTietHoaDonBan(string ma)
        {
            string sql = "Delete from ChiTietHDBan where MaCTHDBan='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable timkiemChiTietHoaDonBanTheoMaCTHDBan(string macthdb)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDBan where MaCTHDBan like N'%" + macthdb + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable timkiemChiTietHoaDonBanTheoMaHDBan(string mahdb)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from ChiTietHDBan where MaHDBan like N'%" + mahdb + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable loadcbbMaHDBan_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonBan", _con);
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
            da = new SqlDataAdapter("select MaHang,SoLuong from ChiTietHDBan where MaCTHDBan like N'%" + ma + "%'", _con);
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
