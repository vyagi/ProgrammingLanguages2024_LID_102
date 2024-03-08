using FluentAssertions;

namespace Geometry.Tests
{
    public class PolygonalChainTests
    {
        [Fact]
        public void PolygonalChain_can_be_created_and_start_and_end_are_valid()
        {
            var pc = new PolygonalChain(new Point(1, 2), new Point(3, 4));

            pc.Start.X.Should().Be(1);
            pc.Start.Y.Should().Be(2);

            pc.End.X.Should().Be(3);
            pc.End.Y.Should().Be(4);
        }

        [Fact]
        public void Midpoints_can_be_added_to_the_polygonal_chain()
        {
            var pc = new PolygonalChain(new Point(1, 2), new Point(3, 4));

            pc.AddMidpoint(new Point(0, 0));

            pc.Midpoints.Should().HaveCount(1);
            pc.Midpoints.First().X.Should().Be(0);
            pc.Midpoints.First().Y.Should().Be(0);
        }

        [Fact]
        public void Adding_the_same_midpoint_is_not_allowed()
        {
            var pc = new PolygonalChain(new Point(1, 2), new Point(3, 4));
            pc.AddMidpoint(new Point(0, 0));

            Action repeatingStartPoint = () => pc.AddMidpoint(new Point(1, 2));
            Action repeatingMidpoint = () => pc.AddMidpoint(new Point(0, 0));
            Action repeatingEndPoint = () => pc.AddMidpoint(new Point(3, 4));

            repeatingStartPoint.Should().Throw<ArgumentException>();
            repeatingMidpoint.Should().Throw<ArgumentException>();
            repeatingEndPoint.Should().Throw<ArgumentException>();
        }
    }
}
