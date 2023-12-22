using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonNhap
    {
        public string MaHDNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public DTO_HoaDonNhap()
        {

        }
        public DTO_HoaDonNhap(string MaHDNhap, DateTime NgayNhap, string MaNhanVien, string MaNhaCungCap)
        {
            this.MaHDNhap = MaHDNhap;
            this.NgayNhap = NgayNhap;
            this.MaNhanVien = MaNhanVien;
            this.MaNhaCungCap = MaNhaCungCap;
        }
    }
}
