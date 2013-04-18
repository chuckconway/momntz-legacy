CREATE TABLE [dbo].[Exif] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [MomentoId] INT             NOT NULL,
    [Key]       NVARCHAR (50)   NOT NULL,
    [Value]     NVARCHAR (4000) NULL,
    [Type]      INT             NOT NULL,
    CONSTRAINT [PK_Exif] PRIMARY KEY CLUSTERED ([Id] ASC)
);



