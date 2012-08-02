-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagPerson_Delete]
(
	@MomentoId int,
	@TagPersonId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @Username nvarchar(100)
	Set @Username  = (Select Username From TagPerson Where Id = @TagPersonId)
	
	Declare @TagId int
	Set @TagId = (Select TagId From TagPerson Where Id = @TagPersonId)

	Delete From TagPerson
	Where Id = @TagPersonId AND (Username = @Username OR CreatedBy = @Username)

	Delete From TagMomento
	Where TagId = @TagId AND MomentoId = @MomentoId

	Declare @TagCount int
	Set @TagCount = (Select count(*) From TagMomento Where TagId = @TagId)


	exec MomentoUser_DeleteByUsernameAndMomentoId @Username, @MomentoId;

	--Delete From 
	--MomentoUser 
	--Where Username = @Username AND MomentoId = @MomentoId

	IF @TagCount = 0
	BEGIN
		Delete From Tag
		Where Id = @TagId
	END

END