public class Calculator
{
    private Parser _parser;

    public Calculator(Parser parser) => _parser = parser;

    public int Calculate()
    {
        return 100 / _parser.Parse();
    }
}