CREATE PROCEDURE [dbo].[spEmployee_Search]
    @SearchText NVARCHAR(50)
AS
BEGIN
    SELECT [Id], [FirstName], [LastName], [Position], [Department]
    FROM [dbo].[Employee]
    WHERE [FirstName] LIKE '%' + @SearchText + '%' 
       OR [LastName]  LIKE '%' + @SearchText + '%';
END
GO