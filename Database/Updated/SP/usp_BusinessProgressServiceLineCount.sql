Create or Alter Procedure dbo.usp_BusinessProgressServiceLineCount --1354
@EnrollmentId			INT
As
	BEGIN
		Select Category, TotalCount= IsNull(T1.TotalCount,0) From M_DigitalCategory DC LEFT JOIN 
			(
			Select TotalCount= Sum(CustomersNo)
			,DS.DigitalCategoryId
			From BusinessProgressServiceLine BPSL 
			Inner Join M_DigitalService DS On BPSL.ServiceLineId=DS.ServiceId
			Inner Join BusinessProgressForm BPF On BPSL.BusinessProgressId=BPF.BusinessProgressId
			Where BPF.EnrollmentId=@EnrollmentId
			AND DS.IsDeleted=0
			Group By DS.DigitalCategoryId
			) AS T1 on DC.CategoryId=T1.DigitalCategoryId
			Order By DC.DisplayOrder
	END
