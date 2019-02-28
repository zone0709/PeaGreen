CREATE TABLE [dbo].[EmployeeGroupMapping] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId]      INT NOT NULL,
    [EmployeeGroupId] INT NOT NULL,
    CONSTRAINT [PK_EmployeeGroupMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeGroupMapping_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeGroupMapping_EmployeeGroup] FOREIGN KEY ([EmployeeGroupId]) REFERENCES [dbo].[EmployeeGroup] ([Id])
);

