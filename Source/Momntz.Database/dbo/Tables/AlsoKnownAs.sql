CREATE TABLE [dbo].[AlsoKnownAs] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FullName]   NVARCHAR (100) CONSTRAINT [DF_AlsoKnownAs_FullName] DEFAULT ('') NOT NULL,
    [FirstName]  NVARCHAR (50)  NULL,
    [MiddleName] NVARCHAR (50)  NULL,
    [LastName]   NVARCHAR (50)  NULL,
    [Suffix]     NVARCHAR (10)  NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [IsDefault]  BIT            CONSTRAINT [DF_AlsoKnownAs_IsDefault] DEFAULT ((0)) NOT NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_AlsoKnownAs_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_AlsoKnownAs_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);





