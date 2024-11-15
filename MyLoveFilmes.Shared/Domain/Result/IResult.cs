namespace MyLoveFilmes.Shared.Domain.Result
{
    public interface IResult
    {
        string Title { get; }
        bool IsSuccess { get; }

        string Error { get; }
        bool HasValue();
        object GetObjectValue();

        StatusCode StatusCode { get; }
        IReadOnlyDictionary<string, string[]> Issues { get; }
    }
}
