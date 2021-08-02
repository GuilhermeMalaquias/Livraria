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

CREATE TABLE [Authors] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(50) NOT NULL,
    [Document] varchar(14) NOT NULL,
    [TypePerson] int NOT NULL,
    [About] varchar(300) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Companies] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Document] varchar(14) NOT NULL,
    [TypePerson] int NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Genres] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Description] varchar(300) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [Image] varchar(100) NOT NULL,
    [ISBN] varchar(13) NOT NULL,
    [PublicationDate] datetime2 NOT NULL,
    [Price] decimal(8,2) NOT NULL,
    [Active] bit NOT NULL,
    [Description] varchar(300) NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [GenreId] uniqueidentifier NOT NULL,
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Books_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Books_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'Document', N'Name', N'TypePerson') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] ON;
INSERT INTO [Authors] ([Id], [About], [Document], [Name], [TypePerson])
VALUES ('7c022886-4877-419a-94c3-824fb7aee950', 'Dr. Harvey M. Deitel, presidente e diretor de estratégia da Deitel & Associates, Inc., tem 45 anos de experiência acadêmica e industrial na área de informática. Dr. Deitel recebeu B.S. e M.S. graus do MIT e um Ph.D. da Boston University.', '07927830007', 'Harvey Deitel', 1),
('ca7329e9-dede-42ee-9a04-b372bd902751', 'Luciano Ramalho é programador Python desde 1998, Fellow da Python Software Foundation; é sócio do Python.pro.br – uma empresa de treinamento – e cofundador do Garoa Hacker Clube, o primeiro hackerspace do Brasil.', '06057967003', 'Luciano Ramalho', 1),
('1e221da8-5000-446b-9477-4f67cd2fce7a', 'Robert Cecil Martin, também conhecido como Uncle Bob, é uma grande personalidade da comunidade de desenvolvimento de software, métodos ágeis e software craftsmanship, atuando na área desde 1970.', '54935366000181', 'Robert Cecil Martin', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'About', N'Document', N'Name', N'TypePerson') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Document', N'Name', N'TypePerson') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] ON;
INSERT INTO [Companies] ([Id], [Document], [Name], [TypePerson])
VALUES ('59c5a2c3-d45c-481a-855d-8abc2904c95f', '00591191000103', 'Novatec Editora', 2),
('a507ce21-f383-41d6-a583-d596adc80bb3', '01404158001838', 'Pearson Universidades', 2),
('1e255a90-d95b-4164-bf01-8bd7cdae040b', '51319823000115', 'Alta Books', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Document', N'Name', N'TypePerson') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] ON;
INSERT INTO [Genres] ([Id], [Description], [Name])
VALUES ('640a79e8-a4ac-472d-8086-59773836d907', 'Tecnologia é o conjunto de técnicas, habilidades, métodos e processos usados na produção de bens ou serviços, ou na realização de objetivos, como em investigações científicas.', 'Tecnologia');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Active], [AuthorId], [CompanyId], [Description], [GenreId], [ISBN], [Image], [Price], [PublicationDate], [Title])
VALUES ('14a8666b-908c-4915-86c2-6ee42b8ec80f', CAST(1 AS bit), '7c022886-4877-419a-94c3-824fb7aee950', 'a507ce21-f383-41d6-a583-d596adc80bb3', 'O Autor explica neste livro, como usar a linguagem de programação C# a principal linguagem na iniciativa .NET da Microsoft para programação de propósito geral e para desenvolver aplicativos multicamadas, cliente-servidor, com uso intensivo de banco de dados, baseados na Internet e na Web.', '640a79e8-a4ac-472d-8086-59773836d907', '9788534614597', '906708E8-3F62-4626-8514-DF9EAC682460_image.jpg', 150.0, '2021-08-02T10:11:01.2338044-03:00', 'C#: Como Programar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Active], [AuthorId], [CompanyId], [Description], [GenreId], [ISBN], [Image], [Price], [PublicationDate], [Title])
VALUES ('6ac30476-7f85-43fe-9a48-bd6a583f89a3', CAST(1 AS bit), 'ca7329e9-dede-42ee-9a04-b372bd902751', '59c5a2c3-d45c-481a-855d-8abc2904c95f', 'A simplicidade de Python permite que você se torne produtivo rapidamente, porém isso muitas vezes significa que você não estará usando tudo que ela tem a oferecer. Com este guia prático, você aprenderá a escrever um código Python eficiente e idiomático aproveitando seus melhores recursos', '640a79e8-a4ac-472d-8086-59773836d907', '9788575224625', '52557B29-C28C-4866-A08D-D0C00526E921_PythonFluente.jpg', 115.0, '2021-08-02T10:11:01.2348949-03:00', 'Python Fluente');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Active], [AuthorId], [CompanyId], [Description], [GenreId], [ISBN], [Image], [Price], [PublicationDate], [Title])
VALUES ('22ff22c1-5acd-4a71-bd16-50376b706ccf', CAST(0 AS bit), '1e221da8-5000-446b-9477-4f67cd2fce7a', '1e255a90-d95b-4164-bf01-8bd7cdae040b', 'Mesmo um código ruim pode funcionar. Mas se ele não for limpo, pode acabar com uma empresa de desenvolvimento. Perdem-se a cada ano horas incontáveis e recursos importantes devido a um código mal escrito. Mas não precisa ser assim.', '640a79e8-a4ac-472d-8086-59773836d907', '9788576082675', '0DBC0E1F-C13B-430E-9A11-65C1A669FAEA_CleanCode.jpg', 75.0, '2021-08-02T10:11:01.2348988-03:00', 'Código limpo');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'AuthorId', N'CompanyId', N'Description', N'GenreId', N'ISBN', N'Image', N'Price', N'PublicationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

CREATE INDEX [IX_Books_CompanyId] ON [Books] ([CompanyId]);
GO

CREATE INDEX [IX_Books_GenreId] ON [Books] ([GenreId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210802131101_AddModelsAndDataSeeding', N'5.0.8');
GO

COMMIT;
GO

