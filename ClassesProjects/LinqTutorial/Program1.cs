//int[] numbers1 = { 2, 5, 10, 12, 5, 1, 12, 2, 10, 11, 4 };
//int[] numbers2 = { 10, 1, 56, 7, 12, 1, 8, 5 , 1, 2, 2 };

#region Oldstuff
//Console.WriteLine(numbers1.Count());
//Console.WriteLine(numbers1.Sum());
//Console.WriteLine(numbers1.Min());
//Console.WriteLine(numbers1.Max());
//Console.WriteLine(numbers1.Average());

//var zip = numbers1.Zip(numbers2);
//var union = numbers1.Union(numbers2);
//var concat = numbers1.Concat(numbers2);
//var except = numbers1.Except(numbers2);
//var intersect = numbers1.Intersect(numbers2);

//var solution1 = numbers1.Except(numbers2).Union(numbers2.Except(numbers1));
//var solution2 = numbers1.Union(numbers2).Except(numbers1.Intersect(numbers2));

//var reverse = numbers1.Reverse();
//var takeWhile = numbers1.TakeWhile(x => x < 12);
//var skipWhile = numbers1.SkipWhile(x => x < 12);

//var takeLast = numbers1.TakeLast(4);
//var skipLast = numbers1.SkipLast(4);

//Console.WriteLine(numbers1.All(x => x < 12));
//Console.WriteLine(numbers1.Any(x => x < 12));

//var chunks = numbers1.Chunk(3);

//foreach (var chunk in chunks)
//{
//    Console.WriteLine("A new chunk: ");
//    foreach (var item in chunk)
//    {
//        Console.WriteLine(item);
//    }
//}
#endregion

//Console.WriteLine(numbers1.SequenceEqual(numbers2));
//Console.WriteLine(numbers1.SequenceEqual(numbers1));

//var names = new List<string> { "Marcin", "Antek", "Maksymilian", "Jaś", "Zorro"};

//Console.WriteLine(names.OrderByDescending(x => x.Length).First().Length);
//Console.WriteLine(names.MaxBy(x => x.Length).Length);



///////// Usage of IEnumerable in PolygonalChain
//using Geometry;

//var pc = new PolygonalChain(new Point(1,1), new Point(5,6));
//pc.AddMidpoint(new Point(1,2));
//pc.AddMidpoint(new Point(1,3));
//pc.AddMidpoint(new Point(1,4));
//pc.AddMidpoint(new Point(2,5));

//foreach (var point in pc)
//{
//    Console.WriteLine(point);
//    break;
//}
//Console.WriteLine(pc.First());
//Console.WriteLine(pc.Count());


///////////////////Some missing pieces from last semester
//var p1 = new Person
//{
//    Name = "JAmes Bond",
//    Age = 50
//};

//var p2 = new Person
//{
//    Name = "JAmes Bond",
//    Age = 50
//};

////Console.WriteLine(p1.Equals(p2));

//Console.WriteLine(p1.ToString());
//Console.WriteLine(p1.Name);
//public class Person
//{
//    public  int Age { get; init; }

//    public required string Name { get; init; }

//    //public override bool Equals(object? obj)
//    //{
//    //    var otherPerson = (Person)obj;
//    //    return Age == otherPerson.Age && Name == otherPerson.Name;
//    //}
//}