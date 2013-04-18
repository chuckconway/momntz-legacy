CREATE TABLE [dbo].[Configuration] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Value]       NVARCHAR (500) NOT NULL,
    [Environment] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ([Id] ASC)
);





