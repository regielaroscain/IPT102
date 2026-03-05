CREATE PROCEDURE [dbo].[spEmployee_GetAll]
AS
BEGIN
    SELECT [Id], [FirstName], [LastName], [Position], [Department]
    FROM [dbo].[Employee];
END
GO