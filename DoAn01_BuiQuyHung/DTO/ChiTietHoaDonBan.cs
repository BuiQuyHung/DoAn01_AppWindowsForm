using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonBan
    {
        public string MaCTHDBan { get; set; }
        public string MaHDBan { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public DTO_ChiTietHoaDonBan()
        {

        }

        public DTO_ChiTietHoaDonBan(string MaCTHDBan, string MaHDBan, string MaHang, int SoLuong, float DonGia, float ThanhTien)
        {
            this.MaCTHDBan = MaCTHDBan;
            this.MaHDBan = MaHDBan;
            this.MaHang = MaHang;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.ThanhTien = ThanhTien;
        }
    }
}

