CREATE TABLE [dbo].[WorkType] (
    [Id]           INT           NOT NULL,
    [WorkTypeName] NVARCHAR (50) NULL,
    [FromTime]     DATETIME      NOT NULL,
    [ToTime]       DATETIME      NOT NULL,
    [WorkTypeRate] FLOAT (53)    NOT NULL,
    [IsUnNormal]   BIT           NOT NULL,
    [IsActive]     BIT           NOT NULL,
    CONSTRAINT [PK_WorkType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

