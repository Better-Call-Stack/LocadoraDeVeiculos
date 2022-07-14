CREATE TABLE [dbo].[TBPlanoDeCobranca] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [ValorKmRodado_PlanoDiario]        DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoDiario]          DECIMAL (10, 2) NOT NULL,
    [ValorKmRodado_PlanoKmControlado]  DECIMAL (10, 2) NOT NULL,
    [KmLivreIncluso_PlanoKmControlado] DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoKmControlado]    DECIMAL (10, 2) NOT NULL,
    [ValorPorDia_PlanoKmLivre]         DECIMAL (10, 2) NOT NULL,
    [GrupoVeiculos_Id]                    UNIQUEIDENTIFIER             NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupoVeiculos] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);
