CREATE TABLE [dbo].[TagMomento] (
    [TagId]     INT NOT NULL,
    [MomentoId] INT NOT NULL,
    CONSTRAINT [PK_TagMomento] PRIMARY KEY CLUSTERED ([TagId] ASC, [MomentoId] ASC)
);

