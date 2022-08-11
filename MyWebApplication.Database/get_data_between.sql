USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[get_data_between]    Script Date: 8/11/2022 5:46:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_data_between]     
 @month1 int,
 @month2 int
AS  
 SET NOCOUNT ON  
 DECLARE @result1 MyDataType;
 insert @result1 exec create_data_tvp @month_id=@month1

 DECLARE @result2 MyDataType;
 insert @result2 exec create_data_tvp @month_id=@month2
   
 select * from @result1 union all select * from @result2
 
GO

