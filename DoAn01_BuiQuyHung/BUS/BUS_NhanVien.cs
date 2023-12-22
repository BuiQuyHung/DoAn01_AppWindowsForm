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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalnv = new DAL_NhanVien();
        public DataTable getNhanVien()
        {
            return dalnv.getNhanVien();
        }
        public int kiemtramatrung(string ma)
        {
            return dalnv.kiemtramatrung(ma);
        }
        public bool themNV(NhanVien nv)
        {
            return dalnv.themNV(nv);
        }
        public bool suaNV(NhanVien nv)
        {
            return dalnv.suaNV(nv);
        }
        public bool xoaNV(string ma)
        {
            return dalnv.xoaNV(ma);
        }
        public DataTable TKMa(string ma)
        {
            return dalnv.TKMa(ma);
        }

        public DataTable TKTen(string ten)
        {
            return dalnv.TKTen(ten);
        }
    }
}
