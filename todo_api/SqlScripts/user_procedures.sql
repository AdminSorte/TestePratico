-- BUSCA USUÁRIO PELO ID
    CREATE PROCEDURE [SP_FIND_USER_BY_ID]
    (
        @Id INT
    )
    AS

    SELECT  [Id],
            [Name],
            [LastName],
            [Email],
            [Password],
            [CreateAt],
            [UpdateAt]
    FROM    [dbo].[tb_user]
    WHERE   [Id] = @Id

GO

-- BUSCA USUÁRIO PELO EMAIL
    CREATE PROCEDURE [SP_FIND_USER_BY_EMAIL]
    (
        @Email VARCHAR(100)
    )
    AS

    SELECT  [Id],
            [Name],
            [LastName],
            [Email],
            [Password],
            [CreateAt],
            [UpdateAt]
    FROM    [dbo].[tb_user]
    WHERE   [Email] = @Email

GO

-- CRIA O USUÁRIO
    CREATE PROCEDURE [SP_CREATE_USER]
    (
        @Name VARCHAR(60),
        @LastName VARCHAR(60),
        @Email VARCHAR(100),
        @Password NVARCHAR(MAX)
    )
    AS

    INSERT  INTO [dbo].[tb_user]
    (
        [Name],
        [LastName],
        [Email],
        [Password],
        [CreateAt]
    )
    VALUES
    (
        @Name,
        @LastName,
        @Email,
        @Password,
        GETDATE()
    )

    SELECT SCOPE_IDENTITY()

GO

-- ALTERA O USUÁRIO
    CREATE PROCEDURE [SP_UPDATE_USER]
    (
        @Id INT,
        @Name VARCHAR(60),
        @LastName VARCHAR(60)
    )
    AS

    UPDATE  [dbo].[tb_user]
    SET     [Name] = @Name,
            [LastName] = @LastName,
            [UpdateAt] = GETDATE()
    WHERE   [Id] = @Id

GO

-- ALTERA A SENHA DO USUÁRIO
    CREATE PROCEDURE [SP_CHANGE_PASSWORD]
    (
        @Id INT,
        @Password NVARCHAR(MAX)
    )
    AS

    UPDATE  [dbo].[tb_user]
    SET     [Password] = @Password,
            [UpdateAt] = GETDATE()
    WHERE   [Id] = @Id

GO

-- REMOVE O USUÁRIO
    CREATE PROCEDURE [SP_REMOVE_USER]
    (
        @Id INT
    )
    AS

    DELETE  FROM [dbo].[tb_user]
    WHERE   [Id] = @Id