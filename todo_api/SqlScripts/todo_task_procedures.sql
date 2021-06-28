-- BUSCA AGENDA PELO ID
    CREATE PROCEDURE [SP_FIND_TODO_TASK_BY_ID]
    (
        @Id INT
    )
    AS

    SELECT  [Id],
            [Title],
            [Description],
            [DateTodo],
            [CreateAt],
            [UpdateAt],
            [UserId]
    FROM    [dbo].[tb_todo_task]
    WHERE   [Id] = @Id

GO

-- BUSCA AGENDAS PELO ID DO USUÁRIO
    CREATE PROCEDURE [SP_FIND_TODO_TASK_BY_USER]
    (
        @UserId INT
    )
    AS

    SELECT  [Id],
            [Title],
            [Description],
            [DateTodo],
            [CreateAt],
            [UpdateAt],
            [UserId]
    FROM    [dbo].[tb_todo_task]
    WHERE   [UserId] = @UserId

GO

-- CRIA A AGENDA
    CREATE PROCEDURE [SP_CREATE_TODO_TASK]
    (
        @Title VARCHAR(30),
        @Description VARCHAR(200),
        @UserId INT,
        @DateTodo DATETIME
    )
    AS

    INSERT  INTO [dbo].[tb_todo_task]
    (
        [Title],
        [Description],
        [DateTodo],
        [UserId],
        [CreateAt]
    )
    VALUES
    (
        @Title,
        @Description,
        @DateTodo,
        @UserId,
        GETDATE()
    )

    SELECT SCOPE_IDENTITY()

GO

-- ALTERA A AGENDA
    CREATE PROCEDURE [SP_UPDATE_TODO_TASK]
    (
        @Id INT,
        @Title VARCHAR(30),
        @Description VARCHAR(200),
        @DateTodo DATETIME
    )
    AS

    UPDATE  [dbo].[tb_todo_task]
    SET     [Title] = @Title,
            [Description] = @Description,
            [DateTodo] = @DateTodo,
            [UpdateAt] = GETDATE()
    WHERE   [Id] = @Id

GO

-- REMOVE A AGENDA
    CREATE PROCEDURE [SP_REMOVE_TODO_TASK]
    (
        @Id INT
    )
    AS

    DELETE  FROM [dbo].[tb_todo_task]
    WHERE   [Id] = @Id