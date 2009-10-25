EXEC master.dbo.sp_addlinkedserver @server = N'APOLLO.TFS2.COM', @srvproduct=N'SQL Server'
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'APOLLO.TFS2.COM',@useself=N'False',@locallogin=NULL,@rmtuser=N'sa',@rmtpassword='willypete'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'collation compatible', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'rpc', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'rpc out', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'APOLLO.TFS2.COM', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO


