CREATE OR ALTER function [dbo].[GetBlock](@bname varchar(50),@dname int  )
 RETURNS nvarchar(10)
Begin
	Declare @BlockId nvarchar(10)
	Set @BlockId=(select Top 1 BlockId from M_BLock where LOWER(BlockName)=LOWER(@bname) and DistrictId= @dname and StateId Is not Null)
	Return @BlockId
End