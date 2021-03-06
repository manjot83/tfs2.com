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
	keyfieldid int NULL,
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
	 EXEC('INSERT INTO dbo.Tmp_forms (id, name, shortname, tfsfnumber, remarks, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, name, shortname, tfsfnumber, remarks, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.forms WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_forms OFF
GO
ALTER TABLE dbo.formfields
	DROP CONSTRAINT FK_formfields_forms
GO
ALTER TABLE dbo.formfiles
	DROP CONSTRAINT FK_formfiles_forms
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
ALTER TABLE dbo.forms ADD CONSTRAINT
	FK_forms_formfields FOREIGN KEY
	(
	keyfieldid
	) REFERENCES dbo.formfields
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.5', '9/2/2008', GetDate() )