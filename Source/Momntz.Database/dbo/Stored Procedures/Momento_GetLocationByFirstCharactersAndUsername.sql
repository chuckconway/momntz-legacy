-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Momento_GetLocationByFirstCharactersAndUsername
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100),
	@Term nvarchar(250)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Select M.Location
	From MomentoDetail M
	Where M.Location Is NOT Null AND M.Location LIKE @Term + '%'

END