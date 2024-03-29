﻿CREATE TABLE [dbo].[TBFuncionario] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Nome]           VARCHAR (150)    NOT NULL,
    [CPF]            VARCHAR (20)     NOT NULL,
    [Salario]        DECIMAL (18, 2)  NOT NULL,
    [DataDeAdmissao] DATE             NOT NULL,
    [Login]          VARCHAR (50)     NOT NULL,
    [Senha]          VARCHAR (50)     NOT NULL,
    [Perfil]         INT              NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

