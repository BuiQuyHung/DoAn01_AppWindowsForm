using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class DAL_HoaDonNhap : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getHDNhap()
        {
            _con.Open();
            da = new SqlDataAdapter("select HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, sum(CTHDN.ThanhTien) as TongTien\r\nfrom HoaDonNhap AS HDN, ChiTietHDNhap as CTHDN\r\nWHERE HDN.MaHDNhap=CTHDN.MaHDNhap\r\ngroup by HDN.MaHDNhap,HDN.NgayNhap, HDN.MaNhanVien,HDN.MaNhaCungCap", _con);
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
            string sql = "Select count(*) from HoaDonNhap where MaHDNhap='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            string ngaynhap = string.Format("{0}/{1}/{2}", hdn.NgayNhap.Year, hdn.NgayNhap.Month, hdn.NgayNhap.Day);
            string sql = "Insert into HoaDonNhap values('" + hdn.MaHDNhap + "',N'" + ngaynhap + "',N'" + hdn.MaNhanVien + "',N'" + hdn.MaNhaCungCap + "')";
            thucthisql(sql);
            return true;
        }
        public bool suaHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            string ngaynhap = string.Format("{0}/{1}/{2}", hdn.NgayNhap.Year, hdn.NgayNhap.Month, hdn.NgayNhap.Day);
            string sql = "Update HoaDonNhap set NgayNhap=N'" + ngaynhap + "',MaNhanVien=N'" + hdn.MaNhanVien + "', MaNhaCungCap='" + hdn.MaNhaCungCap + "' where MaHDNhap='" + hdn.MaHDNhap + "'";
            thucthisql(sql);
            return true;
        }
        public bool xoaHoaDonNhap(string ma)
        {
            string sql = "Delete from HoaDonNhap where MaHDNhap='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable timkiemHoaDonNhapTheoMaHDNhap(string mahdn)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonNhap where MaHDNhap like N'%" + mahdn + "%' ", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable timkiemHoaDonNhapTheoMaNhaCungCap(string makh)
        {
            _con.Open();
            da = new SqlDataAdapter("select * from HoaDonNhap where MaNhaCungCap like N'%" + makh + "%' ", _con);
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
        public DataTable loadcbbMaNhaCungCap_phikn()
        {
            _con.Open();
            da = new SqlDataAdapter("select * from NhaCungCap", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public DataTable KetXuatHDNExcel(string mahdn)
        {
            _con.Open();
            da = new SqlDataAdapter("SELECT HDN.MaHDNhap AS [Mã hóa đơn nhập], HDN.NgayNhap AS [Ngày nhập], NV.TenNhanVien AS [Nhân viên lập hóa đơn], NCC.TenNhaCungCap AS [Tên nhà cung cấp], SP.TenHang AS [Sản phẩm], CTHDN.DonGia AS[Đơn giá], CTHDN.SoLuong AS [Số lượng], CTHDN.ThanhTien AS [Thành tiền] FROM HoaDonNhap AS HDN, ChiTietHDNhap AS CTHDN, HangHoa AS SP, NhanVien AS NV, NhaCungCap AS NCC WHERE HDN.MaHDNhap = CTHDN.MaHDNhap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.MaNhaCungCap = NCC.MaNhaCungCap AND CTHDN.MaHang = SP.MaHang AND HDN.MaHDNhap like N'%" + mahdn + "%' GROUP BY HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, NV.TenNhanVien, NCC.TenNhaCungCap, SP.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
    }
}
