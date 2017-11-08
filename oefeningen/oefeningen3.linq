<Query Kind="Statements">
  <Connection>
    <ID>08e769d1-9f81-4660-ae18-c4ca3657b057</ID>
    <Persist>true</Persist>
    <Server>qais187_</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/* 1. Toon de productnamen waarvan we minder dan 20 UnitsInStock tellen, toon ook de bijbehorende categorienaam */
Products.Join(Categories,
p => p.CategoryID,
c => c.CategoryID,
(p, c) => new{
ProductNaam = p.ProductName,
UnitsInStock = p.UnitsInStock,
Categorie = c.CategoryName})
.Where(p => p.UnitsInStock < 20).Dump("Oefening 1");

/* 2. Toon de namen van de klanten waar in de ContactTitle het woord "sales" voorkomt en afkomstig zijn uit Italië */
Customers
.Where(c => c.ContactTitle.Contains("sales") && c.Country == "Italy" )
.GroupBy(c => c.ContactName)
.Select(c => new {
Naam = c.Key}).Dump("Oefening 2");

/* 3. Toon de namen van de klanten waar in de ContactTitle het woord "sales" voorkomt en afkomstig zijn uit Italië, Frankrijk of Portugal*/
Customers
.Where(c => c.ContactTitle.Contains("sales") && c.Country == "Italy" || c.Country == "France" || c.Country == "Portugal" )
.GroupBy(c => c.ContactName)
.Select(c => new {
Naam = c.Key}).Dump("Oefening 3");


/* 	4. Geef voor elke werknemer die een overste heeft (reportsto is ingevuld)
	   de voornaam en familienaam weer alsook hoeveel orders ze hebben behandeld in het meest recente jaar */

Employees.Join(Orders,
e => e.EmployeeID,
o => o.EmployeeID,
(e,o) => new {
EmployeeID = e.EmployeeID,
Voornaam = e.FirstName, 
Achternaam = e.LastName,
ReportsTo = e.ReportsTo,
OrderDate = o.OrderDate,
Orders = e.Orders.Count})
.Where(e => e.ReportsTo != null)
.GroupBy(e => new
{
	e.EmployeeID,
	e.Voornaam,
	e.Achternaam,
	e.Orders	
})
.Select(c => new {
Employers = c.Key})
.Dump("Oefening 4");


/* 5. Toon de eerste letter en het aantal ProductNames dat met deze letter begint.
      We zien enkel de letters waarvoor er meer dan 2 producten zijn. */
Products
.GroupBy(p => p.ProductName[0])
.Select(p => new { 
Naam = p.Key,
Aantal = p.Count(),
}).Where(p => p.Aantal >=2)
.Dump("Oefening 5");