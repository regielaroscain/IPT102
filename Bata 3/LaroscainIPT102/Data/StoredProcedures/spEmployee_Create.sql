CREATE PROCEDURE [dbo].[spEmployee_Create]
    @FirstName  NVARCHAR(50),
    @LastName   NVARCHAR(50),
    @Position   NVARCHAR(50),
    @Department NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[Employee] ([FirstName], [LastName], [Position], [Department])
    VALUES (@FirstName, @LastName, @Position, @Department);
END
GO