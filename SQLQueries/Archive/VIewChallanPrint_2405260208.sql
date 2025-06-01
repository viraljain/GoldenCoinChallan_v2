USE [AA_2023_2024]
GO

/****** Object:  View [dbo].[ViewChallanPrint]    Script Date: 26-05-2024 02:08:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewChallanPrint]
AS
SELECT --*
Tbl_VchMst.Date, Tbl_VchMst.BillNo, Tbl_VchMst.Remark, Tbl_VchMst.TotQty,
tbl_AcctMst.Name, tbl_AcctMst.Add1, tbl_AcctMst.Add2, tbl_AcctMst.Add3, tbl_AcctMst.TinCst, tbl_AcctMst.PinCode,
left(Tbl_VchDtl.ItemDesc, len(Tbl_VchDtl.ItemDesc)-charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)) as ItemName, 
right(Tbl_VchDtl.ItemDesc, iif(charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)=0,1,charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0))-1) as ItemSize, Tbl_VchDtl.Qty,
--iif(charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)=0,1,charindex(' ', reverse(Tbl_VchDtl.ItemDesc), 0)),
TblUnit.FieldValue1 
FROM
(
SELECT 
--*
Date, BillNo, Remark, TotQty, PartyCode 
FROM DBO.Vch_Hd
WHERE 
--BillNo = 'CH/0056'
--AND 
Vch_Type=5
) AS Tbl_VchMst
inner JOIN
(
SELECT 
CODE, Name, Add1, Add2, Add3, TinCst, PinCode
 FROM DBO.AccountMaster
--WHERE CODE=687
) as tbl_AcctMst
ON Tbl_VchMst.PartyCode=tbl_AcctMst.Code
inner join
(
 select
 BillDate, BillNo, PartyCode, ItemCode, ItemDesc, Qty, Unit, Descp, InOutTag,
 code, VchId, Vch_Type, Srno,
 ItemUcode
 from dbo.Vch_Dtl
 --where BillNo not like '%opening%' and BillDate between '2024-Feb-01' and '2024-Feb-29'
 ) as Tbl_VchDtl
 on Tbl_VchMst.BillNo = Tbl_VchDtl.BillNo
 inner join
 (
	SELECT [Code]
      ,[FieldValue1]
        FROM [dbo].[Master]
		where FieldName1 = 'Unit Name'
 ) as TblUnit
 on TblUnit.Code=Tbl_VchDtl.Unit;

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Tbl_VchMst"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_AcctMst"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tbl_VchDtl"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblUnit"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 102
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewChallanPrint'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewChallanPrint'
GO

