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
    public class BUS_HangHoa
    {
        DAL_HangHoa dalsp = new DAL_HangHoa();
        public DataTable getHangHoa()
        {
            return dalsp.getHangHoa();
        }
        public int kiemtramatrung(string ma)
        {
            return dalsp.kiemtramatrung(ma);
        }
        public bool themSP(HangHoa sp)
        {
            return dalsp.themSP(sp);
        }
        public bool suaSP(HangHoa sp)
        {
            return dalsp.suaSP(sp);
        }
        public bool xoaSP(string ma)
        {
            return dalsp.xoaSP(ma);
        }
        public DataTable TKMa(string ma)
        {
            return dalsp.TKMa(ma);
        }

        public DataTable TKTen(string ten)
        {
            return dalsp.TKTen(ten);
        }
        public DataTable SoLuongHangHoa(string ma)
        {
            return dalsp.SoLuongHangHoa(ma);
        }
    }
}
