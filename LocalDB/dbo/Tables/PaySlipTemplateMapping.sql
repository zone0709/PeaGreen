CREATE TABLE [dbo].[PaySlipTemplateMapping] (
    [ID]                INT IDENTITY (1, 1) NOT NULL,
    [PaySlipTemplateID] INT NOT NULL,
    [PayrollDetailID]   INT NOT NULL,
    [IsActive]          BIT NULL,
    CONSTRAINT [PK_PaySlipTemplateMapping] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PaySlipTemplateMapping_PayrollDetail] FOREIGN KEY ([PayrollDetailID]) REFERENCES [dbo].[PayrollDetail] ([Id]),
    CONSTRAINT [FK_PaySlipTemplateMapping_PaySlipTemplate] FOREIGN KEY ([PaySlipTemplateID]) REFERENCES [dbo].[PaySlipTemplate] ([ID])
);

