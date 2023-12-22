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
    public class DAL_DanhMucSanPham :DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //Hiển thị danh sách Danh mục sản phẩm ra màn hình
        public DataTable getDanhMucSanPham()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from DanhMucSanPham", _con);
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
            string sql = "Select count(*) from DanhMucSanPham where MaDanhMuc='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themDMSP(DanhMucSanPham dmsp)
        {
            string sql = "Insert into DanhMucSanPham values('" + dmsp.MaDanhMuc + "',N'" + dmsp.TenDanhMuc + "')";

            thucthisql(sql);
            return true;
        }
        public bool suaDMSP(DanhMucSanPham dmsp)
        {
            string sql = "Update DanhMucSanPham set TenDanhMuc=N'" + dmsp.TenDanhMuc +  "' where MaDanhMuc='" + dmsp.MaDanhMuc + "'";

            thucthisql(sql);
            return true;
        }
        public bool xoaDMSP(string ma)
        {
            string sql = "Delete from DanhMucSanPham where MaDanhMuc='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TKMa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from DanhMucSanPham where MaDanhMuc like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable TKTen(string ten)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from DanhMucSanPham where TenDanhMuc like N'%" + ten + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}

