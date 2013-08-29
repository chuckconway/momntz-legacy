GO
/****** Object:  StoredProcedure [dbo].[User_GetConnectionsByUsername]    Script Date: 8/23/2013 3:45:45 PM ******/
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
	Select Max(M.Id), C.Username
	From Connection C
	Inner Join MomentoUser MU
		On C.Username = MU.Username
	Inner Join Momento M
		On MU.MomentoId = M.Id
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


/****** Object:  View [dbo].[ConnectionView]    Script Date: 8/26/2013 9:39:45 PM ******/
DROP VIEW [dbo].[ConnectionView]
GO

/****** Object:  View [dbo].[ConnectionView]    Script Date: 8/26/2013 9:39:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ConnectionView]
AS
SELECT        dbo.AlsoKnownAs.Username, dbo.Connection.Owner, dbo.AlsoKnownAs.FullName, dbo.Connection.Id
FROM            dbo.AlsoKnownAs INNER JOIN
                         dbo.Connection ON dbo.AlsoKnownAs.Username = dbo.Connection.Username AND dbo.AlsoKnownAs.IsDefault = 1

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
	Select Max(M.Id), C.Username
	From Connection C
	Inner Join MomentoUser MU
		On C.Username = MU.Username
	Inner Join Momento M
		On MU.MomentoId = M.Id
	Where C.Owner = @Username
	Group By C.Username

	Select C.Id as Id, C.Username, C.FullName as Name, M.Url
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


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Momento_RetrieveById')
DROP PROCEDURE Momento_RetrieveById
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Momento_RetrieveTagsByMomentoId')
DROP PROCEDURE Momento_RetrieveTagsByMomentoId
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'MomentoMedia_GetByMomentoIdAndMediaType')
DROP PROCEDURE MomentoMedia_GetByMomentoIdAndMediaType
GO

GO
/****** Object:  StoredProcedure [dbo].[User_Create]    Script Date: 8/29/2013 10:32:22 AM ******/
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
	@DisplayName nvarchar(100) = '',
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
	Insert into AlsoKnownAs(FullName, FirstName, LastName, Username, IsDefault)Values(@DisplayName, @FirstName, @LastName, @Username, 1)
END


GO
/****** Object:  StoredProcedure [dbo].[Album_GetNext40Momentos]    Script Date: 8/29/2013 3:10:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Album_GetNext40Momentos]
(
	@AlbumId int,
	@MomentoId int,
	@Username nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @Ablum table (AlbumId int, MomentoId int, [Row] int);
 
	Insert Into @Ablum(AlbumId, MomentoId, [Row])
	Select AlbumId, MomentoId,
	Row_Number() over(Order by AM.CreateDate) as Row
	From [dbo].[AlbumMomento] AM
	Inner Join Album A
		On AM.AlbumId = A.Id
	Where AM.AlbumId = @AlbumId AND A.Username = @Username

	declare @BeginRow int
	Set @BeginRow = (Select Row From @Ablum Where MomentoId = @MomentoId) + 1

	declare @RowCount int
	Set @RowCount = 40 + @BeginRow

	Select M.*
	From @Ablum A
	Inner Join Momento M
		On A.MomentoId = M.Id
	Where Row Between @BeginRow AND @RowCount
END
