Create OR ALTER Procedure dbo.usp_GetVillages --2,25,null
(
	@PageNumber INT = 1,
	@PageSize INT = 25,
	@VillageName NVARCHAR(100) = NULL
)
AS
	BEGIN
			WITH VillageCTE AS (
				SELECT	S.StateName, D.DistrictName, B.BlockName, V.VillageId, V.VillageName,
					   ROW_NUMBER() OVER (ORDER BY S.StateName, D.DistrictName, B.BlockName, V.VillageName) AS RowNum,
					   COUNT(*) OVER () AS TotalCount
				FROM M_Village AS V
				INNER JOIN M_Block AS B ON B.BlockId = V.BlockId
				INNER JOIN M_District AS D ON D.DistrictId = B.DistrictId
				INNER JOIN M_State AS S ON S.StateId = B.StateId
				WHERE 1=1
				  AND (@VillageName IS NULL OR V.VillageName LIKE '%' + @VillageName + '%')
			)
			SELECT StateName, DistrictName, BlockName, VillageId, VillageName, TotalCount,RowNum
			FROM VillageCTE
			WHERE RowNum BETWEEN ((@PageNumber - 1) * @PageSize + 1) AND (@PageNumber * @PageSize)
			ORDER BY RowNum;
	END