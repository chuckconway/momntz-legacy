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

	--Select Username
	--From TagPersonView
	--Group By Username

	Select P.Username, Name, M.Url, U.CreatedBy
	From (
		
		Select V.Username, MomentoId, Name
		From TagPersonView V
		Inner Join (Select Username, Max(Id) as Id
		From TagPersonView
		Group By Username) T
		On T.Id = V.Id
	)P
	Inner Join [User] U
		On P.Username = U.Username And U.UserStatus = 2
	Inner Join (Select * 
	 From MomentoMedia M
		Where M.MediaType = 'MediumImage') M
	  ON M.MomentoId = P.MomentoId

	Where U.CreatedBy = @Username
END