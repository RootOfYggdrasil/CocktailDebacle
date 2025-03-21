CREATE TABLE [dbo].[SearchHistories] (
    [SearchId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NOT NULL,
    [SearchTerm] NVARCHAR (MAX) NOT NULL,
    [SearchDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_SearchHistories] PRIMARY KEY CLUSTERED ([SearchId] ASC),
    CONSTRAINT [FK_SearchHistories_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SearchHistories_UserId]
    ON [dbo].[SearchHistories]([UserId] ASC);

