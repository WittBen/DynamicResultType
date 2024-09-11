namespace DynamicResultType;


public readonly struct Result<TValue, TError>
{
  private readonly TValue? _value;
  private readonly TError? _error;

  public bool IsError { get; }
  public bool IsSuccess => !IsError;

  private Result(TValue value)
  {
    IsError = false;
    _value = value;
    _error = default;
  }
  private Result(TError error)
  {
    IsError = true;
    _value = default;
    _error = error;
  }

  public static Result<TValue, TError> Failure(TError error) => new Result<TValue, TError>(error);
  public static Result<TValue, TError> Success(TValue value) => new Result<TValue, TError>(value);



  public TResult Match<TResult>(Func<TValue, TResult> success, Func<TError, TResult> failure)
  => !IsError ? success(_value!) : failure(_error!);
}
