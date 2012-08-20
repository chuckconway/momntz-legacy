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
	Select M.Username, Name, M.Url
	From TagPersonView P
	Inner Join [User] U
		On P.Username = U.Username And U.UserStatus = 2
	Inner Join (
		 Select Url, R.Username
		 From MomentoMedia M
			Inner Join
			(		Select Username, Max(ID) as Id
		 From MomentoMedia 
		 Where MediaType = 'MediumImage'
		 Group By Username) R
			ON M.Id = R.Id

	) M
		On P.CreatedBy = M.Username		
	Where U.CreatedBy = @Username
END