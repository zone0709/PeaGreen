CREATE TABLE [dbo].[SalaryRuleGroup] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_SalaryRuleGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

