CREATE DATABASE DoAn01_BuiQuyHung
USE DoAn01_BuiQuyHung
GO	

CREATE TABLE DanhMucSanPham
(
  MaDanhMuc NVARCHAR(50),
  TenDanhMuc NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_DanhMucSanPham PRIMARY KEY (MaDanhMuc)
)
CREATE TABLE KhachHang
(
  MaKhach NVARCHAR(10),
  TenKhach NVARCHAR(50),
  DiaChi NVARCHAR(50),
  DienThoai NVARCHAR(50),
  CONSTRAINT PK_KhachHang PRIMARY KEY (MaKhach)
)
CREATE TABLE HangHoa
(
  MaHang NVARCHAR(50),
  TenHang NVARCHAR(50) NOT NULL,
  MaDanhMuc NVARCHAR(50),
  SoLuong FLOAT NOT NULL,
  GhiChu NVARCHAR(200) NULL,
  CONSTRAINT PK_HangHoa PRIMARY KEY (MaHang),
  CONSTRAINT FK_HangHoa_DanhMucSanPham FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucSanPham(MaDanhMuc)
)
CREATE TABLE NhanVien
(
  MaNhanVien NVARCHAR(50),
  TenNhanVien NVARCHAR(50) NOT NULL,
  GioiTinh NVARCHAR(10) NOT NULL,
  DiaChi NVARCHAR(50) NOT NULL,
  DienThoai NVARCHAR(50) NOT NULL,
  NgaySinh DATE,
  CONSTRAINT PK_NhanVien PRIMARY KEY (MaNhanVien)
)
CREATE TABLE HoaDonBan
(
  MaHDBan NVARCHAR(50),
  NgayBan DATE ,
  MaNhanVien NVARCHAR(50) ,
  MaKhach NVARCHAR(10) ,
  CONSTRAINT PK_HoaDonBan PRIMARY KEY (MaHDBan),
  CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
  CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach)
)
CREATE TABLE ChiTietHDBan
(
  MaCTHDBan nvarchar(50),
  MaHDBan nvarchar(50),
  MaHang NVARCHAR(50),
  SoLuong INT ,
  DonGia FLOAT ,
  ThanhTien FLOAT ,
  CONSTRAINT PK_ChiTietHDBan PRIMARY KEY (MaCTHDBan),
  CONSTRAINT FK_ChiTietHDBan_HoaDonBan FOREIGN KEY (MaHDBan) REFERENCES HoaDonBan(MaHDBan),
  CONSTRAINT FK_ChiTietHDBan_HangHoa FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
)
CREATE TABLE NhaCungCap
(
  MaNhaCungCap NVARCHAR(50),
  TenNhaCungCap NVARCHAR(50) NOT NULL,
  DiaChi NVARCHAR(50) NOT NULL,
  DienThoai NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_NhaCungCap PRIMARY KEY (MaNhaCungCap)
)
CREATE TABLE HoaDonNhap
(
  MaHDNhap NVARCHAR(50),
  NgayNhap DATE ,
  MaNhanVien NVARCHAR(50) ,
  MaNhaCungCap NVARCHAR(50) ,
  CONSTRAINT PK_HoaDonNhap PRIMARY KEY (MaHDNhap),
  CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
  CONSTRAINT FK_HoaDonNhap_NhaCungCap FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
)
CREATE TABLE ChiTietHDNhap
(
  MaCTHDNhap nvarchar(50),
  MaHDNhap nvarchar(50),
  MaHang NVARCHAR(50),
  SoLuong INT ,
  DonGia FLOAT ,
  ThanhTien FLOAT ,
  CONSTRAINT PK_ChiTietHDNhap PRIMARY KEY (MaCTHDNhap),
  CONSTRAINT FK_ChiTietHDNhap_HoaDonNhap FOREIGN KEY (MaHDNhap) REFERENCES HoaDonNhap(MaHDNhap),
  CONSTRAINT FK_ChiTietHDNhap_HangHoa FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
)

CREATE TABLE NguoiDung
(
  UserID NVARCHAR(50),
  Pass NVARCHAR(50) NOT NULL,
  Per INT NOT NULL,
  CONSTRAINT PK_NguoiDung PRIMARY KEY (UserID),	
)

SELECT HDB.MaHDBan AS [Mã hóa đơn bán], HDB.NgayBan AS [Ngày bán], NV.TenNhanVien AS [Nhân viên lập hóa đơn], KH.TenKhach AS [Tên khách hàng], SP.TenHang AS [Sản phẩm], CTHDB.DonGia AS[Đơn giá],CTHDB.SoLuong AS [Số lượng], CTHDB.ThanhTien AS [Thành tiền] 
FROM HoaDonBan AS HDB, ChiTietHDBan AS CTHDB, HangHoa AS SP, NhanVien AS NV, KhachHang AS KH 
WHERE HDB.MaHDBan = CTHDB.MaHDBan AND HDB.MaNhanVien = NV.MaNhanVien AND HDB.MaKhach = KH.MaKhach AND CTHDB.MaHang = SP.MaHang AND HDB.MaHDBan like N'HD01' 
GROUP BY HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, NV.TenNhanVien, KH.TenKhach, SP.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien
-------------------------------------------------------------------------------------------------------
SELECT HDN.MaHDNhap AS [Mã hóa đơn nhập], HDN.NgayNhap AS [Ngày nhập], NV.TenNhanVien AS [Nhân viên lập hóa đơn], NCC.TenNhaCungCap AS [Tên nhà cung cấp], SP.TenHang AS [Sản phẩm], CTHDN.DonGia AS[Đơn giá],CTHDN.SoLuong AS [Số lượng], CTHDN.ThanhTien AS [Thành tiền] 
FROM HoaDonNhap AS HDN, ChiTietHDNhap AS CTHDN, HangHoa AS SP, NhanVien AS NV, NhaCungCap AS NCC 
WHERE HDN.MaHDNhap = CTHDN.MaHDNhap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.MaNhaCungCap = NCC.MaNhaCungCap AND CTHDN.MaHang = SP.MaHang AND HDN.MaHDNhap like N'HDN1' 
GROUP BY HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, NV.TenNhanVien, NCC.TenNhaCungCap, SP.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien