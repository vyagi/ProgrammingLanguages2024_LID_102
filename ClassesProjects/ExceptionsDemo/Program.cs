var calculator = new Calculator(new Parser(new Reader()));

Console.WriteLine(calculator.Calculate());


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