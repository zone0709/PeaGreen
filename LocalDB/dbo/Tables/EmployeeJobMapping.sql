CREATE TABLE [dbo].[EmployeeJobMapping] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId]     INT NULL,
    [EmployeeRoleId] INT NULL,
    [IsActive]       BIT NULL,
    CONSTRAINT [PK_EmployeeRoleMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeRoleMapping_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeRoleMapping_EmployeeRole] FOREIGN KEY ([EmployeeRoleId]) REFERENCES [dbo].[EmployeeJob] ([Id])
);

