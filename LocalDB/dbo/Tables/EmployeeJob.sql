CREATE TABLE [dbo].[EmployeeJob] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (250) NULL,
    [IsActive] BIT            NULL,
    CONSTRAINT [PK_EmployeeRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

