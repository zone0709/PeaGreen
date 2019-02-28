CREATE TABLE [dbo].[EmployeeWorkingShiftAutoMapping] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [WorkingShiftAutoTmpId] INT NULL,
    [EmployeeId]            INT NOT NULL,
    [IsActive]              BIT NULL,
    CONSTRAINT [PK_EmployeeWorkingShiftAutoMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeWorkingShiftAutoMapping_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeWorkingShiftAutoMapping_WorkingShiftAutoTmp] FOREIGN KEY ([WorkingShiftAutoTmpId]) REFERENCES [dbo].[WorkingShiftAutoTmp] ([Id])
);

