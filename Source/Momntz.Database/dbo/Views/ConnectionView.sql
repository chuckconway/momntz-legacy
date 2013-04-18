CREATE VIEW dbo.ConnectionView
AS
SELECT        dbo.AlsoKnownAs.Username, dbo.Connection.Owner, dbo.AlsoKnownAs.FullName
FROM            dbo.AlsoKnownAs INNER JOIN
                         dbo.Connection ON dbo.AlsoKnownAs.Username = dbo.Connection.Username AND dbo.AlsoKnownAs.IsDefault = 1
GO

