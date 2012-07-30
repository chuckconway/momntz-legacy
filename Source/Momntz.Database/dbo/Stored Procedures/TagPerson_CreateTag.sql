-- Batch submitted through debugger: SQLQuery13.sql|7|0|C:\Users\Chuck\AppData\Local\Temp\~vs878.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagPerson_CreateTag]
(	-- Add the parameters for the stored procedure here
	@NewUsername nvarchar(100),
	@FullName nvarchar(100),
	@Height int,
	@Width int,
	@CreatedBy nvarchar(100),
	@Username nvarchar(100),
	@XAxis int,
	@YAxis int,
	@MomentoId int,
	@InternalId uniqueidentifier
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF Exists(Select id From TagPersonView T Where T.Name = @FullName AND T.Username = @Username AND T.MomentoId = @MomentoId)
			BEGIN
			Declare @TagPersonId int
			Set @TagPersonId = (Select TagPersonId From TagPersonView T Where T.Name = @FullName AND T.Username = @Username AND T.MomentoId = @MomentoId)
			UPDATE TagPerson
			Set	Width = @Width,
				Height = @Height,
				XAxis = @XAxis,
				YAxis = @YAxis
			Where TagPerson.Id = @TagPersonId				
		END
	ELSE
		Begin
			Insert Into Tag(Name, Kind, Username)Values(@FullName, 0, @Username)
			Declare @TagId int
			Set @TagId = SCOPE_IDENTITY()

			Insert Into TagMomento(MomentoId, TagId)Values(@MomentoId, @TagId)

			Declare @FindOrCreateUsername nvarchar(100)
			Set @FindOrCreateUsername = dbo.GetUsernameFromFullName(@FullName, @Username, @NewUsername)

			IF NOT EXISTS(Select Username From [User] U Where u.Username =  @FindOrCreateUsername)
			BEGIN
				Insert Into [User](Username, UserStatus, CreatedBy)VALUES(@FindOrCreateUsername, 2, @Username)
				INSERT INTO AlsoKnownAs(Fullname, Username, IsDefault)VALUES(@FullName, @FindOrCreateUsername, 1)
			END
			Insert Into TagPerson(CreatedBy, TagId, Width, Height, XAxis, YAxis, InternalId, Username)Values(@CreatedBy, @TagId, @Width, @Height, @XAxis, @YAxis, @InternalId, @FindOrCreateUsername)
		End

END