USE [tfs_opcenter]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formfiles]') AND name = N'ix_formid')
CREATE NONCLUSTERED INDEX [ix_formid] ON [dbo].[formfiles]
(
    [formid] ASC
);
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_fileid')
CREATE NONCLUSTERED INDEX [ix_fileid] ON [dbo].[formrecords]
(
    [fileid] ASC
);
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_fieldid')
CREATE NONCLUSTERED INDEX [ix_fieldid] ON [dbo].[formrecords]
(
    [fieldid] ASC
);
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[formrecords]') AND name = N'ix_codeid')
CREATE NONCLUSTERED INDEX [ix_codeid] ON [dbo].[formrecords]
(
    [codeid] ASC
);
GO