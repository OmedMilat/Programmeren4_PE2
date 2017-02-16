<Query Kind="Statements">
  <Connection>
    <ID>6104ac11-dc8a-4b86-86a3-7f0eae207e8c</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// projection
Products.Where(p => p.Category.CategoryName == "Beverages")
		.Select(p => new
				{
					Name = p.ProductName,
					Price = p.UnitPrice
				}
				).Dump();