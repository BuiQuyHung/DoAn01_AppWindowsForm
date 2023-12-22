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
    public class DAL_HoaDonBan : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getHDBan()
        {
            _con.Open();
            da = new SqlDataAdapter("select HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, sum(CTHDB.ThanhTien) as TongTien\r\nfrom HoaDonBan AS HDB, ChiTietHDBan as CTHDB\r\nWHERE HDB.MaHDBan=CTHDB.MaHDBan\r\ngroup by HDB.MaHDBan,HDB.NgayBan, HDB.MaNhanVien,HDB.MaKhach", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        void thucthisql(string sql)
        {
            _con.Open();
            cmd = new SqlCommand(sql,  _con);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from HoaDonBan where MaHDBan='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themHoaDonBan(DTO_HoaDonBan hdb)
        {
            string ngayban = string.Format("{0}/{1}/{2}", hdb.NgayBan.Year, hdb.NgayBan.Month, hdb.NgayBan.Day);
            string sql = "Insert into HoaDonBan values('" + hdb.MaHDBan + "',N'" + ngayban + "',N'" + hdb.MaNhanVien + "',N'" + hdb.MaKhachHang + "')";
            thucthisql(sql);
            return true;
        }
        public bool suaHoaDonBan(DTO_HoaDonBan hdb)
        {
            string ngayban = string.Format("{0}/{1}/{2}", hdb.NgayBan.Year, hdb.NgayBan.Month, hdb.NgayBan.Day);
            string sql = "Update HoaDonBan set NgayBan=N'" + ngayban + "',MaNhanVien=N'" + hdb.MaNhanVien + "', MaKhach='" + hdb.MaKhachHang + "' where MaHDBan='" + hdb.MaHDBan + "'";
            thucthisql(sql);
            return true;
        }
        public bool xoaHoaDonBan(string ma)
        {
            string sql = "Delete from HoaDonBan where MaHDBan='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable timkiemHoaDonBanTheoMaHDBan(string mahdb)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonBan where MaHDBan like N'%" + mahdb + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable timkiemHoaDonBanTheoMaKhachHang(string makh)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonBan where MaKhach like N'%" + makh + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable loadcbbMaNhanVien_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhanVien", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable loadcbbMaKhachHang_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from KhachHang", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable KetXuatHDBExcel(string mahdb)
        {
            _con.Open();
            da = new SqlDataAdapter("SELECT HDB.MaHDBan AS [Mã hóa đơn bán], HDB.NgayBan AS [Ngày bán], NV.TenNhanVien AS [Nhân viên lập hóa đơn], KH.TenKhach AS [Tên khách hàng], SP.TenHang AS [Sản phẩm], CTHDB.DonGia AS[Đơn giá],CTHDB.SoLuong AS [Số lượng], CTHDB.ThanhTien AS [Thành tiền] FROM HoaDonBan AS HDB, ChiTietHDBan AS CTHDB, HangHoa AS SP, NhanVien AS NV, KhachHang AS KH WHERE HDB.MaHDBan = CTHDB.MaHDBan AND HDB.MaNhanVien = NV.MaNhanVien AND HDB.MaKhach = KH.MaKhach AND CTHDB.MaHang = SP.MaHang AND HDB.MaHDBan like N'%" + mahdb + "%' GROUP BY HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, NV.TenNhanVien, KH.TenKhach, SP.TenHang, CTHDB.DonGia, CTHDB.SoLuong,CTHDB.ThanhTien", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}

