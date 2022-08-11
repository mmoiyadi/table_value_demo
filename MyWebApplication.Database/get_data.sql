USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[get_data]    Script Date: 8/11/2022 5:46:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_data]     
 @id int  
AS  
 SET NOCOUNT ON  
   
 DECLARE @name AS nvarchar(50)
 SET @name = (SELECT name from Data where id=@id)
 --INSERT INTO @tvp SELECT * FROM [dbo].External_Source WHERE month_id = @month_id  
 
   DECLARE @query nvarchar(max)
 select @query = 'select * FROM [myschema].[' + @name + ']'
 EXECUTE sp_executesql @query
GO

