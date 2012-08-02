-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE User_GetOwnerPasswordByUsername
(
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @Found bit
	Set @Found = 0

	--If user is active and exists
	IF Exists(Select * From [User] Where Username = @Username AND UserStatus = 1)
	Begin
		Select Username, Email, UserStatus, [Password] From [User] Where Username = @Username AND UserStatus = 1
		Set @Found = 1
	End

	--If user is a ghost, use the created by user's password to log into the account
	IF @Found = 0
	BEGIN
		Select U1.Username, U1.Email, U1.UserStatus, U2.[Password] 
		From [User] U1
		Inner Join [User] U2
			On U1.CreatedBy = U2.Username
		Where U1.Username = @Username AND U1.UserStatus = 2
	END

	
END