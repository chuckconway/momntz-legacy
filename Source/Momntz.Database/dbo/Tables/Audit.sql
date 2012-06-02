CREATE TABLE [dbo].[Audit] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ItemId]     NVARCHAR (50)  NOT NULL,
    [Item]       NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_Audit_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [ItemType]   NVARCHAR (550) NOT NULL,
    CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

