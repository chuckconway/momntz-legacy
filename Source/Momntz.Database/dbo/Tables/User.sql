CREATE TABLE [dbo].[User] (
    [Username]   NVARCHAR (100) NOT NULL,
    [FirstName]  NVARCHAR (150) NOT NULL,
    [LastName]   NVARCHAR (150) NOT NULL,
    [Email]      NVARCHAR (250) NOT NULL,
    [UserStatus] NVARCHAR (50)  CONSTRAINT [DF_User_UserStatus] DEFAULT ('Active') NOT NULL,
    [Password]   NVARCHAR (250) NOT NULL,
    [CreatedBy]  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Username] ASC)
);



