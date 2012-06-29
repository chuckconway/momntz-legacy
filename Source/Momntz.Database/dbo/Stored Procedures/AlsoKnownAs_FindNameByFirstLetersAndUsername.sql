-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AlsoKnownAs_FindNameByFirstLetersAndUsername
(
	@Search nvarchar(50),
	@Username nvarchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select *
	From AlsoKnownAs A
	Where (A.FirstName Like  @Search + '%' OR  A.MiddleName Like @Search + '%' OR A.LastName Like @Search + '%')
		AND A.Username = @Username

END