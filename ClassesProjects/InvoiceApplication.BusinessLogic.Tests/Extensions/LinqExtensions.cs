namespace InvoiceApplication.BusinessLogic.Tests.Extensions;

public static class LinqExtensions
{
    public static T Second<T>(this IEnumerable<T> input) => input.Skip(1).First();
    public static T Third<T>(this IEnumerable<T> input) => input.Skip(2).First();
}
