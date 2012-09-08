-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Connection_Add]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100),
	@MomentoId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @Owner nvarchar(100)
	SET @Owner = (Select Username From Momento Where Id = @MomentoId)

	Insert Into Connection(Username, [Owner])
	Select p.Username, @Username AS [Owner]
	From TagMomento M
	Inner Join TagPerson P
		On M.TagId = P.TagId	
	Where Username <> @Username AND Username Not In (Select Username From Connection C WHere C.[Owner] =  @Username)	

END