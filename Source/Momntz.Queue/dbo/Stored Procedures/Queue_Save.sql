-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Queue_Save
	-- Add the parameters for the stored procedure here
(
	@Implementation nvarchar(250),
	@Payload nvarchar(max),
	@MessageStatus nvarchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into [Queue] (Implementation, Payload, MessageStatus)Values(@Implementation, @Payload, @MessageStatus)
END