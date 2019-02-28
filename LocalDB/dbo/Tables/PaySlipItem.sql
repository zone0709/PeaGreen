CREATE TABLE [dbo].[PaySlipItem] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [PaySlipID]       INT           NOT NULL,
    [PayrollDeatilID] INT           NOT NULL,
    [Value]           FLOAT (53)    NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [IsActive]        BIT           NULL,
    CONSTRAINT [PK_PaySlipItem] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PaySlipItem_PayrollDetail] FOREIGN KEY ([PayrollDeatilID]) REFERENCES [dbo].[PayrollDetail] ([Id]),
    CONSTRAINT [FK_PaySlipItem_PaySlip] FOREIGN KEY ([PaySlipID]) REFERENCES [dbo].[PaySlip] ([ID])
);

