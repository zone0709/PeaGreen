CREATE TABLE [dbo].[EmployeeGroup] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [CreateDate] DATETIME       NULL,
    CONSTRAINT [PK_EmployeeGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);



