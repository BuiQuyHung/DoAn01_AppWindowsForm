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
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dalncc = new DAL_NhaCungCap();
        public DataTable getNhaCungCap()
        {
            return dalncc.getNhaCungCap();
        }
        public int kiemtramatrung(string ma)
        {
            return dalncc.kiemtramatrung(ma);
        }
        public bool themNCC(NhaCungCap ncc)
        {
            return dalncc.themNCC(ncc);
        }
        public bool suaNCC(NhaCungCap ncc)
        {
            return dalncc.suaNCC(ncc);
        }
        public bool xoaNCC(string ma)
        {
            return dalncc.xoaNCC(ma);
        }
        public DataTable TKMa(string ma)
        {
            return dalncc.TKMa(ma);
        }

        public DataTable TKTen(string ten)
        {
            return dalncc.TKTen(ten);
        }
    }
}
