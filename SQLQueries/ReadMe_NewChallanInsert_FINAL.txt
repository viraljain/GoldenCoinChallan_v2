DECLARE @ChallanPrefix varchar(15), @ChallanNum int, @PartyCode smallint, @VchId int, @Vch_Type int, @SerType int;

SET @Vch_Type = 5; SET @SerType=81;

SELECT @VchId = MAX(Code)+1
FROM dbo.Vch_Hd;

DECLARE @VchDtlRowId int;
SELECT @VchDtlRowId=max(code)
FROM dbo.Vch_Dtl;

DECLARE @Date DATETIME;
SET @Date = GETDATE();

SELECT @ChallanPrefix=FieldValue3, @ChallanNum=FieldValue5+1
FROM DBO.Master
where code=81 and fieldvalue2='Challan RBS';

/****	VOUCHER HEADER BEGINS	****/
insert into dbo.Vch_Hd
(TotQty, NumBillNo, UpdateDateTime, DueDate, code, SerType,Vch_Type,Date,BillNo,PartyCode, SaleType, StkUptTag, TransTypeTag, DateOfPre, TimeOfPre, CreatedBy, CreatedDate,CreatedIp,CompName, STATION, Remark)
select TotalItemQty, @ChallanNum, @Date, @Date, @VchId, @SerType, @Vch_Type, @Date, CONCAT(@ChallanPrefix,FORMAT(@ChallanNum,'0000')), DealerCode, 1,1,1, CAST(@Date AS DATE), CAST(@Date AS TIME), 'Admin', @Date, '192.168.1.1', 'OfficeSN', 'State', Remarks
from tblNewChallanTemp_Header;
--(899, 2709, DATETIME, DATETIME, 11182,81,5,DATETIME,'CH/2709','229', 1, 1,1, DATE, TIME, USERNAME,DATETIME,IPADDRESS,MACHINENAME, STATENAME)
--(899, 2709, '2026-03-24 18:34:25.000', '2026-03-24 00:00:00.000', 11182,81,5,'2026-03-24 00:00:00.000','CH/2709','229', 1, 1,1, '2026-03-24 00:00:00.000', '6:02:07 PM', 'Admin','2026-03-24 18:34:25.000','192.168.1.11','OfficeSN', 'Uttar Pradesh')


/****	VOUCHER DETAIL BEGINS	****/
SELECT @PartyCode=DealerCode
FROM tblNewChallanTemp_Header; 

insert into dbo.Vch_Dtl
(BillNo, code, partycode, BillDate, ItemCode, ItemDesc, Qty, Unit, Descp, InOutTag, VchId, Vch_Type /*Srno,*/ ,ItemUcode, SelfShow)
SELECT 
	CONCAT(@ChallanPrefix,FORMAT(@ChallanNum,'0000')) as BillNo, @VchDtlRowId+ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) as BillDtlCode, @PartyCode as PartyCode, 
	@Date as BillDate, material.Code as ItemCode, material.Name as ItemDesc, 
	tblNewChallanTemp.ItemQty as Qty, Material.UnitCode as Unit, 'Challan v2 Issue' as Descp,
	1 as InOutTag, @VchId as VchId, @Vch_Type as VchType, Material.Ucode as ItemUCode, 1 as SelfShow  
from tblNewChallanTemp
inner join dbo.Material
on material.name like tblNewChallanTemp.ItemName + '%'+tblNewChallanTemp.ItemSize+'%';

/****	UPDATING Value in MASTER Table	****/
update [dbo].[Master]
set fieldvalue5 = fieldvalue5+1
where code=81 and fieldvalue2='Challan RBS';

/****	DELETE FROM TEMP TABLES	****/
delete from tblNewChallanTemp;
delete from tblNewChallanTemp_Header;