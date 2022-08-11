USE [mydatabase]
GO

/****** Object:  Table [dbo].[Data]    Script Date: 8/11/2022 5:47:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Data](
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IsPublished] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO

