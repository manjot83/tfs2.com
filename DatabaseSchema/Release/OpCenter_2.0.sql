CREATE TABLE [dbo].[persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](100) NOT NULL,
	[lastname] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[displayname] [varchar](150) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_persons_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED ([id] ASC),
 CONSTRAINT [IX_persons_email] UNIQUE NONCLUSTERED ([email] ASC),
 CONSTRAINT [IX_persons_username] UNIQUE NONCLUSTERED ([username] ASC)
)
GO

CREATE TABLE [dbo].[externallinks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[navurl] [varchar](250) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_externallinks_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_links] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[helparticles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[content] [ntext] NOT NULL,	
	[deleted] [bit] NULL CONSTRAINT [DF_helparticles_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NOT NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_helparticles] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[articlecategories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](100) NOT NULL,	
	[deleted] [bit] NULL CONSTRAINT [DF_articlecategories_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED ([id] ASC)
) 
GO

CREATE TABLE [dbo].[newsposts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personid] [int] NOT NULL,
	[categoryid] [int] NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[content] [ntext] NOT NULL,
	[isurgent] [bit] NOT NULL CONSTRAINT [DF_newsposts_isurgent]  DEFAULT ((0)),	
	[deleted] [bit] NULL CONSTRAINT [DF_newsposts_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NOT NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[availability](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personid] [int] NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[day] [int] NOT NULL,
	[isavailable] [bit] NOT NULL CONSTRAINT [DF_availability_isvailable]  DEFAULT ((0)),
 CONSTRAINT [PK_availability] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

CREATE TABLE [dbo].[dbversion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NOT NULL,
	[createdon] [datetime] NOT NULL,
	[appliedon] [datetime] NULL,
 CONSTRAINT [PK_dbversion] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

ALTER TABLE [dbo].[newsposts]  WITH NOCHECK ADD  CONSTRAINT [FK_newsposts_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[newsposts] NOCHECK CONSTRAINT [FK_newsposts_persons]
GO

ALTER TABLE [dbo].[newsposts]  WITH CHECK ADD  CONSTRAINT [FK_newsposts_articlecategories] FOREIGN KEY([categoryid])
REFERENCES [dbo].[articlecategories] ([id])
GO
ALTER TABLE [dbo].[newsposts] CHECK CONSTRAINT [FK_newsposts_articlecategories]
GO

ALTER TABLE [dbo].[availability]  WITH CHECK ADD  CONSTRAINT [FK_availability_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
GO
ALTER TABLE [dbo].[availability] CHECK CONSTRAINT [FK_availability_persons]
GO


/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.0', '7/1/2008', GetDate() )