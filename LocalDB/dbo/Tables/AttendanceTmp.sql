CREATE TABLE [dbo].[AttendanceTmp] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT            NOT NULL,
    [Time]       DATETIME       NULL,
    [ImageSrc]   NVARCHAR (MAX) NULL,
    [Confidence] FLOAT (53)     NULL,
    [IsActive]   BIT            NOT NULL,
    CONSTRAINT [PK_ActualShift] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AttendanceTmp_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);

