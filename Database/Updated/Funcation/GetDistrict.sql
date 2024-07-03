CREATE OR ALTER function [dbo].[GetDistrict](@dname varchar(50), @StateId Int )
 RETURNS int
Begin
	Declare @DistrictId int
	Set @DistrictId=(Select DistrictId from M_District where LOWER(DistrictName)=LOWER(@dname) AND StateId=@StateId ) 
	Return @DistrictId
End