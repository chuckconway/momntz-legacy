﻿CREATE TABLE [dbo].[Momento] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [InternalId] UNIQUEIDENTIFIER NOT NULL,
    [Username]   NVARCHAR (100)   NOT NULL,
    [UploadedBy] NVARCHAR (100)   NOT NULL,
    [Visibility] NVARCHAR (20)    NULL,
    [Story]      NVARCHAR (MAX)   NULL,
    [Title]      NVARCHAR (250)   NULL,
    [CreateDate] DATETIME2 (7)    CONSTRAINT [DF_Momento_CreateDate] DEFAULT (getutcdate()) NULL,
    [Day]        INT              NULL,
    [Month]      INT              NULL,
    [Year]       INT              NULL,
    [Location]   NVARCHAR (250)   NULL,
    [Latitude]   NUMERIC (26, 13) NULL,
    [Longitude]  NUMERIC (26, 13) NULL,
    CONSTRAINT [PK_Momento] PRIMARY KEY CLUSTERED ([Id] ASC)
);







