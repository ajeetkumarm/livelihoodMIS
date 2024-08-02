ALTER PROCEDURE [dbo].[USP_DigitalCategoryM]
(
	@QString varchar(30)='Update',
	@CategoryId int='1',
	@Category varchar(100)='AAA',
	@CreatedBy varchar(30)='',
	@UpdatedBy varchar(30)='UpdAdmin',
	@DisplayOrder		INT=0
)
AS
BEGIN
	IF(@QString='Insert')
	BEGIN
		INSERT INTO M_DigitalCategory(Category,CreatedBy,CreatedOn,DisplayOrder)
		VALUES(@Category,@CreatedBy,GETDATE(),@DisplayOrder)
	END
	ELSE IF(@QString='Update')
	BEGIN
		UPDATE M_DigitalCategory SET Category=@Category,UpdatedBy=@UpdatedBy,UpdatedOn=GETDATE(),DisplayOrder=@DisplayOrder
		WHERE CategoryId=@CategoryId
	END
	ELSE IF(@QString='Delete')
	BEGIN
		DELETE FROM M_DigitalCategory WHERE CategoryId=@CategoryId
	END
	ELSE IF(@QString='Detail')
	BEGIN
		SELECT CategoryId,Category,DisplayOrder FROM M_DigitalCategory
		WHERE IsDeleted=0 AND ( CategoryId=@CategoryId or isnull(@CategoryId,0)=0)
		ORDER BY DisplayOrder, Category
	END
END
