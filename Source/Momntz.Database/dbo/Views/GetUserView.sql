CREATE VIEW dbo.GetUserView
AS
SELECT        dbo.AlsoKnownAs.FirstName, dbo.AlsoKnownAs.LastName, dbo.AlsoKnownAs.Suffix, dbo.AlsoKnownAs.MiddleName, dbo.[User].Username, dbo.[User].Email, 
                         dbo.[User].UserStatus, dbo.[User].Password, dbo.[User].CreatedBy, dbo.AlsoKnownAs.FullName
FROM            dbo.AlsoKnownAs INNER JOIN
                         dbo.[User] ON dbo.AlsoKnownAs.Username = dbo.[User].Username
WHERE        (dbo.AlsoKnownAs.IsDefault = 1)
GO

