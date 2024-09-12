Create   function [dbo].[GetStringWithOutSpace](@InputString varchar(200))
 RETURNS Varchar(200)
Begin
	
	Declare @ReturnValue Varchar(200)

	SET @ReturnValue= (SELECT 
				CASE 
					WHEN CHARINDEX(' ', @InputString) > 0 THEN LEFT(@InputString, CHARINDEX(' ', @InputString))
					ELSE @inputString
				END AS Result
			);

	RETURN TRIM(@ReturnValue)
End