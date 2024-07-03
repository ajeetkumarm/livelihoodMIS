CREATE OR ALTER function [dbo].[GetState](@sname varchar(50) )
 RETURNS int
Begin
	Declare @stateId Int
	Set @stateId=(Select StateId from M_State where LOWER(StateName)=LOWER(@sname))
	Return @stateId
End