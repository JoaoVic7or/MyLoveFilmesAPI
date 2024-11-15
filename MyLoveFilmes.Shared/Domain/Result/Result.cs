namespace MyLoveFilmes.Shared.Domain.Result
{
    public partial class Result : IResult
    {
        public object Value { get; set; }
        public string Title { get; set; }
        public string Detail { get; }
        public string Error { get; set; }
        public bool IsSuccess { get; set; }
        public StatusCode StatusCode { get; set; }
        public IReadOnlyDictionary<string, string[]> Issues { get; set; }

        public object GetObjectValue()
        {
            return Value;
        }

        public bool HasValue()
        {
            return Value != null;
        }

        public Result(object value = default(object),
                      StatusCode statusCode = StatusCode.OK,
                      bool isSucess = true,
                      string error = null,
                      IReadOnlyDictionary<string, string[]> issues = null,
                      string title = null,
                      string detail = null)
        {
            Value = value;
            StatusCode = statusCode;
            IsSuccess = isSucess;
            Error = error;
            Issues = issues;
            Title = title;
            Detail = detail;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Success(string message)
        {
            return new Result(detail: message, statusCode: StatusCode.OK);
        }

        public static Result Fail(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.BadRequest, error: error);
        }

        public static Result BadRequest(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.BadRequest, error: error);
        }

        public static Result BadRequest(string error, IReadOnlyDictionary<string, string[]> issues)
        {
            return new Result(isSucess: false, statusCode: StatusCode.BadRequest, error: error, issues: issues);
        }

        public static Result NotFound()
        {
            return NotFound("Not found");
        }

        public static Result NotFound(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.NotFound, error: error);
        }

        public static Result Unauthorized(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.Unauthorized, error: error);
        }

        public static Result Forbidden(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.Forbidden, error: error);
        }

        public Result ServerInternalError(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.ServerInternalError, error: error);
        }

        public static Result ServiceUnavailable(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.ServiceUnavailable, error: error);
        }

        public static Result BadGateway(string error)
        {
            return new Result(isSucess: false, statusCode: StatusCode.BadGateway, error: error);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(default(T), StatusCode.BadGateway, false, error);
        }

        public static Task<Result> Ok()
        {
            throw new NotImplementedException();
        }
    }
}
