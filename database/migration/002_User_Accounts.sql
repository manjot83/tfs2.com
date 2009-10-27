INSERT INTO [Users] (FirstName, LastName, DisplayName, Email, Username, [Disabled])
    SELECT [firstname],[lastname],[displayname],[email],[username],[deleted] as [Disabled]
    FROM [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[persons]
GO