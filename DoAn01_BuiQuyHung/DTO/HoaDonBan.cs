using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonBan
    {
        public string MaHDBan { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }


        public DTO_HoaDonBan()
        {

        }

        public DTO_HoaDonBan(string MaHDBan, DateTime NgayBan, string MaNhanVien, string MaKhachHang)
        {
            this.MaHDBan = MaHDBan;
            this.NgayBan = NgayBan;
            this.MaNhanVien = MaNhanVien;
            this.MaKhachHang = MaKhachHang;

        }
    }
}
