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
    public class BUS_DanhMucSanPham
    {
        DAL_DanhMucSanPham daldmsp = new DAL_DanhMucSanPham();
        public DataTable getDanhMucSanPham()
        {
            return daldmsp.getDanhMucSanPham();
        }
        public int kiemtramatrung(string ma)
        {
            return daldmsp.kiemtramatrung(ma);
        }
        public bool themDMSP(DanhMucSanPham dmsp)
        {
            return daldmsp.themDMSP(dmsp);
        }
        public bool suaDMSP(DanhMucSanPham dmsp)
        {
            return daldmsp.suaDMSP(dmsp);
        }
        public bool xoaDMSP(string ma)
        {
            return daldmsp.xoaDMSP(ma);
        }
        public DataTable TKMa(string ma)
        {
            return daldmsp.TKMa(ma);
        }

        public DataTable TKTen(string ten)
        {
            return daldmsp.TKTen(ten);
        }

    }
}
