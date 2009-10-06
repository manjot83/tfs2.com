USE tfs_opcenter

/*first delete all data*/
DELETE FROM [newsposts];
DELETE FROM [externallinks];
DELETE FROM [articlecategories];
DELETE FROM [helparticles];
DELETE FROM [availability];

/* create temp functions */

/*first table, externallinks*/

SET IDENTITY_INSERT [externallinks] ON
GO
INSERT INTO [externallinks] ([id], [name], [navurl], [deleted])
	SELECT [id], [linkname] as [name], [navurl], 0 as [deleted] FROM [tfs2_intranet]..[links]
GO
SET IDENTITY_INSERT [externallinks] OFF
GO

/*next table, [articlecategories]*/

SET IDENTITY_INSERT [articlecategories] ON
GO
INSERT INTO [articlecategories] ([id], [name], [description], [deleted])
	SELECT [id], [name], [description], 0 as [deleted] FROM [tfs2_intranet]..[categories]
GO
SET IDENTITY_INSERT [articlecategories] OFF
GO

/*next table, [helparticles]*/

SET IDENTITY_INSERT [helparticles] ON
GO
INSERT INTO [helparticles] ([id], [subject], [content], [createdon], [deleted])
	SELECT [id], [subject], [content], [postdate], 0 as [deleted] FROM [tfs2_intranet]..[helparticles]
GO
SET IDENTITY_INSERT [helparticles] OFF
GO

/*next table, [newsposts]*/

SET IDENTITY_INSERT [newsposts] ON
GO
INSERT INTO [newsposts] ([id], [personid], [subject], [content], [categoryid], [createdon], [isurgent], [deleted])
	SELECT [id], [dbo].[temp_getpersonidfromname]([postuser]) as [personid], [subject], [content], [dbo].[temp_getarticlecategory](), [postdate], 0 as [isurgent], 0 as [deleted] FROM [tfs2_intranet]..[posts]
GO
SET IDENTITY_INSERT [newsposts] OFF
GO

/*next table, [availability]*/

SET IDENTITY_INSERT [availability] ON
GO
INSERT INTO [availability] ([id], [personid], [month], [year], [day], [isavailable])
	SELECT [id], [dbo].[temp_getpersonidfromname]([Username]) as [personid], [Month], [Year], [Day], [available] as [isavailable] FROM [tfs2_scheduling]..[availability]
GO
SET IDENTITY_INSERT [availability] OFF
GO

/* drop temp functions */
DROP FUNCTION temp_getpersonidfromname
GO
DROP FUNCTION temp_getarticlecategory
GO