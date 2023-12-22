using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }

        public NhanVien()
        {

        }
        public NhanVien(string ma, string ten, string gt, string dc, string dt, DateTime ns)
        {
            this.MaNV = ma;
            this.TenNV = ten;
            this.GioiTinh = gt;
            this.DiaChi = dc;
            this.DienThoai = dt;
            this.NgaySinh = ns;
        }
    }
}
