-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE MomentoUser_DeleteByUsernameAndMomentoId
	-- Add the parameters for the stored procedure here
	@Username nvarchar(100),
	@MomentoId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Begin Transaction

    -- Insert statements for procedure here
	Declare @Id int
	
	IF Exists (Select * From MomentoUser Where Username = @Username AND MomentoId = @MomentoId)
	BEGIN
		
		Set @Id = (Select top 1 Id From MomentoUser Where Username = @Username AND MomentoId = @MomentoId)
		Delete From MomentoUser
		Where Id = @id
	END

	Commit
END