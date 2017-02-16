<Query Kind="Statements" />

var names = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" }.AsQueryable();
// Lambda Syntax - Extension methods
var query = names
			 .Select( n => new
				 {
					 Original = n,
					 Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
				 }
			  );
query.Dump();



// Query Syntax
var query2 = from n in names
select new
{
	Original = n,
	Vowelless = n.Replace ("a", "").Replace ("e", "").Replace ("i", "").Replace ("o", "").Replace ("u", "")
};
query2.Dump();
