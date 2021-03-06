CREATE TABLE [dbo].[personnelfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personid] [int] NULL,	
	[deleted] [bit] NULL CONSTRAINT [DF_personnelfiles_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_personnelfiles] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[formfields](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[name] [varchar](50) NOT NULL,	
	[deleted] [bit] NULL CONSTRAINT [DF_formfields_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formfields] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[formcodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldid] [int] NOT NULL,	
	[label] [varchar](50) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_form_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formcodes] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[formrecords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileid] [int] NOT NULL,
	[fieldid] [int] NOT NULL,
	[codeid] [int] NULL,
	[storedvalue] [varchar](50) NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_formrecords_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formrecords] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

ALTER TABLE [dbo].[personnelfiles]  WITH CHECK ADD  CONSTRAINT [FK_personnelfiles_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
GO
ALTER TABLE [dbo].[personnelfiles] CHECK CONSTRAINT [FK_personnelfiles_persons]
GO

ALTER TABLE [dbo].[formcodes]  WITH CHECK ADD  CONSTRAINT [FK_formcodes_formfields] FOREIGN KEY([fieldid])
REFERENCES [dbo].[formfields] ([id])
GO
ALTER TABLE [dbo].[formcodes] CHECK CONSTRAINT [FK_formcodes_formfields]
GO

ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formrecords_personnelfiles] FOREIGN KEY([fileid])
REFERENCES [dbo].[personnelfiles] ([id])
GO
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formrecords_personnelfiles]
GO

ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formrecords_formfields] FOREIGN KEY([fieldid])
REFERENCES [dbo].[formfields] ([id])
GO
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formrecords_formfields]

ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formrecords_formcodes] FOREIGN KEY([codeid])
REFERENCES [dbo].[formcodes] ([id])
GO
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formrecords_formcodes]


/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.1', '7/17/2008', GetDate() )