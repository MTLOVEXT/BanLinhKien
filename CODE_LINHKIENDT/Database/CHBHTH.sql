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
insert into PhanQuyen values ('Nhân Viên');

/* Thêm dữ liệu */
-- Chèn dữ liệu mẫu cho bảng TaiKhoan
INSERT INTO TaiKhoan (HoTen, Email, Dienthoai, Matkhau, IDQuyen, Diachi) VALUES
(N'Nguyễn Văn A', 'nguyenvana@gmail.com', '0987654321', '123456', 1, N'123 Lê Lợi, Quận 1, TP.HCM'),
(N'Trần Thị B', 'tranthib@gmail.com', '0976543210', 'abcdef', 2, N'456 Trần Hưng Đạo, Quận 5, TP.HCM'),
(N'Lê Văn C', 'levanc@gmail.com', '0965432109', 'password', 2, N'789 Nguyễn Huệ, Quận 3, TP.HCM');

-- Chèn dữ liệu mẫu cho bảng NhaCungCap
INSERT INTO NhaCungCap (TenNCC) VALUES
(N'Công ty Sách Việt Nam'),
(N'Công ty Văn phòng phẩm ABC'),
(N'Công ty Đồ chơi Trẻ em X');

-- Chèn dữ liệu mẫu cho bảng LoaiHang
INSERT INTO LoaiHang (TenLoai) VALUES
(N'Sách giáo khoa'),
(N'Dụng cụ học tập'),
(N'Đồ chơi trẻ em');

-- Chèn dữ liệu mẫu cho bảng SanPham
INSERT INTO SanPham (TenSP, GiaBan, Soluong, MoTa, MaLoai, MaNCC, AnhSP) VALUES
(N'Tiếng Anh lớp 9', 55000, 100, N'Sách giáo khoa Tiếng Anh lớp 9', 1, 1, N'english9.jpg'),
(N'Bút bi Thiên Long', 5000, 200, N'Bút bi màu xanh, chất lượng cao', 2, 2, N'pen.jpg'),
(N'Lego City', 300000, 50, N'Bộ đồ chơi Lego chủ đề thành phố', 3, 3, N'lego.jpg');

-- Chèn dữ liệu mẫu cho bảng DonHang
INSERT INTO DonHang (NgayDat, TinhTrang, ThanhToan, DiaChiNhanHang, MaNguoiDung, TongTien) VALUES
(GETDATE(), 1, 1, N'123 Lê Lợi, Quận 1, TP.HCM', 1, 60000),
(GETDATE(), 0, 0, N'456 Trần Hưng Đạo, Quận 5, TP.HCM', 2, 350000);

-- Chèn dữ liệu mẫu cho bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (MaDon, MaSP, SoLuong, DonGia, ThanhTien, PhuongThucThanhToan) VALUES
(1, 1, 1, 55000, 55000, 1),
(2, 3, 1, 300000, 300000, 0);

-- Chèn dữ liệu mẫu cho bảng TinTuc
INSERT INTO TinTuc (TieuDe, NoiDung) VALUES
(N'Khuyến mãi mùa tựu trường', N'Giảm giá 20% cho tất cả các sản phẩm sách giáo khoa từ ngày 1/8 đến 31/8.'),
(N'Lễ hội đồ chơi trẻ em', N'Thưởng thức lễ hội đồ chơi với nhiều quà tặng hấp dẫn diễn ra từ ngày 10/12 đến 25/12.');

