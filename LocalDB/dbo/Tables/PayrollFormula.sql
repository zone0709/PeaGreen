CREATE TABLE [dbo].[PayrollFormula] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [PayrollDetailID] INT            NULL,
    [Condition]       NVARCHAR (MAX) NULL,
    [Expression]      NVARCHAR (250) NOT NULL,
    [IsActive]        BIT            NOT NULL,
    CONSTRAINT [PK_PayrollFormula] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PayrollFormula_PayrollDetail] FOREIGN KEY ([PayrollDetailID]) REFERENCES [dbo].[PayrollDetail] ([Id])
);

