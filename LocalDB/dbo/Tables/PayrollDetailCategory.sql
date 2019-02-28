CREATE TABLE [dbo].[PayrollDetailCategory] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Priority] INT           NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_PayrollDetailCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
);

