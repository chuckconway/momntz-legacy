CREATE TABLE [dbo].[Tag] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)   NOT NULL,
    [Story]    NVARCHAR (4000) NULL,
    [Kind]     NVARCHAR (50)   NOT NULL,
    [Username] NVARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC)
);



