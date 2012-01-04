SET IDENTITY_INSERT [RateGroups] ON
GO
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (8,'Navigator',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (9,'Loadmaster',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (10,'Co-Pilot',0,NULL,NULL,NULL,NULL);
SET IDENTITY_INSERT [RateGroups] OFF
GO
dbcc checkident ([RateGroups], reseed, 11);
GO