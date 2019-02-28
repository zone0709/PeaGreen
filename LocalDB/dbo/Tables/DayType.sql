CREATE TABLE [dbo].[DayType] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [DayTypeName]   NVARCHAR (50) NULL,
    [DaysOfTheWeek] NVARCHAR (50) NULL,
    [FromDate]      DATE          NULL,
    [ToDate]        DATE          NULL,
    [Priority]      INT           NULL,
    [IsActive]      BIT           NOT NULL,
    [DateCreate]    DATE          NULL,
    CONSTRAINT [PK_DayType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



