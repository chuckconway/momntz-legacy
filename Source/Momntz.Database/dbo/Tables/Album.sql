CREATE TABLE [dbo].[Album] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (150) NOT NULL,
    [Story]      NVARCHAR (MAX) NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_Album_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED ([Id] ASC)
);

