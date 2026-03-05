CREATE PROCEDURE [dbo].[spEmployee_Update]
    @Id         INT,
    @FirstName  NVARCHAR(50),
    @LastName   NVARCHAR(50),
    @Position   NVARCHAR(50),
    @Department NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Employee]
    SET [FirstName] = @FirstName,
        [LastName]  = @LastName,
        [Position]  = @Position,
        [Department] = @Department
    WHERE [Id] = @Id;
END
GO