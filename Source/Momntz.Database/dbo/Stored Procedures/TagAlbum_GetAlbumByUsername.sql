-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagAlbum_GetAlbumByUsername]
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

Select T.Username, T.Name, D.Url
From
	(
		Select MAX(Id) as Id
		From TagAlbumView
		Group By Name
	) R
	Inner Join TagAlbumView T
		ON R.Id = T.Id
	Inner Join MomentoMedia D
		ON T.MomentoId = D.MomentoId AND D.MediaType = 'MediumImage'
	Where T.Username = @Username
END