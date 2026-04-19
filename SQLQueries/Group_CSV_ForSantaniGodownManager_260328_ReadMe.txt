--QUERY to be used in VisualStudio Project DataSet
SELECT        T1.ItemName,
T1.ItemName+'|||'+T1.UnitName+'|||'+ REPLACE(dbo.Group_CSV(iif(TblSizeMap.ParentSize IS NULL, t1.ItemSize, TblSizeMap.ParentSize)),',','|||') AS ItemSize
--T1.UnitName, iif(TblSizeMap.ParentSize IS NULL, t1.ItemSize, TblSizeMap.ParentSize) AS ItemSize, TblSizeMap.SizeSNo
FROM (SELECT        LEFT(Material.Name, len(Material.Name) - charindex(' ', reverse(Material.Name), 0)) 
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

-------------------*****************************************---------------------
------------------- 		STEPS for UDA Group_CSV     ---------------------
-------------------*****************************************---------------------
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

CREATE ASSEMBLY Group_CSV FROM 'I:\Dev\Nucleus_Nozomi\Nucleus\Honda_Archive\Libraries\Steps_GroupCSV_Concatenate_Release_SO_CR1\Group_CSV.dll';
GO
CREATE AGGREGATE Group_CSV(@input NVARCHAR(MAX)) RETURNS NVARCHAR(MAX)
EXTERNAL NAME Group_CSV.Group_CSV;

DROP AGGREGATE Group_CSV;
DROP ASSEMBLY Group_CSV;