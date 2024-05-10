internal class OldProgram
{
    private static void Main1(string[] args)
    {
        //First approach

        //OurDelegate d1;

        //d1 = SomeMethod;

        ////d1.Invoke();
        //d1();

        //d1 = AnotherMethod;
        //d1();

        //d1 += SomeMethod;
        //d1 += SomeMethod;
        //d1();

        //d1 -= AnotherMethod;
        //d1();

        OurDelegate d1 = SomeMethod;

        //Don't use it - although you can see it in very legacy code
        //d1 += delegate ()
        //{
        //    Console.WriteLine("Some anonymous function");
        //};

        d1 += () => Console.WriteLine("Now it's a lambda !");

        d1();
    }

    public static void SomeMethod()
    {
        Console.WriteLine("SomeMethod was called");
    }

    public static void AnotherMethod()
    {
        Console.WriteLine("AnotherMethod was called");
    }

    public delegate void OurDelegate();
}