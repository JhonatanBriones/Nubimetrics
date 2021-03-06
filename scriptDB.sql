USE [master]
GO

CREATE DATABASE [NubimetricsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NubimetricsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NubimetricsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NubimetricsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NubimetricsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NubimetricsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NubimetricsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NubimetricsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NubimetricsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NubimetricsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NubimetricsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NubimetricsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NubimetricsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NubimetricsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NubimetricsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NubimetricsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NubimetricsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NubimetricsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NubimetricsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NubimetricsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NubimetricsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NubimetricsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NubimetricsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NubimetricsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NubimetricsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NubimetricsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NubimetricsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NubimetricsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NubimetricsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NubimetricsDB] SET  MULTI_USER 
GO
ALTER DATABASE [NubimetricsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NubimetricsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NubimetricsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NubimetricsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NubimetricsDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NubimetricsDB', N'ON'
GO
USE [NubimetricsDB]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/2/2022 20:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Apellido] [varchar](150) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (1, N'Juan Martín', N'Pérez', N'JuanP@gmail.com', N'10000.VD4X/lKI4DihiiSNVEAk6w==.QWU6rZXEYTmpHCmmejt7o1HdPzjpFeOtjehMZgze044=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (2, N'Pedro', N'Porchelo', N'PedroP@gmail.com', N'10000.ZQMzz4JtHQRboEUc6LoeNA==.r6JkTlVgeekoqCL+awydFoEVUDh7bM0Q1LuWxH2fxdw=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (3, N'María', N'Sánchez', N'MSanchez@gmail.com', N'10000.pDV0VLVNGNzJDc+4YKt8QQ==.7rgtEqfH3yNS+70RgU2mgPGrNKYiIQEyW7vpdLYj6C8=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (4, N'Olga', N'Tocarruncho', N'OlgaT@gmail.com', N'10000.wMPldOZCRPgoYFFEO94XeA==.IFGC8dvuoI4Hx5gYZeKXEPza4ulm4WkHmslSVEV3xJ8=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (5, N'Carla', N'Oura', N'CarlaO@gmail.com', N'10000.2gV6IA8TsMReVaBJTS+0Zw==.nAlgTQJdM53HPlG0d2Pht2b2LZEhnMPHMCcuDzuk5hA=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (7, N'Alma Lara', N'Cruzado', N'AlmaC@gmail.com', N'10000.knPRMAZIrx1M3olZITx5Lw==.CkwjeFYvzUWx9Jzp/TgUsX8LD7yaYPg3SMnEHAA7rt4=')
INSERT [dbo].[User] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (8, N'Judith', N'Tomatis', N'Judith@gmail.com', N'10000.MTvU1MXLFe8FvUua+u9i/w==.22zkFrHX4yE4F61WWBBOoV+MAJkESNtBet4ozV6Zo+w=')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [NubimetricsDB] SET  READ_WRITE 
GO
