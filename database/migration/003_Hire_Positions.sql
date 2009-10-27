INSERT INTO [Positions] (Title)
    SELECT [name]
    FROM [APOLLO.TFS2.COM].[tfs2_billing].[dbo].[RateGroups]
GO