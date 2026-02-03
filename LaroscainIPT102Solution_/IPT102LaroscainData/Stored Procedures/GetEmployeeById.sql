CREATE PROCEDURE [dbo].[GetEmployeeById]
	@Id INT
AS
BEGIN
	SELECT Id, Name, Position, Salary 
    FROM Employees 
    WHERE Id = @Id AND IsActive = 1;
END