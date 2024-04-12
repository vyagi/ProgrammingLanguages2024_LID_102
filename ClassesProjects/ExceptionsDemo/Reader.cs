public class Reader
{
    private string _path = "input1111.txt";

    public string Read()
    {
		try
		{
            return File.ReadAllText(_path);
        }
        catch (FileNotFoundException ex)
		{
			//Here some log, most often to a log file, but for now, let's just Console.Writeline
			Console.WriteLine("Here comes a problem...");

			throw new ThereIsNoFileException($"There was no file: {_path}", ex);
		}
        catch (Exception ex)
        {
            //Here some log, most often to a log file, but for now, let's just Console.Writeline
            Console.WriteLine("Here comes a really nasty problem...");
            throw;
        }
    }
}

public class ThereIsNoFileException : Exception
{
	public ThereIsNoFileException(string message, Exception innerException) : base(message, innerException)
	{

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