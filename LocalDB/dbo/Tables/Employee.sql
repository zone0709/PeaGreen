CREATE TABLE [dbo].[Employee] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Code]          NVARCHAR (50)  NULL,
    [EmployeeName]  NVARCHAR (500) NULL,
    [DateOfBirth]   DATE           NULL,
    [Address]       NVARCHAR (500) NULL,
    [Phone]         NVARCHAR (500) NULL,
    [SalaryLevelId] INT            NOT NULL,
    [PIN]           NVARCHAR (50)  NULL,
    [IsActive]      BIT            NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_SalaryLevel] FOREIGN KEY ([SalaryLevelId]) REFERENCES [dbo].[SalaryLevel] ([Id])
);



