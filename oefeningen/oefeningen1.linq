<Query Kind="Statements" />

List<int> numbers = new List<int> { 20, 35, 17, 105, 90 };

// 1. Getallen deelbaar door 5
numbers.Where  (n => n % 5 == 0).Dump("Oefening 1");

// 2. grootste getal
numbers.Max().Dump("Oefening 2");

// 3. voorlaatste getal
numbers[numbers.Count-2].Dump("Oefening 3");


List<string> games = new List<string> { "Dominion", "Manillen", "Schaken", "Kolonisten van Catan", "Cluedo"};

// 4. Uit hoeveel letters bestaan alle spellen samen (spaties niet meetellen)?

games
.Select(n => n.Replace(" ",""))
.Sum (n => n.Length).Dump("Oefening 4");

// 5. koppel de nummers aan de spellen: nummer is prijs van spel op dezelfde positie
games
.Select(n => n.Replace(" ",""))
.Sum (n => n.Length)
.OrderBy(n => n).Dump("Oefening 5");