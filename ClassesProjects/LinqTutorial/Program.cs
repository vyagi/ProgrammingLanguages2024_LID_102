//List<int> numbers1 = new List<int>{ 2, 5, 10, 12, 5, 1, 12, 2, 10, 11, 4 };

//var greaterThanTen = numbers1.Where(x => x > 10);

//numbers1.Add(50);

//foreach (var item in greaterThanTen)
//{
//    Console.WriteLine(item);
//}

using System.Reflection.Metadata.Ecma335;

var persons = new Person[] {
    new Person(1, "James", "Bond", 58, new [] { "Spying", "Women", "Cars" }),
    new Person(2, "Kirk", "Hammett", 55, new [] { "Guitar", "Comic books", "Horrors" }),
    new Person(3, "Ozzy", "Ozbourne", 70, new [] { "Guitar", "Singing", "Women", "Alcohol", "Drugs" }),
    new Person(4, "John", "Lennon", 74, new [] { "Guitar", "Singing", "Poetry" }),
    new Person(5, "Donald", "Trump", 80, new [] { "Money", "Women", "Power" }),
    new Person(6, "Donald", "Duck", 71, new [] { "Seed", "Quacking" }),
    new Person(7, "John", "Travolta", 33, new [] { "Singing", "Acting" }),
};
var addresses = new Address[] {
    new Address(1, 1, "London", "Baker street", TypeOfAddress.Home),
    new Address(2, 1, "Birmingham", "Aldrige St.", TypeOfAddress.Mail),
    new Address(3, 2, "San Francisco", "10 Avenue", TypeOfAddress.Home),
    new Address(4, 2, "San Francisco", "Roman Blvd", TypeOfAddress.Mail),
    new Address(5, 2, "Los Angeles", "Mulholland Drive", TypeOfAddress.Temporary),
    new Address(6, 2, "Los Angeles", "Beverly Hills 90210", TypeOfAddress.Temporary),
    new Address(100, -1, "Moon", "Dark side", TypeOfAddress.Home),
    new Address(100, -1, "Sun", "Gas", TypeOfAddress.Temporary),
};

var query = from person in persons
            where person.Age < 70
            orderby person.Hobbies.Count() descending
            select $"{person.FirstName}";

var crappySyntaxJoin = from person in persons
               from address in addresses
               where person.Id == address.PersonId
               select new { Person = person, Address = address };

//works like inner join
var properJoin = from person in persons 
                join address in addresses 
                on person.Id equals address.PersonId
                select new { Person = person, Address = address };



public enum TypeOfAddress { Home, Mail, Temporary }
public record Person(int Id, string FirstName, string LastName, int Age, string[] Hobbies);
public record Address(int Id, int PersonId, string City, string Street, TypeOfAddress AddressType);


//var groupedByNumberOfHobbies = persons.GroupBy(x => x.Hobbies.Length);

//foreach (var collection in groupedByNumberOfHobbies)
//{
//    Console.WriteLine(collection.Key);
//    foreach (var item in collection)
//    {
//        Console.WriteLine(item.FirstName + " " + item.LastName);
//    }
//}

//Console.WriteLine("******************");

//var byAge = persons.GroupBy(x => x.Age / 10).OrderBy(x=>x.Key);
//foreach (var collection in byAge)
//{
//    Console.WriteLine(collection.Key * 10);
//    foreach (var item in collection)
//    {
//        Console.WriteLine(item.FirstName + " " + item.LastName);
//    }
//}