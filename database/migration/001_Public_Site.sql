INSERT INTO [dev_tfs2.com].[dbo].[StaticImages] (Id, MimeType, [Description])
    SELECT NEWID() AS Id, ContentType AS MimeType, [Description] 
    FROM [tfs2_public_web].[dbo].[Images]
GO

INSERT INTO [dev_tfs2.com].[dbo].[Pages] (Id, URI, Title, Content, BannerFileName, HeaderFileName)
    SELECT NEWID() AS Id, StaticContent.URI, Title,
        [Content].AttributeValue as Content,
        [Banners].AttributeValue as BannerFileName, 
        [Headers].AttributeValue as HeaderFileName
    FROM [tfs2_public_web].[dbo].[StaticContent]
        INNER JOIN [tfs2_public_web].[dbo].[StaticContentAttributes] as [Headers] ON [Headers].uri = StaticContent.uri
        INNER JOIN [tfs2_public_web].[dbo].[StaticContentAttributes] as [Banners] ON [Banners].uri = StaticContent.uri
        INNER JOIN [tfs2_public_web].[dbo].[StaticContentAttributes] as [Content] ON [Content].uri = StaticContent.uri
        WHERE [Headers].AttributeType = 'pageheader'
        AND [Banners].AttributeType = 'banner'
        AND [Content].AttributeType = 'markdown'
GO