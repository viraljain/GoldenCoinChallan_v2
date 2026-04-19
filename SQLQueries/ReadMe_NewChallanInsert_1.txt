CREATE TABLE tblNewChallanTemp
(
ItemName varchar(200), ItemUnit varchar(10), ItemSize varchar(5), ItemQty smallint
--Size45 smallint, Size50 smallint, Size55 smallint, Size60 smallint, Size65 smallint,Size70 smallint,Size75 smallint,Size78 smallint,Size80 smallint,Size85 smallint,
--Size90 smallint, Size95 smallint, Size100 smallint, Size105 smallint, Size110 smallint, Size120 smallint, SizeMisc smallint
)

select * from tblNewChallanTemp;

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

select * from dbo.Vch_Dtl where BillNo = 'CH/2305'

SELECT CODE, Name, Add1, Add2, Add3, TinCst, PinCode
FROM DBO.AccountMaster
where GrpCode = 8 and CODE = 258
