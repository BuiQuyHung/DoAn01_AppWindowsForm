using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalkh = new DAL_KhachHang();
        public DataTable getKhachHang()
        {
            return dalkh.getKhachHang();
        }
        public int kiemtramatrung(string ma)
        {
            return dalkh.kiemtramatrung(ma);
        }
        public bool themKH(KhachHang kh)
        {
            return dalkh.themKH(kh);
        }
        public bool suaKH(KhachHang kh)
        {
            return dalkh.suaKH(kh);
        }
        public bool xoaKH(string ma)
        {
            return dalkh.xoaKH(ma);
        }
        public DataTable TKMa(string ma)
        {
            return dalkh.TKMa(ma);
        }

        public DataTable TKTen(string ten)
        {
            return dalkh.TKTen(ten);
        }
    }
}
