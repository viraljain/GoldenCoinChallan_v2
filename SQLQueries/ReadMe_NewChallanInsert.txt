SELECT        T1.ItemName,T1.ItemName+'|||'+T1.UnitName+'|||'+ String_Agg(iif(TblSizeMap.ParentSize IS NULL, t1.ItemSize, TblSizeMap.ParentSize), '|||') 
AS ItemSize
/*, T1.UnitName, iif(TblSizeMap.ParentSize IS NULL, t1.ItemSize, TblSizeMap.ParentSize) AS ItemSize, TblSizeMap.SizeSNo*/ FROM (SELECT        LEFT(Material.Name, len(Material.Name) - charindex(' ', reverse(Material.Name), 0)) 
AS ItemName, RIGHT(Material.Name, iif(charindex(' ', reverse(Material.Name), 0) = 0, 1, 
charindex(' ', reverse(Material.Name), 0)) - 1) AS ItemSize, dbo.Material.Code, Ucode, 
UnitCode, TblUnit.UnitName
FROM            dbo.Material INNER JOIN
    (SELECT        [Code], [FieldValue1] AS UnitName
        FROM            [dbo].[Master]
        WHERE        FieldName1 = 'Unit Name') AS TblUnit ON 
TblUnit.Code = Material.UnitCode/*	where Name like '%N-1%'*/ ) AS T1 LEFT JOIN
dbo.tblSizeMap AS TblSizeMap ON T1.ItemSize = TblSizeMap.ChildSize
GROUP BY T1.ItemName, T1.UnitName

-------------------------------------------------
declare @ChallanNo varchar(128) ='CH/0542'
SELECT
	iif(T3.Srno IS NULL, 999, T3.Srno) as Srno,
	iif(T1.ItemName IS NULL, T2.b, T1.ItemName) AS ItemName, 
	iif(T3.Date IS NULL,CONVERT (date, SYSDATETIME()), T3.Date) AS DATE, IIF(T3.BillNo IS NULL, '-',T3.BillNo) AS BillNo, IIF(T3.Remark IS NULL, '-',T3.Remark) as Remark , iif(T3.TotQty is null, 0, t3.TotQty) as TotQty, 
	iif(T3.Name IS NULL, '-', T3.Name) as Name, iif(T3.Add1 IS NULL, '-', T3.Add1) as Add1, iif(T3.Add2 IS NULL, '-', T3.Add2) as Add2, iif(T3.Add3 IS NULL, '-', T3.Add3) as Add3, 
	iif(T3.TinCst is null, '-', T3.TinCst) as TinCst, T3.PinCode, iif(T3.ItemSize is null, NULL, T3.ItemSize) as ItemSize, iif(T3.Qty is null, 0, T3.Qty) as Qty, 
	iif(T3.FieldValue1 is NULL, '-', T3.FieldValue1) as FieldValue1, iif(T3.SizeSNo is Null, NULL, T3.SizeSNo) AS SizeSNo 
FROM            (SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY ItemName) AS SNo, ItemName
FROM            ViewChallanPrint
WHERE        (BillNo = @ChallanNo)
GROUP BY ItemName) AS T1 RIGHT JOIN
    (SELECT        a, b
      FROM            (VALUES (1, ' '), (2, '  '), (3, '   '), (4, '    '), (5, '     '), (6, '      '), (7, '       '), (8, '        '), (9, '         '), (10, '          '), 
	  (11, '           '), (12, '            '), (13, '             '), (14, '              '), (15, '               '), (16, '                '), 
	  (17, '                 ')
	  --, (18, '~~'), (19, '~~~'), (20, '~~~~')
	  ) 
	  AS t (a, b)) AS T2 ON T1.SNo = T2.a LEFT JOIN
    (SELECT        Srno, Date, BillNo, Remark, TotQty, Name, Add1, Add2, Add3, TinCst, PinCode, ItemName, ItemSize, Qty, FieldValue1, SizeSNo
      FROM            ViewChallanPrint
      WHERE        (BillNo = @ChallanNo)) AS T3 ON T1.ItemName = T3.ItemName

----------------------------------------
SELECT        T1.Srno, T1.Add1, T1.Add2, T1.Add3, T1.BillNo, T1.Date, T1.FieldValue1, T1.ItemName, T1.Name, T1.Qty, T1.Remark, T1.TotQty, iif(t2.ParentSize IS NULL, t1.ItemSize, t2.ParentSize) AS ItemSize, T2.SizeSNo, T1.PinCode, 
                         T1.TinCST
FROM            (SELECT        Tbl_VchDtl.Srno, Tbl_VchMst.Date, Tbl_VchMst.BillNo, Tbl_VchMst.Remark, Tbl_VchMst.TotQty, tbl_AcctMst.Name, tbl_AcctMst.Add1, tbl_AcctMst.Add2, tbl_AcctMst.Add3, tbl_AcctMst.TinCst, tbl_AcctMst.PinCode, 
                                                    LEFT(Tbl_VchDtl.ItemDesc, len(Tbl_VchDtl.ItemDesc) - charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)) AS ItemName, RIGHT(Tbl_VchDtl.ItemDesc, iif(charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0) = 0, 1, 
                                                    charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)) - 1) AS ItemSize, Tbl_VchDtl.Qty, /*iif(charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)=0,1,charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)),*/ TblUnit.FieldValue1
                          FROM            (SELECT        /***/ Date, BillNo, Remark, TotQty, PartyCode
                                                    FROM            DBO.Vch_Hd
                                                    WHERE        Vch_Type = 5) AS Tbl_VchMst INNER JOIN
                                                        (SELECT        CODE, Name, Add1, Add2, Add3, TinCst, PinCode
                                                          FROM            DBO.AccountMaster) AS tbl_AcctMst ON Tbl_VchMst.PartyCode = tbl_AcctMst.Code INNER JOIN
                                                        (SELECT        BillDate, BillNo, PartyCode, ItemCode, ItemDesc, Qty, Unit, Descp, InOutTag, code, VchId, Vch_Type, Srno, ItemUcode
                                                          FROM            dbo.Vch_Dtl/*where BillNo not like '%opening%' and BillDate between '2024-Feb-01' and '2024-Feb-29'*/ ) AS Tbl_VchDtl ON Tbl_VchMst.BillNo = Tbl_VchDtl.BillNo INNER JOIN
                                                        (SELECT        [Code], [FieldValue1]
                                                          FROM            [dbo].[Master]
                                                          WHERE        FieldName1 = 'Unit Name') AS TblUnit ON TblUnit.Code = Tbl_VchDtl.Unit) AS T1 LEFT JOIN
                         dbo.tblSizeMap AS T2 ON t1.ItemSize = T2.ChildSize;

---------------------------
select top 10 * from dbo.Material
where Name like 'BodyGuard FLAIR Gents SET RNFS+I/E%'+'%80%';

-------------------------------

CREATE TABLE tblNewChallanTemp
(
ItemName varchar(200), ItemUnit varchar(10), ItemSize varchar(5), ItemQty smallint
--Size45 smallint, Size50 smallint, Size55 smallint, Size60 smallint, Size65 smallint,Size70 smallint,Size75 smallint,Size78 smallint,Size80 smallint,Size85 smallint,
--Size90 smallint, Size95 smallint, Size100 smallint, Size105 smallint, Size110 smallint, Size120 smallint, SizeMisc smallint
)

select * from tblNewChallanTemp;
--Currently 21 rows are there in the table
select tblNewChallanTemp.*, material.name, material.Code, material.* 
from tblNewChallanTemp
inner join dbo.Material
on material.name like tblNewChallanTemp.ItemName + '%'+tblNewChallanTemp.ItemSize+'%';

--Vch_Dtl
--BillDate					BillNo	PartyCode	ItemCode	ItemDesc							Qty	Unit	Descp			InOutTag	code	VchId	Vch_Type	Srno	ItemUcode
--2024-06-17 00:00:00.000	CH/0542	258			1356		Divya Alia Panty (1 Pc) Print 080	3	36		Challan Issue	1			27251	3250	5			1		1337

--Vch_Hd
--Date						BillNo	Remark					TotQty	PartyCode
--2024-06-17 00:00:00.000	CH/0542	2 MATRIX, 9 PURO BOTTLE	138		258
/*UI
Dealer Name, Challan No., Remark
*/
/*
1) Fetch ChallanNo. - select top 1 BillNo from dbo.Vch_Hd order by CreatedDate desc;
2) Fetch DealerName & PartyCode - SELECT CODE, Name, Add1, Add2, Add3, TinCst, PinCode FROM DBO.AccountMaster where GrpCode = 8
3) ItemCode Code
4) Unit Code
5) ChallanCode & VchId needs to be checked*/
--Vch_HD
--Remark, TotQty, NumBillNo, UpdateDateTime /*UpdateTimeStamp*/, CODE /*(Counter)*/, SerType /*81-Sale,49-PSlip*/, VchType /*5-Sale,4-PSlip*/, Date, BillNo, PartyCode, SaleType /*1-Sale,2-PSlip*/, 
--StkUptTag /*1-Sale,1-PSlip*/, LedUptTag /*0-Sale,1-PSlip*/, CreatedBy /*Admin*/, CreatedDate /*TimeStamp*/, CreatedIP, CompName, PriceDecFormat /*2*/,

--Vch_Dtl
--ItemUCode, UpdateDateTime, Code /*(Counter)*/, VchId /*(Vch_HD CODE Column)*/, VchType /*5-Sale,4-PSlip*/, Srno, PartyCode, BillNo, BillDate, SerType /*81-Sale,49-PSlip*/, ItemCode, ItemDesc,
--Qty, Unit /*UnitCode*/, InOutTag /*1-Sale, 0-PSlip*/, Descp /*ChallanIssue-Sale, Purchase Invoice-PSlip*/

select top 10 * from dbo.Vch_Hd 
order by CreatedDate desc;

select * from dbo.Vch_Dtl where BillNo = 'PI-0001664'

SELECT CODE, Name, Add1, Add2, Add3, TinCst, PinCode
FROM DBO.AccountMaster
where GrpCode = 8 and CODE = 258

----------------------

/*
1) Fetch ChallanNo. - select top 1 BillNo from dbo.Vch_Hd order by CreatedDate desc;
2) Fetch DealerName & PartyCode - SELECT CODE, Name, Add1, Add2, Add3, TinCst, PinCode FROM DBO.AccountMaster where GrpCode = 8 - Done
3) ItemCode Code
4) Unit Code
5) ChallanCode & VchId needs to be checked
6) CREATE AN SP or FUNCTION & PROCESS ITEM DATA, DEALER DETAILS & CHALLAN ETC. & INSERT INTODB POST VERIFICATION 
7) ChallanTemp needs to be cleared/emptied before new insertion */
