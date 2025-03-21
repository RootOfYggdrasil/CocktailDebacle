CREATE TABLE [dbo].[Users] (
    [UserId]         INT            IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (MAX) NOT NULL,
    [Email]          NVARCHAR (MAX) NOT NULL,
    [PasswordHash]   NVARCHAR (MAX) NOT NULL,
    [ConsentProfile] BIT            NOT NULL,
    [CreatedAt]      DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

