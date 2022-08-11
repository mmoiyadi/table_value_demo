USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[create_data_tvp]    Script Date: 8/11/2022 5:45:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[create_data_tvp] 
	@month_id int
as
	SET NOCOUNT ON  
   
 DECLARE @tvp  MyDataType  

 INSERT INTO @tvp SELECT * FROM [dbo].External_Source WHERE month_id = @month_id  
 --return @tvp
 SELECT * FROM @tvp
GO

