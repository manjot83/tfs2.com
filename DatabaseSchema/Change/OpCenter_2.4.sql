/* drop the storedvalue varchar(50) column, rename storedtext as storedvalue */

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.formrecords
	DROP COLUMN storedvalue
GO
EXECUTE sp_rename N'dbo.formrecords.storedtext', N'Tmp_storedvalue', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.formrecords.Tmp_storedvalue', N'storedvalue', 'COLUMN' 
GO
COMMIT


/*version info*/
INSERT INTO [dbo].[dbversion] VALUES ('2.4', '8/24/2008', GetDate() )