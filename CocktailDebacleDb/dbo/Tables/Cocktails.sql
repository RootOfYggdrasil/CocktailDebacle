CREATE TABLE [dbo].[Cocktails] (
    [CocktailId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Category]     NVARCHAR (MAX) NULL,
    [Alcoholic]    BIT            NOT NULL,
    [GlassType]    NVARCHAR (MAX) NULL,
    [Instructions] NVARCHAR (MAX) NULL,
    [ImageUrl]     NVARCHAR (MAX) NULL,
    [Source]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Cocktails] PRIMARY KEY CLUSTERED ([CocktailId] ASC)
);

