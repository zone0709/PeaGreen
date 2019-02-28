CREATE TABLE [dbo].[WorkingShift] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [WorkingShiftName] NVARCHAR (50) NULL,
    [WorkingShiftType] INT           NULL,
    [ShiftMin]         TIME (7)      NULL,
    [ShiftMax]         TIME (7)      NULL,
    [ExpandTime]       TIME (7)      NULL,
    [IsActive]         BIT           NOT NULL,
    CONSTRAINT [PK_WorkingShift] PRIMARY KEY CLUSTERED ([Id] ASC)
);



