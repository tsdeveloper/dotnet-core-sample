
CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    [UF] nvarchar(max) NULL,
    [Celular] nvarchar(max) NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);

GO



CREATE TABLE [Financiamento] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [Cpf] nvarchar(max) NULL,
    [Tipo] nvarchar(max) NULL,
    [ValorTotal] decimal(18,2) NOT NULL,
    [DataUltimoVencimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Financiamento] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Financiamento_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Parcela] (
    [Id] int NOT NULL IDENTITY,
    [FinanciamentoId] int NOT NULL,
    [NumParcelas] nvarchar(max) NULL,
    [ValorParcela] decimal(18,2) NOT NULL,
    [DataPagamento] datetime2 NOT NULL,
    CONSTRAINT [PK_Parcela] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Parcela_Financiamento_FinanciamentoId] FOREIGN KEY ([FinanciamentoId]) REFERENCES [Financiamento] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Financiamento_ClienteId] ON [Financiamento] ([ClienteId]);

GO

CREATE INDEX [IX_Parcela_FinanciamentoId] ON [Parcela] ([FinanciamentoId]);

GO


