Update PoP SET PoP.StateId=(Select [dbo].[GetState](TPop.[State]))
From VillageExcel PoP INNER JOIN  VillageExcel TPop On Pop.Id=TPop.Id

--Select Distinct StateId From VillageExcel Where StateId Is null

Update PoP SET PoP.DistrictId=(Select [dbo].[GetDistrict](TPop.District,Tpop.StateId ))
From VillageExcel PoP INNER JOIN  VillageExcel TPop On Pop.Id=TPop.Id


--Select  StateId,DistrictId, State, District From VillageExcel Where DistrictId Is Null

---- Update Block Id
Update PoP SET PoP.BlockId=(Select [dbo].[GetBlock](TPop.[Name of Block],TPop.DistrictId))
From VillageExcel PoP INNER JOIN  VillageExcel TPop On Pop.Id=TPop.Id
									
Select Distinct StateId,DistrictId, State, District,[Name of Block], BlockId From VillageExcel Where BlockId Is Null

Select * From M_State Where StateId=5

Update PoP SET PoP.VillageId=(Select [dbo].[GetVillage](TPop.[Name of village],TPop.DistrictId,TPop.BlockId))
From VillageExcel PoP INNER JOIN  VillageExcel TPop On Pop.Id=TPop.Id 


--Select  DistrictId, BlockName,Count(1) From M_BLock  Group By  DistrictId, BlockName Having Count(1)>1

--Select B.*,S.StateName From M_BLock B left Join M_State S On B.StateId=S.StateId Where BlockName='Matanhail'

Select StateId,DistrictId,BlockId,VillageId, [Name of village] From VillageExcel Where VillageId Is Null


MERGE INTO M_Village AS target
USING VillageExcel AS source
ON target.VillageId = source.VillageId AND target.StateId = source.StateId AND target.DistrictId = source.DistrictId AND target.BlockId = source.BlockId
-- Add more columns in the ON clause if necessary to uniquely identify rows
WHEN NOT MATCHED BY TARGET THEN
    INSERT (StateId, DistrictId, BlockId,VillageName)
    VALUES (source.StateId, source.DistrictId, source.BlockId,source.[Name of village]);



Update VillageExcel SET DistrictId=Null,BlockId=Null, VillageId=Null


