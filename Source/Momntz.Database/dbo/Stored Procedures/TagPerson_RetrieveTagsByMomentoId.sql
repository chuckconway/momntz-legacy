-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TagPerson_RetrieveTagsByMomentoId]
	-- Add the parameters for the stored procedure here
(
	@MomentoId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	--USE TAGPERSON VIEW HERE

    -- Insert statements for procedure here
	Select TP.Id as TagId, MomentoId, TP.Id, CreatedBy, Width, Height, XAxis, YAxis, A.Username, A.FullName As DisplayName
	From TagMomento TM
	Inner Join TagPerson TP
		ON TM.TagId = TP.TagId
	Inner Join AlsoKnownAs A
		On TP.Username = A.Username AND A.IsDefault = 1
	Where TM.MomentoId = @MomentoId
END