declare @table_name varchar(200)
declare @SQL varchar(300)

DECLARE vendor_cursor cursor 
        FOR SELECT sys.tables.name
        FROM sys.tables WHERE sys.tables.name NOT LIKE '%_dss'
OPEN vendor_cursor

FETCH NEXT FROM vendor_cursor 
INTO @table_name

WHILE @@FETCH_STATUS = 0
BEGIN
 SELECT @SQL =  'ALTER INDEX ALL ON '+@table_name+' REBUILD WITH ( ALLOW_PAGE_LOCKS = ON )';
 EXEC(@SQL);
 print 'INDEX Rebuild on all indexes in table '+@table_name+' is done.';
 FETCH NEXT FROM vendor_cursor  INTO @table_name
END 
CLOSE vendor_cursor;
DEALLOCATE vendor_cursor;
GO