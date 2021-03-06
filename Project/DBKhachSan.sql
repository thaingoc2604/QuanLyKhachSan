USE [master]
GO
/****** Object:  Database [DBQuanLyKhachSan]    Script Date: 5/17/2021 1:50:11 PM ******/
CREATE DATABASE [DBQuanLyKhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBQuanLyKhachSan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBQuanLyKhachSan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBQuanLyKhachSan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBQuanLyKhachSan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBQuanLyKhachSan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBQuanLyKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBQuanLyKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBQuanLyKhachSan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DBQuanLyKhachSan] SET QUERY_STORE = OFF
GO
USE [DBQuanLyKhachSan]
GO
/****** Object:  User [saDB]    Script Date: 5/17/2021 1:50:11 PM ******/
CREATE USER [saDB] FOR LOGIN [saDB] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idRoom] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[names] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[names] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableRoom]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableRoom](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'ddd', N'dd', N'3244185981728979115075721453575112', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'ngoc', N'Phương Thái Ngọc - PTN', N'3244185981728979115075721453575112', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff', N'staff', N'3244185981728979115075721453575112', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff1', N'staff', N'3244185981728979115075721453575112', 0)
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (64, CAST(N'2021-03-11' AS Date), CAST(N'2021-03-11' AS Date), 2, 1, 10, 675)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (65, CAST(N'2021-03-11' AS Date), CAST(N'2021-03-11' AS Date), 4, 1, 20, 48)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (66, CAST(N'2021-03-11' AS Date), CAST(N'2021-03-11' AS Date), 6, 1, 20, 24)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (67, CAST(N'2021-03-15' AS Date), CAST(N'2021-03-16' AS Date), 5, 1, 0, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (68, CAST(N'2021-03-16' AS Date), CAST(N'2021-04-20' AS Date), 1, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (69, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (70, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (71, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 450)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (72, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (73, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (74, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 8, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (75, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 11, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (76, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 11, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (77, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 11, 1, 0, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (78, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 7, 1, 0, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (79, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 7, 1, 0, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (80, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 7, 1, 0, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (81, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 7, 1, 0, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (82, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (83, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (84, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 5, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (85, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (86, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (87, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (88, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (89, CAST(N'2021-03-21' AS Date), CAST(N'2021-03-21' AS Date), 6, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (90, CAST(N'2021-03-22' AS Date), CAST(N'2021-03-23' AS Date), 3, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (91, CAST(N'2021-04-26' AS Date), CAST(N'2021-04-26' AS Date), 1, 1, 0, 150)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (93, CAST(N'2021-04-26' AS Date), CAST(N'2021-04-26' AS Date), 3, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (65, 64, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (66, 65, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (67, 65, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (76, 69, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (77, 70, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (78, 71, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (79, 72, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (80, 73, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (81, 74, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (82, 75, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (83, 76, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (84, 77, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (85, 78, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (86, 79, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (87, 80, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (88, 81, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (89, 82, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (90, 83, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (91, 84, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (92, 85, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (93, 86, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (94, 87, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (95, 88, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (96, 89, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (97, 90, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (98, 68, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idRoom], [count]) VALUES (99, 91, 2, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (2, N'Thịt Bò Nướng', 1, 150000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (3, N'Canh Chua', 1, 10000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (4, N'7up', 2, 50000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (9, N'Chè', 2, 3000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (10, N'Máy Chơi Game', 3, 50000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (11, N'Ngắm Thiên Văn', 4, 300000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (12, N'Máy MátXa', 3, 250000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (13, N'Cá Lóc Nướng Chui', 1, 10000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (14, N'Ếch Nướng Muối Ớt', 1, 15000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (15, N'Bào Ngư', 1, 50000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (19, N'Cua Hoàng Đế', 1, 500000)
INSERT [dbo].[Room] ([id], [names], [idCategory], [price]) VALUES (21, N'Thịt Bò Nướng', 1, 150000)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomCategory] ON 

INSERT [dbo].[RoomCategory] ([id], [names]) VALUES (1, N'Đồ Ăn')
INSERT [dbo].[RoomCategory] ([id], [names]) VALUES (2, N'Canh Chua')
INSERT [dbo].[RoomCategory] ([id], [names]) VALUES (3, N'Canh hoi Chua')
INSERT [dbo].[RoomCategory] ([id], [names]) VALUES (4, N'MS')
INSERT [dbo].[RoomCategory] ([id], [names]) VALUES (8, N'Nước')
SET IDENTITY_INSERT [dbo].[RoomCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[TableRoom] ON 

INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (1, N'Phòng 0', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (2, N'Phòng 1', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (3, N'Phòng 2', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (4, N'Phòng 3', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (5, N'Phòng 4', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (6, N'Phòng 5', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (7, N'Phòng 6', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (8, N'Phòng 7', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (9, N'Phòng 8', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (10, N'Phòng 9', N'Trống')
INSERT [dbo].[TableRoom] ([id], [name], [status]) VALUES (11, N'Phòng 10', N'Trống')
SET IDENTITY_INSERT [dbo].[TableRoom] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Kter') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (N'chưa đặt tên') FOR [names]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[RoomCategory] ADD  DEFAULT (N'chưa đặt tên') FOR [names]
GO
ALTER TABLE [dbo].[TableRoom] ADD  DEFAULT (N'chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableRoom] ADD  DEFAULT (N'trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableRoom] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[RoomCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
as
begin
---> danh mục hóa đơn mà mình muốn xuất ra
	select t.name as [Tên Phòng],b.totalPrice as [Tổng Tiền], DateCheckIn as [Ngày Vào], DateCheckOut as [Ngày ra], discount as [Giảm Giá]
	from dbo.Bill as b,dbo.TableRoom as t
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status =1
	and t.id = b.idTable 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date, @page int
as
begin
	declare @pageRows int  = 10
	declare @selectRows int = @pageRows
	declare @exceptRows int = (@page - 1) * @pageRows
---> danh mục hóa đơn mà mình muốn xuất ra

	;with BillShow as (select b.id, t.name as [Tên Phòng], b.totalPrice as [Tổng Tiền], DateCheckIn as [Ngày Vào], DateCheckOut as [Ngày ra], discount as [Giảm Giá]
	from dbo.Bill as b,dbo.TableRoom as t
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status =1
	and t.id = b.idTable)

	select top (@selectRows) * from BillShow where id not in (select top (@exceptRows) id from BillShow)
	
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateOfRP]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetListBillByDateOfRP]
@checkIn date, @checkOut date
as
begin
---> danh mục hóa đơn mà mình muốn xuất ra
	select t.name ,b.totalPrice , DateCheckIn, DateCheckOut,b.discount
	from dbo.Bill as b,dbo.TableRoom as t
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status =1
	and t.id = b.idTable 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNumBillByDate]
@checkIn date, @checkOut date
as
begin
---> danh mục hóa đơn mà mình muốn xuất ra
	select count(*)
	from dbo.Bill as b,dbo.TableRoom as t
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status =1
	and t.id = b.idTable 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc	[dbo].[USP_GetTableList]
as select * from dbo.TableRoom
GO
/****** Object:  StoredProcedure [dbo].[USP_InserStartBill]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InserStartBill]
@idRoom Int
AS
BEGIN
	INSERT INTO dbo.Bill
	(
	    DateCheckIn,
	    DateCheckOut,
	    idTable,
	    status,
		discount,
		totalPrice
	)
	VALUES
	(   GETDATE(), -- DateTimeCheckIn - datetime
	    null, -- DateTimeCheckOut - datetime
	    @idRoom,         -- idRoom - int
	    0,
		0,
		0        -- status - int
	    )
		UPDATE dbo.TableRoom SET status=N'Có Người' WHERE id=@idRoom
		
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[USP_InsertBill]
@idTable int
as
begin
	insert into dbo.Bill
	(DateCheckIn,DateCheckOut,idTable,status,discount)
values
	(GETDATE(),null,@idTable,0,0)

end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBillInfo]
@idBill int, @idRoom int , @count int 
as
begin
	declare @isExitBillBillInfo int
	declare @roomCount int =1

	select @isExitBillBillInfo = id, @roomCount = count 
	from dbo.BillInfo where idBill=@idBill and idRoom=@idRoom	--ktra xem thuc an nay co ton tai trong billinfo khong

	if(@isExitBillBillInfo >0)
	begin
		declare @newCount int = @roomCount + @count
		if(@newCount >0)
		-- neu thuc an do co ton tai thi ta se cap nhat no len
		update dbo.BillInfo set count = @roomCount+@count where @idRoom=idRoom;
		else
			delete BillInfo where @idBill=idBill and idRoom=@idRoom;
	end
	else
	begin
		insert dbo.BillInfo	
			(idBill,idRoom,count)
		values
			(
			@idBill
			,@idRoom
			,@count
			)
	end

	
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Login]
@userName nvarchar(100) ,@passWord nvarchar(100) 
as
begin
	select * from Account where UserName = @userName and PassWord =@passWord
end 
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_SwitchTable]
@idTable1 int, @idTable2 int
as 
begin

	declare @idFirstBill int 
	declare @idSecondBill int
	
	declare @isFirstTablEmty int = 1
	declare @isSecondTablEmty int = 1

	select @idSecondBill = id from dbo.Bill where idTable = @idTable2 and status = 0 -- thằng này có thể bị null nếu không có bill
	select @idFirstBill = id from dbo.Bill where idTable = @idTable1 and status = 0 -- thằng này có thể bị null nếu không có bill

	if(@idFirstBill is null)
	begin 
		insert into dbo.Bill
			(DateCheckIn,DateCheckOut,idTable,status)
		values
			(GETDATE(),null,@idTable1,0)

		select @idFirstBill = max(id) from dbo.Bill where idTable = @idTable1 and status =0	
	end
	select @isFirstTablEmty =count(*) from dbo.BillInfo where idBill =@idFirstBill


	if(@idSecondBill is null)
	begin 

		insert into dbo.Bill
			(DateCheckIn,DateCheckOut,idTable,status)
		values
			(GETDATE(),null,@idTable2,0)

		select @idSecondBill = max(id) from dbo.Bill where idTable = @idTable2 and status =0
		
		set @isSecondTablEmty = 1
	end
	select @isSecondTablEmty = count(*) from dbo.BillInfo where idBill = @idSecondBill


	select id into IDBillInfoTable from dbo.BillInfo where idBill =@idSecondBill
	
	update dbo.BillInfo set idBill = @idSecondBill where idBill = @idFirstBill

	update BillInfo set idBill = @idFirstBill where id in (select * from IDBillInfoTable)
	--- trường hợp giả sử cái bàn đó chưa có Bill thì sao


	drop table IDBillInfoTable
	if(@isFirstTablEmty = 0)
		update dbo.TableRoom set status = N'Trống' where  id=@idTable2
	if(@isSecondTablEmty = 0)
		update dbo.TableRoom set status = N'Trống' where  id=@idTable1
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 5/17/2021 1:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAccount]
@userName nvarchar(100), @displayName nvarchar(100), @password nvarchar(100), @newPassword nvarchar(100)
as
begin
	declare @isRightPass int
	select  @isRightPass = count(*) from dbo.Account where USERName = @userName and PassWord = @password

	if(@isRightPass = 1)
	begin
		if(@newPassword = null and  @newPassword ='')
		begin
			update dbo.Account set DisplayName =@displayName where UserName = @userName
		end
		else
			update dbo.Account set DisplayName =@displayName , PassWord =@newPassword where UserName = @userName
	end
end
GO
USE [master]
GO
ALTER DATABASE [DBQuanLyKhachSan] SET  READ_WRITE 
GO
