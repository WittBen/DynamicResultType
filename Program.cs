using System;

namespace DynamicResultType;


class Program
{
  static void Main()
  {
    var divisionResult = Divide(10, 0);

    var myResult = divisionResult.Match(
       resultValue => "Division succeeded. Result: " + resultValue,
       errorMessage => "Division failed with the error: " + errorMessage.Message);

    Console.WriteLine(myResult);

    Console.ReadKey();
  }

  static Result<int, MyError> Divide(int numerator, int denominator)
  {
    if (denominator == 0)
    {
      return Result<int, MyError>.Failure(new MyError("Division by zero is not allowed."));
    }

    int result = numerator / denominator;
    return Result<int, MyError>.Success(result);
  }


}
