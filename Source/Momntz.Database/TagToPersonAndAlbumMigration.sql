
--Migrate the Albums into the Album tables
Begin Transaction 

Set Identity_Insert Album ON

Insert Into Album(Id, Name, Story, CreateDate, Username)
Select Id, Name, Story, CreateDate, Username 
From Tag T
Where T.Kind = 3

Set Identity_Insert Album Off

Insert Into AlbumMomento (AlbumId, MomentoId)
Select TagId as AlbumId, MomentoId
From TagMomento TM
Inner Join Tag T
	On TM.TagId = T.Id
Where T.Kind = 3

Set Identity_Insert Person ON
Insert Into Person(Id,Name, CreatedBy, Width, Height, XAxis, YAxis, Username)
Select T.Id,Name, CreatedBy, Width, Height, XAxis, YAxis, T.Username
From Tag T
Inner Join TagPerson TP
	On T.Id = TP.TagId
Where T.Kind = 0
Set Identity_Insert Person Off

Insert Into PersonMomento (PersonId, MomentoId)
Select TagId as PersonId, MomentoId
From TagMomento TM
Inner Join Tag T
	On TM.TagId = T.Id
Where T.Kind = 0

RollBack