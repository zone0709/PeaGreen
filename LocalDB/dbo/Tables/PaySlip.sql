CREATE TABLE [dbo].[PaySlip] (
    [ID]              INT        IDENTITY (1, 1) NOT NULL,
    [PayrollPeriodId] INT        NULL,
    [EmployeeID]      INT        NOT NULL,
    [NetPay]          FLOAT (53) NULL,
    [IsActive]        BIT        NULL,
    CONSTRAINT [PK_PaySlip] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PaySlip_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_PaySlip_PayrollPeriod] FOREIGN KEY ([PayrollPeriodId]) REFERENCES [dbo].[PayrollPeriod] ([Id])
);

