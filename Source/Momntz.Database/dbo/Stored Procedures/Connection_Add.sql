-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Connection_Add]
	-- Add the parameters for the stored procedure here
(
	@MomentoId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Declare @Connections Table (Username Nvarchar(100), Owner Nvarchar(100))

	Insert Into @Connections(Username, Owner)
	Select Username, CreatedBy as Owner
					From TagMomento TM
					Inner Join TagPerson TP
						On TM.TagId = TP.TagId
					Where TM.MomentoId = 2 
					--AND Username Not in (Select C.Username From Connection C Where C.Username = TP.Username AND C.Owner = TP.CreatedBy) 

	Insert Into @Connections(Username, Owner)	
	Select C1.Username, C2.[Username] as [Owner]
	From @Connections C1
	Inner Join @Connections C2
		ON C1.Username <> C2.Username
	Where C1.Username Not in (Select C.Username From Connection C Where C.Username = C1.Username AND C.Owner = C2.Username) 


Insert Into Connection(Username, Owner)
Select C.Username, C.Owner
From @Connections C
Where Username Not In (Select Username From Connection CN WHERE CN.Owner = C.Owner AND CN.Username = C.Username)
AND Owner Not In (Select Owner From Connection CN WHERE CN.Owner = C.Owner AND CN.Username = C.Username)

END