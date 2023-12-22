using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public NhaCungCap()
        {

        }
        public NhaCungCap(string ma, string ten, string diachi, string dt)
        {
            this.MaNCC = ma;
            this.TenNCC = ten;
            this.DiaChi = diachi;
            this.DienThoai = dt;
        }
    }
}
