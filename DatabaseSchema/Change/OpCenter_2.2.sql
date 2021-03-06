CREATE TABLE [dbo].[forms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,	
	[deleted] [bit] NULL CONSTRAINT [DF_forms_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_forms] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

/* rename table */
ALTER TABLE dbo.personnelfiles
	DROP CONSTRAINT FK_personnelfiles_persons
GO
ALTER TABLE dbo.personnelfiles
	DROP CONSTRAINT DF_personnelfiles_deleted
GO
CREATE TABLE dbo.Tmp_personnelfiles
	(
	id int NOT NULL IDENTITY (1, 1),
	formid int NOT NULL,
	personid int NULL,
	deleted bit NULL,
	createdon datetime NULL,
	modifiedon datetime NULL,
	createdby varchar(50) NULL,
	modifiedby varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_personnelfiles ADD CONSTRAINT
	DF_formfiles_deleted DEFAULT ((0)) FOR deleted
GO
SET IDENTITY_INSERT dbo.Tmp_personnelfiles ON
GO
IF EXISTS(SELECT * FROM dbo.personnelfiles)
	 EXEC('INSERT INTO dbo.Tmp_personnelfiles (id, personid, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, personid, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.personnelfiles WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_personnelfiles OFF
GO
ALTER TABLE dbo.formrecords
	DROP CONSTRAINT FK_formrecords_personnelfiles
GO
DROP TABLE dbo.personnelfiles
GO
EXECUTE sp_rename N'dbo.Tmp_personnelfiles', N'formfiles', 'OBJECT' 
GO
ALTER TABLE dbo.formfiles ADD CONSTRAINT
	PK_formfiles PRIMARY KEY CLUSTERED 
	(id) ON [PRIMARY]
GO
ALTER TABLE dbo.formfiles ADD CONSTRAINT FK_formfiles_persons FOREIGN KEY (personid) 
	REFERENCES dbo.persons (id) 
GO
ALTER TABLE [dbo].formfiles CHECK CONSTRAINT FK_formfiles_persons
GO
ALTER TABLE dbo.formrecords ADD CONSTRAINT FK_formfiles_personnelfiles FOREIGN KEY (fileid)
	REFERENCES dbo.formfiles (id)
GO
ALTER TABLE [dbo].formrecords CHECK CONSTRAINT FK_formfiles_personnelfiles
GO
/*end rename table */

ALTER TABLE [dbo].[formfiles] ADD CONSTRAINT [FK_formfiles_forms] FOREIGN KEY (formid) 
	REFERENCES [dbo].[forms] (id)
GO
ALTER TABLE [dbo].[formfiles] CHECK CONSTRAINT [FK_formfiles_forms]
GO

/* Add formid to formfields */
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
	DROP CONSTRAINT DF_formfields_deleted
GO
CREATE TABLE dbo.Tmp_formfields
	(
	id int NOT NULL IDENTITY (1, 1),
	formid int NOT NULL,
	name varchar(50) NOT NULL,
	deleted bit NULL,
	createdon datetime NULL,
	modifiedon datetime NULL,
	createdby varchar(50) NULL,
	modifiedby varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_formfields ADD CONSTRAINT
	DF_formfields_deleted DEFAULT ((0)) FOR deleted
GO
SET IDENTITY_INSERT dbo.Tmp_formfields ON
GO
IF EXISTS(SELECT * FROM dbo.formfields)
	 EXEC('INSERT INTO dbo.Tmp_formfields (id, name, deleted, createdon, modifiedon, createdby, modifiedby)
		SELECT id, name, deleted, createdon, modifiedon, createdby, modifiedby FROM dbo.formfields WITH (HOLDLOCK TABLOCKX)')
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
/* End Add formid to formfields */


ALTER TABLE [dbo].[formfields] ADD CONSTRAINT [FK_formfields_forms] FOREIGN KEY (formid) 
	REFERENCES [dbo].[forms] (id)
GO
ALTER TABLE [dbo].[formfields] CHECK CONSTRAINT [FK_formfields_forms]
GO


/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.2', '7/29/2008', GetDate() )