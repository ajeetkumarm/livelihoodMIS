ALTER PROCEDURE [dbo].[USP_AllMasters]  
(  
 @QType varchar(30)='UserCat',  
 @StateId int='2',  
 @DistrictId int='',  
 @BlockId int='',  
 @VillageId int='',  
 @DigitalCategoryId int='2',  
 @PartnerId int='1'  
)  
AS  
BEGIN  
 IF(@QType='State')  
 BEGIN  
  SELECT StateId,StateName FROM M_State WHERE (StateId=@StateId or isnull(@StateId,0)=0  )
 END  
 ELSE IF(@QType='District')  
 BEGIN  
  IF(@DistrictId!='')  
  BEGIN  
   SELECT DistrictId,DistrictName FROM M_District WHERE StateId=@StateId and DistrictId=@DistrictId  
  END  
  ELSE  
  BEGIN  
   SELECT DistrictId,DistrictName FROM M_District WHERE StateId=@StateId  
  END    
 END  
 ELSE IF(@QType='Block')  
 BEGIN  
  IF(@BlockId!='')  
  BEGIN  
   SELECT BlockId,BlockName FROM M_BLock WHERE StateId=@StateId and DistrictId=@DistrictId and BlockId=@BlockId  
  END  
  ELSE  
  BEGIN  
   SELECT BlockId,BlockName FROM M_BLock WHERE StateId=@StateId and DistrictId=@DistrictId  
  END    
 END  
 ELSE IF(@QType='Village')  
 BEGIN  
  IF(@VillageId!='')  
  BEGIN  
   SELECT VillageId,VillageName FROM M_Village WHERE StateId=@StateId and DistrictId=@DistrictId   
   and BlockId=@BlockId and VillageId=@VillageId  
  END  
  ELSE  
  BEGIN  
   SELECT VillageId,VillageName FROM M_Village WHERE StateId=@StateId and DistrictId=@DistrictId and BlockId=@BlockId  
  END     
 END  
 ELSE IF(@QType='SHG')  
 BEGIN  
  SELECT SHGId,SHGName FROM M_SHG  
 END  
 ELSE IF(@QType='Cast')  
 BEGIN  
  SELECT CastId,CastName FROM M_Cast  
 END  
 ELSE IF(@QType='EcoStatus')  
 BEGIN  
  SELECT EconomicId,EconomicStatus FROM M_EconomicStatus  
 END  
 ELSE IF(@QType='Education')  
 BEGIN  
  SELECT EducationId,EducationName FROM M_Education  
 END  
 ELSE IF(@QType='Scheme')  
 BEGIN  
  SELECT SchemeId,SchemeName FROM M_Scheme  
 END  
 ELSE IF(@QType='Theme')  
 BEGIN  
  SELECT ThemeId,ThemeName,ThemeShortName FROM M_Theme  
 END  
  
  
 ELSE IF(@QType='UserCat')  
 BEGIN  
  SELECT CategoryId,Category FROM M_UserCategory   
 END  
 ELSE IF(@QType='DigiCat')  
 BEGIN  
  SELECT CategoryId,Category FROM M_DigitalCategory  Where IsDeleted=0 Order By DisplayOrder
  --WHERE CategoryId=@DigitalCategoryId or isnull(@DigitalCategoryId,0)=0  
 END  
 ELSE IF(@QType='ProjectLocation')  
 BEGIN  
  SELECT ProjectId,ProjectName FROM M_ProjectLocation  
 END  
 ELSE IF(@QType='DigiService')  
 BEGIN  
  SELECT ServiceId,ServiceLine FROM M_DigitalService   
  WHERE IsDeleted=0 AND DigitalCategoryId=@DigitalCategoryId or isnull(@DigitalCategoryId,0)=0  
  Order By DisplayOrder
 END  
 ELSE IF(@QType='Partner')  
 BEGIN  
  SELECT PartnerId,PartnerName FROM M_Partner   
 END  
 ELSE IF(@QType='Project')  
 BEGIN  
  select ProjectId,ProjectName from M_Project where PartnerId=@PartnerId  
 END  
END  