using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_ChiTietHoaDonNhap
    {
        DAL_ChiTietHoaDonNhap dalcthdn = new DAL_ChiTietHoaDonNhap();
        public DataTable getCTHDNhap()
        {
            return dalcthdn.getCTHDNhap();
        }
        public int kiemtramatrung(string ma)
        {
            return dalcthdn.kiemtramatrung(ma);
        }
        public bool themChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            return dalcthdn.themChiTietHoaDonNhap(cthdn);
        }
        public bool suaChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap cthdn)
        {
            return dalcthdn.suaChiTietHoaDonNhap(cthdn);
        }
        public bool xoaChiTietHoaDonNhap(string ma)
        {
            return dalcthdn.xoaChiTietHoaDonNhap(ma);
        }
        public DataTable timkiemChiTietHoaDonNhapTheoMaCTHDNhap(string ma)
        {
            return dalcthdn.timkiemChiTietHoaDonNhapTheoMaCTHDNhap(ma);
        }

        public DataTable timkiemChiTietHoaDonNhapTheoMaHDNhap(string ten)
        {
            return dalcthdn.timkiemChiTietHoaDonNhapTheoMaHDNhap(ten);
        }
        public DataTable loadcbbMaHDNhap_phikn()
        {
            return dalcthdn.loadcbbMaHDNhap_phikn();
        }
        public DataTable loadcbbMaHang_phikn()
        {
            return dalcthdn.loadcbbMaHang_phikn();
        }
        public DataTable SoLuongHang(string ma)
        {
            return dalcthdn.SoLuongHang(ma);
        }
        public bool SuaSP(string sl, string ma)
        {
            return dalcthdn.SuaSP(sl, ma);
        }
    }
}
