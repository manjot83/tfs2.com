ALTER TABLE dbo.Users ADD CONSTRAINT
	IX_Users_Username UNIQUE NONCLUSTERED (Username)
GO

ALTER TABLE dbo.Pages ADD CONSTRAINT
	IX_Pages_URI UNIQUE NONCLUSTERED (URI)
GO