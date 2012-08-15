-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagAlbum_Remove]
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

	Begin Transaction

	Declare @AlbumId int
	Set @AlbumId = (Select T.Id From Tag T Where T.Name = @Tag AND T.Username = @Username AND Kind = 3)

	IF @AlbumId Is NOT Null AND Exists( Select * From TagAlbumView T Where T.MomentoId = @MomentoId AND T.TagId = @AlbumId)
	BEGIN
		Delete From TagMomento
		Where MomentoId = @MomentoId AND TagId = @AlbumId

		Declare @ItemCount int
		Set @ItemCount = (Select count(*) From TagAlbumView T Where T.MomentoId = @MomentoId AND T.TagId = @AlbumId)

		IF @ItemCount = 0
		BEGIN
			Delete From Tag
			Where Id = @AlbumId 

		END

	END

	commit;
END