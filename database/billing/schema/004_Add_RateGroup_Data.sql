SET IDENTITY_INSERT [RateGroups] ON
GO
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (1,'Program Manager',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (2,'Pilot',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (3,'Flight Engineer',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (4,'Admin',0,NULL,NULL,NULL,NULL);
SET IDENTITY_INSERT [RateGroups] OFF
GO
dbcc checkident ([RateGroups], reseed, 5);
GO