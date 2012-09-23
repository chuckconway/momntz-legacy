CREATE VIEW dbo.MomentoUserView
AS
SELECT        dbo.MomentoUser.Username, dbo.MomentoUser.MomentoId, dbo.Momento.Id, dbo.Momento.InternalId, dbo.Momento.UploadedBy, dbo.Momento.Visibility, 
                         dbo.Momento.Story, dbo.Momento.Title, dbo.Momento.CreateDate, dbo.Momento.Day, dbo.Momento.Month, dbo.Momento.Year, dbo.Momento.Location, 
                         dbo.Momento.Latitude, dbo.Momento.Longitude
FROM            dbo.Momento INNER JOIN
                         dbo.MomentoUser ON dbo.Momento.Id = dbo.MomentoUser.MomentoId
GO

