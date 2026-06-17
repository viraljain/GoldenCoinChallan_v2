SELECT Material.Code, Material.UnitCode, Material.Ucode, Material.Name,ItemName, ItemUnit, ItemSize, SUM(ItemQty) as ItemQty, --SNo,
		DENSE_RANK() OVER (
			ORDER BY (SELECT MIN(SNo) 
						FROM dbo.tblNewChallanTemp t2 
						WHERE t2.ItemName = tblNewChallanTemp.ItemName)
		) AS GroupNo
--		INTO #tblNewChallanTempGrouped
FROM dbo.tblNewChallanTemp
inner join dbo.Material
			on material.name like tblNewChallanTemp.ItemName + '%'+ tblNewChallanTemp.ItemSize +'%' and CHECKSUM(tblNewChallanTemp.ItemName) = CHECKSUM(LEFT(Material.Name, len(Material.Name) - charindex(' ', reverse(Material.Name), 0)))
GROUP BY ItemName, ItemUnit, ItemSize, Material.Code, Material.UnitCode, Material.Ucode, Material.Name;
