CREATE TABLE [dbo].[TagPerson] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [CreatedBy]  NVARCHAR (100)   NOT NULL,
    [TagId]      INT              NOT NULL,
    [Width]      DECIMAL (18)     NULL,
    [Height]     DECIMAL (18)     NULL,
    [XAxis]      DECIMAL (18)     NULL,
    [YAxis]      DECIMAL (18)     NULL,
    [InternalId] UNIQUEIDENTIFIER NOT NULL,
    [Username]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_TagPerson] PRIMARY KEY CLUSTERED ([Id] ASC, [TagId] ASC, [Username] ASC)
);







