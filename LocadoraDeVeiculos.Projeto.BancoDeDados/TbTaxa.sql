CREATE TABLE [dbo].[TbTaxa] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (50)     NOT NULL,
    [Valor]        DECIMAL (18, 2)     NOT NULL,
    [TipoCobranca] INT              NOT NULL,
    CONSTRAINT [PK_TbTaxa_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

