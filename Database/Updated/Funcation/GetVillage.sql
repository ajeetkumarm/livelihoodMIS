CREATE OR ALTER function [dbo].[GetVillage](@vname varchar(50),@dname int,@bname int )
 RETURNS int
Begin
	Declare @VillageId int
	Set @VillageId=(select Distinct VillageId from 
					M_Village Where 1=1
					AND  LOWER(VillageName)=LOWER(@vname) 
					AND BlockId=@bname 
					AND DistrictId= @dname 
					AND VillageId not in(40,290))

	Return @VillageId
End