CREATE TABLE [dbo].[TBPlanoDeCobranca] (
    [Id]                                  INT             IDENTITY (1, 1) NOT NULL,
    [ValorKmRodado_PlanoDiario]        DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoDiario]          DECIMAL (10, 2) NOT NULL,
    [ValorKmRodado_PlanoKmControlado]  DECIMAL (10, 2) NOT NULL,
    [KmLivreIncluso_PlanoKmControlado] DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoKmControlado]    DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoKmLivre]         DECIMAL (10, 2) NOT NULL,
    [GrupoVeiculos_Id]                    INT             NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoVeiculos] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);
