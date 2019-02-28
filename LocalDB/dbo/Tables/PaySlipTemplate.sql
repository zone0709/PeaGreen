CREATE TABLE [dbo].[PaySlipTemplate] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_PaySlipTemplate] PRIMARY KEY CLUSTERED ([ID] ASC)
);

