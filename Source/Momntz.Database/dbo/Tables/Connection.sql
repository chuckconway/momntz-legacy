CREATE TABLE [dbo].[Connection] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (100) NOT NULL,
    [Owner]    NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Connection] PRIMARY KEY CLUSTERED ([Id] ASC)
);

