CREATE FUNCTION temp_getpersonidfromname
(
	@username VARCHAR(50)
)
RETURNS INT
AS
BEGIN	
	DECLARE @id INT
	SELECT @id = [id] FROM [persons] ORDER BY [id]
	SELECT @id = [id] FROM [persons] WHERE [username] = @username
	RETURN @id
END
GO