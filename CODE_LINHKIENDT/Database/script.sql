USE [master]
GO
/****** Object:  Database [CHBHTH]    Script Date: 11/12/2024 07:43:32 PM ******/
CREATE DATABASE [CHBHTH] ON  PRIMARY 
( NAME = N'CHBHTH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MTLOVEXT\MSSQL\DATA\CHBHTH.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CHBHTH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MTLOVEXT\MSSQL\DATA\CHBHTH_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CHBHTH] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CHBHTH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CHBHTH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CHBHTH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CHBHTH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CHBHTH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CHBHTH] SET ARITHABORT OFF 
GO
ALTER DATABASE [CHBHTH] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CHBHTH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CHBHTH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CHBHTH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CHBHTH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CHBHTH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CHBHTH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CHBHTH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CHBHTH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CHBHTH] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CHBHTH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CHBHTH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CHBHTH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CHBHTH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CHBHTH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CHBHTH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CHBHTH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CHBHTH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CHBHTH] SET  MULTI_USER 
GO
ALTER DATABASE [CHBHTH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CHBHTH] SET DB_CHAINING OFF 
GO
USE [CHBHTH]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[CTMaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaDon] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[PhuongThucThanhToan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CTMaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[Madon] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [datetime] NULL,
	[TinhTrang] [int] NULL,
	[ThanhToan] [int] NULL,
	[DiaChiNhanHang] [nvarchar](100) NULL,
	[MaNguoiDung] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Madon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[IDQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](100) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[Soluong] [int] NULL,
	[MoTa] [ntext] NULL,
	[MaLoai] [int] NULL,
	[MaNCC] [int] NULL,
	[AnhSP] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Dienthoai] [varchar](50) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 11/12/2024 07:43:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[MaTT] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON 

INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (1, 1, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (4, 3, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (5, 3, 4, 1, CAST(25000000 AS Decimal(18, 0)), CAST(25000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (7, 4, 1, 10, CAST(10000000 AS Decimal(18, 0)), CAST(100000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (8, 4, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (9, 5, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (10, 6, 4, 1, CAST(25000000 AS Decimal(18, 0)), CAST(25000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (11, 7, 5, 1, CAST(1200000 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (24, 17, 4, 1, CAST(25000000 AS Decimal(18, 0)), CAST(25000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (25, 18, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (26, 18, 4, 10, CAST(25000000 AS Decimal(18, 0)), CAST(250000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (27, 19, 1, 10, CAST(10000000 AS Decimal(18, 0)), CAST(100000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (28, 20, 9, 10, CAST(150000 AS Decimal(18, 0)), CAST(1500000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (29, 21, 10, 1, CAST(1000 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (30, 22, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (31, 23, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (32, 24, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (33, 25, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (34, 26, 6, 1, CAST(3000000 AS Decimal(18, 0)), CAST(3000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (35, 27, 5, 1, CAST(1200000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (36, 28, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (37, 29, 5, 10, CAST(1200000 AS Decimal(18, 0)), CAST(12000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (38, 30, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (39, 31, 1, 10, CAST(10000000 AS Decimal(18, 0)), CAST(100000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (40, 43, 1, 1, CAST(10000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (41, 47, 6, 1, CAST(3000000 AS Decimal(18, 0)), CAST(3000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (42, 48, 10, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (43, 49, 10, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (44, 50, 10, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (45, 51, 10, 6, CAST(100000 AS Decimal(18, 0)), CAST(600000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (46, 52, 10, 10, CAST(100000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (47, 53, 10, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (48, 54, 10, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (49, 55, 10, 2, CAST(100000 AS Decimal(18, 0)), CAST(200000 AS Decimal(18, 0)), 2)
INSERT [dbo].[ChiTietDonHang] ([CTMaDon], [MaDon], [MaSP], [SoLuong], [DonGia], [ThanhTien], [PhuongThucThanhToan]) VALUES (50, 56, 11, 1, CAST(100000 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (1, CAST(N'2024-10-01T00:00:00.000' AS DateTime), 1, 1, N'789 Pham Van Dong, HCM', 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (2, CAST(N'2024-10-02T00:00:00.000' AS DateTime), 2, 0, N'101 Nguyen Dinh Chieu, HN', 2, CAST(500000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (3, CAST(N'2024-11-18T09:47:13.977' AS DateTime), 1, 2, N'Hậu Giang', 3, CAST(35500000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (4, CAST(N'2024-11-27T22:42:45.970' AS DateTime), NULL, 2, N'Hậu Giang', 3, CAST(101200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (5, CAST(N'2024-11-28T08:31:32.573' AS DateTime), NULL, 2, N'Hậu Giang', 3, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (6, CAST(N'2024-11-28T08:38:36.960' AS DateTime), NULL, 1, N'', 3, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (7, NULL, NULL, 2, N'Hậu Giang', NULL, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (17, CAST(N'2024-12-01T12:37:11.763' AS DateTime), 1, 2, N'Hậu Giang', 3, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (18, CAST(N'2024-12-01T12:39:22.430' AS DateTime), 1, 1, N'Hậu Giang', 3, CAST(260000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (19, CAST(N'2024-12-01T13:11:31.000' AS DateTime), 1, 2, N'Hậu Giang', 3, CAST(100000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (20, CAST(N'2024-12-02T01:37:43.933' AS DateTime), 1, 2, N'An Dương Vương', 7, CAST(1500000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (21, CAST(N'2024-12-02T12:33:13.823' AS DateTime), NULL, 1, N'Hậu Giang', 7, CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (22, CAST(N'2024-12-02T13:13:50.943' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (23, CAST(N'2024-12-02T13:18:16.030' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (24, CAST(N'2024-12-02T13:41:07.990' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (25, CAST(N'2024-12-02T14:04:55.230' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (26, CAST(N'2024-12-02T14:15:15.117' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (27, CAST(N'2024-12-02T14:19:15.387' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (28, CAST(N'2024-12-02T14:40:38.620' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (29, CAST(N'2024-12-02T15:00:09.903' AS DateTime), NULL, 2, N'Hậu Giang', 7, CAST(12000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (30, CAST(N'2024-12-02T15:13:56.287' AS DateTime), NULL, 2, N'Hậu Giang', 3, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (31, CAST(N'2024-12-02T22:06:43.337' AS DateTime), NULL, 1, N'Hậu Giang', 7, CAST(100000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (35, CAST(N'2024-12-02T23:40:23.373' AS DateTime), 1, 2, N'Hậu Giang', NULL, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (36, CAST(N'2024-12-03T00:21:14.973' AS DateTime), 1, 2, N'Hậu Giang', NULL, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (37, CAST(N'2024-12-03T00:37:55.443' AS DateTime), 1, 2, N'Hậu Giang', NULL, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (38, CAST(N'2024-12-03T00:55:23.427' AS DateTime), 1, 2, N'Hậu Giang', NULL, CAST(250000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (39, CAST(N'2024-12-03T01:05:10.767' AS DateTime), 1, 2, N'Hậu Giang', NULL, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (40, CAST(N'2024-12-03T01:12:22.000' AS DateTime), 3, 2, NULL, NULL, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (41, CAST(N'2024-12-03T01:23:00.000' AS DateTime), 2, 2, N'Hậu Giang', 3, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (42, CAST(N'2024-12-03T01:30:54.037' AS DateTime), 2, 2, N'Hậu Giang', 3, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (43, CAST(N'2024-12-03T01:35:56.290' AS DateTime), NULL, 1, N'Hậu Giang', 3, CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (44, CAST(N'2024-12-03T01:36:16.547' AS DateTime), 2, 2, N'Hậu Giang', 3, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (45, CAST(N'2024-12-03T01:39:37.410' AS DateTime), 2, 2, N'Hậu Giang', 3, CAST(25000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (46, CAST(N'2024-12-03T01:41:56.200' AS DateTime), 0, 2, N'Hậu Giang', 3, CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (47, CAST(N'2024-12-03T01:45:14.427' AS DateTime), 0, 2, N'Hậu Giang', 3, CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (48, CAST(N'2024-12-05T01:46:28.340' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (49, CAST(N'2024-12-05T01:47:13.667' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (50, CAST(N'2024-12-05T05:58:34.687' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (51, CAST(N'2024-12-05T06:13:16.527' AS DateTime), NULL, 1, N'Hậu Giang', 7, CAST(600000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (52, CAST(N'2024-12-05T06:13:46.130' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(1000000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (53, CAST(N'2024-12-05T06:57:18.937' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (54, CAST(N'2024-12-05T12:31:33.977' AS DateTime), 0, 2, N'Hậu Giang', 7, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (55, CAST(N'2024-12-05T12:58:46.240' AS DateTime), 0, 2, N'Hậu Giang', 3, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (56, CAST(N'2024-12-09T23:00:51.047' AS DateTime), 1, 1, N'Hậu Giang', 3, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (57, CAST(N'2024-12-11T19:34:36.230' AS DateTime), 1, 1, N'123 Lê Lợi, Quận 1, TP.HCM', 1, CAST(60000 AS Decimal(18, 0)))
INSERT [dbo].[DonHang] ([Madon], [NgayDat], [TinhTrang], [ThanhToan], [DiaChiNhanHang], [MaNguoiDung], [TongTien]) VALUES (58, CAST(N'2024-12-11T19:34:36.230' AS DateTime), 0, 0, N'456 Trần Hưng Đạo, Quận 5, TP.HCM', 2, CAST(350000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiHang] ON 

INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (1, N'Điện Máy')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (3, N'Điện Lạnh')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (5, N'Điện Thoại')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (6, N'Hàng Mới')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (7, N'Sách giáo khoa')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (8, N'Dụng cụ học tập')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (9, N'Đồ chơi trẻ em')
SET IDENTITY_INSERT [dbo].[LoaiHang] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (1, N'Công ty A')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (2, N'Công ty B')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (3, N'Công ty C')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (5, N'Công ty Sách Việt Nam')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (6, N'Công ty Văn phòng phẩm ABC')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC]) VALUES (7, N'Công ty Đồ chơi Trẻ em X')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (1, N'Adminstrator')
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (2, N'Member')
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (3, N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (1, N'Smartphone A', CAST(10000000 AS Decimal(18, 0)), 27, N'Đi?n tho?i thông minh v?i nhi?u tính năng.', 1, 1, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (4, N'Laptop Gaming X', CAST(25000000 AS Decimal(18, 0)), 30, N'Laptop gaming hi?u su?t cao v?i card đ? h?a r?i.', 1, 1, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (5, N'Tai nghe Bluetooth Y', CAST(1200000 AS Decimal(18, 0)), 85, N'Tai nghe không dây v?i âm thanh ch?t lư?ng cao.', 1, 2, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (6, N'Smartwatch Z', CAST(3000000 AS Decimal(18, 0)), 48, N'Đ?ng h? thông minh v?i nhi?u ch?c năng theo d?i s?c kh?e.', 1, 3, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (7, N'Máy ?nh K', CAST(15000000 AS Decimal(18, 0)), 20, N'Máy ?nh DSLR chuyên nghi?p cho ngư?i đam mê nhi?p ?nh.', 1, 1, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (8, N'Máy chi?u L', CAST(7000000 AS Decimal(18, 0)), 105, N' Máy chi?u mini cho các bu?i h?p ho?c gi?i trí. ', 1, 1, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (9, N'Tên sản phẩm', CAST(150000 AS Decimal(18, 0)), 100, N'Mô tả sản phẩm', 1, 1, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (10, N'Sản phẩm rẻ', CAST(100000 AS Decimal(18, 0)), 976, N'Test', 3, 3, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (11, N'SamSung A56', CAST(100000 AS Decimal(18, 0)), 999, N'Test', 5, 3, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [GiaBan], [Soluong], [MoTa], [MaLoai], [MaNCC], [AnhSP]) VALUES (12, N'Sản Phẩm Mới', CAST(1000000 AS Decimal(18, 0)), 1000, N'Test', 6, 2, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (1, N'Nguyen Van A', N'Admin@gmail.com', N'0123456789', N'123123', 1, N'123 Nguyen Trai, HCM')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (2, N'Tran Thi B', N'nguyenvana@gmail.com', N'0987654321', N'123123', 2, N'456 Le Lai, HN')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (3, N'Thành', N'a@gmail.com', N'0907788054', N'123123123', NULL, N'123Hậu Giang')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (4, N'MTMTMT', N'mt@gmail.com', N'0907788143', N'123123', 1, N'123Hậu Giang')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (6, N'Nhân Viên 1', N'nv1@gmail.com', N'0907788054', N'123123', 3, N'An Dương Vương')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (7, N'Khách Hàng 1', N'kh1@gmail.com', N'0907655643', N'123123', NULL, N'123Hậu Giang')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (8, N'Khách Hàng 2', N'kh2@gmail.com', N'0907788054', N'123123123', NULL, N'Hậu Giang')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (9, N'Nguyễn Văn A', N'nguyenvana@gmail.com', N'0987654321', N'123456', 1, N'123 Lê Lợi, Quận 1, TP.HCM')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (10, N'Trần Thị B', N'tranthib@gmail.com', N'0976543210', N'abcdef', 2, N'456 Trần Hưng Đạo, Quận 5, TP.HCM')
INSERT [dbo].[TaiKhoan] ([MaNguoiDung], [HoTen], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi]) VALUES (11, N'Lê Văn C', N'levanc@gmail.com', N'0965432109', N'password', 2, N'789 Nguyễn Huệ, Quận 3, TP.HCM')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([MaTT], [TieuDe], [NoiDung]) VALUES (1, N'Tin T?c 1', N'N?i dung tin t?c s? 1.')
INSERT [dbo].[TinTuc] ([MaTT], [TieuDe], [NoiDung]) VALUES (2, N'Tin T?c 2', N'N?i dung tin t?c s? 2.')
INSERT [dbo].[TinTuc] ([MaTT], [TieuDe], [NoiDung]) VALUES (3, N'Tin Tức Mới', N'<h1>Hello ae M&igrave;nh l&agrave; ABC</h1>
')
INSERT [dbo].[TinTuc] ([MaTT], [TieuDe], [NoiDung]) VALUES (5, N'Khuyến mãi mùa tựu trường', N'Giảm giá 20% cho tất cả các sản phẩm sách giáo khoa từ ngày 1/8 đến 31/8.')
INSERT [dbo].[TinTuc] ([MaTT], [TieuDe], [NoiDung]) VALUES (6, N'Lễ hội đồ chơi trẻ em', N'Thưởng thức lễ hội đồ chơi với nhiều quà tặng hấp dẫn diễn ra từ ngày 10/12 đến 25/12.')
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO
ALTER TABLE [dbo].[LoaiHang] ADD  DEFAULT (NULL) FOR [TenLoai]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_cthd_hd] FOREIGN KEY([MaDon])
REFERENCES [dbo].[DonHang] ([Madon])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_cthd_hd]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_cthd_sp] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_cthd_sp]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_hd_tk] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[TaiKhoan] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_hd_tk]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_sp_loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiHang] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_sp_loai]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_sp_ncc] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_sp_ncc]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_tk_pq] FOREIGN KEY([IDQuyen])
REFERENCES [dbo].[PhanQuyen] ([IDQuyen])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_tk_pq]
GO
USE [master]
GO
ALTER DATABASE [CHBHTH] SET  READ_WRITE 
GO
