USE [MyTurn]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dayId] [int] NULL,
	[hour] [time](7) NULL,
	[userId] [int] NULL,
	[getServiceDate] [datetime] NULL,
	[DurationService] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 04/06/2020 13:06:46 ******/
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
/****** Object:  Table [dbo].[Business]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategory] [int] NULL,
	[name] [nvarchar](50) NULL,
	[phoneNumber] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancelations]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancelations](
	[branchId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 04/06/2020 13:06:46 ******/
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
/****** Object:  Table [dbo].[Days]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shiftId] [int] NULL,
	[Day] [nvarchar](10) NULL,
	[openTime] [time](7) NULL,
	[ClosedTime] [time](7) NULL,
	[avgServiceTime] [float] NULL,
	[zGrade] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategory] [int] NULL,
	[name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBranch] [int] NULL,
	[idService] [int] NULL,
	[MinTimeToCancel] [float] NULL,
	[PaymentforCancel] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/06/2020 13:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NULL,
	[email] [varchar](20) NULL,
	[phoneNumber] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([dayId])
REFERENCES [dbo].[Days] ([id])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD FOREIGN KEY([idBusiness])
REFERENCES [dbo].[Business] ([id])
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Cancelations]  WITH CHECK ADD FOREIGN KEY([branchId])
REFERENCES [dbo].[Branches] ([id])
GO
ALTER TABLE [dbo].[Days]  WITH CHECK ADD FOREIGN KEY([shiftId])
REFERENCES [dbo].[Shifts] ([id])
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD FOREIGN KEY([idBranch])
REFERENCES [dbo].[Branches] ([id])
GO
ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD FOREIGN KEY([idService])
REFERENCES [dbo].[Services] ([id])
GO
