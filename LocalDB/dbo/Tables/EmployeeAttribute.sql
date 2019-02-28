CREATE TABLE [dbo].[EmployeeAttribute] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Code]     NVARCHAR (50) NOT NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_EmployeeAttribute] PRIMARY KEY CLUSTERED ([ID] ASC)
);

