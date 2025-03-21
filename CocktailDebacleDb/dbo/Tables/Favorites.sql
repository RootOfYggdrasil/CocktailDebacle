CREATE TABLE [dbo].[Favorites] (
    [UserId]     INT NOT NULL,
    [CocktailId] INT NOT NULL,
    CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED ([UserId] ASC, [CocktailId] ASC),
    CONSTRAINT [FK_Favorites_Cocktails_CocktailId] FOREIGN KEY ([CocktailId]) REFERENCES [dbo].[Cocktails] ([CocktailId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorites_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Favorites_CocktailId]
    ON [dbo].[Favorites]([CocktailId] ASC);

