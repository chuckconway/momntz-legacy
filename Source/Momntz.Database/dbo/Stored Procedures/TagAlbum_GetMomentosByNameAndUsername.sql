-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagAlbum_GetMomentosByNameAndUsername]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100),
	@Name nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
Select R.Title, R.Story, R.Day, R.Month, R.Year, R.Location, R.Added, R.AddedUsername, R.DisplayName, R.Id, R.Username
From
	(Select D.Title, D.Story, D.Day, D.Month, D.Year, D.Location, D.Added, D.AddedUsername, D.DisplayName, D.Id, D.Username, A.TagId
	From MomentoDetail D
	Inner Join TagAlbumView A
		On D.Id = A.MomentoId) R
Inner Join Tag T
		ON R.TagId = T.Id
	Where T.Username = @Username AND T.Name = @Name	

END