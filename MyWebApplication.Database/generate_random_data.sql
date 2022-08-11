USE [mydatabase]
GO

/****** Object:  StoredProcedure [dbo].[generate_random_data]    Script Date: 8/11/2022 5:45:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[generate_random_data] 
	@count INT
AS
	set nocount on
	
	truncate table External_Source
	Declare @Id int
	Set @Id = 1

	While @Id <= @count
	Begin 
		DECLARE @int1 INT
		DECLARE @int2 INT
		DECLARE @int3 INT
		DECLARE @month_id INT
		DECLARE @date1 Datetime
		DECLARE @date2 Datetime
		DECLARE @date3 Datetime
		SET @date1 = GETDATE() + (365 * 2 * RAND() - 365)
		SET @date2 = GETDATE() + (365 * 2 * RAND() - 365)
		SET @date3 = GETDATE() + (365 * 2 * RAND() - 365)
		SELECT @int1 = CAST(RAND() * 5 + 3 as INT)
		SELECT @int2 = CAST(RAND() * 5 + 3 as INT)
		SELECT @int3 = CAST(RAND() * 5 + 3 as INT)
		SELECT @month_id = CAST(RAND() * 5 + 3 as INT)
		Insert Into External_Source values (@int1, 
											@int2, 
											@int3, 
											'str1_'+CAST(@Id as nvarchar(10)),
											'str2_'+CAST(@Id as nvarchar(10)),
											'str3_'+CAST(@Id as nvarchar(10)), 
											@date1,
											@date2,
											@date3,
											@month_id)
	   Set @Id = @Id + 1
	End


	
	
GO

