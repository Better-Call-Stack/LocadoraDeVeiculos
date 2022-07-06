CREATE TABLE [dbo].[TbTaxa] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (50) NOT NULL,
    [Valor]        DECIMAL (18, 2) NOT NULL,
    [TipoCobranca] INT          NOT NULL,
    CONSTRAINT [PK_TbTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);