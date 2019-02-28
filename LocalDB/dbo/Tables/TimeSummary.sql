CREATE TABLE [dbo].[TimeSummary] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeId]      INT           NULL,
    [TimeModeId]      INT           NOT NULL,
    [PayrollPeriodId] INT           NULL,
    [Date]            DATE          NULL,
    [TotalHours]      TIME (7)      NULL,
    [Status]          INT           NULL,
    [UpdatedPerson]   NVARCHAR (50) NULL,
    [IsActive]        BIT           NOT NULL,
    CONSTRAINT [PK_EmployeeTimeModeMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TimeSummary_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_TimeSummary_TimeMode] FOREIGN KEY ([TimeModeId]) REFERENCES [dbo].[TimeMode] ([Id])
);

