CREATE TABLE [dbo].[AlbumMomento] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [AlbumId]    INT      NOT NULL,
    [MomentoId]  INT      NOT NULL,
    [CreateDate] DATETIME CONSTRAINT [DF_AlbumMomento_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_AlbumMomento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

