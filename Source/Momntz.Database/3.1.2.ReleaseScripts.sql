/****** Object:  StoredProcedure [dbo].[User_Create]    Script Date: 4/15/2013 10:12:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER Procedure [dbo].[User_Create]
(
	@Username nvarchar(100),
	@CreatedBy nvarchar(100),
	@Email nvarchar(250),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Password nvarchar(250)

)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @Id int
	
    -- Insert statements for procedure here
	Insert Into [User](Email, Username, UserStatus, Password, CreatedBy) VALUES(@Email, @Username, 1, @Password, @CreatedBy)
	Insert into AlsoKnownAs(FullName, FirstName, LastName, Username, IsDefault)Values(@FirstName + ' ' + @LastName, @FirstName, @LastName, @Username, 1)
END



GO
/****** Object:  StoredProcedure [dbo].[User_GetConnectionsByUsername]    Script Date: 6/17/2013 10:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery21.sql|7|0|C:\Users\Chuck\AppData\Local\Temp\~vs3EE8.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[User_GetConnectionsByUsername]
	-- Add the parameters for the stored procedure here
(
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @MomentosByUser Table (Id int, Username Nvarchar(100))
	
	Insert Into @MomentosByUser(Id, Username)
	Select Max(M.Id) as ID, C.Username
	From Connection C
	Inner Join Person P
		On C.Username = P.Username
	Inner Join Momento M
		ON C.Id = p.MomentoId
	Where C.Owner = @Username
	Group By C.Username

	Select M.MomentoId as Id, C.Username, C.FullName as Name, M.Url
		 From MomentoMedia M 
		 Inner Join  (Select Max(MM.Id) as Id, MU.Username 
				      From MomentoMedia MM
					  Inner Join  @MomentosByUser MU
					  ON mm.MomentoId = MU.Id AND MM.MediaType ='MediumImage' 
					  Group by mu.Username
					)R
		 ON R.Id = M.Id
		Inner Join ConnectionView C		 
		On R.Username = C.Username
		 Where C.[Owner] = @Username
END

/****** Object:  View [dbo].[UserAliasView]    Script Date: 6/20/2013 11:41:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[UserAliasView]
AS
SELECT        dbo.AlsoKnownAs.IsDefault, dbo.AlsoKnownAs.FullName, dbo.[User].Username, dbo.[User].Email, dbo.[User].UserStatus, dbo.[User].Password, 
                         dbo.[User].CreatedBy, dbo.AlsoKnownAs.Id AS AlsoKnownAsId
FROM            dbo.AlsoKnownAs INNER JOIN
                         dbo.[User] ON dbo.AlsoKnownAs.Username = dbo.[User].Username AND dbo.AlsoKnownAs.IsDefault = 1

GO

Delete Configuration
Where Name = 'Database.Queue'

Delete Configuration
Where Environment = 'DEV'

IF Not Exists(Select Id From Configuration Where Name = 'ServiceBus.Queue' AND Environment = 'Local')
BEGIN
	Insert Into Configuration(Name, Value, Environment)Values('ServiceBus.Queue', 'Endpoint=sb://momntzdev.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=TU9SBGWvdxeO6THM8uQrxA9fmJEhTlLHha80rTkNj7Y=', 'LOCAL')
END

IF Not Exists(Select Id From Configuration Where Name = 'ServiceBus.Queue' AND Environment = 'QA')
BEGIN
	Insert Into Configuration(Name, Value, Environment)Values('ServiceBus.Queue', 'Endpoint=sb://momntzqa.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=IbgyP8beHL15QtPGUN3KKFsogMUozdeX7603EF7xd40=', 'QA')
END

IF Not Exists(Select Id From Configuration Where Name = 'ServiceBus.Queue' AND Environment = 'PROD')
BEGIN
	Insert Into Configuration(Name, Value, Environment)Values('ServiceBus.Queue', 'Endpoint=sb://momntz.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=6d1C5tpI4JRCUqWZ1QxIx+4+M1uYZZgZiR2lYL2ieXw=', 'PROD')
END


