CREATE TABLE [dbo].[CocktailIngredients] (
    [CocktailId]   INT            NOT NULL,
    [IngredientId] INT            NOT NULL,
    [Measure]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_CocktailIngredients] PRIMARY KEY CLUSTERED ([CocktailId] ASC, [IngredientId] ASC),
    CONSTRAINT [FK_CocktailIngredients_Cocktails_CocktailId] FOREIGN KEY ([CocktailId]) REFERENCES [dbo].[Cocktails] ([CocktailId]) ON DELETE CASCADE,
    CONSTRAINT [FK_CocktailIngredients_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([IngredientId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CocktailIngredients_IngredientId]
    ON [dbo].[CocktailIngredients]([IngredientId] ASC);

