CREATE PROCEDURE [dbo].[DeleteEmployee]
	@Id INT
AS
BEGIN
	UPDATE Employees SET IsActive = 0 WHERE Id = @Id;
END