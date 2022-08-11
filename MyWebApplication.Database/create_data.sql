USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[create_data]    Script Date: 8/11/2022 5:45:26 PM ******/
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
	@name sysname,
	@month_id int
AS
	SET NOCOUNT ON  
	IF NOT EXISTS ( SELECT  *  
                FROM    sys.schemas  
                WHERE   name = N'myschema' )  
		EXEC('CREATE SCHEMA [myschema]');  
	DECLARE @sql NVARCHAR(MAX) = 'SELECT * INTO [myschema].' + @name + ' FROM [dbo].External_Source WHERE month_id = ' + CAST(@month_id as varchar(10))  
	EXEC sp_executesql @sql  

	INSERT Data(Name, Description, IsPublished, CreatedDate) VALUES (@name, @name, 0, CURRENT_TIMESTAMP)   
	SELECT * FROM Data WHERE Name=@name 
	
GO

