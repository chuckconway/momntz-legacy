CREATE VIEW dbo.TagPersonView
AS
SELECT        T.Id, TM.MomentoId, T.Name, T.Story, TP.Username, TP.CreatedBy, TP.Height, TP.InternalId, TP.Width, TP.XAxis, TP.YAxis, TP.Id AS TagPersonId
FROM            dbo.TagMomento AS TM INNER JOIN
                         dbo.Tag AS T ON TM.TagId = T.Id AND T.Kind = 0 INNER JOIN
                         dbo.TagPerson AS TP ON T.Id = TP.TagId
GO






