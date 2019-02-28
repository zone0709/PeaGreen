CREATE TABLE [dbo].[PaySlipAttributeMapping] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [PaySlipId]          INT           NULL,
    [PaySlipAttributeId] INT           NULL,
    [Quality]            NVARCHAR (50) NULL,
    [Quantity]           FLOAT (53)    NULL,
    [IsActive]           BIT           NULL,
    CONSTRAINT [PK_PaySlipAttributeMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaySlipAttributeMapping_PaySlip] FOREIGN KEY ([PaySlipId]) REFERENCES [dbo].[PaySlip] ([ID]),
    CONSTRAINT [FK_PaySlipAttributeMapping_PaySlipAttribute] FOREIGN KEY ([PaySlipAttributeId]) REFERENCES [dbo].[PaySlipAttribute] ([Id])
);

