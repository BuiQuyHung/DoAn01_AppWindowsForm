using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public KhachHang()
        {

        }
        public KhachHang(string ma, string ten, string dc, string dt)
        {
            this.MaKH = ma;
            this.TenKH = ten;
            this.DiaChi = dc;
            this.DienThoai = dt;
        }
    }
}
