CREATE FUNCTION temp_getarticlecategory
(
	
)
RETURNS INT
AS
BEGIN	
	DECLARE @id INT
	SELECT @id = [id] FROM [articlecategories] ORDER BY [id]
	RETURN @id
END
GO
