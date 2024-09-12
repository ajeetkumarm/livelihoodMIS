Create OR Alter Procedure dbo.usp_DigitalCategoryAndServiceLine_List
As
	BEGIN
		Select CategoryId,Category,DisplayOrder From dbo.M_DigitalCategory Where IsDeleted=0 Order By DisplayOrder

		Select ServiceId,DigitalCategoryId,ServiceLine, ServiceURL From M_DigitalService Where IsDeleted=0 Order By DisplayOrder

	END

	