
CREATE PROCEDURE  [dbo].[Momento_RetrieveTagsByMomentoId]
(
	@MomentoId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select * 
	From Tag T
	inner Join TagMomento TM
		ON T.Id = TM.TagId
	Where  TM.MomentoId = @MomentoId

END