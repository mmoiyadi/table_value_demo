USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[create_data]    Script Date: 7/27/2022 5:22:34 PM ******/
DROP PROCEDURE [dbo].[create_data]
GO

/****** Object:  StoredProcedure [dbo].[create_data]    Script Date: 7/27/2022 5:22:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_data] 
	@name sysname
as
	set nocount on
	Insert Data(Name, Description, IsPublished, CreatedDate) values (@name, @name,1, CURRENT_TIMESTAMP) 
	select * from Data where Name=@name
	
GO

