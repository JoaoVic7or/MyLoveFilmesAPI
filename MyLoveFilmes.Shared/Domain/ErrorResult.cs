namespace MyLoveFilmes.Shared.Domain
{
    public class ErrorResult
    {
        public DateTime TimeStamp { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string TraceId { get; set; }
        public string StackTrace { get; set; }

        public IReadOnlyDictionary<string, string[]> Issues { get; set; }
        public string Error { get; set; }

        public static ErrorResult Create(StatusCode statusCode, string title, string detail, string traceId, string stackTrace, IReadOnlyDictionary<string, string[]> issues, string error)
        {
            return new ErrorResult()
            {
                TimeStamp = DateTime.Now,
                Status = (int)statusCode,
                Title = title,
                Detail = detail,
                TraceId = traceId,
                StackTrace = stackTrace,
                Issues = issues,
                Error = error
            };
        }
    }
}
