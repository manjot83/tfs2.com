INSERT INTO [Messages]
	(Id, MessageType, Title, ActiveFromDate, ActiveToDate, Content, Urgent, Announcement_CreatedBy)	
	SELECT NEWID(),
	       1 AS MessageType,
		   [subject] AS Title,		   
		   _posts.[createdon] AS ActiveFromDate,
		   '1/1/2010' AS ActiveToDate,
		   [content] AS Content,
		   [isurgent] AS Urgent,
		   Users.Id AS Announcement_CreatedBy
		FROM [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[newsposts] AS _posts
		INNER JOIN [APOLLO.TFS2.COM].[tfs_opcenter].[dbo].[persons] AS _persons
			ON _posts.personid = _persons.id
		INNER JOIN Users
			ON _persons.username = Users.Username
GO