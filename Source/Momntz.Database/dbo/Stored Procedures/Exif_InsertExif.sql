-- =============================================
-- Author:              <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
Create PROCEDURE [dbo].[Exif_InsertExif]
(       -- Add the parameters for the stored procedure here
        @ExifCollection ExifCollection readonly
)
AS
BEGIN
        -- SET NOCOUNT ON added to prevent extra result sets from
        -- interfering with SELECT statements.
        SET NOCOUNT ON;
        
        Insert Into Exif(MomentoId, [Key], Value, [Type])
        Select MediaId, [Key], Value, [Type]
        From @ExifCollection    

END