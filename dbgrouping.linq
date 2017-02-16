<Query Kind="Statements">
  <Connection>
    <ID>6104ac11-dc8a-4b86-86a3-7f0eae207e8c</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Group by - Automatic Dump
Products
   	.GroupBy(prod => prod.CategoryID)
   	.Select(grouping => grouping)
	.Dump("Group by");
	

// Using the grouping Key
Products
   .GroupBy(prod => prod.CategoryID)
   .Select(g => new
   {
	   CategoryId = g.Key,
	   MaxPrice = g.Max(p => p.UnitPrice),
   })
   .Dump("Using the grouping key");


// Grouping on multiple columns
Products
.GroupBy(prod => new
{
	prod.CategoryID,
	prod.Category.CategoryName
})
.Select(g => new
{
	CategoryId = g.Key.CategoryID,
	CategoryName = g.Key.CategoryName,
	MaxPrice = g.Max(p => p.UnitPrice),
})
.Dump("Group on multiple columns");