CREATE TABLE [dbo].[MomentoUser] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [MomentoId] INT           NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MomentoUser] PRIMARY KEY CLUSTERED ([MomentoId] ASC, [Username] ASC)
);

