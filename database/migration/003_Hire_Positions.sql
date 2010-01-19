INSERT INTO [Positions] (Id, Title)
    SELECT NEWID(), [name]
    FROM [APOLLO.TFS2.COM].[tfs2_billing].[dbo].[RateGroups]
GO