using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Student s3 = null;
        //try
        //{
        //    s3 = new Student("James", "Bond", 50);
        //}
        //finally
        //{ 
        //    s3.Dispose();
        //}

        using var s1 = new Student("James", "Bond", 50);
        using var s2 = new Student("James", "Bond", 50);

        //This is oldschool
        //var name = s1.Name;
        //var lastName = s1.LastName;
        //var age = s1.Age;  

        //Now with deconstruct we can do it like here:
        //(string name, string lastName, int age) = s1;
        //or even better
        //(var name, var lastName, var age) = s1;
        //or even better
        var (name, lastName, age) = s1;

        DateTime date;
        var success = DateTime.TryParse("2000asdasdasd-04-12", null, out date);
        Console.WriteLine(success);
        Console.WriteLine(date);

        var successOfDivision = DivideOldSchool(4, 0, out int result);
        if (successOfDivision)
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Shit happened");
        }

        var resultOfNewDivision = Divide(10, 5);
        Console.WriteLine(resultOfNewDivision.Result);
        Console.WriteLine(resultOfNewDivision.Success);

        var (res, suc) = Divide(10, 5);

        Console.WriteLine(s1.LastName);

        //s1.Dispose(); //Don't do it like this
        Console.WriteLine("Just before the end of the program");

        Console.ReadKey();

        Console.WriteLine("Just after the Console.ReadKey");

    }

    public static (int Result, bool Success) Divide(int a, int b)
    {
        if (b == 0)
        {
            return (0, false);
        }

        return (a/b, true);

    }

    public static bool DivideOldSchool(int a, int b, out int result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }

        result = a / b;
        return true;
    }


    public class Student : IDisposable
    {
        public void Deconstruct(out string name, out string lastName, out int age)
        {
            name = Name; 
            lastName = LastName;
            age = Age;
        }

        public Student(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }

        public string Name { get; }
        public string LastName { get; }
        public int Age { get; }

        public void Dispose()
        {
            Console.WriteLine("I am now in the dispose method. A cleanup can be done here.");
        }

        ~Student() 
        {
            Console.WriteLine("I am in the finalizer now");
        }
    }
}