CREATE TABLE [dbo].[WorkingShiftAutoTmp] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NULL,
    [WorkingShiftType] INT           NULL,
    [Date]             DATE          NULL,
    [TimeStart]        TIME (7)      NULL,
    [TimeEnd]          TIME (7)      NULL,
    [TimeExpand]       TIME (7)      NULL,
    [EmptySlot]        INT           NULL,
    [IsActive]         BIT           NULL,
    CONSTRAINT [PK_WorkingShiftAutoTmp] PRIMARY KEY CLUSTERED ([Id] ASC)
);

