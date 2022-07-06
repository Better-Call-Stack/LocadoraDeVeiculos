CREATE TABLE [dbo].[TBPlanoDeCobranca]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [txtValorKmRodado_PlanoDiario] DECIMAL(10, 2) NOT NULL, 
    [txtValorPorDia_PlanoDiario] DECIMAL(10, 2) NOT NULL, 
    [txtValorKmRodado_PlanoKmControlado] DECIMAL(10, 2) NOT NULL, 
    [txtKmLivreIncluso_PlanoKmControlado] DECIMAL(10, 2) NOT NULL, 
    [txtValorPorDia_PlanoKmControlado] DECIMAL(10, 2) NOT NULL, 
    [txtValorPorDia_PlanoKmLivre] DECIMAL(10, 2) NOT NULL
)
