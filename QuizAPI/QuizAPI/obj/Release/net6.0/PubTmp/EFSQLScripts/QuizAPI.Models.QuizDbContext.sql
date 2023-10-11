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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227190042_quiz')
BEGIN
    CREATE TABLE [Participants] (
        [ParticipantId] int NOT NULL IDENTITY,
        [Email] nvarchar(50) NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Score] int NOT NULL,
        [TimeTaken] int NOT NULL,
        CONSTRAINT [PK_Participants] PRIMARY KEY ([ParticipantId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227190042_quiz')
BEGIN
    CREATE TABLE [Questions] (
        [QnId] int NOT NULL IDENTITY,
        [QmInWords] nvarchar(250) NOT NULL,
        [ImageName] nvarchar(50) NULL,
        [Option1] nvarchar(50) NOT NULL,
        [Option2] nvarchar(50) NOT NULL,
        [Option3] nvarchar(50) NOT NULL,
        [Option4] nvarchar(50) NOT NULL,
        [Answear] int NOT NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([QnId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230227190042_quiz')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230227190042_quiz', N'6.0.13');
END;
GO

COMMIT;
GO

