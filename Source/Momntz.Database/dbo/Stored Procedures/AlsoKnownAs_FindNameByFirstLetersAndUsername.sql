-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlsoKnownAs_FindNameByFirstLetersAndUsername]
(
	@Search nvarchar(50),
	@Username nvarchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	Select A.FullName, A.AlsoKnownAsId
	From UserAliasView A
	Where A.FullName LIKE @Search + '%' AND (A.Username = @Username OR (A.CreatedBy = @Username AND A.UserStatus = 2))

END