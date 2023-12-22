using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangHoa
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaDM { get; set; }
        public float SoLuong { get; set; }
        public string GhiChu { get; set; }

        public HangHoa()
        {

        }
        public HangHoa(string ma, string ten, string madn, float sl,string ghichu)
        {
            this.MaSP = ma;
            this.TenSP = ten;
            this.MaDM = madn;
            this.SoLuong = sl;
            this.GhiChu = ghichu;
        }
    }
}
