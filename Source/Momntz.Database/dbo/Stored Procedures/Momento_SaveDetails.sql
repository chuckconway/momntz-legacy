-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Momento_SaveDetails
(	-- Add the parameters for the stored procedure here

	@Id int, 
	@Location nvarchar(250), 
	@Day int = null, 
	@Month int = null, 
	@Story nvarchar(max),
	@Title nvarchar(250),
	@Year int = null
)		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--TODO://GEO CODE locations

	Update Momento
	Set
		Location = @Location,
		[Day] = @Day,
		[Month] = @Month,
		Story = @Story,
		Title = @Title,
		[Year] = @Year
	Where Id = @Id
END