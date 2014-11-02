USE tfs2_billing
GO 

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[schema_info]') AND type in (N'U'))
DROP TABLE [dbo].[schema_info]
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'webdbreader')
DROP USER [webdbreader]
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'IUSR_APOLLO')
DROP USER [IUSR_APOLLO]
GO


declare @table_name varchar(200)
declare @SQL varchar(300)

DECLARE vendor_cursor cursor 
        FOR SELECT sys.tables.name
        FROM sys.tables WHERE sys.tables.name NOT LIKE '%_dss'
OPEN vendor_cursor

FETCH NEXT FROM vendor_cursor 
INTO @table_name

WHILE @@FETCH_STATUS = 0
BEGIN
 SELECT @SQL =  'ALTER INDEX ALL ON '+@table_name+' REBUILD WITH ( ALLOW_PAGE_LOCKS = ON )';
 EXEC(@SQL);
 print 'INDEX Rebuild on all indexes in table '+@table_name+' is done.';
 FETCH NEXT FROM vendor_cursor  INTO @table_name
END 
CLOSE vendor_cursor;
DEALLOCATE vendor_cursor;
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
DROP VIEW [dbo].[vw_Users]
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Users]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_Users]
AS
SELECT	Tmp_Users.id,
		Tmp_Users.username,
		Tmp_Users.firstname,
		Tmp_Users.lastname,
		Tmp_Users.title,
		Tmp_Users.rategroup,
		[RateGroups].[name] as [rategroupname]
 FROM Tmp_Users
  INNER JOIN [RateGroups] ON [RateGroups].[id] = rategroup	
' 
GO

