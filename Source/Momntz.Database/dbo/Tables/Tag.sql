CREATE TABLE [dbo].[Tag] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100)  NOT NULL,
    [Story]      NVARCHAR (4000) NULL,
    [Kind]       INT             NOT NULL,
    [Username]   NVARCHAR (100)  NOT NULL,
    [CreateDate] DATETIME        CONSTRAINT [DF_Tag_CreateDate] DEFAULT (getutcdate()) NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC, [Kind] ASC)
);











