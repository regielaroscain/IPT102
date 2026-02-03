CREATE PROCEDURE [dbo].[UpdateEmployee]
	@Id INT,
	@Name NVARCHAR(100),
	@Position NVARCHAR(100),
	@Salary DECIMAL(18,2)
AS
BEGIN
	UPDATE Employees 
	SET Name = @Name, Position = @Position, Salary = @Salary 
	WHERE Id = @Id;
END