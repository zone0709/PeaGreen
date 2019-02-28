CREATE TABLE [dbo].[TimeMode] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [TimeModeName]     NVARCHAR (50) NULL,
    [WorkingShiftType] INT           NULL,
    [TimeStart]        TIME (7)      NULL,
    [TimeEnd]          TIME (7)      NULL,
    [DurationMin]      TIME (7)      NULL,
    [DurationMax]      TIME (7)      NULL,
    [DayTypeId]        INT           NULL,
    [Priority]         INT           NULL,
    [IsActive]         BIT           NOT NULL,
    [DateCreate]       DATE          NULL,
    CONSTRAINT [PK_Coefficient] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TimeMode_DayType] FOREIGN KEY ([DayTypeId]) REFERENCES [dbo].[DayType] ([Id])
);



