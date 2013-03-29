-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[TagAlbum_GetAlbumByUsernameScroll]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100),
	@CreateDate DateTime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

Select Top(40) T.Username, T.Name, D.Url, T.CreateDate
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
	Where T.Username = @Username AND T.CreateDate < @CreateDate
	order by T.CreateDate desc
END