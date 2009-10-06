ALTER VIEW [dbo].[vw_Users]
AS
SELECT	0 AS id,
		sAMAccountName AS username,
		givenName as firstname,
		sn AS lastname,
		title as title,
		department as rategroup,
		[RateGroups].[name] as [rategroupname]
 FROM 
OpenQuery(ADSI, 
		'SELECT title, sn, givenName, sAMAccountName, department FROM ''LDAP://DC=TFS2,DC=LOCAL'' where objectClass = ''User'' and memberOf = ''CN=payrollUsers,OU=Security Groups,DC=tfs2,DC=local'' ')
  INNER JOIN [RateGroups] ON [RateGroups].[id] = department	
GO




/*

/*
ALTER VIEW [dbo].[vw_Users]
AS
SELECT [Tmp_Users].[id], [username], [firstname], [lastname], [title], [rategroup], [RateGroups].[name] as [rategroupname] 
FROM [Tmp_Users]
INNER JOIN [RateGroups] ON [RateGroups].[id] = [Tmp_Users].[rategroup]
GO

*/