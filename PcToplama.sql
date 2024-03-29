USE [master]
GO
/****** Object:  Database [PcToplama]    Script Date: 28.11.2022 22:53:12 ******/
CREATE DATABASE [PcToplama]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PcToplama', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\PcToplama.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PcToplama_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\PcToplama_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PcToplama].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PcToplama] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PcToplama] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PcToplama] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PcToplama] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PcToplama] SET ARITHABORT OFF 
GO
ALTER DATABASE [PcToplama] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PcToplama] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PcToplama] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PcToplama] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PcToplama] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PcToplama] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PcToplama] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PcToplama] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PcToplama] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PcToplama] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PcToplama] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PcToplama] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PcToplama] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PcToplama] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PcToplama] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PcToplama] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PcToplama] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PcToplama] SET RECOVERY FULL 
GO
ALTER DATABASE [PcToplama] SET  MULTI_USER 
GO
ALTER DATABASE [PcToplama] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PcToplama] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PcToplama] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PcToplama] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PcToplama] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PcToplama', N'ON'
GO
ALTER DATABASE [PcToplama] SET QUERY_STORE = OFF
GO
USE [PcToplama]
GO
/****** Object:  Table [dbo].[tbl_City]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City Name] [varchar](25) NULL,
 CONSTRAINT [PK_tbl_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CPU]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CPU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](30) NULL,
	[Seri] [varchar](30) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Stok] [int] NULL,
	[Güç] [int] NULL,
	[Soket Id] [int] NULL,
	[Full Ad] [varchar](125) NULL,
	[Hız] [varchar](20) NULL,
	[Ön Bellek] [tinyint] NULL,
 CONSTRAINT [PK_tbl_CPU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Soyad] [varchar](50) NULL,
	[Telno] [varchar](11) NULL,
	[Adres] [varchar](500) NULL,
	[TC] [varchar](11) NULL,
	[Email] [varchar](100) NULL,
	[City] [int] NULL,
	[Doğum_Tarihi] [date] NULL,
	[Username] [varchar](55) NULL,
	[Password] [varchar](55) NULL,
	[Admin/Customer] [bit] NULL,
 CONSTRAINT [PK_tbl_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Disk]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Disk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SSD/Sabit Disk] [bit] NULL,
	[Marka] [varchar](30) NULL,
	[GB] [int] NULL,
	[Model] [varchar](30) NULL,
	[Soket] [varchar](10) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Stok] [int] NULL,
	[Full Ad] [varchar](125) NULL,
 CONSTRAINT [PK_tbl_Disk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Ekran]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Ekran](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](50) NULL,
	[Boyut] [varchar](20) NULL,
	[Çözünürlük] [varchar](30) NULL,
	[Tazeleme hızı] [varchar](10) NULL,
	[HDR] [bit] NULL,
	[Panel] [varchar](20) NULL,
	[MS] [varchar](20) NULL,
	[Display Port] [varchar](30) NULL,
	[HDMI] [varchar](30) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Stok] [int] NULL,
	[FullAD] [varchar](125) NULL,
 CONSTRAINT [PK_tbl_Ekran] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GPU]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GPU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Üretici] [varchar](50) NULL,
	[Marka] [varchar](30) NULL,
	[Seri] [varchar](30) NULL,
	[Model] [varchar](30) NULL,
	[Bellek Kapasitesi] [tinyint] NULL,
	[Bit] [int] NULL,
	[Soket] [varchar](15) NULL,
	[Güç] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Full Ad] [varchar](125) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_GPU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_kasa]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kasa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](30) NULL,
	[Tip] [varchar](30) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[USB sayısı] [tinyint] NULL,
	[Full ad] [varchar](125) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_kasa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Keyboard]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Keyboard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](50) NULL,
	[Mekanik] [bit] NULL,
	[RGB] [bit] NULL,
	[Kablolu] [bit] NULL,
	[Türkçe/İngilizce] [bit] NULL,
	[Renk] [varchar](20) NULL,
	[switch] [varchar](20) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[FullAd] [varchar](125) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_Keyboard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Kulaklık]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Kulaklık](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](30) NULL,
	[Kablolu/Kablosuz] [bit] NULL,
	[RGB] [bit] NULL,
	[Renk] [varchar](20) NULL,
	[Frekans Tepkisi] [varchar](50) NULL,
	[Mikrofon var/yok] [bit] NULL,
	[Ses Çıkışı] [varchar](30) NULL,
	[Ses Kartı var/yok] [bit] NULL,
	[Full Ad] [varchar](125) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_Kulaklık] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MotherBoard]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MotherBoard](
	[MB Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](30) NULL,
	[Price] [decimal](18, 2) NULL,
	[Soket_Id] [int] NULL,
	[Full Ad] [varchar](125) NULL,
	[Yapı] [varchar](30) NULL,
	[Bellek Tip] [varchar](30) NULL,
	[Ram Slot sayısı] [tinyint] NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_MotherBoard] PRIMARY KEY CLUSTERED 
(
	[MB Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mouse]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Model] [varchar](50) NULL,
	[DPI] [varchar](20) NULL,
	[Tuş sayısı] [tinyint] NULL,
	[Kablolu/kablosuz] [bit] NULL,
	[RGB] [bit] NULL,
	[Renk] [varchar](20) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[FullAd] [varchar](125) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_mouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Order]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[Date] [date] NULL,
	[Cpu_Id] [int] NULL,
	[MotherBoard_Id] [int] NULL,
	[Ram_Id] [int] NULL,
	[Powersup_Id] [int] NULL,
	[GPU_Id] [int] NULL,
	[Case_Id] [int] NULL,
	[Keyboard_Id] [int] NULL,
	[Mouse_Id] [int] NULL,
	[Screen_Id] [int] NULL,
	[Total_Price] [decimal](18, 2) NULL,
	[Kulaklık_Id] [int] NULL,
	[Disk_Id] [int] NULL,
 CONSTRAINT [PK_tbl_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PSU]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PSU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Güc] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Full Ad] [varchar](125) NULL,
	[Verimlilik sertifikası] [varchar](30) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_PSU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RAM]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RAM](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marka] [varchar](30) NULL,
	[Toplam GB] [tinyint] NULL,
	[Soket] [varchar](10) NULL,
	[MHz] [int] NULL,
	[Kit] [varchar](10) NULL,
	[SAYI] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Full Ad] [varchar](125) NULL,
	[Stok] [int] NULL,
 CONSTRAINT [PK_tbl_RAM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Socket]    Script Date: 28.11.2022 22:53:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Socket](
	[Soket Id] [int] IDENTITY(1,1) NOT NULL,
	[Soket Name] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_Socket] PRIMARY KEY CLUSTERED 
(
	[Soket Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_City] ON 

INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (1, N'Adana')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (2, N'Adıyaman')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (3, N'Afyonkarahisar')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (4, N'Ağrı')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (5, N'Amasya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (6, N'Ankara')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (7, N'Antalya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (8, N'Artvin')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (9, N'Aydın')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (10, N'Balıkesir')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (11, N'Bilecik')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (12, N'Bingöl')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (13, N'Bitlis')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (14, N'Bolu')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (15, N'Burdur')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (16, N'Bursa')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (17, N'Çanakkale')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (18, N'Çankırı')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (19, N'Çorum')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (20, N'Denizli')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (21, N'Diyarbakır')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (22, N'Edirne')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (23, N'Elazığ')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (24, N'Erzincan')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (25, N'Erzurum')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (26, N'Eskişehir')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (27, N'Gaziantep')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (28, N'Giresun')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (29, N'Gümüşhane')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (30, N'Hakkari')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (31, N'Hatay')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (32, N'Isparta')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (33, N'Mersin')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (34, N'İstanbul')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (35, N'İzmir')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (36, N'Kars')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (37, N'Kastamonu')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (38, N'Kayseri')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (39, N'Kırklareli')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (40, N'Kırşehir')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (41, N'Kocaeli')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (42, N'Konya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (43, N'Kütahya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (44, N'Malatya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (45, N'Manisa')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (46, N'Kahramanmaraş')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (47, N'Mardin')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (48, N'Muğla')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (49, N'Muş')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (50, N'Nevşehir')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (51, N'Niğde')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (52, N'Ordu')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (53, N'Rize')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (54, N'Sakarya')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (55, N'Samsun')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (56, N'Siirt')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (57, N'Sinop')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (58, N'Sivas')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (59, N'Tekirdağ')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (60, N'Tokat')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (61, N'Trabzon')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (62, N'Tunceli')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (63, N'Şanlıurfa')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (64, N'Uşak')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (65, N'Van')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (66, N'Yozgat')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (67, N'Zonguldak')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (68, N'Aksaray')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (69, N'Bayburt')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (70, N'Karaman')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (71, N'Kırıkkale')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (72, N'Batman')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (73, N'Şırnak')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (74, N'Bartın')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (75, N'Ardahan')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (76, N'Iğdır')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (77, N'Yalova')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (78, N'Karabük')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (79, N'Kilis')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (80, N'Osmaniye')
INSERT [dbo].[tbl_City] ([Id], [City Name]) VALUES (81, N'Düzce')
SET IDENTITY_INSERT [dbo].[tbl_City] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_CPU] ON 

INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (1, N'Intel', N'i5', N'13600KF', CAST(7452.66 AS Decimal(18, 2)), 7, 125, 1, N'Intel Core i5 13600KF 3.5GHz 24MB Önbellek 14 Çekirdek 1700 10nm İşlemci', N'3.5GHz', 24)
INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (2, N'Intel', N'i7', N'12700', CAST(9761.30 AS Decimal(18, 2)), 15, 65, 1, N'Intel Core i7 12700 3.6GHz 25MB Önbellek 12 Çekirdek 1700 10nm İşlemci', N'3.6GHz', 25)
INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (3, N'Intel', N'i9', N'12900KS', CAST(19370.15 AS Decimal(18, 2)), 5, 150, 1, N'Intel Core i9 12900KS 3.4GHz 30MB Önbellek 16 Çekirdek 1700 10nm', N'3.4GHz', 30)
INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (4, N'Amd', N'Ryzen 9', N'5900X', CAST(8955.55 AS Decimal(18, 2)), 20, 105, 3, N'AMD RYZEN 9 5900X 3.7GHz 64MB Önbellek 12 Çekirdek AM4 7nm İşlemci', N'3.7GHz', 64)
INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (5, N'Amd', N'Ryzen 7', N'5800X', CAST(6012.08 AS Decimal(18, 2)), 25, 105, 3, N'AMD RYZEN 7 5800X 3.8GHz 32MB Önbellek 8 Çekirdek AM4 7nm İşlemci', N'3.8GHz', 32)
INSERT [dbo].[tbl_CPU] ([Id], [Marka], [Model], [Seri], [Fiyat], [Stok], [Güç], [Soket Id], [Full Ad], [Hız], [Ön Bellek]) VALUES (6, N'Amd', N'Ryzen 5', N'5600X', CAST(3974.56 AS Decimal(18, 2)), 30, 65, 3, N'AMD RYZEN 5 5600X 3.7GHz 32MB Önbellek 6 Çekirdek AM4 7nm İşlemci', N'3.7GHz', 32)
SET IDENTITY_INSERT [dbo].[tbl_CPU] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Customer] ON 

INSERT [dbo].[tbl_Customer] ([ID], [Ad], [Soyad], [Telno], [Adres], [TC], [Email], [City], [Doğum_Tarihi], [Username], [Password], [Admin/Customer]) VALUES (7, N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', N'123', 1)
INSERT [dbo].[tbl_Customer] ([ID], [Ad], [Soyad], [Telno], [Adres], [TC], [Email], [City], [Doğum_Tarihi], [Username], [Password], [Admin/Customer]) VALUES (1007, N'İsmail', N'Yazıcı', N'53531353135', N'asdgagfa', N'11551446465', N'masteriso@hotmail.com', 58, CAST(N'1999-07-15' AS Date), N'i_yazici', N'123456789', 0)
INSERT [dbo].[tbl_Customer] ([ID], [Ad], [Soyad], [Telno], [Adres], [TC], [Email], [City], [Doğum_Tarihi], [Username], [Password], [Admin/Customer]) VALUES (1008, N'Ziyacan', N'Aydın', N'16165165115', N'İstanbul', N'16145161561', N'avadfasfas', 29, CAST(N'1988-12-27' AS Date), N'ziyacan_29', N'123456789', 0)
INSERT [dbo].[tbl_Customer] ([ID], [Ad], [Soyad], [Telno], [Adres], [TC], [Email], [City], [Doğum_Tarihi], [Username], [Password], [Admin/Customer]) VALUES (1009, N'Hayrettin', N'Hayrettin', N'14414144141', N'adgda', N'14414141441', N'adgdag', 1, CAST(N'1989-06-14' AS Date), N'Hayrettin', N'Hayrettin', 0)
SET IDENTITY_INSERT [dbo].[tbl_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Disk] ON 

INSERT [dbo].[tbl_Disk] ([Id], [SSD/Sabit Disk], [Marka], [GB], [Model], [Soket], [Fiyat], [Stok], [Full Ad]) VALUES (1, 1, N'MLD', 120, N'M200', N'SATA 3.0', CAST(249.00 AS Decimal(18, 2)), 47, N'MLD 120GB M200 SATA 3.0 2.5inch SSD 540MB Okuma - 510MB Yazma')
INSERT [dbo].[tbl_Disk] ([Id], [SSD/Sabit Disk], [Marka], [GB], [Model], [Soket], [Fiyat], [Stok], [Full Ad]) VALUES (2, 1, N'SAMSUNG', 8000, N'870 QVO', N'SATA 3.0', CAST(16699.31 AS Decimal(18, 2)), 150, N'SAMSUNG 8TB 870 QVO SATA 3.0 2.5inch SSD 560MB Okuma - 530MB Yazma')
INSERT [dbo].[tbl_Disk] ([Id], [SSD/Sabit Disk], [Marka], [GB], [Model], [Soket], [Fiyat], [Stok], [Full Ad]) VALUES (3, 0, N'Seagate', 18000, N'Ironwolf Pro', N'SATA 3.0', CAST(12859.99 AS Decimal(18, 2)), 10, N'Seagate 18TB Ironwolf Pro 256MB 7200rpm 3.5inch SATA 3.0 NAS Harddisk')
SET IDENTITY_INSERT [dbo].[tbl_Disk] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Ekran] ON 

INSERT [dbo].[tbl_Ekran] ([Id], [Marka], [Model], [Boyut], [Çözünürlük], [Tazeleme hızı], [HDR], [Panel], [MS], [Display Port], [HDMI], [Fiyat], [Stok], [FullAD]) VALUES (1, N'Ekran Seçilmedli', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 9999996, N'Ekran Seçilmedi')
INSERT [dbo].[tbl_Ekran] ([Id], [Marka], [Model], [Boyut], [Çözünürlük], [Tazeleme hızı], [HDR], [Panel], [MS], [Display Port], [HDMI], [Fiyat], [Stok], [FullAD]) VALUES (2, N'ASUS', N'ProArt PA32DC', N'32"', N'3840 x 2160', N'60Hz', 1, N'OLED', N'0.1 ms', N'1.4 x 1', N'2.0 x 2', CAST(110249.00 AS Decimal(18, 2)), 1, N'ASUS ProArt PA32DC 60Hz 0.1ms HDMI DP HDR-10 USB-C Dolby Vision UHD OLED Profesyonel Monitör')
INSERT [dbo].[tbl_Ekran] ([Id], [Marka], [Model], [Boyut], [Çözünürlük], [Tazeleme hızı], [HDR], [Panel], [MS], [Display Port], [HDMI], [Fiyat], [Stok], [FullAD]) VALUES (3, N'LG', N'22MK400H-B', N'21.5"', N'1920 x 1080', N'75Hz', 0, N'TN', N'1.0 ms', N'Yok', N'HDMI x 1', CAST(1899.00 AS Decimal(18, 2)), 20, N'LG 21.5 inch 22MK400H-B 75Hz 1ms VGA HDMI TN FHD FreeSync Gaming Monitör')
INSERT [dbo].[tbl_Ekran] ([Id], [Marka], [Model], [Boyut], [Çözünürlük], [Tazeleme hızı], [HDR], [Panel], [MS], [Display Port], [HDMI], [Fiyat], [Stok], [FullAD]) VALUES (4, N'Allianware', N'AW2521H', N'24.5"', N'1920 x 1080', N'360Hz', 0, N'IPS', N'1.0 ms', N'Display Port x 1', N'HDMI x 2', CAST(12589.00 AS Decimal(18, 2)), 15, N'Alienware 24.5 inch AW2521H 360Hz 1ms 2xHDMI DP FHD USB Fast IPS G-Sync Gaming Monitör')
SET IDENTITY_INSERT [dbo].[tbl_Ekran] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_GPU] ON 

INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (1, N'NVDIA', N'GIGABYTE', N'RTX 3050', N'EAGLE', 8, 128, N'GDDR6', 450, CAST(7999.00 AS Decimal(18, 2)), N'GIGABYTE GeForce RTX 3050 EAGLE GDDR6 8GB 128 Bit Ekran Kartı', 12)
INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (2, N'NVDIA', N'GIGABYTE', N'RTX 3070 Ti', N'VISION OC', 8, 256, N'GDDR6X', 750, CAST(18183.59 AS Decimal(18, 2)), N'GIGABYTE GeForce RTX 3070 Ti VISION OC 8GB GDDR6X 256 Bit LHR Ekran Kartı', 10)
INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (3, N'NVDIA', N'ASUS', N'RTX 4080', N'ROG STRIX', 16, 256, N'GDDR6X', 750, CAST(40099.99 AS Decimal(18, 2)), N'ASUS ROG STRIX GeForce RTX 4080 16GB GDDR6X 256 Bit Ekran Kartı', 2)
INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (4, N'AMD', N'GIGABYTE', N'RX 6600', N'EAGLE', 8, 128, N'GDDR6', 500, CAST(6349.99 AS Decimal(18, 2)), N'GIGABYTE Radeon RX 6600 EAGLE 8G 8GB GDDR6 128 Bit Ekran Kartı', 25)
INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (5, N'AMD', N'GIGABYTE', N'RX 6650 XT', N'GAMING OC', 8, 128, N'GDDR6', 500, CAST(8441.43 AS Decimal(18, 2)), N'GIGABYTE Radeon RX 6650 XT GAMING OC 8GB GDDR6 128 Bit Ekran Kartı', 20)
INSERT [dbo].[tbl_GPU] ([Id], [Üretici], [Marka], [Seri], [Model], [Bellek Kapasitesi], [Bit], [Soket], [Güç], [Fiyat], [Full Ad], [Stok]) VALUES (6, N'AMD', N'ASUS', N'RX 6750 XT', N'DUAL OC', 12, 192, N'GDDR6', 750, CAST(16600.00 AS Decimal(18, 2)), N'ASUS Radeon RX 6750 XT DUAL OC 12GB GDDR6 192 Bit Ekran Kartı', 15)
SET IDENTITY_INSERT [dbo].[tbl_GPU] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_kasa] ON 

INSERT [dbo].[tbl_kasa] ([Id], [Marka], [Model], [Tip], [Fiyat], [USB sayısı], [Full ad], [Stok]) VALUES (1, N'Thermaltake', N'DistroCase 350P', N'mATX', CAST(17585.50 AS Decimal(18, 2)), 4, N'Thermaltake DistroCase 350P Tempered Glass USB 3.0 Uzay Montaj Mid Tower Kasa', 10)
INSERT [dbo].[tbl_kasa] ([Id], [Marka], [Model], [Tip], [Fiyat], [USB sayısı], [Full ad], [Stok]) VALUES (2, N'POWER BOOST', N'VK-G2080C', N'mATX', CAST(830.00 AS Decimal(18, 2)), 3, N'POWER BOOST VK-G2080C RGB USB 3.0 Mid Tower Kasa', 18)
INSERT [dbo].[tbl_kasa] ([Id], [Marka], [Model], [Tip], [Fiyat], [USB sayısı], [Full ad], [Stok]) VALUES (3, N'NZXT', N'H510', N'mATX', CAST(1540.00 AS Decimal(18, 2)), 5, N'NZXT H510 Tempered Glass USB 3.1 BeyazSiyah Mid Tower Kasa', 35)
SET IDENTITY_INSERT [dbo].[tbl_kasa] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Keyboard] ON 

INSERT [dbo].[tbl_Keyboard] ([Id], [Marka], [Model], [Mekanik], [RGB], [Kablolu], [Türkçe/İngilizce], [Renk], [switch], [Fiyat], [FullAd], [Stok]) VALUES (1, N'Klavye Seçilmedi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'Klavye Seçilmedi', 999996)
INSERT [dbo].[tbl_Keyboard] ([Id], [Marka], [Model], [Mekanik], [RGB], [Kablolu], [Türkçe/İngilizce], [Renk], [switch], [Fiyat], [FullAd], [Stok]) VALUES (2, N'GameBooster', N'G69K Outlander', 0, 1, 1, 1, N'Siyah', N'Membrane', CAST(219.00 AS Decimal(18, 2)), N'GameBooster G69K Outlander Rainbow Membrane Gaming Klavye', 15)
INSERT [dbo].[tbl_Keyboard] ([Id], [Marka], [Model], [Mekanik], [RGB], [Kablolu], [Türkçe/İngilizce], [Renk], [switch], [Fiyat], [FullAd], [Stok]) VALUES (3, N'Razer', N'Blackwidow V3', 1, 1, 1, 1, N'Siyah', N'Razer Green', CAST(2870.00 AS Decimal(18, 2)), N'Razer Blackwidow V3 Green Switch Türkçe RGB Mekanik Gaming Klavye', 10)
INSERT [dbo].[tbl_Keyboard] ([Id], [Marka], [Model], [Mekanik], [RGB], [Kablolu], [Türkçe/İngilizce], [Renk], [switch], [Fiyat], [FullAd], [Stok]) VALUES (5, N'Logitech G', N'G915 LIGHTSPEED', 1, 1, 0, 0, N'Metalic', N'GL Clicky', CAST(5469.00 AS Decimal(18, 2)), N'Logitech G G915 LIGHTSPEED Clicky İngilizce RGB Mekanik Kablosuz Gaming Klavye', 30)
SET IDENTITY_INSERT [dbo].[tbl_Keyboard] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Kulaklık] ON 

INSERT [dbo].[tbl_Kulaklık] ([Id], [Marka], [Model], [Kablolu/Kablosuz], [RGB], [Renk], [Frekans Tepkisi], [Mikrofon var/yok], [Ses Çıkışı], [Ses Kartı var/yok], [Full Ad], [Fiyat], [Stok]) VALUES (1, N'Kulaklık Seçilmedi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Kulaklık Seçilmedi', CAST(0.00 AS Decimal(18, 2)), 99997)
INSERT [dbo].[tbl_Kulaklık] ([Id], [Marka], [Model], [Kablolu/Kablosuz], [RGB], [Renk], [Frekans Tepkisi], [Mikrofon var/yok], [Ses Çıkışı], [Ses Kartı var/yok], [Full Ad], [Fiyat], [Stok]) VALUES (2, N'SteelSeries', N'Arctis Nova pro', 0, 0, N'Siyah', N'10Hz-40KHz', 1, N'Stereo', 1, N'SteelSeries Arctis Nova Pro Siyah Kablosuz Gaming Kulaklık', CAST(8999.00 AS Decimal(18, 2)), 15)
INSERT [dbo].[tbl_Kulaklık] ([Id], [Marka], [Model], [Kablolu/Kablosuz], [RGB], [Renk], [Frekans Tepkisi], [Mikrofon var/yok], [Ses Çıkışı], [Ses Kartı var/yok], [Full Ad], [Fiyat], [Stok]) VALUES (3, N'GameBooster', N'H001 Vital', 1, 1, N'Siyah', N'20Hz-20KHz', 1, N'Stereo', 0, N'GameBooster H001 Vital Rainbow Siyah Oyuncu Kulaklığı', CAST(269.00 AS Decimal(18, 2)), 30)
INSERT [dbo].[tbl_Kulaklık] ([Id], [Marka], [Model], [Kablolu/Kablosuz], [RGB], [Renk], [Frekans Tepkisi], [Mikrofon var/yok], [Ses Çıkışı], [Ses Kartı var/yok], [Full Ad], [Fiyat], [Stok]) VALUES (4, N'HyperX', N'Cloud II ', 1, 0, N'Siyah', N'15Hz-25KHz', 1, N'7.1 Surround', 1, N'HyperX Cloud II 7.1 Surround Kırmızı Kablolu Gaming Kulaklık', CAST(1120.00 AS Decimal(18, 2)), 19)
SET IDENTITY_INSERT [dbo].[tbl_Kulaklık] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MotherBoard] ON 

INSERT [dbo].[tbl_MotherBoard] ([MB Id], [Marka], [Model], [Price], [Soket_Id], [Full Ad], [Yapı], [Bellek Tip], [Ram Slot sayısı], [Stok]) VALUES (1, N'GIGABYTE', N'H610M H', CAST(2102.48 AS Decimal(18, 2)), 1, N'GIGABYTE H610M H 3200MHz DDR4 Soket 1700 M.2 HDMI D-Sub mATX Anakart', N'mATX', N'DDR4', 2, 20)
INSERT [dbo].[tbl_MotherBoard] ([MB Id], [Marka], [Model], [Price], [Soket_Id], [Full Ad], [Yapı], [Bellek Tip], [Ram Slot sayısı], [Stok]) VALUES (3, N'ASUS', N'ROG STRIX Z790-A', CAST(10600.00 AS Decimal(18, 2)), 1, N'ASUS ROG STRIX Z790-A GAMING WIFI D4 5333MHz(OC) DDR4 Soket 1700 M.2 HDMI DP ATX Anakart', N'ATX', N'DDR4', 4, 15)
INSERT [dbo].[tbl_MotherBoard] ([MB Id], [Marka], [Model], [Price], [Soket_Id], [Full Ad], [Yapı], [Bellek Tip], [Ram Slot sayısı], [Stok]) VALUES (4, N'MSI', N'A320M-A PRO', CAST(1144.60 AS Decimal(18, 2)), 3, N'MSI A320M-A PRO 3200MHz(OC) DDR4 Soket AM4 HDMI DVI mATX Anakart', N'mATX', N'DDR4', 2, 27)
INSERT [dbo].[tbl_MotherBoard] ([MB Id], [Marka], [Model], [Price], [Soket_Id], [Full Ad], [Yapı], [Bellek Tip], [Ram Slot sayısı], [Stok]) VALUES (5, N'MSI', N'MEG X570S ACE MAX', CAST(10910.55 AS Decimal(18, 2)), 3, N'MSI MEG X570S ACE MAX 5300(O.C) DDR4 Soket AM4 M.2 ATX Anakart', N'ATX', N'DDR4', 4, 20)
SET IDENTITY_INSERT [dbo].[tbl_MotherBoard] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_mouse] ON 

INSERT [dbo].[tbl_mouse] ([Id], [Marka], [Model], [DPI], [Tuş sayısı], [Kablolu/kablosuz], [RGB], [Renk], [Fiyat], [FullAd], [Stok]) VALUES (1, N'Mouse Seçilmedi', NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'Mouse Seçilmedi', 99996)
INSERT [dbo].[tbl_mouse] ([Id], [Marka], [Model], [DPI], [Tuş sayısı], [Kablolu/kablosuz], [RGB], [Renk], [Fiyat], [FullAd], [Stok]) VALUES (2, N'Razer', N'Viper V2 Pro', N'30000 DPI', 5, 0, 0, N'Siyah', CAST(3470.00 AS Decimal(18, 2)), N'Razer Viper V2 Pro Siyah Kablosuz Gaming Mouse', 15)
INSERT [dbo].[tbl_mouse] ([Id], [Marka], [Model], [DPI], [Tuş sayısı], [Kablolu/kablosuz], [RGB], [Renk], [Fiyat], [FullAd], [Stok]) VALUES (3, N'Everest', N'SM-M9 3D', N'1000 DPI', 3, 1, 1, N'Siyah', CAST(61.26 AS Decimal(18, 2)), N'Everest SM-M9 3D Kablolu Siyah Mouse', 30)
INSERT [dbo].[tbl_mouse] ([Id], [Marka], [Model], [DPI], [Tuş sayısı], [Kablolu/kablosuz], [RGB], [Renk], [Fiyat], [FullAd], [Stok]) VALUES (4, N'Philips', N'SPK9403B G403', N'4000 DPI', 7, 1, 1, N'Siyah', CAST(228.92 AS Decimal(18, 2)), N'Philips SPK9403B G403 Rainbow Siyah Kablolu Gaming Mouse', 25)
SET IDENTITY_INSERT [dbo].[tbl_mouse] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PSU] ON 

INSERT [dbo].[tbl_PSU] ([Id], [Marka], [Güc], [Fiyat], [Full Ad], [Verimlilik sertifikası], [Stok]) VALUES (1, N'POWER BOOST', 650, CAST(903.45 AS Decimal(18, 2)), N'POWER BOOST FURY 650W 80+ 120mm Fanlı PSU', N'80+', 55)
INSERT [dbo].[tbl_PSU] ([Id], [Marka], [Güc], [Fiyat], [Full Ad], [Verimlilik sertifikası], [Stok]) VALUES (2, N'Thermaltake', 750, CAST(2650.39 AS Decimal(18, 2)), N'Thermaltake Toughpower GF 750W 80+ GOLD Full Modüler 140mm Fanlı PSU', N'80+ GOLD', 12)
INSERT [dbo].[tbl_PSU] ([Id], [Marka], [Güc], [Fiyat], [Full Ad], [Verimlilik sertifikası], [Stok]) VALUES (3, N'Cooler Master', 2000, CAST(14749.73 AS Decimal(18, 2)), N'Cooler Master M2000 2000W 80+ Platinum Full Modüler 135mm Fanlı PSU', N'80+ Platinum', 5)
INSERT [dbo].[tbl_PSU] ([Id], [Marka], [Güc], [Fiyat], [Full Ad], [Verimlilik sertifikası], [Stok]) VALUES (4, N'ASUS', 1000, CAST(9699.00 AS Decimal(18, 2)), N'ASUS ROG THOR PII EVA Edition 1000W 80+ Platinum ARGB Full Modüler PSU', N'80+ Platinum', 10)
SET IDENTITY_INSERT [dbo].[tbl_PSU] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_RAM] ON 

INSERT [dbo].[tbl_RAM] ([Id], [Marka], [Toplam GB], [Soket], [MHz], [Kit], [SAYI], [Fiyat], [Full Ad], [Stok]) VALUES (2, N'CORSAIR', 16, N'DDR4', 4000, N'Dual Kit', 2, CAST(8622.60 AS Decimal(18, 2)), N'CORSAIR 16GB 2x8GB Dominator Platinum RGB Beyaz 4000MHz CL19 DDR4 Dual Kit Ram', 17)
INSERT [dbo].[tbl_RAM] ([Id], [Marka], [Toplam GB], [Soket], [MHz], [Kit], [SAYI], [Fiyat], [Full Ad], [Stok]) VALUES (3, N'CORSAIR', 16, N'DDR4', 3200, N'Single Kit', 1, CAST(1068.30 AS Decimal(18, 2)), N'CORSAIR 16GB Vengeance LPX Siyah 3200MHz CL16 DDR4 Single Kit Ram', 30)
INSERT [dbo].[tbl_RAM] ([Id], [Marka], [Toplam GB], [Soket], [MHz], [Kit], [SAYI], [Fiyat], [Full Ad], [Stok]) VALUES (4, N'GSKILL', 32, N'DDR4', 3200, N'Dual Kit', 2, CAST(3280.00 AS Decimal(18, 2)), N'GSKILL 32GB 2x16GB Trident Z Neo RGB 3200MHz CL16 DDR4 Dual Kit Ram', 0)
INSERT [dbo].[tbl_RAM] ([Id], [Marka], [Toplam GB], [Soket], [MHz], [Kit], [SAYI], [Fiyat], [Full Ad], [Stok]) VALUES (1002, N'GoodRam', 8, N'DDR4', 3200, N'Single Kit', 1, CAST(519.00 AS Decimal(18, 2)), N'GoodRam 8GB IRDM X 3200MHz CL16 DDR4 Kırmızı Single Kit Ram', 25)
SET IDENTITY_INSERT [dbo].[tbl_RAM] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Socket] ON 

INSERT [dbo].[tbl_Socket] ([Soket Id], [Soket Name]) VALUES (1, N'FCLGA1700')
INSERT [dbo].[tbl_Socket] ([Soket Id], [Soket Name]) VALUES (2, N'AM5')
INSERT [dbo].[tbl_Socket] ([Soket Id], [Soket Name]) VALUES (3, N'AM4')
SET IDENTITY_INSERT [dbo].[tbl_Socket] OFF
GO
ALTER TABLE [dbo].[tbl_CPU]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CPU_tbl_Socket] FOREIGN KEY([Soket Id])
REFERENCES [dbo].[tbl_Socket] ([Soket Id])
GO
ALTER TABLE [dbo].[tbl_CPU] CHECK CONSTRAINT [FK_tbl_CPU_tbl_Socket]
GO
ALTER TABLE [dbo].[tbl_Customer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Customer_tbl_City] FOREIGN KEY([City])
REFERENCES [dbo].[tbl_City] ([Id])
GO
ALTER TABLE [dbo].[tbl_Customer] CHECK CONSTRAINT [FK_tbl_Customer_tbl_City]
GO
ALTER TABLE [dbo].[tbl_MotherBoard]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MotherBoard_tbl_Socket1] FOREIGN KEY([Soket_Id])
REFERENCES [dbo].[tbl_Socket] ([Soket Id])
GO
ALTER TABLE [dbo].[tbl_MotherBoard] CHECK CONSTRAINT [FK_tbl_MotherBoard_tbl_Socket1]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_CPU] FOREIGN KEY([Cpu_Id])
REFERENCES [dbo].[tbl_CPU] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_CPU]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[tbl_Customer] ([ID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_Disk] FOREIGN KEY([Disk_Id])
REFERENCES [dbo].[tbl_Disk] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_Disk]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_Ekran] FOREIGN KEY([Screen_Id])
REFERENCES [dbo].[tbl_Ekran] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_Ekran]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_GPU] FOREIGN KEY([GPU_Id])
REFERENCES [dbo].[tbl_GPU] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_GPU]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_kasa] FOREIGN KEY([Case_Id])
REFERENCES [dbo].[tbl_kasa] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_kasa]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_Keyboard] FOREIGN KEY([Keyboard_Id])
REFERENCES [dbo].[tbl_Keyboard] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_Keyboard]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_Kulaklık] FOREIGN KEY([Kulaklık_Id])
REFERENCES [dbo].[tbl_Kulaklık] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_Kulaklık]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_MotherBoard] FOREIGN KEY([MotherBoard_Id])
REFERENCES [dbo].[tbl_MotherBoard] ([MB Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_MotherBoard]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_mouse] FOREIGN KEY([Mouse_Id])
REFERENCES [dbo].[tbl_mouse] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_mouse]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_PSU] FOREIGN KEY([Powersup_Id])
REFERENCES [dbo].[tbl_PSU] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_PSU]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_RAM] FOREIGN KEY([Ram_Id])
REFERENCES [dbo].[tbl_RAM] ([Id])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_RAM]
GO
USE [master]
GO
ALTER DATABASE [PcToplama] SET  READ_WRITE 
GO
