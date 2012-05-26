CREATE TABLE [dbo].[Momento] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (100)  NOT NULL,
    [UploadedBy] NVARCHAR (100)  NOT NULL,
    [Visibility] NVARCHAR (4000) NULL,
    [Story]      NVARCHAR (MAX)  NULL,
    [Title]      NVARCHAR (250)  NULL,
    [Filename]   NVARCHAR (50)   NULL,
    [FileType]   NVARCHAR (10)   NULL,
    [Bytes]      VARBINARY (MAX) NULL,
    [Size]       INT             NULL,
    [UploadDate] DATETIME2 (7)   NULL,
    [CreateDate] DATETIME2 (7)   CONSTRAINT [DF_Momento_CreateDate] DEFAULT (getutcdate()) NULL,
    CONSTRAINT [PK_Momento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

