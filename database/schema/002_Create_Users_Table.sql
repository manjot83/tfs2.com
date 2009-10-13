CREATE DEFAULT [dbo].[df_deleted]
AS
   0
GO

CREATE TABLE Users (
       Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(100) NOT NULL,
       LastName NVARCHAR(100) NOT NULL,
       DisplayName NVARCHAR(150) NOT NULL,
       Email NVARCHAR(254) NOT NULL,
       Username NVARCHAR(100) NOT NULL,
       [Disabled] BIT NOT NULL,
       PasswordHash NVARCHAR(25) null,
       CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id])
    )
    
EXEC sys.sp_bindefault @defname=N'[dbo].[df_deleted]', @objname=N'[dbo].[Users].[Disabled]' , @futureonly='futureonly'
GO