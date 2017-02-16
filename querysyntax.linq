<Query Kind="Statements">
  <Connection>
    <ID>6104ac11-dc8a-4b86-86a3-7f0eae207e8c</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };


// 1
// extension methods
var query = names
	.Where(n => n.Contains("a"))
	.OrderBy(n => n.Length)
	.Select(n => n.ToUpper());

query.Dump("names containing a");

// query syntax
var query2 = from n in names
where n.Contains("a")
orderby n.Length
select n.ToUpper();

query2.Dump("names containing a");

// 2
// extension methods and lambda expressions
Customers.Where(c => c.CustomerID.StartsWith("A")).Dump("Customers starting with A");

// query syntax
var customers =
	from c in Customers
	where c.CustomerID.StartsWith("A")
	select c;
customers.Dump("Customers starting with A");


