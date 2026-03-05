-- Siguraduhing gamit ang tamang database
-- CREATE DATABASE EmployeeDB;
-- GO
-- USE EmployeeDB;
-- GO

CREATE TABLE [dbo].[Employee] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Position]   NVARCHAR (50) NULL,
    [Department] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO