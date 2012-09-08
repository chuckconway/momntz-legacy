-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_GetConnectionsByUsername]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Select M.Username, Name, M.Url
	--From TagPersonView P
	--Inner Join [User] U
	--	On P.Username = U.Username And U.UserStatus = 2
	--Inner Join (
	--	 Select Url, R.Username
	--	 From MomentoMedia M
	--		Inner Join
	--		(		Select Username, Max(ID) as Id
	--	 From MomentoMedia 
	--	 Where MediaType = 'MediumImage'
	--	 Group By Username) R
	--		ON M.Id = R.Id

	--) M
	--	On P.CreatedBy = M.Username		
	--Where U.CreatedBy = @Username

    Declare @MomentosByUser Table (Id int, Username Nvarchar(100))
	
	Insert Into @MomentosByUser(Id, Username)
	Select TOP 1 Id, Username From Momento M
	Where M.Username = @Username

	Insert Into @MomentosByUser(Username, Id)
	Select Distinct Username, MomentoId as Id 
	From TagPerson P
	Inner Join TagMomento M
		On P.TagId = M.TagId
	Where Username Not In (Select Username From @MomentosByUser)

    Select Url, C.Username, C.FullName as Name
	From MomentoMedia M
			Inner Join
			(Select Username, Max(ID) as Id
		 From MomentoMedia 
		 Where MediaType = 'MediumImage'
		 Group By Username) R
			ON M.Id = R.Id
         Inner Join @MomentosByUser MU
			ON MU.Id = M.MomentoId
	Inner Join ConnectionView C
		On MU.Username = C.[Owner]
	Where C.[Owner] = @Username


	--Select C.Username, C.FullName as Name, M.Url
	--From ConnectionView C
	--Inner Join [User] U
	--	On C.Username = U.Username And U.UserStatus = 2
	--Inner Join (
	--	 Select Url, R.Username, M.MomentoId
	--	 From MomentoMedia M
	--		Inner Join
	--		(Select Username, Max(ID) as Id
	--	 From MomentoMedia 
	--	 Where MediaType = 'MediumImage'
	--	 Group By Username) R
	--		ON M.Id = R.Id
 --        Inner Join @MomentosByUser MU
	--		ON MU.Id = M.MomentoId
	--) M
	--	On C.[Owner] = M.Username		
	--Where C.[Owner] = @Username


	--Select * From Connection C
	--Where C.[Owner] = @Username

END