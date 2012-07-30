CREATE TABLE [dbo].[User] (
    [Username]   NVARCHAR (100) NOT NULL,
    [Email]      NVARCHAR (250) NULL,
    [UserStatus] INT            CONSTRAINT [DF_User_UserStatus] DEFAULT ('Active') NOT NULL,
    [Password]   NVARCHAR (250) NULL,
    [CreatedBy]  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Username] ASC)
);









