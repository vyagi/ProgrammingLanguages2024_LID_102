using FluentAssertions;
using System.Diagnostics;
using System.Xml.Linq;

namespace InvoiceApplication.BusinessLogic.Tests
{
    public class InvoiceProcessorTests
    {
        [Fact]
        public void GroupByCategories_should_return_proper_data()
        {
            var invoiceProcessor = new InvoiceProcessor();

            var invoices = new List<string>
            {
                "Name; Price; Category",
                "Bread; 1000; Food",
                "Sushi; 2000; Food",
                "Lego; 2500; Toys",
                "Pizza; 100; Food",
                "New laptop; 50000; Equipment",
                "A model car; 400; Toys",
            };

            var categories = invoiceProcessor.GroupByCategories(invoices);

            categories.First().Item1.Should().Be("Food");
            categories.First().Item2.Should().Be(3100M);

            categories.Skip(1).First().Item1.Should().Be("Toys");
            categories.Skip(1).First().Item2.Should().Be(2900M);

            categories.Skip(2).First().Item1.Should().Be("Equipment");
            categories.Skip(2).First().Item2.Should().Be(50000M);
        }
    }
}