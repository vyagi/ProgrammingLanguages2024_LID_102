namespace InvoiceApplication.BusinessLogic
{
    public class Invoice
    {
        public static Invoice FromString(string input)
        {
            var split = input.Split(';');

            return new Invoice(split[0].Trim(), decimal.Parse(split[1]), split[2].Trim());
        }

        public Invoice(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public string Name { get; }
        public decimal Price { get; }
        public string Category { get; }
    }

    public class InvoiceProcessor
    {
        public List<(string, decimal)> GroupByCategories(List<string> invoices) => invoices
                .Skip(1)
                .Select(x => Invoice.FromString(x))
                .GroupBy(x => x.Category)
                .Select(x => (x.Key, x.Select(y => y.Price).Sum()))
                .ToList();
    }
}