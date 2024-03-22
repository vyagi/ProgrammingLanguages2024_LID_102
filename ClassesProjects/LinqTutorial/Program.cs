using Geometry;

var pc = new PolygonalChain(new Point(1,1), new Point(5,6));
pc.AddMidpoint(new Point(1,2));
pc.AddMidpoint(new Point(1,3));
pc.AddMidpoint(new Point(1,4));
pc.AddMidpoint(new Point(2,5));

foreach (var point in pc)
{
    Console.WriteLine(point);
    break;
}
Console.WriteLine(pc.First());
Console.WriteLine(pc.Count());

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