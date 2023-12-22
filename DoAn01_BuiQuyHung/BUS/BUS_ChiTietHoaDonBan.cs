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
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dalcthdb = new DAL_ChiTietHoaDonBan();
        public DataTable getCTHDBan()
        {
            return dalcthdb.getCTHDBan();
        }
        public int kiemtramatrung(string ma)
        {
            return dalcthdb.kiemtramatrung(ma);
        }
        public bool themChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            return dalcthdb.themChiTietHoaDonBan(cthdb);
        }
        public bool suaChiTietHoaDonBan(DTO_ChiTietHoaDonBan cthdb)
        {
            return dalcthdb.suaChiTietHoaDonBan(cthdb);
        }
        public bool xoaChiTietHoaDonBan(string ma)
        {
            return dalcthdb.xoaChiTietHoaDonBan(ma);
        }
        public DataTable timkiemChiTietHoaDonBanTheoMaCTHDBan(string ma)
        {
            return dalcthdb.timkiemChiTietHoaDonBanTheoMaCTHDBan(ma);
        }

        public DataTable timkiemChiTietHoaDonBanTheoMaHDBan(string ten)
        {
            return dalcthdb.timkiemChiTietHoaDonBanTheoMaHDBan(ten);
        }
        public DataTable loadcbbMaHDBan_phikn()
        {
            return dalcthdb.loadcbbMaHDBan_phikn();
        }
        public DataTable loadcbbMaHang_phikn()
        {
            return dalcthdb.loadcbbMaHang_phikn();
        }
        public DataTable SoLuongHang(string ma)
        {
            return dalcthdb.SoLuongHang(ma);
        }
        public bool SuaSP(string sl, string ma)
        {
            return dalcthdb.SuaSP(sl, ma);
        }
    }
}
