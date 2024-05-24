namespace MultithreadingDemo
{
    internal class Program
    {
        private static int SomeValue;

        private static object Dummy = new();

        static void Main(string[] args)
        { 
            var t1 = new Thread(Increment);
            var t2 = new Thread(Increment);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(SomeValue);
        }

        private static void Increment()
        {
            for (int i = 0; i < 1_000_000_000; i++)
            {
                //Interlocked.Increment(ref SomeValue);
                lock (Dummy)
                {
                    SomeValue++;
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    var t = new Thread(TheJobToBeDone);
        //    //Console.WriteLine(t.IsBackground);
        //    t.IsBackground= true;

        //    t.Start();

        //    var list = new List<int>();

        //    for (int i = 0; i < 500_000_000; i++)
        //    {
        //        if (i > 0 && i % 100_000_000 == 0)
        //            Console.WriteLine($"{i} was reached in the main method");

        //        list.Add(i);
        //    }
        //    Console.WriteLine("The work is done in the main method");

        //    t.Join();

        //    //Console.ReadLine();
        //}

        public static void TheJobToBeDone()
        {
            var list = new List<int>();

            for (int i = 0; i < 1_000_000_000; i++)
            {
                if (i > 0 && i % 100_000_000 == 0)
                    Console.WriteLine($"{i} was reached");

                list.Add(i);
            }
            Console.WriteLine("The work is done");
        }
    }
}