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

