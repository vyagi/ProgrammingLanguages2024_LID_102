using System.Collections;
using System.Runtime.CompilerServices;

namespace Geometry
{
    public class PolygonalChain : Segment, IMoveable, IEnumerable<Point>
    {
        private List<Point> _midpoints = new List<Point>();

        public PolygonalChain(Point start, Point end) : base(start, end) { }

        public List<Point> Midpoints => _midpoints.Select(x=>x).ToList();

        public void AddMidpoint(Point midpoint)
        {
            var allPoints = _getAllPoints();

            if (allPoints.Any(x => x.X == midpoint.X && x.Y == midpoint.Y))
                throw new ArgumentException("The midpoint already exists");

            _midpoints.Add(midpoint);
        }

        public void Move(double x, double y)
        {
            _start.Move(x, y);
            _end.Move(x, y);

            foreach (var midpoint in _midpoints)
                midpoint.Move(x, y);
        }

        public override double Length
        {
            get
            {
                var allPoints = _getAllPoints();

                var totalLength = 0.0;
                for (int i = 0; i < allPoints.Count - 1; i++)
                {
                    var start = allPoints[i];
                    var end = allPoints[i + 1];
                    totalLength += new Segment(start, end).Length;
                }

                return totalLength;
            }
        }

        private List<Point> _getAllPoints()
        {
            var allPoints = new List<Point>();

            allPoints.Add(_start);
            allPoints.AddRange(_midpoints);
            allPoints.Add(_end);

            return allPoints;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            var startTime = DateTime.Now;
            Console.WriteLine($"The enumerator {new Random().Next(100)} was called at {startTime}");

            Console.WriteLine("It will now return _start");
            yield return _start;
            
            Console.WriteLine("Start was returned. Now it will now return Midpoints");

            foreach (var midpoint in Midpoints)
                yield return midpoint;

            Console.WriteLine("Midpoints were returned. Now it will now return _end");

            yield return _end;

            Console.WriteLine("Everything was returned");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}