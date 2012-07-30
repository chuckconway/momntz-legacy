-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE TagPerson_Delete
(
	@Username nvarchar(100),
	@MomentoId int,
	@TagPersonId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	Declare @TagId int
	Set @TagId = (Select TagId From TagPerson Where Id = @TagPersonId)

	Delete From TagPerson
	Where Id = @TagPersonId AND (Username = @Username OR CreatedBy = @Username)

	Delete From TagMomento
	Where TagId = @TagId AND MomentoId = @MomentoId

	Declare @TagCount int
	Set @TagCount = (Select count(*) From TagMomento Where TagId = @TagId)

	IF @TagCount = 0
	BEGIN
		Delete From Tag
		Where Id = @TagId
	END

END