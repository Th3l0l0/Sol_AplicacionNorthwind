use northwind
go
-- listar los clientes
create procedure listar_clientes
as
select c.CustomerID, c.CompanyName
 from Customers as c
go
-- listar las ordenes en base a un codigo
-- de cliente
create procedure ordenes_por_cliente
@codigo char(5)
as
select o.OrderID, o.OrderDate, o.EmployeeID
  from Orders as o
	where o.CustomerID = @codigo
go
--
execute ordenes_por_cliente 'ALFKI'
go

-- 
create procedure ordenes_por_fecha
@fecha datetime
as
select o.OrderID, o.OrderDate, o.EmployeeID
  from Orders as o
	where o.OrderDate >= @fecha
go

exec ordenes_por_fecha '01/05/1998'
go
