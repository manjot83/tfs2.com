SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articlecategories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[articlecategories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_articlecategories_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[availability]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[availability](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personid] [int] NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[day] [int] NOT NULL,
	[isavailable] [bit] NOT NULL CONSTRAINT [DF_availability_isvailable]  DEFAULT ((0)),
 CONSTRAINT [PK_availability] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[externallinks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[externallinks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[navurl] [varchar](250) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_externallinks_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_links] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[formcodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[formcodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldid] [int] NOT NULL,
	[label] [varchar](50) NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_form_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formcodes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[formfields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[formfields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[formid] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[metadata] [text] NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_formfields_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formfields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[formfiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[formfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[formid] [int] NOT NULL,
	[personid] [int] NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_formfiles_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[formrecords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileid] [int] NOT NULL,
	[fieldid] [int] NOT NULL,
	[codeid] [int] NULL,
	[storedvalue] [text] NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_formrecords_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_formrecords] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[shortname] [varchar](50) NULL,
	[tfsfnumber] [varchar](50) NULL,
	[remarks] [varchar](255) NULL,
	[keyfieldid] [int] NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_forms_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_forms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[helparticles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[helparticles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[content] [ntext] NOT NULL,
	[deleted] [bit] NULL CONSTRAINT [DF_helparticles_deleted]  DEFAULT ((0)),
	[createdon] [datetime] NOT NULL,
	[modifiedon] [datetime] NULL,
	[createdby] [varchar](50) NULL,
	[modifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_helparticles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[newsposts]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[persons]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_persons_email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_persons_username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_availability_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[availability]'))
ALTER TABLE [dbo].[availability]  WITH CHECK ADD  CONSTRAINT [FK_availability_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_availability_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[availability]'))
ALTER TABLE [dbo].[availability] CHECK CONSTRAINT [FK_availability_persons]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formcodes_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[formcodes]'))
ALTER TABLE [dbo].[formcodes]  WITH CHECK ADD  CONSTRAINT [FK_formcodes_formfields] FOREIGN KEY([fieldid])
REFERENCES [dbo].[formfields] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formcodes_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[formcodes]'))
ALTER TABLE [dbo].[formcodes] CHECK CONSTRAINT [FK_formcodes_formfields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfields_forms]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfields]'))
ALTER TABLE [dbo].[formfields]  WITH CHECK ADD  CONSTRAINT [FK_formfields_forms] FOREIGN KEY([formid])
REFERENCES [dbo].[forms] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfields_forms]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfields]'))
ALTER TABLE [dbo].[formfields] CHECK CONSTRAINT [FK_formfields_forms]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_forms]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfiles]'))
ALTER TABLE [dbo].[formfiles]  WITH CHECK ADD  CONSTRAINT [FK_formfiles_forms] FOREIGN KEY([formid])
REFERENCES [dbo].[forms] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_forms]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfiles]'))
ALTER TABLE [dbo].[formfiles] CHECK CONSTRAINT [FK_formfiles_forms]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfiles]'))
ALTER TABLE [dbo].[formfiles]  WITH CHECK ADD  CONSTRAINT [FK_formfiles_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[formfiles]'))
ALTER TABLE [dbo].[formfiles] CHECK CONSTRAINT [FK_formfiles_persons]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_personnelfiles]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formfiles_personnelfiles] FOREIGN KEY([fileid])
REFERENCES [dbo].[formfiles] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formfiles_personnelfiles]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formfiles_personnelfiles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formrecords_formcodes]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formrecords_formcodes] FOREIGN KEY([codeid])
REFERENCES [dbo].[formcodes] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formrecords_formcodes]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formrecords_formcodes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formrecords_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords]  WITH CHECK ADD  CONSTRAINT [FK_formrecords_formfields] FOREIGN KEY([fieldid])
REFERENCES [dbo].[formfields] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_formrecords_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[formrecords]'))
ALTER TABLE [dbo].[formrecords] CHECK CONSTRAINT [FK_formrecords_formfields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_forms_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[forms]'))
ALTER TABLE [dbo].[forms]  WITH CHECK ADD  CONSTRAINT [FK_forms_formfields] FOREIGN KEY([keyfieldid])
REFERENCES [dbo].[formfields] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_forms_formfields]') AND parent_object_id = OBJECT_ID(N'[dbo].[forms]'))
ALTER TABLE [dbo].[forms] CHECK CONSTRAINT [FK_forms_formfields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_articlecategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts]  WITH CHECK ADD  CONSTRAINT [FK_newsposts_articlecategories] FOREIGN KEY([categoryid])
REFERENCES [dbo].[articlecategories] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_articlecategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] CHECK CONSTRAINT [FK_newsposts_articlecategories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts]  WITH NOCHECK ADD  CONSTRAINT [FK_newsposts_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
NOT FOR REPLICATION 
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] NOCHECK CONSTRAINT [FK_newsposts_persons]
GO
