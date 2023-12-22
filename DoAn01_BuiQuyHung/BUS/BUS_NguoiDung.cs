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
    public class BUS_NguoiDung
    {
        DAL_NguoiDung dalnd = new DAL_NguoiDung();
        public DataTable getNguoiDung()
        {
            return dalnd.getNguoiDung();
        }
        public int kiemtramatrung(string ma)
        {
            return dalnd.kiemtramatrung(ma);
        }
        public bool themNguoiDung(DTO_NguoiDung nd)
        {
            return dalnd.themNguoiDung(nd);
        }
        public bool suaNguoiDung(DTO_NguoiDung nd)
        {
            return dalnd.suaNguoiDung(nd);
        }
        public bool xoaNguoiDung(string ma)
        {
            return dalnd.xoaNguoiDung(ma);
        }
        public DataTable timkiemNguoiDungTheoUserID(string userID)
        {
            return dalnd.timkiemNguoiDungTheoUserID(userID);
        }

        public DataTable timkiemNguoiDungTheoPer(string Per)
        {
            return dalnd.timkiemNguoiDungTheoPer(Per);
        }
    }
}
