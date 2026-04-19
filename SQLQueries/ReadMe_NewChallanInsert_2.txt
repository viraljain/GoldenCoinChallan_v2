SELECT [Old_Code],[Frequency],[FreqDate],[IncTaxTag],[PriceStruCode2]
      ,[FieldName10],[FieldValue10],[FieldName11],[FieldValue11],[Code]
      ,[PosId],[Name],[Type],[TypeName],[Descp],[FieldName1]
      ,[FieldValue1],[FieldName2],[FieldValue2],[FieldName3],[FieldValue3]
      ,[FieldName4],[FieldValue4],[FieldName5],[FieldValue5],[FieldName6]
      ,[FieldValue6],[FieldName7],[FieldValue7],[FieldName8],[FieldValue8]
      ,[FieldName9],[FieldValue9]
      ,[PriceStruCode],[PartyCode],[Header],[Date2]
      ,[CreatedDate],[PriceStruCodeINT2],[UserName],[SmsMessage]
      ,[SmsUser],[SmsPass]
  FROM [AA_2023_2024].[dbo].[Master]
  where code=81;

-----------------------------
select * from dbo.Vch_Hd where BillNo='CH/2706'

insert into dbo.Vch_Hd
(TotQty, NumBillNo, UpdateDateTime, DueDate, code, SerType,Vch_Type,Date,BillNo,PartyCode, SaleType, StkUptTag, TransTypeTag, DateOfPre, TimeOfPre, CreatedBy, CreatedDate,CreatedIp,CompName, STATION)
values 
(899, 2709, '2026-03-24 18:34:25.000', '2026-03-24 00:00:00.000', 11182,81,5,'2026-03-24 00:00:00.000','CH/2709','229', 1, 1,1, '2026-03-24 00:00:00.000', '6:02:07 PM', 'Admin','2026-03-24 18:34:25.000','192.168.1.11','OfficeSN', 'Uttar Pradesh')
----------------
update [dbo].[Master]
set fieldvalue5 = fieldvalue5+1
where code=81 and fieldvalue2='Challan RBS' 


select tblNewChallanTemp.*, material.name, material.Code, material.* 
from tblNewChallanTemp
inner join dbo.Material
on material.name like tblNewChallanTemp.ItemName + '%'+tblNewChallanTemp.ItemSize+'%';
