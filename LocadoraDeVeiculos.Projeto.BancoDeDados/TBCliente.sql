CREATE TABLE [dbo].[TbCliente] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (50) NOT NULL,
    [CPF]        VARCHAR (50) NULL,
    [CNPJ]       VARCHAR (50) NULL,
    [Cidade]     VARCHAR (50) NOT NULL,
    [Endereco]   VARCHAR (50) NOT NULL,
    [Telefone]   VARCHAR (50) NOT NULL,
    [CNH]        VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NULL,
    [TipoPessoa] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);