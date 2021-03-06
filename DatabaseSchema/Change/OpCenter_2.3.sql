/*

Changes the Forms table to add some columns

*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.forms
	DROP CONSTRAINT DF_forms_deleted
GO
CREATE TABLE dbo.Tmp_forms
	(
	id int NOT NULL IDENTITY (1, 1),
	name varchar(50) NOT NULL,
	shortname varchar(50) NULL,
	tfsfnumber varchar(50) NULL,
	remarks varchar(255) NULL,
	deleted bit NULL,
	createdon datetime NULL,
	modifiedon datetime NULL,
	createdby varchar(50) NULL,
	modifiedby varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_forms ADD CONSTRAINT
	DF_forms_deleted DEFAULT ((0)) FOR deleted
GO
SET IDENTITY_INSERT dbo.Tmp_forms ON
GO
IF EXISTS(SELECT * FROM dbo.forms)
	 EXEC('INSERT INTO dbo.Tmp_forms (id, name, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, name, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.forms WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_forms OFF
GO
ALTER TABLE dbo.formfiles
	DROP CONSTRAINT FK_formfiles_forms
GO
ALTER TABLE dbo.formfields
	DROP CONSTRAINT FK_formfields_forms
GO
DROP TABLE dbo.forms
GO
EXECUTE sp_rename N'dbo.Tmp_forms', N'forms', 'OBJECT' 
GO
ALTER TABLE dbo.forms ADD CONSTRAINT
	PK_forms PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formfields ADD CONSTRAINT
	FK_formfields_forms FOREIGN KEY
	(
	formid
	) REFERENCES dbo.forms
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formfiles ADD CONSTRAINT
	FK_formfiles_forms FOREIGN KEY
	(
	formid
	) REFERENCES dbo.forms
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

/* Add field to form records for text */

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT FK_formrecords_formfields
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT FK_formfiles_personnelfiles
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT FK_formrecords_formcodes
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT DF_formrecords_deleted
GO
CREATE TABLE dbo.Tmp_formrecords
	(
	id int NOT NULL IDENTITY (1, 1),
	fileid int NOT NULL,
	fieldid int NOT NULL,
	codeid int NULL,
	storedvalue varchar(50) NULL,
	storedtext text NULL,
	deleted bit NULL,
	createdon datetime NULL,
	modifiedon datetime NULL,
	createdby varchar(50) NULL,
	modifiedby varchar(50) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_formrecords ADD CONSTRAINT
	DF_formrecords_deleted DEFAULT ((0)) FOR deleted
GO
SET IDENTITY_INSERT dbo.Tmp_formrecords ON
GO
IF EXISTS(SELECT * FROM dbo.formrecords)
	 EXEC('INSERT INTO dbo.Tmp_formrecords (id, fileid, fieldid, codeid, storedvalue, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, fileid, fieldid, codeid, storedvalue, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.formrecords WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_formrecords OFF
GO
DROP TABLE dbo.formrecords
GO
EXECUTE sp_rename N'dbo.Tmp_formrecords', N'formrecords', 'OBJECT' 
GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT
	PK_formrecords PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT
	FK_formrecords_formcodes FOREIGN KEY
	(
	codeid
	) REFERENCES dbo.formcodes
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT
	FK_formfiles_personnelfiles FOREIGN KEY
	(
	fileid
	) REFERENCES dbo.formfiles
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT
	FK_formrecords_formfields FOREIGN KEY
	(
	fieldid
	) REFERENCES dbo.formfields
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

/*

Add metadata field to formfields

*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formfields
	DROP CONSTRAINT FK_formfields_forms
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formfields
	DROP CONSTRAINT DF_formfields_deleted
GO
CREATE TABLE dbo.Tmp_formfields
	(
	id int NOT NULL IDENTITY (1, 1),
	formid int NOT NULL,
	name varchar(50) NOT NULL,
	metadata text NULL,
	deleted bit NULL,
	createdon datetime NULL,
	modifiedon datetime NULL,
	createdby varchar(50) NULL,
	modifiedby varchar(50) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_formfields ADD CONSTRAINT
	DF_formfields_deleted DEFAULT ((0)) FOR deleted
GO
SET IDENTITY_INSERT dbo.Tmp_formfields ON
GO
IF EXISTS(SELECT * FROM dbo.formfields)
	 EXEC('INSERT INTO dbo.Tmp_formfields (id, formid, name, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, formid, name, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.formfields WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_formfields OFF
GO
ALTER TABLE dbo.formcodes
	DROP CONSTRAINT FK_formcodes_formfields
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT FK_formrecords_formfields
GO
DROP TABLE dbo.formfields
GO
EXECUTE sp_rename N'dbo.Tmp_formfields', N'formfields', 'OBJECT' 
GO
ALTER TABLE dbo.formfields ADD CONSTRAINT
	PK_formfields PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.formfields ADD CONSTRAINT
	FK_formfields_forms FOREIGN KEY
	(
	formid
	) REFERENCES dbo.forms
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT
	FK_formrecords_formfields FOREIGN KEY
	(
	fieldid
	) REFERENCES dbo.formfields
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formcodes ADD CONSTRAINT
	FK_formcodes_formfields FOREIGN KEY
	(
	fieldid
	) REFERENCES dbo.formfields
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT


/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.3', '8/7/2008', GetDate() )