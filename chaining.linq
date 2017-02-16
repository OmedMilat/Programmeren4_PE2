<Query Kind="Statements" />

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query = names
	.Where   (n => n.Contains ("a"))
	.OrderBy (n => n.Length)
	.Select  (n => n.ToUpper());
	
query.Dump();

// The same query constructed progressively:
IEnumerable<string> filtered   = names.Where      (n => n.Contains ("a"));
IEnumerable<string> sorted     = filtered.OrderBy (n => n.Length);
IEnumerable<string> finalQuery = sorted.Select    (n => n.ToUpper());

filtered.Dump   ("Filtered");
sorted.Dump     ("Sorted");
finalQuery.Dump ("FinalQuery");

// stripping out the vowels
(
	names
	.Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
	.Where(n => n.Length > 2)
	.OrderBy(n => n)
)
.Dump("Chaining in fluent syntax");

// mind the sequence!
(
	names
	.Where(n => n.Length > 2)
	.Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
	.OrderBy(n => n)
)
.Dump("Mind the sequence!");

// using into --> composition
(
	from n in names
	select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
	into noVowel
	where noVowel.Length > 2
	orderby noVowel
	select noVowel
)
.Dump("The preceding query revisited, with the 'into' keyword");