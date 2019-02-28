CREATE TABLE [dbo].[PaySlipItemAttributeMapping] (
    [Id]                     INT           NOT NULL,
    [PaySlipItemId]          INT           NULL,
    [PaySlipItemAttributeId] INT           NULL,
    [Quality]                NVARCHAR (50) NULL,
    [Quantity]               INT           NULL,
    [IsActive]               BIT           NULL,
    CONSTRAINT [PK_PaySlipItemAttributeMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaySlipItemAttributeMapping_PaySlipItem] FOREIGN KEY ([PaySlipItemId]) REFERENCES [dbo].[PaySlipItem] ([ID]),
    CONSTRAINT [FK_PaySlipItemAttributeMapping_PaySlipItemAttrtibute] FOREIGN KEY ([PaySlipItemAttributeId]) REFERENCES [dbo].[PaySlipItemAttrtibute] ([Id])
);

