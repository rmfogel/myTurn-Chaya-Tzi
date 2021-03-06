USE [master]
GO
/****** Object:  Database [MyTurn]    Script Date: 08/12/2020 14:40:15 ******/
CREATE DATABASE [MyTurn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyTurn', FILENAME = N'C:\Users\This_User\MyTurn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyTurn_log', FILENAME = N'C:\Users\This_User\MyTurn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MyTurn] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyTurn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyTurn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyTurn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyTurn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyTurn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyTurn] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyTurn] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyTurn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyTurn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyTurn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyTurn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyTurn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyTurn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyTurn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyTurn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyTurn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyTurn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyTurn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyTurn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyTurn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyTurn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyTurn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyTurn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyTurn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyTurn] SET  MULTI_USER 
GO
ALTER DATABASE [MyTurn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyTurn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyTurn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyTurn] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyTurn] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyTurn] SET QUERY_STORE = OFF
GO
USE [MyTurn]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MyTurn]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BranchDayId] [int] NULL,
	[dateTimeTurn] [datetime] NULL,
	[userId] [int] NULL,
	[getServiceDate] [datetime] NULL,
	[DurationService] [int] NULL,
	[RouteId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Branches]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBusiness] [int] NULL,
	[adress] [nvarchar](50) NULL,
	[phoneNumber] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Business]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategory] [int] NULL,
	[name] [nvarchar](50) NULL,
	[phoneNumber] [nvarchar](10) NULL,
	[email] [nchar](200) NULL,
	[passward] [nvarchar](50) NULL,
	[image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cancelations]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancelations](
	[id] [int] NOT NULL,
	[appointmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Routes]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[RouteId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[StartPoint] [nvarchar](100) NOT NULL,
	[EndPoint] [nvarchar](100) NULL,
	[WalkingBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RouteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[businessId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShiftDayDetails]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftDayDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shiftId] [int] NULL,
	[DayOfWeek] [int] NULL,
	[openTime] [time](7) NULL,
	[ClosedTime] [time](7) NULL,
	[avgServiceTime] [float] NULL,
	[zGrade] [float] NULL,
	[waitingTimeAvg] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBranch] [int] NULL,
	[idService] [int] NULL,
	[MinTimeToCancel] [int] NULL,
	[PaymentforCancel] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/12/2020 14:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](10) NULL,
	[lastName] [nvarchar](10) NULL,
	[email] [varchar](20) NULL,
	[phoneNumber] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([id], [BranchDayId], [dateTimeTurn], [userId], [getServiceDate], [DurationService], [RouteId]) VALUES (2033, 2, CAST(N'2020-12-02T12:00:00.000' AS DateTime), 1, CAST(N'2020-12-02T12:00:00.000' AS DateTime), 0, 1015)
INSERT [dbo].[Appointments] ([id], [BranchDayId], [dateTimeTurn], [userId], [getServiceDate], [DurationService], [RouteId]) VALUES (2036, 3, CAST(N'2020-12-02T13:35:00.000' AS DateTime), 1, CAST(N'2020-12-02T13:35:00.000' AS DateTime), 0, 1017)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (1, 1, N'רבי עקיבא 30 בני ברק', N'111')
INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (2, 2, N'רבי עקיבא 50 בני ברק', N'444')
INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (3, 1, N'רחוב ירושלים נתיבות', N'222')
INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (4, 3, N'רבי יהודה הנשיא 12 מודיעין עילית', N'222')
INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (5, 1, N'ירושלים רמת גן', NULL)
INSERT [dbo].[Branches] ([id], [idBusiness], [adress], [phoneNumber]) VALUES (6, 1, N'מרכז עסקים עילית מודיעין עילית', NULL)
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[Business] ON 

INSERT [dbo].[Business] ([id], [idCategory], [name], [phoneNumber], [email], [passward], [image]) VALUES (1, 2, N'דואר ישראל', N'''12', N'12                                                                                                                                                                                                      ', N'12', N'https://upload.wikimedia.org/wikipedia/he/thumb/1/14/Israel_Post.svg/langhe-375px-Israel_Post.svg.png')
INSERT [dbo].[Business] ([id], [idCategory], [name], [phoneNumber], [email], [passward], [image]) VALUES (2, 1, N'נעלי העיר', N'222', N'222                                                                                                                                                                                                     ', N'222', NULL)
INSERT [dbo].[Business] ([id], [idCategory], [name], [phoneNumber], [email], [passward], [image]) VALUES (3, 3, N'בנק ירושלים', N'333', N'333                                                                                                                                                                                                     ', N'333', N'https://upload.wikimedia.org/wikipedia/he/a/a8/%D7%91%D7%A0%D7%A7_%D7%99%D7%A8%D7%95%D7%A9%D7%9C%D7%99%D7%9D.png')
INSERT [dbo].[Business] ([id], [idCategory], [name], [phoneNumber], [email], [passward], [image]) VALUES (4, 3, N'בנק לאומי', NULL, NULL, NULL, N'https://www.ergo.co.il/wp-content/uploads/2018/03/%D7%91%D7%A0%D7%A7-%D7%9C%D7%90%D7%95%D7%9E%D7%99-%D7%9C%D7%95%D7%92%D7%95-%D7%90%D7%A0%D7%92%D7%9C%D7%99%D7%AA.png')
INSERT [dbo].[Business] ([id], [idCategory], [name], [phoneNumber], [email], [passward], [image]) VALUES (5, 3, N'בנק הפועלים', NULL, NULL, NULL, N'https://customer-service.xyz/wp-content/uploads/2020/01/%D7%91%D7%A0%D7%A7-%D7%94%D7%A4%D7%95%D7%A2%D7%9C%D7%99%D7%9D-%D7%9C%D7%95%D7%92%D7%95.jpg')
SET IDENTITY_INSERT [dbo].[Business] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name]) VALUES (1, N'הנעלה')
INSERT [dbo].[Categories] ([id], [name]) VALUES (2, N'חבילות')
INSERT [dbo].[Categories] ([id], [name]) VALUES (3, N'משכנתא')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Routes] ON 

INSERT [dbo].[Routes] ([RouteId], [UserId], [Date], [StartTime], [EndTime], [StartPoint], [EndPoint], [WalkingBy]) VALUES (1015, 1, CAST(N'2020-12-02' AS Date), CAST(N'11:55:00' AS Time), CAST(N'12:37:00' AS Time), N'בני ברק, ישראל', N'מודיעין מכבים רעות, ישראל', 1)
INSERT [dbo].[Routes] ([RouteId], [UserId], [Date], [StartTime], [EndTime], [StartPoint], [EndPoint], [WalkingBy]) VALUES (1017, 1, CAST(N'2020-12-02' AS Date), CAST(N'12:25:00' AS Time), CAST(N'14:36:00' AS Time), N'בני ברק, ישראל', N'מודיעין מכבים רעות, ישראל', 1)
SET IDENTITY_INSERT [dbo].[Routes] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([id], [name], [businessId]) VALUES (1, N'אשנב כל', 1)
INSERT [dbo].[Services] ([id], [name], [businessId]) VALUES (2, N'מדרסים', 2)
INSERT [dbo].[Services] ([id], [name], [businessId]) VALUES (3, N'פתיחת חשבון', 3)
INSERT [dbo].[Services] ([id], [name], [businessId]) VALUES (4, N'בקשת הלוואה', 3)
INSERT [dbo].[Services] ([id], [name], [businessId]) VALUES (5, N'איסוף חבילה', 1)
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[ShiftDayDetails] ON 

INSERT [dbo].[ShiftDayDetails] ([id], [shiftId], [DayOfWeek], [openTime], [ClosedTime], [avgServiceTime], [zGrade], [waitingTimeAvg]) VALUES (1, 1, 3, CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 120, 2, 10)
INSERT [dbo].[ShiftDayDetails] ([id], [shiftId], [DayOfWeek], [openTime], [ClosedTime], [avgServiceTime], [zGrade], [waitingTimeAvg]) VALUES (2, 2, 3, CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 30, 8, 15)
INSERT [dbo].[ShiftDayDetails] ([id], [shiftId], [DayOfWeek], [openTime], [ClosedTime], [avgServiceTime], [zGrade], [waitingTimeAvg]) VALUES (3, 3, 3, CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5, 1, 15)
INSERT [dbo].[ShiftDayDetails] ([id], [shiftId], [DayOfWeek], [openTime], [ClosedTime], [avgServiceTime], [zGrade], [waitingTimeAvg]) VALUES (4, 4, 3, CAST(N'06:00:00' AS Time), CAST(N'12:00:00' AS Time), 5, 2, 10)
SET IDENTITY_INSERT [dbo].[ShiftDayDetails] OFF
SET IDENTITY_INSERT [dbo].[Shifts] ON 

INSERT [dbo].[Shifts] ([id], [idBranch], [idService], [MinTimeToCancel], [PaymentforCancel]) VALUES (1, 1, 1, 24, 0.0000)
INSERT [dbo].[Shifts] ([id], [idBranch], [idService], [MinTimeToCancel], [PaymentforCancel]) VALUES (2, 2, 2, 0, 0.0000)
INSERT [dbo].[Shifts] ([id], [idBranch], [idService], [MinTimeToCancel], [PaymentforCancel]) VALUES (3, 3, 1, 24, 0.0000)
INSERT [dbo].[Shifts] ([id], [idBranch], [idService], [MinTimeToCancel], [PaymentforCancel]) VALUES (4, 4, 3, 0, 0.0000)
SET IDENTITY_INSERT [dbo].[Shifts] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [firstName], [lastName], [email], [phoneNumber]) VALUES (1, N'aa', N'ss', N'aa@aa.s', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([BranchDayId])
REFERENCES [dbo].[ShiftDayDetails] ([id])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([RouteId])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD FOREIGN KEY([idBusiness])
REFERENCES [dbo].[Business] ([id])
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Cancelations]  WITH CHECK ADD FOREIGN KEY([appointmentId])
REFERENCES [dbo].[Appointments] ([id])
GO
ALTER TABLE [dbo].[Routes]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([businessId])
REFERENCES [dbo].[Business] ([id])
GO
ALTER TABLE [dbo].[ShiftDayDetails]  WITH CHECK ADD FOREIGN KEY([shiftId])
REFERENCES [dbo].[Shifts] ([id])
GO
ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD FOREIGN KEY([idBranch])
REFERENCES [dbo].[Branches] ([id])
GO
ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD FOREIGN KEY([idService])
REFERENCES [dbo].[Services] ([id])
GO
USE [master]
GO
ALTER DATABASE [MyTurn] SET  READ_WRITE 
GO
