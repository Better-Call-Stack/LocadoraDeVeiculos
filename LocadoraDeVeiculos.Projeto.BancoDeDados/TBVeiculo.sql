CREATE TABLE [dbo].[TbVeiculo] (
    [Id]                 UNIQUEIDENTIFIER    NOT NULL,
    [Modelo]             VARCHAR (50)   NOT NULL,
    [Fabricante]         VARCHAR (50)   NOT NULL,
    [Placa]              VARCHAR (7)    NOT NULL,
    [Cor]                VARCHAR (50)   NOT NULL,
    [TipoCombustivel]    INT            NOT NULL,
    [CapacidadeDoTanque] DECIMAL (5, 2) NOT NULL,
    [Ano]                INT            NOT NULL,
    [KmPercorrido]       INT            NULL,
    [GrupoVeiculos_Id]   UNIQUEIDENTIFIER            NOT NULL,
    [StatusVeiculo] INT NOT NULL, 
    [FotoVeiculo] VARBINARY(MAX) NOT NULL, 
    CONSTRAINT [PK_TbVeiculo] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TbVeiculo_TBGrupoVeiculos] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);