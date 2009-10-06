CREATE VIEW [dbo].[vw_Users]
AS
SELECT [Tmp_Users].[id], [username], [firstname], [lastname], [title], [rategroup], [RateGroups].[name] as [rategroupname] 
FROM [Tmp_Users]
INNER JOIN [RateGroups] ON [RateGroups].[id] = [Tmp_Users].[rategroup]
GO