CREATE TABLE [dbo].[TBPlanoDeCobranca] (
    [Id]                                  INT             IDENTITY (1, 1) NOT NULL,
    [txtValorKmRodado_PlanoDiario]        DECIMAL (10, 2) NOT NULL,
    [txtValorPorDia_PlanoDiario]          DECIMAL (10, 2) NOT NULL,
    [txtValorKmRodado_PlanoKmControlado]  DECIMAL (10, 2) NOT NULL,
    [txtKmLivreIncluso_PlanoKmControlado] DECIMAL (10, 2) NOT NULL,
    [txtValorPorDia_PlanoKmControlado]    DECIMAL (10, 2) NOT NULL,
    [txtValorPorDia_PlanoKmLivre]         DECIMAL (10, 2) NOT NULL,
    [GrupoVeiculos_Id]                    INT             NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoVeiculos] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);
