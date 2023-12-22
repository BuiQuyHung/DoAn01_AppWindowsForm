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
    public class DAL_NhaCungCap : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách NhaCungCap ra ngoài màn hình
        public DataTable getNhaCungCap()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from NhaCungCap", _con);
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
            string sql = "Select count(*) from NhaCungCap where MaNhaCungCap='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themNCC(NhaCungCap ncc)
        {
            string sql = "Insert into NhaCungCap values('" + ncc.MaNCC + "',N'" + ncc.TenNCC + "',N'" + ncc.DiaChi + "',N'" + ncc.DienThoai + "')";

            thucthisql(sql);
            return true;
        }
        public bool suaNCC(NhaCungCap ncc)
        {
            string sql = "Update NhaCungCap set TenNhaCungCap=N'" + ncc.TenNCC + "', DiaChi=N'" + ncc.DiaChi + "', DienThoai=N'" + ncc.DienThoai + "' where MaNhaCungCap='" + ncc.MaNCC + "'";

            thucthisql(sql);
            return true;
        }
        public bool xoaNCC(string ma)
        {
            string sql = "Delete from NhaCungCap where MaNhaCungCap='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TKMa(string ma)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhaCungCap where MaNhaCungCap like N'%" + ma + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable TKTen(string ten)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhaCungCap where TenNhaCungCap like N'%" + ten + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
