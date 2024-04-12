public class Parser
{
    private Reader _reader;

    public Parser(Reader reader) => _reader = reader;

    public int Parse()
    {
		try
		{
            return int.Parse(_reader.Read());
        }
        catch (OverflowException ex)
		{
            return int.MaxValue;
		}
        catch (Exception ex)
        {
            //here log again
            Console.WriteLine($"Something wrong happened {ex.Message}");
            throw;
        }
    }
}


//Basic demo of exceptions

//try
//{
//    Console.WriteLine(ChangeStringToInt("ab1"));
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//	//throw;
//}
//Console.WriteLine("Program ended");

//static int ChangeStringToInt(string input)
//{
//    if (input.Any(x => !char.IsDigit(x)))
//        throw new InvalidOperationException("The input contains letters");

//    return int.Parse(input);
//}