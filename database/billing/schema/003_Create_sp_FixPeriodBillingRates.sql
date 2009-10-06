CREATE PROCEDURE [dbo].[sp_FixPeriodBillingRates]
	@PeriodID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @GroupID int;
	DECLARE @BillingPeriodAccountID int;
	DECLARE @AccountID int;

	DECLARE billingPeriodAccounts CURSOR READ_ONLY FOR
	SELECT id, accountid FROM BillingPeriodAccounts WHERE periodid=@PeriodID
	OPEN billingPeriodAccounts
	FETCH NEXT FROM billingPeriodAccounts INTO @BillingPeriodAccountID, @AccountID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		/*inner loop*/
		DECLARE rateGroupIDs CURSOR READ_ONLY FOR
		SELECT id FROM RateGroups
		OPEN rateGroupIDs
		FETCH NEXT FROM rateGroupIDs INTO @GroupID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			DECLARE @DefaultRate int;
			SET @DefaultRate = 0;
			IF ((SELECT COUNT(rate) FROM DefaultBillingRates WHERE accountid=@AccountID AND groupid=@GroupID)>0)
				SET @DefaultRate = (SELECT rate FROM DefaultBillingRates WHERE accountid=@AccountID AND groupid=@GroupID)
						
			
			IF NOT EXISTS (SELECT id FROM BillingRates WHERE periodaccountid=@BillingPeriodAccountID AND groupid=@GroupID)
				INSERT INTO BillingRates (periodaccountid, groupid, rate, isDeleted, CreatedOn, CreatedBy) VALUES (@BillingPeriodAccountID, @GroupID, @DefaultRate, 0, GetDate(), 'Server Process');

			FETCH NEXT FROM rateGroupIDs INTO @GroupID	
		END
		CLOSE rateGroupIDs
		DEALLOCATE rateGroupIDs
		/* end inner loop*/
		FETCH NEXT FROM billingPeriodAccounts INTO @BillingPeriodAccountID, @AccountID
	END
	CLOSE billingPeriodAccounts
	DEALLOCATE billingPeriodAccounts

END
