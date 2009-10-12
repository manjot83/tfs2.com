CREATE TABLE Pages (
   Id UNIQUEIDENTIFIER not null,
   URI NVARCHAR(255) not null,
   Title NVARCHAR(255) not null,
   Content NVARCHAR(255) not null,
   PRIMARY KEY (Id)
)
GO

CREATE TABLE PageStaticImages (
   PageId UNIQUEIDENTIFIER not null,
   StaticImageId UNIQUEIDENTIFIER not null
)
GO

CREATE TABLE StaticImages (
   Id UNIQUEIDENTIFIER not null,
   MimeType NVARCHAR(255) not null,
   [Description] NVARCHAR(255) not null,
   PRIMARY KEY (Id)
)
GO

ALTER TABLE PageStaticImages 
    ADD CONSTRAINT FK_PageStaticImages_StaticImages
    FOREIGN KEY (StaticImageId)
    REFERENCES StaticImages
GO

ALTER TABLE PageStaticImages 
    ADD CONSTRAINT FK_PageStaticImages_Pages
    FOREIGN KEY (PageId)
    REFERENCES Pages
GO