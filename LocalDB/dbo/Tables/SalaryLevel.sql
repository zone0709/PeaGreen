CREATE TABLE [dbo].[SalaryLevel] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [SalaryLevelName] NVARCHAR (50) NULL,
    [SalaryValue]     FLOAT (53)    NULL,
    [IsActive]        BIT           NOT NULL,
    CONSTRAINT [PK_SalaryLevel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

