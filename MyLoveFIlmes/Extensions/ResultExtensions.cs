using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Extensions
{
    public static class ResultHelper
    {
        public static IActionResult AsResult(Result result)
        {
            if (result.IsSuccess)
            {
                var response = string.IsNullOrEmpty(result.Detail) ? result.GetObjectValue() : result.Detail;
                return new OkObjectResult(response);
            }

            return new ObjectResult(new { error = result.Error, detail = result.Detail })
            {
                StatusCode = (int)result.StatusCode
            };
        }

        public static IActionResult AsResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(result.GetObjectValue());
            }

            return new ObjectResult(new { error = result.Error, detail = result.Detail })
            {
                StatusCode = (int)result.StatusCode
            };
        }
    }
}
