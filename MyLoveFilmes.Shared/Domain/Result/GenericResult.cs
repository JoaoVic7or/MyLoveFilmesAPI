namespace MyLoveFilmes.Shared.Domain.Result
{
    public sealed partial class Result<T> : IResult
    {
        public T Value { get; }
        public string Title { get; }
        public string Detail { get; }
        public string Error { get; }
        public bool IsSuccess { get; }
        public StatusCode StatusCode { get; }
        public IReadOnlyDictionary<string, string[]> Issues { get; }

        public object GetObjectValue()
        {
            return Value;
        }

        public bool HasValue()
        {
            return Value != null;
        }

        public Result(T value = default(T),
                      StatusCode statusCode = StatusCode.OK,
                      bool isSuccess = true,
                      string error = null,
                      IReadOnlyDictionary<string, string[]> issues = null,
                      string title = null,
                      string detail = null)
        {
            Value = value;
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            Error = error;
            Issues = issues;
            Title = title;
            Detail = detail;
        }

        public static implicit operator bool(Result<T> Result)
        {
            return Result.IsSuccess;
        }

        public static implicit operator Result<T>(Result result)
        {
            T resultValue = default(T);

            if (result.HasValue())
                resultValue = (T)result.Value;

            return new Result<T>(resultValue, result.StatusCode, result.IsSuccess, result.Error, result.Issues, result.Title, result.Detail);
        }

        public static implicit operator Result(Result<T> result)
        {
            return new Result(result.Value, result.StatusCode, result.IsSuccess, result.Error, result.Issues, result.Title, result.Detail);
        }
    }
}
