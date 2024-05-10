using System.Drawing;

namespace DelegatesAndEvents
{
    public delegate void NotifyAction(int floor);

    public class FloorReachedEventArgs : EventArgs
    {
        public int FloorReached { get; }

        public FloorReachedEventArgs(int floorReached) => FloorReached = floorReached;
    }

    //Your homework will be to paramterizethe MinFloor, MaxFloor, MilisecondsBetweenFloors
    //Also extend event mechanism to know if the floor reached was just intermediary or destination
    public class BetterElevator
    {
        public EventHandler<FloorReachedEventArgs> FloorReachedEvent;
        public int CurrentFloor { get; private set; }
        public int MinFloor => 0;
        public int MaxFloor => 5;
        public int MiliSecondsBetweenFloors => 1000;

        public void Move(int floor)
        {
            if (floor < MinFloor || floor > MaxFloor)
                throw new ArgumentOutOfRangeException(nameof(floor));

            Task.Run(async () =>
            {
                while (CurrentFloor != floor)
                {
                    await Task.Delay(MiliSecondsBetweenFloors);

                    CurrentFloor += CurrentFloor < floor ? 1 : -1;

                    FloorReachedEvent?.Invoke(this, new FloorReachedEventArgs(CurrentFloor));
                }
            });
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //var elevator = new Elevator();

            //elevator.NotifyAction += (int floor) => Console.WriteLine($"The {floor} floor reached");
            ////elevator.NotifyAction = null; //It would be possible with delegate but it is not with event
            //elevator.Move(3);

            //Console.ReadLine();

            var elevator = new BetterElevator();

            elevator.FloorReachedEvent += (sender, args) => Console.WriteLine($"The {args.FloorReached} floor reached");

            elevator.Move(3);

            Console.ReadLine();
        }


        static void MainForDelegates(string[] args)
        {
            var integrator = new Integrator();
            
            //What is the point of creating a varialbe to use it only once !
            //IntegrableFunction myDelegate = Squarer;
            //var area = integrator.Integrate(myDelegate);

            var area = integrator.Integrate(Squarer);

            Console.WriteLine(area);

            Console.WriteLine(integrator.Integrate(x => Math.Sin(x)));
        }

        public static double Squarer(double x) => x * x;
    }
}
