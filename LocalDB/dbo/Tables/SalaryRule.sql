CREATE TABLE [dbo].[SalaryRule] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [TimeModeId]  INT           NULL,
    [Name]        NVARCHAR (50) NULL,
    [DurationMin] FLOAT (53)    NULL,
    [DurationMax] FLOAT (53)    NULL,
    [FixValue]    FLOAT (53)    NULL,
    [RateValue]   FLOAT (53)    NULL,
    [IsActive]    BIT           NULL,
    CONSTRAINT [PK_SalaryRule] PRIMARY KEY CLUSTERED ([Id] ASC)
);



