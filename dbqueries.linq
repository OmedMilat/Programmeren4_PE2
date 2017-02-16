<Query Kind="Statements">
  <Connection>
    <ID>6104ac11-dc8a-4b86-86a3-7f0eae207e8c</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// realy simple
Categories.Dump("Categories");

// extension methods and lambda expressions
Customers.Where(c => c.CustomerID.StartsWith("A")).Dump("Customers starting with A");

// using variables
string customerId = "Alfki";
Orders
	.Where(o => o.CustomerID == customerId)	.Dump($"{customerId}'s Orders")
	.Count()								.Dump($"#{customerId}'s Orders");

int categoryID = 1;
Products
	.Where(p => p.CategoryID == categoryID)		.Dump($"Products of Catogry {categoryID}")
	.Sum(p => p.UnitPrice)						.Dump("Total Price for products of Catogry {categoryID}");
	
// with DataContext variable, easier to copy/paste to Visual Studio
var context = this;
context.Products.Where(p => p.Category.CategoryName == "Beverages").Dump();





  