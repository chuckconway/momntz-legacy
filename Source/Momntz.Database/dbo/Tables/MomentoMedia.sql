CREATE TABLE [dbo].[MomentoMedia] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [MomentoId]  INT            NOT NULL,
    [Filename]   NVARCHAR (50)  NOT NULL,
    [Extension]  NVARCHAR (20)  NOT NULL,
    [Content]    NVARCHAR (MAX) NULL,
    [Url]        NVARCHAR (500) NOT NULL,
    [Size]       INT            NOT NULL,
    [CreateDate] DATETIME2 (7)  CONSTRAINT [DF_MomentoMedia_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [MediaType]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_MomentoMedia] PRIMARY KEY CLUSTERED ([Id] ASC)
);







