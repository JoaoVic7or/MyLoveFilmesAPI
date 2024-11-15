namespace MyLoveFilmes.Shared.Domain
{
    public enum StatusCode
    {
        OK = 200,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        ServerInternalError = 500,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504
    }
}
