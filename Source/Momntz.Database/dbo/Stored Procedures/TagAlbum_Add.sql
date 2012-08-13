-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagAlbum_Add]
	-- Add the parameters for the stored procedure here
(
	@Tag nvarchar(50),
	@MomentoId int,
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


	Declare @AlbumId int
	Set @AlbumId = null

	If Exists (Select T.Id From Tag T Where T.Name = @Tag AND T.Kind = 3 AND T.Username = @Username)
	BEGIN
		Set @AlbumId = (Select T.Id From Tag T Where T.Name = @Tag AND T.Kind = 3 AND T.Username = @Username)

		Declare @TagCount int

		SET @TagCount = (Select Count(*)
		FROM TagAlbum T
		Where T.MomentoId = @MomentoId
			AND T.TagId = @AlbumId)

		IF @TagCount = 0
			BEGIN
				Insert Into TagAlbum(MomentoId, TagId)Values(@MomentoId, @AlbumId)
				Insert Into TagMomento(MomentoId, TagId)Values(@MomentoId, @AlbumId)
			END
	END
	Else
		BEGIN
			Insert Into Tag (Name, Kind, Username) Values(@Tag, 3, @Username)
			Set @AlbumId = SCOPE_IDENTITY()

			Insert Into TagAlbum(MomentoId, TagId)Values(@MomentoId, @AlbumId)
			Insert Into TagMomento(MomentoId, TagId)Values(@MomentoId, @AlbumId)
		END
END