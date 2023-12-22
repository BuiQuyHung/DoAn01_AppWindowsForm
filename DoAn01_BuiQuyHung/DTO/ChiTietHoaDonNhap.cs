using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonNhap
    {
        public string MaCTHDNhap { get; set; }
        public string MaHDNhap { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public DTO_ChiTietHoaDonNhap()
        {

        }
        public DTO_ChiTietHoaDonNhap(string MaCTHDNhap, string MaHDNhap, string MaHang, int SoLuong, float DonGia, float ThanhTien)
        {
            this.MaCTHDNhap = MaCTHDNhap;
            this.MaHDNhap = MaHDNhap;
            this.MaHang = MaHang;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.ThanhTien = ThanhTien;
        }
    }
}