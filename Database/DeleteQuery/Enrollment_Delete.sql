WITH CTE AS 
(
    SELECT 
        BeneficiaryCode,
        EnrollmentId,  -- Assuming you have a unique identifier like an ID column
        ROW_NUMBER() OVER (PARTITION BY BeneficiaryCode ORDER BY CreatedOn DESC) AS RowNum
    FROM 
        EnrollmentForm Where
		BeneficiaryCode IN 
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

--SELECT EnrollmentId
--    FROM CTE
--    WHERE RowNum > 0

Delete From EnrollmentForm
WHERE EnrollmentId IN 
(
    SELECT EnrollmentId
    FROM CTE
    WHERE RowNum > 0
);



--Delete From EnrollmentForm
--WHERE EnrollmentId IN 
--(
--    SELECT EnrollmentId
--    FROM CTE
--    WHERE RowNum > 0
--)
--AND BeneficiaryCode Not In 
--(
--'9707225161SwapnaBudhanEMP',
--'8876702683SwapnaSOMESWAREMP',
--'8453098248AnamikaKashyapEMP',
--'7086854201TriptiDipakEMP',
--'7577097185AimoniPabanEMP',
--'8638582421IlaRajumoniEMP',
--'6913627949DimpalPrafullaEMP',
--'8099438785AktaraSaidulEMP',
--'6000570173MAMUSUSHILEMP',
--'8011760337SNIGDHAMRIDUPABANEMP',
--'6003057484GITASHREEJITENEMP',
--'9957712601DipaliPulinEMP',
--'6913109558JyotiSomeshwarEMP',
--'7896662961RITURANJITEMP',
--'9854274501KabitaAbaniEMP',
--'9395582521AnimaMaheswarEMP',
--'8811000484JontiBipulEMP'
--);


