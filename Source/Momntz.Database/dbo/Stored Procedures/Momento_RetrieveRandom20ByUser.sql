-- =============================================
-- Author: Chucksoft CodeGen
-- Create date: Friday, October 30, 2009
-- =============================================
CREATE PROCEDURE  [dbo].[Momento_RetrieveRandom20ByUser]
(
	@Username nvarchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select Top(40) *
	From dbo.MomentoUserView
	Where Username = @Username
	Order by CreateDate desc

END