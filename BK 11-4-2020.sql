USE [master]
GO
/****** Object:  Database [EvaluacionesRRHH]    Script Date: 12/4/2020 00:20:28 ******/
CREATE DATABASE [EvaluacionesRRHH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EvaluacionesRRHH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EvaluacionesRRHH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EvaluacionesRRHH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EvaluacionesRRHH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EvaluacionesRRHH] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EvaluacionesRRHH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EvaluacionesRRHH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET ARITHABORT OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EvaluacionesRRHH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EvaluacionesRRHH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EvaluacionesRRHH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EvaluacionesRRHH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EvaluacionesRRHH] SET  MULTI_USER 
GO
ALTER DATABASE [EvaluacionesRRHH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EvaluacionesRRHH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EvaluacionesRRHH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EvaluacionesRRHH] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EvaluacionesRRHH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EvaluacionesRRHH] SET QUERY_STORE = OFF
GO
USE [EvaluacionesRRHH]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelPregunta]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelPregunta](
	[ID_Nivel] [int] IDENTITY(1,1) NOT NULL,
	[Nivel] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_NivelPregunta] PRIMARY KEY CLUSTERED 
(
	[ID_Nivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pregunta](
	[ID_Pregunta] [int] IDENTITY(1,1) NOT NULL,
	[Pregunta] [nvarchar](max) NOT NULL,
	[Imagen] [nvarchar](100) NULL,
	[ID_Nivel] [int] NOT NULL,
	[Activo] [bit] NULL,
	[ID_TipoPregunta] [int] NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[ID_Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaCategoria]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaCategoria](
	[ID_Pregunta] [int] NOT NULL,
	[ID_Categoria] [int] NOT NULL,
 CONSTRAINT [PK_PreguntaCategoria] PRIMARY KEY CLUSTERED 
(
	[ID_Pregunta] ASC,
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[ID_Respuesta] [int] IDENTITY(1,1) NOT NULL,
	[Respuesta] [nchar](10) NOT NULL,
	[Orden] [tinyint] NULL,
	[Correcta] [bit] NULL,
	[ID_Pregunta] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED 
(
	[ID_Respuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPregunta]    Script Date: 12/4/2020 00:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPregunta](
	[ID_TipoPregunta] [int] IDENTITY(1,1) NOT NULL,
	[TipoPregunta] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoPregunta] PRIMARY KEY CLUSTERED 
(
	[ID_TipoPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Pregunta_NivelPregunta] FOREIGN KEY([ID_Nivel])
REFERENCES [dbo].[NivelPregunta] ([ID_Nivel])
GO
ALTER TABLE [dbo].[Pregunta] CHECK CONSTRAINT [FK_Pregunta_NivelPregunta]
GO
ALTER TABLE [dbo].[Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Pregunta_TipoPregunta] FOREIGN KEY([ID_TipoPregunta])
REFERENCES [dbo].[TipoPregunta] ([ID_TipoPregunta])
GO
ALTER TABLE [dbo].[Pregunta] CHECK CONSTRAINT [FK_Pregunta_TipoPregunta]
GO
ALTER TABLE [dbo].[PreguntaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaCategoria_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categoria] ([ID_Categoria])
GO
ALTER TABLE [dbo].[PreguntaCategoria] CHECK CONSTRAINT [FK_PreguntaCategoria_Categoria]
GO
ALTER TABLE [dbo].[PreguntaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaCategoria_Pregunta] FOREIGN KEY([ID_Pregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[PreguntaCategoria] CHECK CONSTRAINT [FK_PreguntaCategoria_Pregunta]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Pregunta] FOREIGN KEY([ID_Pregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Pregunta]
GO
USE [master]
GO
ALTER DATABASE [EvaluacionesRRHH] SET  READ_WRITE 
GO
