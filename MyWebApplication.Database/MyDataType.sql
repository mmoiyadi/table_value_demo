USE [mydatabase]
GO

/****** Object:  UserDefinedTableType [dbo].[MyDataType]    Script Date: 8/11/2022 5:47:51 PM ******/
CREATE TYPE [dbo].[MyDataType] AS TABLE(
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
)
GO

