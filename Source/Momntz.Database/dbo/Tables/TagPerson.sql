CREATE TABLE [dbo].[TagPerson] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [CreatedBy]  NVARCHAR (100)   NOT NULL,
    [TagId]      INT              NOT NULL,
    [Width]      INT              NULL,
    [Height]     INT              NULL,
    [XAxis]      INT              NULL,
    [YAxis]      INT              NULL,
    [InternalId] UNIQUEIDENTIFIER NOT NULL,
    [Username]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_TagPerson] PRIMARY KEY CLUSTERED ([Id] ASC, [TagId] ASC, [Username] ASC)
);





