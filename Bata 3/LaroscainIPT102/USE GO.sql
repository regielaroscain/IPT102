USE Testdb;
GO

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Position NVARCHAR(100),
    Department NVARCHAR(100)
);
GO

CREATE PROCEDURE spEmployee_GetAll AS SELECT * FROM Employees;
GO
CREATE PROCEDURE spEmployee_Create @FirstName NVARCHAR(100), @LastName NVARCHAR(100), @Position NVARCHAR(100), @Department NVARCHAR(100)
AS INSERT INTO Employees (FirstName, LastName, Position, Department) VALUES (@FirstName, @LastName, @Position, @Department);
-- ... (atbp para sa Update at Delete)