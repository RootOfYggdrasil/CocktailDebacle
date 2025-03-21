CREATE TABLE [dbo].[UserCocktails] (
    [UserId]         INT NOT NULL,
    [CocktailId]     INT NOT NULL,
    [UserCocktailId] INT NOT NULL,
    CONSTRAINT [PK_UserCocktails] PRIMARY KEY CLUSTERED ([UserId] ASC, [CocktailId] ASC),
    CONSTRAINT [FK_UserCocktails_Cocktails_CocktailId] FOREIGN KEY ([CocktailId]) REFERENCES [dbo].[Cocktails] ([CocktailId]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserCocktails_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserCocktails_CocktailId]
    ON [dbo].[UserCocktails]([CocktailId] ASC);

