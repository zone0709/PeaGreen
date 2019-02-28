CREATE TABLE [dbo].[EmployeeWorkingShiftRegitser] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeId]     INT      NULL,
    [WorkingShiftId] INT      NULL,
    [Date]           DATE     NULL,
    [TimeCreated]    DATETIME NULL,
    [IsActive]       BIT      NULL,
    CONSTRAINT [PK_EmployeeWorkingShiftRegitser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeWorkingShiftRegitser_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeWorkingShiftRegitser_WorkingShift] FOREIGN KEY ([WorkingShiftId]) REFERENCES [dbo].[WorkingShift] ([Id])
);

