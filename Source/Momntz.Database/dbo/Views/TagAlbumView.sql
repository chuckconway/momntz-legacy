CREATE VIEW dbo.TagAlbumView
AS
SELECT        T.Name, T.Username, A.MomentoId, A.TagId, T.Story, A.Id
FROM            dbo.TagMomento AS A INNER JOIN
                         dbo.Tag AS T ON A.TagId = T.Id AND T.Kind = 3
GO
 
