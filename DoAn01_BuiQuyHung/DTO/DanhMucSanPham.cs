namespace DTO
{
    public class DanhMucSanPham
    {
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public DanhMucSanPham()
        { }
        public DanhMucSanPham(string ma, string ten)
        {
            this.MaDanhMuc = ma;
            this.TenDanhMuc = ten;
        }
    }

}
