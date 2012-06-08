CREATE TABLE [dbo].[Media] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Filename]    NVARCHAR (250)   NOT NULL,
    [Extension]   NVARCHAR (10)    NOT NULL,
    [Size]        INT              NOT NULL,
    [CreateDate]  DATETIME         CONSTRAINT [DF_Media_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [Username]    NVARCHAR (50)    NOT NULL,
    [ContentType] NVARCHAR (25)    NOT NULL,
    [MediaType]   NVARCHAR (50)    NOT NULL,
    [Bytes]       VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_Media] PRIMARY KEY CLUSTERED ([Id] ASC)
);

