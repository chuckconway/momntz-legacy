CREATE VIEW dbo.UserAliasView
AS
SELECT        dbo.AlsoKnownAs.IsDefault, dbo.AlsoKnownAs.FullName, dbo.[User].Username, dbo.[User].Email, dbo.[User].UserStatus, dbo.[User].Password, 
                         dbo.[User].CreatedBy, dbo.AlsoKnownAs.Id AS AlsoKnownAsId
FROM            dbo.AlsoKnownAs INNER JOIN
                         dbo.[User] ON dbo.AlsoKnownAs.Username = dbo.[User].Username
GO
