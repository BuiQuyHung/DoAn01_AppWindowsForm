-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
GO


--Hàng tồn kho
create procedure dbo.HangTonKho
as
select H.MaHang, H.TenHang, DM.TenDanhMuc, H.SoLuong, H.GhiChu
from HangHoa H, DanhMucSanPham DM
WHERE DM.MaDanhMuc = H.MaDanhMuc

--Doanh thu
--Doanh thu theo ngày
create procedure dbo.DoanhThuTheoNgay
@NgayBan Date
as
select HDB.MaHDBan, HDB.NgayBan, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien
from HoaDonBan as HDB, ChiTietHDBan as CTHDB, HangHoa as H, NhanVien as NV, KhachHang as KH
WHERE HDB.MaHDBan = CTHDB.MaHDBan AND HDB.MaNhanVien = NV.MaNhanVien AND HDB.MaKhach = KH.MaKhach AND CTHDB.MaHang = H.MaHang and  HDB.NgayBan=@NgayBan
group by HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien

--Doanh thu theo tháng
create procedure dbo.DoanhThuTheoThang
@NgayBan Date
as
select HDB.MaHDBan, HDB.NgayBan, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien
from HoaDonBan as HDB, ChiTietHDBan as CTHDB, HangHoa as H, NhanVien as NV, KhachHang as KH
WHERE HDB.MaHDBan = CTHDB.MaHDBan AND HDB.MaNhanVien = NV.MaNhanVien AND HDB.MaKhach = KH.MaKhach AND CTHDB.MaHang = H.MaHang and  Month(HDB.NgayBan)=Month(@NgayBan)
group by HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien

--Doanh thu theo năm
create procedure dbo.DoanhThuTheoNam
@NgayBan Date
as
select HDB.MaHDBan, HDB.NgayBan, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien
from HoaDonBan as HDB, ChiTietHDBan as CTHDB, HangHoa as H, NhanVien as NV, KhachHang as KH
WHERE HDB.MaHDBan = CTHDB.MaHDBan AND HDB.MaNhanVien = NV.MaNhanVien AND HDB.MaKhach = KH.MaKhach AND CTHDB.MaHang = H.MaHang and  Year(HDB.NgayBan)=Year(@NgayBan)
group by HDB.MaHDBan, HDB.NgayBan, HDB.MaNhanVien, HDB.MaKhach, NV.TenNhanVien, KH.TenKhach, H.TenHang, CTHDB.DonGia, CTHDB.SoLuong, CTHDB.ThanhTien


--Quản lý việc nhập hàng hóa
--Nhập theo ngày
create procedure dbo.NhapTheoNgay
@NgayNhap Date
as
select HDN.MaHDNhap, HDN.NgayNhap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien
from HoaDonNhap as HDN, ChiTietHDNhap as CTHDN, HangHoa as H, NhanVien as NV, NhaCungCap NCC
WHERE HDN.MaHDNhap = CTHDN.MaHDNhap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.MaNhaCungCap = NCC.MaNhaCungCap AND CTHDN.MaHang = H.TenHang and  HDN.NgayNhap=@NgayNhap
group by HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien


--Nhập theo tháng
create procedure dbo.NhapTheoThang
@NgayNhap Date
as
select HDN.MaHDNhap, HDN.NgayNhap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien
from HoaDonNhap as HDN, ChiTietHDNhap as CTHDN, HangHoa as H, NhanVien as NV, NhaCungCap NCC
WHERE HDN.MaHDNhap = CTHDN.MaHDNhap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.MaNhaCungCap = NCC.MaNhaCungCap AND CTHDN.MaHang = H.MaHang and  MONTH(HDN.NgayNhap)=MONTH(@NgayNhap)
group by HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien


--Nhập theo năm
create procedure dbo.NhapTheoNam
@NgayNhap Date
as
select HDN.MaHDNhap, HDN.NgayNhap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien
from HoaDonNhap as HDN, ChiTietHDNhap as CTHDN, HangHoa as H, NhanVien as NV, NhaCungCap NCC
WHERE HDN.MaHDNhap = CTHDN.MaHDNhap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.MaNhaCungCap = NCC.MaNhaCungCap AND CTHDN.MaHang = H.MaHang and  YEAR(HDN.NgayNhap)=YEAR(@NgayNhap)
group by HDN.MaHDNhap, HDN.NgayNhap, HDN.MaNhanVien, HDN.MaNhaCungCap, NV.TenNhanVien, NCC.TenNhaCungCap, H.TenHang, CTHDN.DonGia, CTHDN.SoLuong, CTHDN.ThanhTien


--Xem hàng tồn kho
select H.TenHang, CTHDB.SoLuong, CTHDB.ThanhTien
from ChiTietHDBan CTHDB, HoaDonBan HDB, HangHoa H
WHERE HDB.MaHDBan=CTHDB.MaHDBan AND CTHDB.MaHang=H.MaHang
ORDER BY  CTHDB.ThanhTien DESC


--Xem hàng bán chạy
--Bán chạy theo ngày
create procedure dbo.HangBanChayTheoNgay
@NgayBan Date
as
select H.TenHang, CTHDB.SoLuong, CTHDB.ThanhTien
from ChiTietHDBan CTHDB, HoaDonBan HDB, HangHoa H
WHERE HDB.MaHDBan=CTHDB.MaHDBan AND CTHDB.MaHang=H.MaHang  and  HDB.NgayBan=@NgayBan
ORDER BY  CTHDB.SoLuong DESC


--Bán chạy theo tháng
create procedure dbo.HangBanChayTheoThang
@NgayBan Date
as
select H.TenHang, CTHDB.SoLuong, CTHDB.ThanhTien
from ChiTietHDBan CTHDB, HoaDonBan HDB, HangHoa H
WHERE HDB.MaHDBan=CTHDB.MaHDBan AND CTHDB.MaHang=H.MaHang and  MONTH(HDB.NgayBan)=MONTH(@NgayBan)
ORDER BY  CTHDB.SoLuong DESC

--Bán chạy theo năm
create procedure dbo.HangBanChayTheoNam
@NgayBan Date
as
select H.TenHang, CTHDB.SoLuong, CTHDB.ThanhTien
from ChiTietHDBan CTHDB, HoaDonBan HDB, HangHoa H
WHERE HDB.MaHDBan=CTHDB.MaHDBan AND CTHDB.MaHang=H.MaHang  and  YEAR(HDB.NgayBan)=YEAR(@NgayBan)
ORDER BY  CTHDB.SoLuong DESC