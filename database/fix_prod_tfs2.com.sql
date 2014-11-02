USE [prod_tfs2.com]
GO
ALTER TABLE PageStaticImages ADD Id int IDENTITY NOT NULL;
GO
ALTER TABLE dbo.PageStaticImages ADD CONSTRAINT PK_PageStaticImages PRIMARY KEY CLUSTERED  ( Id )
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[df_deleted]') AND OBJECTPROPERTY(object_id, N'IsDefault') = 1)
DROP DEFAULT [dbo].[df_deleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[df_false]') AND OBJECTPROPERTY(object_id, N'IsDefault') = 1)
DROP DEFAULT [dbo].[df_false]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_datareader] TO [db_datareader]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_datawriter] TO [db_datawriter]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [dbo]
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'webapp')
DROP USER [webapp]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[schema_info]') AND type in (N'U'))
DROP TABLE [dbo].[schema_info]
GO

-- missing column
IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'PayrollAdmin' AND object_id = OBJECT_ID('Users'))
ALTER TABLE Users ADD PayrollAdmin bit NOT NULL CONSTRAINT DF_Users_PayrollAdmin DEFAULT (0);
IF EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF_Users_PayrollAdmin')
ALTER TABLE Users DROP CONSTRAINT DF_Users_PayrollAdmin;
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

-- 
-- Missing Columns

IF NOT EXISTS (SELECT * FROM sys.columns WHERE name = 'title' AND object_id = OBJECT_ID('Users'))
ALTER TABLE Users ADD title nvarchar(255) NOT NULL CONSTRAINT DF_Users_title DEFAULT ('NOT SET');
GO
IF EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF_Users_title')
ALTER TABLE Users DROP CONSTRAINT DF_Users_title;
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE name = 'rategroup' AND object_id = OBJECT_ID('Users'))
ALTER TABLE Users ADD rategroup int NOT NULL CONSTRAINT DF_Users_rategroup DEFAULT (-1);
GO
IF EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF_Users_rategroup')
ALTER TABLE Users DROP CONSTRAINT DF_Users_rategroup;
GO
