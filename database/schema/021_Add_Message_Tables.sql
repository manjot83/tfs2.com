 CREATE TABLE [Messages] (
   Id UNIQUEIDENTIFIER NOT NULL,
   MessageType INT NOT NULL,
   Title NVARCHAR(100) NOT NULL,
   ActiveFromDate datetime2(7) NOT NULL,
   ActiveToDate datetime2(7) NOT NULL,
   Content NVARCHAR(MAX) NULL,
   Urgent BIT NULL,
   Announcement_CreatedBy UNIQUEIDENTIFIER NULL,
   UserAlert_UserId UNIQUEIDENTIFIER NULL,
   CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id])
)

CREATE TABLE [MessagesForUsers] (
   UserId UNIQUEIDENTIFIER NOT NULL,
   MessageId UNIQUEIDENTIFIER NOT NULL,
   SeenAtDate datetime2(7) NOT NULL,
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
