IF NOT EXISTS (SELECT * FROM [RateGroups] WHERE [name]='rategroup1')
	INSERT INTO RateGroups VALUES ('rategroup1', DEFAULT, NULL, NULL, NULL, NULL);
IF NOT EXISTS (SELECT * FROM [RateGroups] WHERE [name]='rategroup2')
	INSERT INTO RateGroups VALUES ('rategroup2', DEFAULT, NULL, NULL, NULL, NULL);

IF NOT EXISTS (SELECT * FROM [BillingAccounts] WHERE [name] = 'testaccount')
	INSERT INTO BillingAccounts VALUES ('testaccount', 50, DEFAULT, NULL, NULL, NULL, NULL);

DECLARE @account int;
DECLARE @rategroup1 int;
DECLARE @rategroup2 int;

SET @account = (SELECT TOP 1 id FROM [BillingAccounts] WHERE [name] = 'testaccount');
SET @rategroup1 = (SELECT TOP 1 id FROM [RateGroups] WHERE [name] = 'rategroup1');
SET @rategroup2 = (SELECT TOP 1 id FROM [RateGroups] WHERE [name] = 'rategroup2');

IF NOT EXISTS (SELECT * FROM [DefaultBillingRates] WHERE [accountid]=@account AND [groupid]=@rategroup1)
	INSERT INTO [DefaultBillingRates] VALUES (@account, @rategroup1, 60, DEFAULT, NULL, NULL, NULL, NULL);
IF NOT EXISTS (SELECT * FROM [DefaultBillingRates] WHERE [accountid]=@account AND [groupid]=@rategroup2)
	INSERT INTO [DefaultBillingRates] VALUES (@account, @rategroup2, 70, DEFAULT, NULL, NULL, NULL, NULL);

IF NOT EXISTS (SELECT * FROM [BillingPeriods] WHERE [month]=7 AND [year]=2007)
	INSERT INTO [BillingPeriods] VALUES (7, 2007, '8-1-2007', DEFAULT, NULL, NULL, NULL, NULL);

DECLARE @BillingPeriod int;
SET @BillingPeriod = (SELECT TOP 1 id FROM [BillingPeriods] WHERE [month]=7 AND [year]=2007);

IF NOT EXISTS (SELECT * FROM [BillingPeriodAccounts] WHERE [accountid]=@account AND [periodid]=@BillingPeriod)
	INSERT INTO [BillingPeriodAccounts] VALUES (@BillingPeriod, @account, 50, DEFAULT, NULL, NULL, NULL, NULL)

DECLARE @periodaccount int;
SET @periodaccount = (SELECT TOP 1 id FROM [BillingPeriodAccounts] WHERE [accountid]=@account AND [periodid]=@BillingPeriod);

IF NOT EXISTS (SELECT * FROM [BillingRates] WHERE [periodaccountid]=@periodaccount AND [groupid]=@rategroup1)
	INSERT INTO [BillingRates] VALUES (@periodaccount, @rategroup1, 60, DEFAULT, NULL, NULL, NULL, NULL);
IF NOT EXISTS (SELECT * FROM [BillingRates] WHERE [periodaccountid]=@periodaccount AND [groupid]=@rategroup2)
	INSERT INTO [BillingRates] VALUES (@periodaccount, @rategroup2, 70, DEFAULT, NULL, NULL, NULL, NULL);

IF NOT EXISTS (SELECT * FROM [Timesheets] WHERE [username] = 'jdaigle' AND periodaccountid=@periodaccount)
	INSERT INTO [Timesheets] VALUES ('jdaigle', @periodaccount, 0, DEFAULT, NULL, NULL, NULL, NULL);