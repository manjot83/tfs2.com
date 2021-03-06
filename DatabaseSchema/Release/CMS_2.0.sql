CREATE TABLE [dbo].[Images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContentType] [varchar](50) NOT NULL,
	[Description] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Images] ([ID] ASC)
)
GO

CREATE TABLE [dbo].[StaticContentAttributes](
	[uri] [varchar](50) NOT NULL,
	[AttributeType] [varchar](50) NOT NULL,
	[AttributeValue] [ntext] NOT NULL
)
GO

CREATE TABLE [dbo].[StaticContent](
	[uri] [varchar](50) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[isLink] [bit] NOT NULL CONSTRAINT [DF_StaticContent_isLink]  DEFAULT ((0)),
	[active] [bit] NOT NULL CONSTRAINT [DF_StaticContent_active]  DEFAULT ((1))
)
GO