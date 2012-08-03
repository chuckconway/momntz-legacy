-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE TagAlbum_AddMomento
(
	@MomentoId int,
	@AlbumName nvarchar(100),
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	If Not Exists(Select * From TagAlbumView T Where T.MomentoId = @MomentoId AND T.Name = @AlbumName AND T.Username = @Username)
	Begin
		
		Declare @TagId int
		IF Not Exists(Select * From Tag T Where T.Name = @AlbumName AND T.Username = @Username)
			Begin
				Insert into Tag(Name, Kind, Username)Values(@AlbumName, 3, @Username)
				set @TagId = Scope_Identity()

				Insert Into TagAlbum(MomentoId, TagId)Values(@MomentoId, @TagId)
				Insert Into TagMomento(MomentoId, TagId)Values (@MomentoId, @TagId)
			End	
		Else
			Begin
				SET @TagId = (Select Id From Tag T Where T.Name = @AlbumName AND T.Username = @Username)

				--Assume it's already attached to the Momento in the TagMomento Tag
				Insert Into TagAlbum(MomentoId, TagId)Values(@MomentoId, @TagId)
			END

	End
	
END