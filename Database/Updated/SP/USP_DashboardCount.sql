ALTER PROCEDURE [dbo].[USP_DashboardCount]
(
    @CreatedUser            VARCHAR(50) = '521',
    @Project                VARCHAR(50) = '5',
    @FromDate               VARCHAR(10) = NULL,
    @ToDate                 VARCHAR(10) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserCategory VARCHAR(10);
    DECLARE @UserCodes TABLE (UserCode VARCHAR(50));
    DECLARE @condition NVARCHAR(MAX) = '';

    -- Get UserCategory of @CreatedUser
    SELECT @UserCategory = UserCategory
    FROM UserLogin
    WHERE UserCode = @CreatedUser;

    -- Date Filtering
    IF @FromDate IS NOT NULL AND @ToDate IS NOT NULL
    BEGIN
        SET @condition += ' AND CONVERT(DATE, EF.CreatedOn, 105) >= CONVERT(DATE, ''' + @FromDate + ''', 105) ' +
                          ' AND CONVERT(DATE, EF.CreatedOn, 105) <= CONVERT(DATE, ''' + @ToDate + ''', 105) ';
    END

    -- Determine UserCodes based on UserCategory and Project
    IF (@UserCategory = '1' OR @UserCategory = '9') -- Admin User
    BEGIN
		Print 'hi'
        IF (@Project <> '0' AND ISNULL(@Project, '') <> '')
        BEGIN
            SET @condition += ' AND CONVERT(VARCHAR, UL.ProjectCode) = ''' + @Project + ''' ';
        END
    END
    ELSE IF (@UserCategory = '7') -- Specific User
    BEGIN
        SET @condition += ' AND EF.CreatedBy = ''' + @CreatedUser + ''' ';
        IF (ISNULL(@Project, '') <> '')
        BEGIN
            SET @condition += ' AND CONVERT(VARCHAR, UL.ProjectCode) = ''' + @Project + ''' ';
        END
    END
    ELSE -- Other Users
    BEGIN
        -- Build UserCategory string excluding '1' (Admin)
        DECLARE @InputUserCategory NVARCHAR(MAX);
        SELECT @InputUserCategory = STUFF((SELECT DISTINCT ',' + CAST(UserCategory AS VARCHAR(10))
                                           FROM UserLogin
                                           WHERE UserCategory NOT IN ('1')
                                           FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');

        -- Find position of current UserCategory
        DECLARE @Input INT = CHARINDEX(@UserCategory, @InputUserCategory);

        -- Get substring from the position of current UserCategory
        SET @InputUserCategory = SUBSTRING(@InputUserCategory, @Input, LEN(@InputUserCategory));

        -- Build UserCodes excluding higher categories
        DECLARE @LoginUser NVARCHAR(MAX);
        SELECT @LoginUser = STUFF((SELECT DISTINCT ',' + CAST(UserCode AS VARCHAR(10))
                                   FROM UserLogin
                                   WHERE UserCategory NOT IN ('1', '7') AND UserCategory >= @UserCategory
                                   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');

        SET @condition += ' AND EF.CreatedBy IN (' + @LoginUser + ') ';
        IF (ISNULL(@Project, '') <> '')
        BEGIN
            SET @condition += ' AND CONVERT(VARCHAR, UL.ProjectCode) = ''' + @Project + ''' ';
        END
    END

    -- Declare variables for counts
    DECLARE @TotalEnrollment INT = 0;
    DECLARE @TotalEDPTraining INT = 0;
    DECLARE @TotalEnterpriesTraining INT = 0;
    DECLARE @TotalBusinessProgress INT = 0;
    DECLARE @TotalBusinessNew INT = 0;
    DECLARE @TotalBusinessUpgrade INT = 0;
    DECLARE @TotalBusinessInnovative INT = 0;
    DECLARE @TotalFinancialLiteracyTraining INT = 0;
	DECLARE @TotalBusinessProgressActive INT = 0;
	DECLARE @TotalBusinessProgressHold INT = 0;
	DECLARE @TotalBusinessProgressClose INT = 0;

    -- Build dynamic SQL queries
    DECLARE @SQL NVARCHAR(MAX);

    -- Total Enrollment
    SET @SQL = 'SELECT @TotalEnrollment = COUNT(*) FROM EnrollmentForm EF
                INNER JOIN UserLogin UL ON EF.CreatedBy = UL.UserCode
                WHERE 1 = 1 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalEnrollment INT OUTPUT', @TotalEnrollment OUTPUT;

    -- Total EDP Training
    SET @SQL = 'SELECT @TotalEDPTraining = COUNT(*) FROM TrainingForm TF
                INNER JOIN UserLogin UL ON TF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON TF.EnrollmentId = EF.EnrollmentId
                WHERE 1 = 1 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalEDPTraining INT OUTPUT', @TotalEDPTraining OUTPUT;

    -- Total Enterprise Training
    SET @SQL = 'SELECT @TotalEnterpriesTraining = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE 1 = 1 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalEnterpriesTraining INT OUTPUT', @TotalEnterpriesTraining OUTPUT;

    -- Total Business Progress
    SET @SQL = 'SELECT @TotalBusinessProgress = COUNT(*) FROM BusinessProgressForm BPF
                INNER JOIN UserLogin UL ON BPF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON BPF.EnrollmentId = EF.EnrollmentId
                WHERE 1 = 1 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessProgress INT OUTPUT', @TotalBusinessProgress OUTPUT;

    -- Total Business New
    SET @SQL = 'SELECT @TotalBusinessNew = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE ETF.Business = ''New Business'' ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessNew INT OUTPUT', @TotalBusinessNew OUTPUT;

    -- Total Business Upgrade
    SET @SQL = 'SELECT @TotalBusinessUpgrade = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE ETF.Business = ''Upgrade Business'' ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessUpgrade INT OUTPUT', @TotalBusinessUpgrade OUTPUT;

    -- Total Business Innovative
    SET @SQL = 'SELECT @TotalBusinessInnovative = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE ETF.Business = ''Innovative Business'' ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessInnovative INT OUTPUT', @TotalBusinessInnovative OUTPUT;

    -- Total Financial Literacy Training
    SET @SQL = 'SELECT @TotalFinancialLiteracyTraining = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE ISNULL(ETF.DigitalInclusion, '''') <> '''' ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalFinancialLiteracyTraining INT OUTPUT', @TotalFinancialLiteracyTraining OUTPUT;

	-- Total Financial Literacy Training
    SET @SQL = 'SELECT @TotalFinancialLiteracyTraining = COUNT(*) FROM EnterpriesTrainingForm ETF
                INNER JOIN UserLogin UL ON ETF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON ETF.EnrollmentId = EF.EnrollmentId
                WHERE ISNULL(ETF.DigitalInclusion, '''') <> '''' ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalFinancialLiteracyTraining INT OUTPUT', @TotalFinancialLiteracyTraining OUTPUT;

	-- Total Business Progress Active
    SET @SQL = 'SELECT @TotalBusinessProgressActive = COUNT(*) FROM BusinessProgressForm BPF
                INNER JOIN BusinessProgressStatus BPS ON BPF.EnrollmentId = BPS.EnrollmentId
                INNER JOIN UserLogin UL ON BPF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON BPF.EnrollmentId = EF.EnrollmentId
                WHERE BPS.BusinessStatus = 1 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessProgressActive INT OUTPUT', @TotalBusinessProgressActive OUTPUT;

    -- Total Business Progress Hold
    SET @SQL = 'SELECT @TotalBusinessProgressHold = COUNT(*) FROM BusinessProgressForm BPF
                INNER JOIN BusinessProgressStatus BPS ON BPF.EnrollmentId = BPS.EnrollmentId
                INNER JOIN UserLogin UL ON BPF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON BPF.EnrollmentId = EF.EnrollmentId
                WHERE BPS.BusinessStatus = 2 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessProgressHold INT OUTPUT', @TotalBusinessProgressHold OUTPUT;

    -- Total Business Progress Close
    SET @SQL = 'SELECT @TotalBusinessProgressClose = COUNT(*) FROM BusinessProgressForm BPF
                INNER JOIN BusinessProgressStatus BPS ON BPF.EnrollmentId = BPS.EnrollmentId
                INNER JOIN UserLogin UL ON BPF.CreatedBy = UL.UserCode
                INNER JOIN EnrollmentForm EF ON BPF.EnrollmentId = EF.EnrollmentId
                WHERE BPS.BusinessStatus = 3 ' + @condition;
    EXEC sp_executesql @SQL, N'@TotalBusinessProgressClose INT OUTPUT', @TotalBusinessProgressClose OUTPUT;

    -- Return all counts in a single result set
    SELECT
        @TotalEnrollment AS TotalEnrollment,
        @TotalEDPTraining AS TotalEDPTraining,
        @TotalEnterpriesTraining AS TotalEnterpriesTraining,
        @TotalBusinessProgress AS TotalBusinessProgress,
        @TotalBusinessNew AS TotalBusinessNew,
        @TotalBusinessUpgrade AS TotalBusinessUpgrade,
        @TotalBusinessInnovative AS TotalBusinessInnovative,
        @TotalFinancialLiteracyTraining AS TotalFinancialLiteracyTraining,
		@TotalBusinessProgressActive AS TotalBusinessProgressActive,
        @TotalBusinessProgressHold AS TotalBusinessProgressHold,
        @TotalBusinessProgressClose AS TotalBusinessProgressClose;
END
