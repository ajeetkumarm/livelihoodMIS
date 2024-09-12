WITH CTE AS 
(
    SELECT 
        BPF.TrainingId,  -- Assuming you have a unique identifier like an ID column
        ROW_NUMBER() OVER (PARTITION BY EF.BeneficiaryCode ORDER BY BPF.TrainingId) AS RowNum
    FROM 
        TrainingForm BPF
    INNER JOIN 
        EnrollmentForm EF ON BPF.EnrollmentId = EF.EnrollmentId
    WHERE 
        EF.BeneficiaryCode IN 
        (
'7535951592ManoramaLokeshEMP',
'9837025251JyotiShaymEMP',
'8634695788KavitaRahulEMP',
'9958497178AsgariHanduEMP',
'9027834428MalaDharmendraEMP',
'9675878296PritiDineshEMP',
'8859141767PoojaSatishEMP',
'7355821841NehaSatyaveerEMP',
'8445203858SunitaHargopalEMP',
'7535035135LaxmiAmitEMP',
'9720323244KusumLaxminarayanEMP',
'7466025593VakilanBadshahEMP',
'9760355359PinkyDineshEMP',
'9557076590PriynkaSatyaveerEMP',
'9897331102MohiniKhemEMP',
'9756262413RekhaSatyaveerEMP',
'9897537548ManjuJagdishEMP',
'9027497350PunamEMP',
'7078616436LalitaPratapEMP',
'7668663223JarinaIslamEMP',
'7060423131PoojaKuldeepEMP',
'7505835405KiranLokeshEMP',
'7060235398PremlataPratapEMP',
'8923355409HemlataLalaramEMP',
'9445007633MamtaVishnuEMP',
'9445167604SumanVishnuEMP',
'8868040977JyotiEMP',
'6396700651GolaChanduEMP',
'8979900789SonamDeendayalEMP',
'9760705840OmvatiDeendayalEMP',
'8923315933RihanaJamilaEMP',
'7088406138ChanchalJayveerEMP',
'9897071860SajanaDeepakEMP',
'9045656278ChandrvatiBhagvanEMP',
'7668066966UrmilaKomlaEMP',
'9760737782AnitaMaheshEMP',
'9997359170DoliSunilEMP',
'7082712508SoniyaDilipEMP',
'8881605252PinkySahabEMP',
'8173304119SoniyaDharmoEMP',
'7219990314MaltiKapoorEMP',
'7690941990MamtaYogendraEMP',
'9694314343EshwarRamChandraEMP',
'9785170832ShardaRaviEMP',
'8239322514MunniAnilEMP'

        )
)


Delete TrainingForm 
WHERE TrainingId IN 
(
    SELECT TrainingId
    FROM CTE
    WHERE RowNum > 0
) 


--Delete TF From TrainingForm TF Inner Join EnrollmentForm EF ON TF.EnrollmentId=EF.EnrollmentId
--WHERE TF.TrainingId IN 
--(
--    SELECT TrainingId
--    FROM CTE
--    WHERE RowNum > 0
--)
--AND EF.BeneficiaryCode Not IN
--(
--'6900739979MITALIBUBULEMP',
--'9707225161SwapnaBudhanEMP',
--'9435667135BONTILT.EMP',
--'9954648346ANAMIKAANANDAEMP',
--'9954648346ANAMIKAANANDAEMP',
--'6003057484GITASHREEJITENEMP',
--'9854274501KabitaAbaniEMP',
--'9395582521AnimaMaheswarEMP',
--'8811000484JontiBipulEMP',
--'8453098248AnamikaKashyapEMP',
--'7086854201TriptiDipakEMP',
--'9127111962RanjuKrishnaEMP',
--'7577097185AimoniPabanEMP',
--'8638582421IlaRajumoniEMP',
--'6913627949DimpalPrafullaEMP',
--'7896662961RITURANJITEMP',
--'8011760337SNIGDHAMRIDUPABANEMP'
--);
