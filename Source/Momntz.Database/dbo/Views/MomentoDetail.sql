CREATE VIEW dbo.MomentoDetail
AS
SELECT        dbo.Momento.Title, dbo.Momento.Story, dbo.Momento.Day, dbo.Momento.Month, dbo.Momento.Year, dbo.Momento.Location, dbo.Momento.CreateDate AS Added, 
                         dbo.Momento.UploadedBy AS AddedUsername, dbo.GetUserView.FullName AS DisplayName, dbo.Momento.Id, dbo.Momento.Username
FROM            dbo.Momento INNER JOIN
                         dbo.GetUserView ON dbo.Momento.Username = dbo.GetUserView.Username
GO
