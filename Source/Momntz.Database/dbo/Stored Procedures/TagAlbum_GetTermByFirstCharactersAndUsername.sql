-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE TagAlbum_GetTermByFirstCharactersAndUsername
	-- Add the parameters for the stored procedure here
(
	@Term nvarchar(50),
	@Username nvarchar(100)	
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Name
	From TagAlbumView T
	Where T.Name LiKe @Term + '%'
		AND T.Username = @Username
END