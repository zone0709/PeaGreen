CREATE TABLE [dbo].[PayrollPeriod] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [PaySlipTemplateId] INT           NULL,
    [Name]              NVARCHAR (50) NULL,
    [FromDate]          DATE          NULL,
    [ToDate]            DATE          NULL,
    [IsActive]          BIT           NULL,
    CONSTRAINT [PK_PayrollPeriod] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PayrollPeriod_PaySlipTemplate] FOREIGN KEY ([PaySlipTemplateId]) REFERENCES [dbo].[PaySlipTemplate] ([ID])
);

