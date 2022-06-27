CREATE TABLE [dbo].[TBGrupoVeiculos] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Nome]                    VARCHAR (100) NOT NULL,
    [ValorPlanoDiario]        DECIMAL (10)  NOT NULL,
    [ValorDiariaKmControlado] DECIMAL (10)  NOT NULL,
    [ValorDiarioKmLivre]      DECIMAL (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
