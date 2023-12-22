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
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dalhdn = new DAL_HoaDonNhap();
        public DataTable getHDNhap()
        {
            return dalhdn.getHDNhap();
        }
        public int kiemtramatrung(string ma)
        {
            return dalhdn.kiemtramatrung(ma);
        }
        public bool themHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            return dalhdn.themHoaDonNhap(hdn);
        }
        public bool suaHoaDonNhap(DTO_HoaDonNhap hdn)
        {
            return dalhdn.suaHoaDonNhap(hdn);
        }
        public bool xoaHoaDonNhap(string ma)
        {
            return dalhdn.xoaHoaDonNhap(ma);
        }
        public DataTable timkiemHoaDonNhapTheoMaHDNhap(string mahdn)
        {
            return dalhdn.timkiemHoaDonNhapTheoMaHDNhap(mahdn);
        }

        public DataTable timkiemHoaDonNhapTheoMaNhaCungCap(string makh)
        {
            return dalhdn.timkiemHoaDonNhapTheoMaNhaCungCap(makh);
        }
        public DataTable loadcbbMaNhanVien_phikn()
        {
            return dalhdn.loadcbbMaNhanVien_phikn();
        }
        public DataTable loadcbbMaNhaCungCap_phikn()
        {
            return dalhdn.loadcbbMaNhaCungCap_phikn();
        }
        public DataTable KetXuatHDNExcel(string mahdn)
        {
            return dalhdn.KetXuatHDNExcel(mahdn);
        }
    }
}
