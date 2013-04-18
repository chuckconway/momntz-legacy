-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure User_Create
(
	@Username nvarchar(100),
	@CreatedBy nvarchar(100),
	@Email nvarchar(250),
	@FirstName nvarchar(50),
	@DisplayName nvarchar(100),
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