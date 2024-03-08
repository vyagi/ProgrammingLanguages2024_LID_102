namespace InvoiceApplication.BusinessLogic
{
    public class InvoiceProcessor
    {
        public Dictionary<string, decimal> GroupByCategories(List<string> invoices)
        {
            var entries = new Dictionary<string, decimal>();

            for (var i = 1; i < invoices.Count; i++)
            {
                var line = invoices[i];

                var split = line.Split(";");

                var category = split[2];
                var price = decimal.Parse(split[1]);

                if (entries.ContainsKey(category))
                {
                    entries[category] += price;
                }
                else
                {
                    entries[category] = price;
                }
            }

            return entries;
        }
    }
}