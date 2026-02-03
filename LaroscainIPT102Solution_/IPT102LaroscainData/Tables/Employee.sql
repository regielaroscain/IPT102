CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(100) NOT NULL, 
    [Position] NVARCHAR(100) NULL, 
    [Salary] DECIMAL(18, 2) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)