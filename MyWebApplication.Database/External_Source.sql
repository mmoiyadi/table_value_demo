USE [mydatabase]
GO

/****** Object:  Table [dbo].[External_Source]    Script Date: 8/11/2022 5:47:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[External_Source](
	[col_int1] [int] NULL,
	[col_int2] [int] NULL,
	[col_int3] [int] NULL,
	[col_str1] [nvarchar](50) NULL,
	[col_str2] [nvarchar](50) NULL,
	[col_str3] [nvarchar](50) NULL,
	[col_date1] [datetime] NULL,
	[col_date2] [datetime] NULL,
	[col_date3] [datetime] NULL,
	[month_id] [int] NULL
) ON [PRIMARY]
GO

