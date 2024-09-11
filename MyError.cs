namespace DynamicResultType;

public class MyError : Exception
{
  public MyError(string message)
    : base(message) { }
}
