CREATE TABLE [dbo].[Queue] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Implementation] NVARCHAR (250)  NOT NULL,
    [Payload]        NVARCHAR (MAX)  NOT NULL,
    [CreateDate]     DATETIME        CONSTRAINT [DF_Queue_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [MessageStatus]  NVARCHAR (50)   NOT NULL,
    [Error]          NVARCHAR (2000) NULL,
    [CompleteDate]   DATETIME        NULL,
    CONSTRAINT [PK_Queue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

