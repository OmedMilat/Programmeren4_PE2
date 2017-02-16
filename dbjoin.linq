<Query Kind="Statements">
  <Connection>
    <ID>6104ac11-dc8a-4b86-86a3-7f0eae207e8c</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


// Total OrderAmounts for orders 10300 - 103310
var orders = Orders.Join(
				Customers, 
				o => o.CustomerID,
				c => c.CustomerID,
				(o, c) => new 
				{
					OrderId = o.OrderID,
					ShipName = o.ShipName,
					CustomerName = c.CompanyName,
					City = c.City,
					OrderAmount = o.OrderDetails.Sum( od => od.Quantity * od.UnitPrice)
				})
				.Where( all => all.OrderId > 10300 && all.OrderId < 10310)
				.OrderBy( all => all.OrderId)			
				.Dump();

