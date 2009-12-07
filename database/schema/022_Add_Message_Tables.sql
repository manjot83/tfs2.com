 CREATE TABLE [Messages] (
   Id INT IDENTITY NOT NULL,
   MessageType INT NOT NULL,
   Title NVARCHAR(100) NOT NULL,
   ActiveFromDate DATETIME NOT NULL,
   ActiveToDate DATETIME NOT NULL,
   Content NVARCHAR(255) NULL,
   Urgent BIT NULL,
   Announcement_CreatedBy INT NULL,
   UserAlert_UserId INT NULL,
   CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id])
)

CREATE TABLE [MessagesForUsers] (
   UserId INT NOT NULL,
   MessageId INT NOT NULL,
   SeenAtDate DATETIME NOT NULL,
   CONSTRAINT [PK_MessagesForUsers] PRIMARY KEY CLUSTERED (UserId, MessageId)
)

ALTER TABLE [Messages] 
    ADD CONSTRAINT FK_Announcement_Messages_Users 
    FOREIGN KEY (Announcement_CreatedBy) 
    REFERENCES Users

ALTER TABLE [Messages] 
    ADD CONSTRAINT FK_UserAlert_Messages_Users 
    FOREIGN KEY (UserAlert_UserId) 
    REFERENCES Users

ALTER TABLE [MessagesForUsers] 
    ADD CONSTRAINT FK_MessagesForUsers_Users 
    FOREIGN KEY (UserId) 
    REFERENCES Users

ALTER TABLE [MessagesForUsers] 
    ADD CONSTRAINT FK_MessagesForUsers_Messages 
    FOREIGN KEY (MessageId) 
    REFERENCES [Messages]
