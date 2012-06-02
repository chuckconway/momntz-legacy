CREATE TABLE [dbo].[TagPerson] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (100) NOT NULL,
    [TagId]    INT            NOT NULL,
    CONSTRAINT [PK_TagPerson] PRIMARY KEY CLUSTERED ([Id] ASC)
);

