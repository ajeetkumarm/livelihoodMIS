ALTER PROCEDURE [dbo].[USP_DigitalServiceM]
(
	@QString varchar(30)='Update',
	@ServiceId int='1',
	@DigitalCategoryId int='',
	@ServiceLine varchar(100)='AAA',
	@CreatedBy varchar(30)='',
	@UpdatedBy varchar(30)='UpdAdmin',
	@ServiceURL	Varchar(255) = NULL,
	@DisplayOrder		INT=0

)
AS
BEGIN
	IF(@QString='Insert')
	BEGIN
		INSERT INTO M_DigitalService(DigitalCategoryId,ServiceLine,CreatedBy,CreatedOn,ServiceURL,DisplayOrder)
		VALUES(@DigitalCategoryId,@ServiceLine,@CreatedBy,GETDATE(),@ServiceURL,@DisplayOrder)
	END
	ELSE IF(@QString='Update')
	BEGIN
		UPDATE M_DigitalService SET DigitalCategoryId=@DigitalCategoryId,ServiceLine=@ServiceLine,UpdatedBy=@UpdatedBy,
		UpdatedOn=GETDATE(),ServiceURL=@ServiceURL,DisplayOrder=@DisplayOrder
		WHERE ServiceId=@ServiceId
	END
	ELSE IF(@QString='Delete')
	BEGIN
		DELETE FROM M_DigitalService WHERE ServiceId=@ServiceId
	END
	ELSE IF(@QString='Detail')
	BEGIN
		SELECT ServiceId,DigitalCategoryId,DC.Category,ServiceLine,DS.ServiceURL,DS.DisplayOrder FROM M_DigitalService DS
		INNER JOIN M_DigitalCategory DC on DS.DigitalCategoryId=DC.CategoryId
		WHERE DS.IsDeleted=0 AND (ServiceId=@ServiceId or isnull(@ServiceId,0)=0)
		ORDER BY DC.DisplayOrder, DS.DisplayOrder, DC.Category,ServiceLine
	END
END
