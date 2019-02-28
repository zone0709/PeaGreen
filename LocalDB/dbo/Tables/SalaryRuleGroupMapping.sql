CREATE TABLE [dbo].[SalaryRuleGroupMapping] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [SalaryRuleGroupId] INT NULL,
    [SalaryRuleId]      INT NULL,
    [IsActive]          BIT NULL,
    CONSTRAINT [PK_SalaryRuleGroupMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalaryRuleGroupMapping_SalaryRule] FOREIGN KEY ([SalaryRuleId]) REFERENCES [dbo].[SalaryRule] ([Id]),
    CONSTRAINT [FK_SalaryRuleGroupMapping_SalaryRuleGroup] FOREIGN KEY ([SalaryRuleGroupId]) REFERENCES [dbo].[SalaryRuleGroup] ([Id])
);

