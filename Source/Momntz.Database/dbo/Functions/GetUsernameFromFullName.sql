CREATE FUNCTION [dbo].[GetUsernameFromFullName] 
(
  @FullName nvarchar(100),
  @Username nvarchar(100),
  @NewUserName nvarchar(100) 
)
RETURNS nvarchar(100)
AS
BEGIN

	Declare @ReturnUserName nvarchar(100)
	Set @ReturnUserName = (Select Top 1 Username From UserAliasView A Where (A.Username = @Username OR A.CreatedBy = @Username) AND A.FullName = @FullName)

  IF @ReturnUserName IS NOT NULL AND LEN(@ReturnUserName) > 0
	BEGIN
		Return @ReturnUserName
	END

  Declare @count int
  set @count = (Select Count(*) 
  From [User] U 
  Where U.Username = @NewUserName)

  IF @count > 0
  BEGIN
	Set @ReturnUserName = @NewUserName + '.' + Cast(@count as nvarchar)
  END
  Else
	  BEGIN
		SET @ReturnUserName = @NewUserName
	  END 

  Return @ReturnUsername
  
END