CREATE TABLE [dbo].[EmployeeAttributeMapping] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]          INT           NOT NULL,
    [EmployeeAttributeID] INT           NOT NULL,
    [Quality]             NVARCHAR (50) NULL,
    [Quantity]            INT           NULL,
    [IsActive]            BIT           NULL,
    CONSTRAINT [PK_EmployeeAttributeMapping] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EmployeeAttributeMapping_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeAttributeMapping_EmployeeAttribute] FOREIGN KEY ([EmployeeAttributeID]) REFERENCES [dbo].[EmployeeAttribute] ([ID])
);

