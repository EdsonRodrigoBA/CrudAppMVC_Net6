IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [fornecedores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(300) NOT NULL,
    [Documento] varchar(300) NOT NULL,
    [TipoFornecedor] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_fornecedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Logradouro] varchar(300) NOT NULL,
    [Numero] varchar(300) NOT NULL,
    [Complemento] varchar(300) NOT NULL,
    [Cep] varchar(300) NOT NULL,
    [Bairro] varchar(300) NOT NULL,
    [Cidade] varchar(300) NOT NULL,
    [Estado] varchar(300) NOT NULL,
    CONSTRAINT [PK_enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_enderecos_fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [fornecedores] ([Id])
);
GO

CREATE TABLE [produtos] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Nome] varchar(300) NOT NULL,
    [Descricao] varchar(300) NOT NULL,
    [Imagem] varchar(300) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_produtos_fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [fornecedores] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_enderecos_FornecedorId] ON [enderecos] ([FornecedorId]);
GO

CREATE INDEX [IX_produtos_FornecedorId] ON [produtos] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230704154811_InicialMigration', N'7.0.8');
GO

COMMIT;
GO

