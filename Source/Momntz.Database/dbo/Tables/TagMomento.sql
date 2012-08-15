CREATE TABLE [dbo].[TagMomento] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [TagId]     INT NOT NULL,
    [MomentoId] INT NOT NULL,
    CONSTRAINT [PK_TagMomento] PRIMARY KEY CLUSTERED ([Id] ASC, [TagId] ASC, [MomentoId] ASC)
);



