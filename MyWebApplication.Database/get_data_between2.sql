USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[get_data_between2]    Script Date: 8/11/2022 5:46:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_data_between2]     
 @month1 int,
 @month2 int
AS  
 SET NOCOUNT ON  
 

DECLARE @currentDb MyDataType;
DECLARE @m int = @month1;
while @m <= @month2 begin
	insert @currentDb  exec create_data_tvp @month_id=@m
	set @m = @m + 1;
end


select * from @currentDb
GO

