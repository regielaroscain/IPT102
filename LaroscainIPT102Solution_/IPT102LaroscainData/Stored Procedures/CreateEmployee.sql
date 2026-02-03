CREATE PROCEDURE [dbo].[CreateEmployee]
	@Name NVARCHAR(100),
	@Position NVARCHAR(100),
	@Salary DECIMAL(18,2)
AS
BEGIN
	INSERT INTO Employees (Name, Position, Salary, IsActive)
	VALUES (@Name, @Position, @Salary, 1);
END