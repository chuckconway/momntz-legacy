-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE MomentoMedia_GetByMomentoIdAndMediaType
	-- Add the parameters for the stored procedure here
(
	@MomentoId int,
	@MediaType nvarchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select *
	From MomentoMedia M
	Where M.MomentoId =  @MomentoId AND M.MediaType = @MediaType
END