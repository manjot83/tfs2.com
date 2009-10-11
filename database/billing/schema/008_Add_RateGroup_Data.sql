SET IDENTITY_INSERT [RateGroups] ON
GO
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (5,'Developer',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (6,'Developer Coordinator',0,NULL,NULL,NULL,NULL);
INSERT INTO [dbo].[RateGroups] ([id],[name],[IsDeleted],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]) VALUES (7,'FCF Pilot',0,NULL,NULL,NULL,NULL);
SET IDENTITY_INSERT [RateGroups] OFF
GO
dbcc checkident ([RateGroups], reseed, 8);
GO