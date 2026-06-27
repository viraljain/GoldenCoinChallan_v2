update DBO.Material 
SET Multiple = 6
where Name like '%SMARLYN%6 Pc%'
and UnitCode=64;

update DBO.Material 
SET Multiple = 6, UnitCode = 64
where Name like '%SMARLYN%6 Pc%'
and UnitCode=35;

update DBO.Material 
SET Multiple = 18
where Name like '%SMARLYN%18 Pc%'
and UnitCode=64;

SELECT * FROM DBO.Material where Name like '%SMARLYN%6 Pc%'
and UnitCode=64;

SELECT * FROM DBO.Material where Name like '%SMARLYN%18 Pc%'
and UnitCode=64;

------------------

Now, in XML - multiply the Quantity by Multiplication factor.

Same has to be done during PSlip ITEM Transfer also.