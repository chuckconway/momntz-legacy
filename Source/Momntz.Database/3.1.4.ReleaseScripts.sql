GO
/****** Object:  StoredProcedure [dbo].[User_GetConnectionsByUsername]    Script Date: 8/23/2013 3:45:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery21.sql|7|0|C:\Users\Chuck\AppData\Local\Temp\~vs3EE8.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[User_GetConnectionsByUsername]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @MomentosByUser Table (Id int, Username Nvarchar(100))
	
	Insert Into @MomentosByUser(Id, Username)
	Select Max(M.Id), C.Username
	From Connection C
	Inner Join MomentoUser MU
		On C.Username = MU.Username
	Inner Join Momento M
		On MU.MomentoId = M.Id
	Where C.Owner = @Username
	Group By C.Username

	Select M.MomentoId as Id, C.Username, C.FullName as Name, M.Url
		 From MomentoMedia M 
		 Inner Join  (Select Max(MM.Id) as Id, MU.Username 
				      From MomentoMedia MM
					  Inner Join  @MomentosByUser MU
					  ON mm.MomentoId = MU.Id AND MM.MediaType ='MediumImage' 
					  Group by mu.Username
					)R
		 ON R.Id = M.Id
		Inner Join ConnectionView C		 
		On R.Username = C.Username
		 Where C.[Owner] = @Username
END