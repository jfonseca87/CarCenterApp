-- Ejercicios planteados en el documento de SQL
-- 5. Consulta de Clientes que han comprado un acumulado $100.000 en los últimos 60 días
SELECT a.* FROM clientes a
INNER JOIN facturas b on a.ClienteId = b.ClienteId
WHERE b.FechaFactura >= DATEADD(DAY, -60, GETDATE()) AND b.FechaFactura <= GETDATE() AND Total >= 100000

-- 6.	Consulta de los 100 productos más vendidos en los últimos 30 días
SELECT TOP 100 a.* FROM Productos a
INNER JOIN DetalleFacturas b ON a.ProductoId = b.ProductoId
INNER JOIN facturas c on c.FacturaId = b.FacturaId
WHERE c.FechaFactura >= DATEADD(DAY, -60, GETDATE()) AND c.FechaFactura <= GETDATE()
ORDER BY VecesVendido DESC

-- 7.	Consulta de las tiendas que han vendido más de 100 UND del producto 4 (Puertas x 1) en los últimos 60 días.
SELECT a.* FROM Sedes a
INNER JOIN Facturas b ON a.SedeId = b.SedeId
INNER JOIN DetalleFacturas c ON b.FacturaId = c.FacturaId
INNER JOIN Productos d ON d.ProductoId = c.ProductoId
WHERE b.FechaFactura >= DATEADD(DAY, -60, GETDATE()) AND b.FechaFactura <= GETDATE() AND 
c.ProductoId = 4 and d.VecesVendido > 100