USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 04.11.2019 7:40:31 ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibraryDB.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibraryDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibraryDB_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](100) NULL,
	[LName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[AuthorID] [int] NULL,
	[GenreID] [int] NULL,
	[ThemeID] [int] NULL,
	[LocationID] [int] NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Emotions]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emotions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genres]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RGE]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NULL,
	[EmotionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RTE]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RTE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThemeID] [int] NULL,
	[EmotionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Themes]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Themes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](150) NULL,
	[LName] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Login] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[RoleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 04.11.2019 7:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[BookID] [int] NULL,
	[Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (1, N'Joanne', N'Rowling')
INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (2, N'Test', N'Atest')
INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (3, N'rr', N'r3')
INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (4, N'tt', N'er')
INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (5, N'Brian', N'Molko')
INSERT [dbo].[Authors] ([Id], [FName], [LName]) VALUES (6, N'Friedrich ', N'Nietzsche')
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (1, N'Test', 4, 14, 4, 2, N'grshrgerh')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (2, N'Lost in Louvre', 1, 19, 10, 1, N'Fine art book')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (3, N'Who killed a man?', 1, 1, 1, 2, N'One killed another')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (4, N'See my Paris', 1, 16, 12, 1, N'This is not my croissant!')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (5, N'Steven Kings nightmare', 1, 13, 1, 3, N'His creepy fantasies')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (6, N'Where is my mind?', 1, 20, 3, 3, N'fine art book')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (7, N'Indian C# tutorials', 1, 10, 7, 2, N'That pretty accent')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (8, N'Placebo', 5, 3, 1, 3, N'just my favourite band''s name')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (9, N'On the Genealogy of Morality', 6, 20, 4, 6, N'Extra complex concepts for an uneasy lifestyle')
INSERT [dbo].[Books] ([Id], [Name], [AuthorID], [GenreID], [ThemeID], [LocationID], [Description]) VALUES (10, N'Rocket making', 1, 18, 4, 1, N'Build a rocket for you pocket')
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Emotions] ON 

INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (1, N'anger')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (2, N'contempt')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (3, N'disgust')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (4, N'fear')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (6, N'happiness')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (5, N'neutral')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (7, N'sadness')
INSERT [dbo].[Emotions] ([Id], [Name]) VALUES (8, N'surprise')
SET IDENTITY_INSERT [dbo].[Emotions] OFF
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (19, N'Art')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (11, N'Autobiography')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (9, N'Business')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (14, N'Children')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Classic')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (15, N'Comic')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (8, N'Contemporary')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Detective')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (18, N'DIY')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Fantastic')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Fantasy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Foreign')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (13, N'Horror')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (16, N'Journalism')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Novel')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (20, N'Philosophy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (12, N'Psychology')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Russian')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10, N'Science')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (21, N'thriller')
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [Name]) VALUES (1, N'A1')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (2, N'A2')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (3, N'A3')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (4, N'A4')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (5, N'B1')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (6, N'B2')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (7, N'B3')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (8, N'B4')
SET IDENTITY_INSERT [dbo].[Locations] OFF
SET IDENTITY_INSERT [dbo].[RGE] ON 

INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (1, 1, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (2, 1, 1)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (5, 1, 8)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (6, 19, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (7, 2, 6)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (8, 2, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (9, 20, 2)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (10, 13, 3)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (11, 3, 3)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (12, 16, 4)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (13, 21, 4)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (14, 13, 4)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (15, 11, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (16, 3, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (17, 20, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (18, 9, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (19, 8, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (20, 14, 6)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (21, 15, 6)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (22, 4, 6)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (23, 6, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (24, 12, 4)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (25, 8, 5)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (26, 16, 1)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (27, 13, 1)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (28, 19, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (29, 11, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (30, 14, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (31, 18, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (32, 2, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (33, 20, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (34, 12, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (35, 3, 7)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (36, 1, 8)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (37, 18, 8)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (38, 5, 8)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (39, 13, 8)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (40, 8, 3)
INSERT [dbo].[RGE] ([Id], [GenreID], [EmotionID]) VALUES (41, 15, 8)
SET IDENTITY_INSERT [dbo].[RGE] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[RTE] ON 

INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (1, 4, 1)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (2, 1, 1)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (3, 1, 2)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (4, 1, 3)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (5, 1, 4)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (6, 1, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (7, 1, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (8, 1, 7)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (9, 1, 8)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (10, 4, 2)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (11, 4, 3)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (12, 3, 4)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (13, 5, 4)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (14, 5, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (15, 1, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (16, 2, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (17, 8, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (18, 11, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (19, 7, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (20, 4, 5)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (21, 2, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (22, 12, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (23, 3, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (24, 9, 6)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (25, 5, 7)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (26, 3, 7)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (27, 12, 7)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (28, 10, 7)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (29, 11, 8)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (30, 3, 8)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (31, 9, 8)
INSERT [dbo].[RTE] ([Id], [ThemeID], [EmotionID]) VALUES (32, 12, 8)
SET IDENTITY_INSERT [dbo].[RTE] OFF
SET IDENTITY_INSERT [dbo].[Themes] ON 

INSERT [dbo].[Themes] ([Id], [Name]) VALUES (5, N'Animals')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (11, N'Architecture')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (10, N'Design')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (4, N'Education')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (1, N'Entertainment')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (2, N'Family')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (3, N'Home')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (8, N'Languages')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (6, N'Marketing')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (9, N'Photography')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (7, N'Programming')
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (12, N'Traveling')
SET IDENTITY_INSERT [dbo].[Themes] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FName], [LName], [Email], [Login], [Password], [RoleID]) VALUES (1, N'Admin', N'Adam', N'adminadam@gmail.com', N'admin', N'1234', 1)
INSERT [dbo].[Users] ([Id], [FName], [LName], [Email], [Login], [Password], [RoleID]) VALUES (2, N'User', N'Adam', N'useradam@gmail.com', N'user', N'1234', 2)
INSERT [dbo].[Users] ([Id], [FName], [LName], [Email], [Login], [Password], [RoleID]) VALUES (3, N'Test', N'Test', N'adrdd@gmail.com', N'testLogin', N'1234', 1)
INSERT [dbo].[Users] ([Id], [FName], [LName], [Email], [Login], [Password], [RoleID]) VALUES (9, N'Harry', N'Potter', N'harry@gmail.com', N'harry', N'1234', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Wishlists] ON 

INSERT [dbo].[Wishlists] ([Id], [UserID], [BookID], [Date]) VALUES (1, 1, 2, CAST(0x55400B00 AS Date))
INSERT [dbo].[Wishlists] ([Id], [UserID], [BookID], [Date]) VALUES (2, 1, 6, CAST(0x55400B00 AS Date))
INSERT [dbo].[Wishlists] ([Id], [UserID], [BookID], [Date]) VALUES (3, 2, 2, CAST(0x56400B00 AS Date))
INSERT [dbo].[Wishlists] ([Id], [UserID], [BookID], [Date]) VALUES (4, 2, 3, CAST(0x56400B00 AS Date))
INSERT [dbo].[Wishlists] ([Id], [UserID], [BookID], [Date]) VALUES (14, 2, 8, CAST(0x56400B00 AS Date))
SET IDENTITY_INSERT [dbo].[Wishlists] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Emotions__737584F6DFDA46C1]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Emotions] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Genres__737584F6855DF6EB]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Genres] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Location__737584F6837D2B68]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Locations] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Roles__737584F6EB39AECF]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Themes__737584F62FB3DF77]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Themes] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__5E55825BE44273D7]    Script Date: 04.11.2019 7:40:31 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((2)) FOR [RoleID]
GO
ALTER TABLE [dbo].[Wishlists] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([ThemeID])
REFERENCES [dbo].[Themes] ([Id])
GO
ALTER TABLE [dbo].[RGE]  WITH CHECK ADD FOREIGN KEY([EmotionID])
REFERENCES [dbo].[Emotions] ([Id])
GO
ALTER TABLE [dbo].[RGE]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[RTE]  WITH CHECK ADD FOREIGN KEY([EmotionID])
REFERENCES [dbo].[Emotions] ([Id])
GO
ALTER TABLE [dbo].[RTE]  WITH CHECK ADD FOREIGN KEY([ThemeID])
REFERENCES [dbo].[Themes] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
