CREATE TABLE [dbo].[TbCondutor] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [CPF]         VARCHAR (50) NOT NULL,
    [CNH]         VARCHAR (50) NOT NULL,
    [ValidadeCNH] DATETIME     NOT NULL,
    [Cidade]      VARCHAR (50) NULL,
    [Endereco]    VARCHAR (50) NOT NULL,
    [Telefone]    VARCHAR (50) NOT NULL,
    [Email]       VARCHAR (50) NULL,
    [Cliente_Id]  INT          NOT NULL,
    CONSTRAINT [PK_TbCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbCondutor_TbCliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TbCliente] ([Id])
);
