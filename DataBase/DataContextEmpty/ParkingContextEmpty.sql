USE [master]
GO
/****** Object:  Database [ParkingContext]    Script Date: 21/11/2019 19:18:41 ******/
CREATE DATABASE [ParkingContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ParkingContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ParkingContext.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ParkingContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ParkingContext_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ParkingContext] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParkingContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParkingContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParkingContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParkingContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParkingContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParkingContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParkingContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ParkingContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParkingContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ParkingContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParkingContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParkingContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParkingContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParkingContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParkingContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParkingContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ParkingContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParkingContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParkingContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParkingContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ParkingContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParkingContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ParkingContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParkingContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ParkingContext] SET  MULTI_USER 
GO
ALTER DATABASE [ParkingContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ParkingContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ParkingContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ParkingContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ParkingContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ParkingContext] SET QUERY_STORE = OFF
GO
USE [ParkingContext]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21/11/2019 19:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 21/11/2019 19:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountCellPhoneNumber] [nvarchar](max) NULL,
	[AccountBalance] [int] NOT NULL,
	[AccountCountry_Name] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21/11/2019 19:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Name] [nvarchar](128) NOT NULL,
	[CostPerMinut] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Countries] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 21/11/2019 19:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseCost] [int] NOT NULL,
	[Account_AccountId] [int] NULL,
 CONSTRAINT [PK_dbo.Purchases] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sms]    Script Date: 21/11/2019 19:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sms](
	[SmsId] [int] NOT NULL,
	[Plates] [nvarchar](max) NULL,
	[Minutes] [nvarchar](max) NULL,
	[StartingHour] [datetime] NOT NULL,
	[EndingHour] [datetime] NOT NULL,
	[LowerHourLimit] [datetime] NOT NULL,
	[UpperHourLimit] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Sms] PRIMARY KEY CLUSTERED 
(
	[SmsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountCountry_Name]    Script Date: 21/11/2019 19:18:41 ******/
CREATE NONCLUSTERED INDEX [IX_AccountCountry_Name] ON [dbo].[Accounts]
(
	[AccountCountry_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Account_AccountId]    Script Date: 21/11/2019 19:18:41 ******/
CREATE NONCLUSTERED INDEX [IX_Account_AccountId] ON [dbo].[Purchases]
(
	[Account_AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SmsId]    Script Date: 21/11/2019 19:18:41 ******/
CREATE NONCLUSTERED INDEX [IX_SmsId] ON [dbo].[Sms]
(
	[SmsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Accounts_dbo.Countries_AccountCountry_Name] FOREIGN KEY([AccountCountry_Name])
REFERENCES [dbo].[Countries] ([Name])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_dbo.Accounts_dbo.Countries_AccountCountry_Name]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Purchases_dbo.Accounts_Account_AccountId] FOREIGN KEY([Account_AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_dbo.Purchases_dbo.Accounts_Account_AccountId]
GO
ALTER TABLE [dbo].[Sms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sms_dbo.Purchases_SmsId] FOREIGN KEY([SmsId])
REFERENCES [dbo].[Purchases] ([PurchaseId])
GO
ALTER TABLE [dbo].[Sms] CHECK CONSTRAINT [FK_dbo.Sms_dbo.Purchases_SmsId]
GO
USE [master]
GO
ALTER DATABASE [ParkingContext] SET  READ_WRITE 
GO
