CREATE TABLE [dbo].[PayrollDetail] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [PayrollDetailCategoryID] INT            NULL,
    [SalaryRuleGroupID]       INT            NULL,
    [Name]                    NVARCHAR (50)  NULL,
    [Value]                   FLOAT (53)     NULL,
    [Description]             NVARCHAR (250) NULL,
    [DefaultFormulaID]        INT            NULL,
    [Frequency]               NVARCHAR (50)  NULL,
    [Variability]             NVARCHAR (50)  NULL,
    [Destination]             NVARCHAR (50)  NULL,
    [IsActive]                BIT            NULL,
    CONSTRAINT [PK_PayrollDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PayrollDetail_PayrollDetailCategory] FOREIGN KEY ([PayrollDetailCategoryID]) REFERENCES [dbo].[PayrollDetailCategory] ([ID]),
    CONSTRAINT [FK_PayrollDetail_SalaryRuleGroup] FOREIGN KEY ([SalaryRuleGroupID]) REFERENCES [dbo].[SalaryRuleGroup] ([Id])
);

