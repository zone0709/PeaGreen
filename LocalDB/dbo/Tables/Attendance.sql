CREATE TABLE [dbo].[Attendance] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeId]       INT            NULL,
    [WorkingShiftType] INT            NULL,
    [Date]             DATE           NULL,
    [CheckMin]         TIME (7)       NULL,
    [CheckMax]         TIME (7)       NULL,
    [ShiftMin]         TIME (7)       NULL,
    [ShiftMax]         TIME (7)       NULL,
    [ExpandTime]       TIME (7)       NULL,
    [Status]           INT            NULL,
    [UpdatePerson]     NVARCHAR (150) NULL,
    [ImageIn]          NVARCHAR (MAX) NULL,
    [ImageOut]         NVARCHAR (MAX) NULL,
    [ConfidenceIn]     FLOAT (53)     NULL,
    [ConfidenceOut]    FLOAT (53)     NULL,
    [IsActive]         BIT            NULL,
    CONSTRAINT [PK_Attendance_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);

