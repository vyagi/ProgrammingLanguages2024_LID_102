namespace Geometry
{
    public class PolygonalChain : Segment, IMoveable
    {
        private List<Point> _midpoints = new List<Point>();

        public List<Point> Midpoints => _midpoints.Select(x=>x).ToList();

        public PolygonalChain(Point start, Point end) : base(start, end) { }

        public void AddMidpoint(Point midpoint)
        {
            var allPoints = new List<Point>();
            allPoints.Add(_start);
            allPoints.AddRange(_midpoints);
            allPoints.Add(_end);

            if (allPoints.Any(x=>x.X == midpoint.X && x.Y == midpoint.Y))
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
                var allPoints = new List<Point>();
                allPoints.Add(_start);
                allPoints.AddRange(_midpoints);
                allPoints.Add(_end);

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
    }
}