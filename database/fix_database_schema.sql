-- FIX FK
USE [tfs_opcenter]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] DROP CONSTRAINT [FK_newsposts_persons]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts]  WITH NOCHECK ADD  CONSTRAINT [FK_newsposts_persons] FOREIGN KEY([personid])
REFERENCES [dbo].[persons] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_newsposts_persons]') AND parent_object_id = OBJECT_ID(N'[dbo].[newsposts]'))
ALTER TABLE [dbo].[newsposts] NOCHECK CONSTRAINT [FK_newsposts_persons]
GO