using FluentAssertions;
using InvoiceApplication.BusinessLogic.Tests.Extensions;

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

            categories.First().Category.Should().Be("Food");
            categories.First().Amount.Should().Be(3100M);

            categories.Second().Category.Should().Be("Toys");
            categories.Second().Amount.Should().Be(2900M);

            categories.Third().Category.Should().Be("Equipment");
            categories.Third().Amount.Should().Be(50000M);
        }
    }
}