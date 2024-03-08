using FluentAssertions;

namespace Geometry.Tests
{
    public class PointTests
    {
        [Fact]
        public void Point_created_with_parameterless_constructor_is_0_0()
        {
            var point = new Point();

            point.X.Should().Be(0);
            point.Y.Should().Be(0);
        }

        [Fact]
        public void Point_created_with_one_parameter_constructor_has_x_equal_y()
        {
            var point = new Point(5.6);

            point.X.Should().Be(5.6);
            point.Y.Should().Be(5.6);
        }

        [Fact]
        public void Point_created_with_two_parameters_constructor_has_proper_x_y()
        {
            var point = new Point(5.6,-3.5);

            point.X.Should().Be(5.6);
            point.Y.Should().Be(-3.5);
        }

        [Fact]
        public void Point_moved_has_proper_coordinates()
        {
            var point = new Point(-2, 3);

            point.Move(-2.5, -3.5);

            point.X.Should().Be(-4.5);
            point.Y.Should().Be(-0.5);
        }

        [Fact]
        public void Point_distance_is_calculated_correctly()
        {
            var point = new Point(3, 4);

            var distance = point.Distance();

            distance.Should().Be(5);
        }

        [Fact]
        public void Point_string_representation_is_correct()
        {
            var point = new Point(3, 4);

            var stringRepresentation = point.ToString();

            stringRepresentation.Should().Be("(3,4)");
        }
    }
}