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
    public class DAL_NguoiDung : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
       
        public DataTable getNguoiDung()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NguoiDung", _con);
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
            string sql = "Select count(*) from NguoiDung where UserID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themNguoiDung(DTO_NguoiDung nd)
        {
            string sql = "Insert into NguoiDung values('" + nd.UserID + "',N'" + nd.Pass + "',N'" + nd.Per + "')";
            thucthisql(sql);
            return true;
        }
        public bool suaNguoiDung(DTO_NguoiDung nd)
        {
            string sql = "Update NguoiDung set Pass=N'" + nd.Pass + "',Per=N'" + nd.Per + "' where UserID='" + nd.UserID + "'";
            thucthisql(sql);
            return true;
        }
        public bool xoaNguoiDung(string userID)
        {
            string sql = "Delete from NguoiDung where UserID='" + userID + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable timkiemNguoiDungTheoUserID(string userID)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NguoiDung where UserID like N'%" + userID + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable timkiemNguoiDungTheoPer(string Per)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NguoiDung where Per like N'%" + Per + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
