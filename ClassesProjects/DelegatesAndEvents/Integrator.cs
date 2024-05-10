namespace DelegatesAndEvents
{
    //Nowadays this is Oldschool, so let's comment it out
    //public delegate double IntegrableFunction(double x);

    //Home work - parametrize the StartingPoint, EndingPoint and number of Midpoints
    public class Integrator
    {
        //Working on this class will be your homework (I am simplifying couple of things)
        public double StartingPoint { get; } = 0;
        public double EndingPoint { get; } = 10;
        public int Midpoints { get; } = 10;

        //public double Integrate(IntegrableFunction function) // I commented the oldschool thing
        public double Integrate(Func<double, double> function)
        {
            //double function(double x)
            //{
            //    return x * x;
            //}

            var arguments = new double[Midpoints + 1];
            var values = new double[Midpoints + 1];

            var argumentStep = (EndingPoint - StartingPoint) / Midpoints;

            for (int i = 0; i <= Midpoints; i++)
            {
                arguments[i] = StartingPoint + i * argumentStep;
                values[i] = function(arguments[i]);
            }

            var sum = 0.0;

            for (int i = 0; i < Midpoints; i++)
            {
                sum += argumentStep * (values[i] + values[i + 1]) / 2;
            }

            return sum;
        }
    }
}
