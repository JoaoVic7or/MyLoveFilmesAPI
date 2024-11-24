using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterController : BaseController
	{
		public PosterController(IMediator mediator) : base(mediator)
		{ }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetPoster(string fileName)
        {
            string nginxUrl = $"http://192.168.1.131/{fileName}";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(nginxUrl);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var contentType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";
            var contentStream = await response.Content.ReadAsStreamAsync();

            return File(contentStream, contentType, fileName);
        }

        [Authorize]
        [HttpPost("{fileName}")]
        public async Task<IActionResult> SavePoster(string fileName, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo inválido.");
            }

            string nginxUrl = $"http://192.168.1.131/{fileName}";

            try
            {
                using var httpClient = new HttpClient();
                using var content = new MultipartFormDataContent();

                var fileStreamContent = new StreamContent(file.OpenReadStream());
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileStreamContent, "file", fileName);

                var response = await httpClient.PutAsync(nginxUrl, fileStreamContent);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, "Erro ao enviar o arquivo para o servidor.");
                }

                return Ok("Arquivo salvo com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}