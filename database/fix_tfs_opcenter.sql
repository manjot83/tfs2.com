-- FIX FK
USE [tfs_opcenter]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] DROP CONSTRAINT [FK_newsposts_persons]
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'TFS2\IUSR_APOLLO')
DROP USER [TFS2\IUSR_APOLLO]
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'webdbreader')
DROP USER [webdbreader]
GO

-- Missing Indexes
USE [tfs_opcenter]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[forms]') AND name = N'ix_keyfieldid')
CREATE NONCLUSTERED INDEX [ix_keyfieldid] ON [dbo].[forms] ( [keyfieldid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formfiles]') AND name = N'ix_formid')
CREATE NONCLUSTERED INDEX [ix_formid] ON [dbo].[formfiles] ( [formid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formfiles]') AND name = N'ix_personid')
CREATE NONCLUSTERED INDEX [ix_personid] ON [dbo].[formfiles] ( [personid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_fileid')
CREATE NONCLUSTERED INDEX [ix_fileid] ON [dbo].[formrecords] ( [fileid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_fieldid')
CREATE NONCLUSTERED INDEX [ix_fieldid] ON [dbo].[formrecords] ( [fieldid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_codeid')
CREATE NONCLUSTERED INDEX [ix_codeid] ON [dbo].[formrecords] ( [codeid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formcodes]') AND name = N'ix_fieldid')
CREATE NONCLUSTERED INDEX [ix_fieldid] ON [dbo].[formcodes] ( [fieldid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formfields]') AND name = N'ix_formid')
CREATE NONCLUSTERED INDEX [ix_formid] ON [dbo].[formfields] ( [formid] ASC );
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formfields]') AND name = N'ix_name')
CREATE NONCLUSTERED INDEX [ix_name] ON [dbo].[formfields] ( [name] ASC );
GO

-- Fix indexes
USE [tfs_opcenter]
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

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'persons')
EXEC sp_rename 'dbo.persons', 'tmp_persons';
GO
IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'PK_persons')
EXEC sp_rename 'dbo.tmp_persons.PK_persons', 'PK_tmp_persons';
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_availability_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[availability]'))
ALTER TABLE [dbo].[availability] DROP CONSTRAINT [FK_availability_persons]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfiles]'))
ALTER TABLE [dbo].[formfiles] DROP CONSTRAINT [FK_formfiles_persons]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] DROP CONSTRAINT [FK_newsposts_persons]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_forms_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[forms]'))
ALTER TABLE [dbo].[forms] DROP CONSTRAINT [FK_forms_formfields]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dbversion]') AND type in (N'U'))
DROP TABLE [dbo].[dbversion]
GO