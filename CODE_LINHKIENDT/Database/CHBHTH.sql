Create database CHBHTH
go
use CHBHTH
go

/*TÀI KHOẢN*/
Create table TaiKhoan
(MaNguoiDung int IDENTITY(1,1) NOT NULL,
	HoTen nvarchar(50) NULL,
	Email varchar(50) NULL,
	Dienthoai varchar(50) NULL,
	Matkhau varchar(50) NULL,
	IDQuyen int NULL,
	Diachi nvarchar(100) NULL,
	primary key(MaNguoiDung));

/*PHÂN QUYỀN*/
Create table PhanQuyen
(IDQuyen int IDENTITY(1,1) NOT NULL,
	TenQuyen nvarchar(20) NULL,
	primary key(IDQuyen));

/*NHÀ CUNG CẤP*/
Create table NhaCungCap
(MaNCC int IDENTITY(1,1) NOT NULL, 
	TenNCC nvarchar(100) NULL, 
	primary key(MaNCC));

/*LOẠI HÀNG*/
Create table LoaiHang
(MaLoai int IDENTITY(1,1) NOT NULL,
	TenLoai nvarchar(100) DEFAULT NULL,
	Primary key(MaLoai));

/*SẢN PHẨM*/
CREATE TABLE SanPham(
	MaSP int IDENTITY(1,1) NOT NULL,
	TenSP nvarchar (100) NULL,
	GiaBan decimal(18,0) NULL,	
	Soluong int NULL,
	MoTa ntext NULL,
	MaLoai int NULL,
	MaNCC int NULL,
	AnhSP nvarchar(100) NULL,
	Primary key(MaSP));


/*ĐƠN HÀNG*/
CREATE TABLE DonHang(
	Madon int IDENTITY(1,1) NOT NULL,	
	NgayDat  datetime NULL,
	TinhTrang  int NULL,
	ThanhToan int NULL,
	DiaChiNhanHang Nvarchar(100) NULL,
	MaNguoiDung int NULL,
	TongTien decimal(18,0),
	Primary key(Madon));

/*CT ĐƠN HÀNG*/
CREATE TABLE ChiTietDonHang(
	CTMaDon int IDENTITY(1,1) NOT NULL,
	MaDon int NOT NULL,
	MaSP int NOT NULL,
	SoLuong int NULL,
	DonGia decimal(18,0) NULL,
	ThanhTien decimal(18,0)  NULL,
	PhuongThucThanhToan int Null,
	Primary key(CTMaDon));

CREATE TABLE TinTuc(
	MaTT int IDENTITY(1,1) NOT NULL,
	TieuDe nvarchar(100),
	NoiDung ntext,
	Primary key(MaTT));


/*Ràng buộc TÀI KHOẢN*/
alter table TaiKhoan
add constraint FK_tk_pq foreign key(IDQuyen) references PhanQuyen(IDQuyen);

/*Ràng buộc SẢN PHẨM*/
alter table SanPham
add constraint FK_sp_ncc foreign key(MaNCC) references NhaCungCap(MaNCC);
alter table SanPham
add constraint FK_sp_loai foreign key(Maloai) references LoaiHang(Maloai);

/*Ràng buộc ĐƠN HÀNG*/
alter table DonHang
add constraint FK_hd_tk foreign key(MaNguoiDung) references taikhoan(MaNguoiDung);

/*Ràng buộc CHI TIẾT ĐƠN HÀNG*/
alter table ChiTietDonHang
add constraint FK_cthd_hd foreign key(MaDon) references DonHang(MaDon);
alter table ChiTietDonHang
add constraint FK_cthd_sp foreign key(MaSP) references SanPham(MaSP);

/*Phân quyền*/
insert into PhanQuyen values ('Adminstrator');
insert into PhanQuyen values ('Member');
