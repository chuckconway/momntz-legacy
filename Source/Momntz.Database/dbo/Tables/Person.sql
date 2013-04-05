CREATE TABLE [dbo].[Person] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [CreatedBy]  NVARCHAR (100) NOT NULL,
    [Width]      DECIMAL (18)   NULL,
    [Height]     DECIMAL (18)   NULL,
    [XAxis]      DECIMAL (18)   NULL,
    [YAxis]      DECIMAL (18)   NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_Person_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [MomentoId]  INT            NULL
);





