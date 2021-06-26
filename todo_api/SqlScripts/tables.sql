CREATE TABLE [dbo].[tb_user]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(60) NOT NULL,
    [LastName] VARCHAR(60) NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL,
    [CreateAt] DATETIME NOT NULL,
    [UpdateAt] DATETIME
)

GO

CREATE TABLE [dbo].[tb_todo_task]
(
    [Id] INT IDENTITY PRIMARY KEY,
    [Title] VARCHAR(30) NOT NULL,
    [Description] VARCHAR(200) NOT NULL,
    [CreateAt] DATETIME NOT NULL,
    [UpdateAt] DATETIME,
    [UserId] INT NOT NULL,
    CONSTRAINT FK_tb_todo_task_tb_user FOREIGN KEY ([UserId]) REFERENCES [tb_user]([Id])
)