﻿CREATE TABLE [dbo].[PaySlipItemAttrtibute] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [Code]     NVARCHAR (50) NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_PaySlipItemAttrtibute] PRIMARY KEY CLUSTERED ([Id] ASC)
);

