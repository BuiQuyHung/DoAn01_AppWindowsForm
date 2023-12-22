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
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dalhdb = new DAL_HoaDonBan();
        public DataTable getHDBan()
        {
            return dalhdb.getHDBan();
        }
        public int kiemtramatrung(string ma)
        {
            return dalhdb.kiemtramatrung(ma);
        }
        public bool themHoaDonBan(DTO_HoaDonBan hdb)
        {
            return dalhdb.themHoaDonBan(hdb);
        }
        public bool suaHoaDonBan(DTO_HoaDonBan hdb)
        {
            return dalhdb.suaHoaDonBan(hdb);
        }
        public bool xoaHoaDonBan(string ma)
        {
            return dalhdb.xoaHoaDonBan(ma);
        }
        public DataTable timkiemHoaDonBanTheoMaHDBan(string mahdb)
        {
            return dalhdb.timkiemHoaDonBanTheoMaHDBan(mahdb);
        }

        public DataTable timkiemHoaDonBanTheoMaKhachHang(string makh)
        {
            return dalhdb.timkiemHoaDonBanTheoMaKhachHang(makh);
        }
        public DataTable loadcbbMaNhanVien_phikn()
        {
            return dalhdb.loadcbbMaNhanVien_phikn();
        }
        public DataTable loadcbbMaKhachHang_phikn()
        {
            return dalhdb.loadcbbMaKhachHang_phikn();
        }
        public DataTable KetXuatHDBExcel(string mahdb)
        {
            return dalhdb.KetXuatHDBExcel(mahdb);
        }
    }
}

