IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
DROP VIEW [dbo].[vw_Users]
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_Users]
AS
SELECT	Users.id,
		Users.username,
		Users.firstname,
		Users.lastname,
		Users.title,
		Users.rategroup,
		[RateGroups].[name] as [rategroupname]
 FROM Users
  INNER JOIN [RateGroups] ON [RateGroups].[id] = rategroup	
WHERE Users.disabled = 0
' 
GO

UPDATE Users
SET title = old.title,
    rategroup = old.rategroup
FROM Users
INNER JOIN Tmp_Users old on Users.Username = old.username;
GO

UPDATE Users
SET [identity] = old.id
FROM Users
INNER JOIN tmp_persons old on Users.Username = old.username;
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_persons]'))
DROP VIEW [dbo].[vw_persons]
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_persons]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_persons]
AS
SELECT [id] = [identity]
      ,[firstname]
      ,[lastname]
      ,[email]
      ,[username]
      ,[displayname]
      ,[deleted] = Disabled
      ,[createdon] = ''2000-01-01''
      ,[modifiedon] = ''2000-01-01''
      ,[createdby] = ''system''
      ,[modifiedby] = ''system''
  FROM [dbo].[Users]
  WHERE [identity] is not null
  '
GO

