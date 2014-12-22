IF NOT EXISTS (SELECT * FROM sys.columns WHERE name = 'PasswordHash' and object_id = OBJECT_ID('dbo.Users'))
BEGIN
ALTER TABLE dbo.Users ADD PasswordHash nvarchar(1000) NULL;
END
GO

UPDATE dbo.Users SET PasswordHash = 'vz95XUvetbBwqHjaZLrXmmwqTB8wOXaNjf1u6F6EX1U=' WHERE PasswordHash IS NULL;
GO