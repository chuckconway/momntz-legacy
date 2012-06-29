CREATE TABLE [dbo].[AlsoKnownAs] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [MiddleName] NVARCHAR (50)  NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [Suffix]     NVARCHAR (10)  NULL,
    [Username]   NVARCHAR (100) NOT NULL,
    [IsDefault]  BIT            CONSTRAINT [DF_AlsoKnownAs_IsDefault] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AlsoKnownAs_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

