using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoStreamController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<VideoStreamController> _logger;

        public VideoStreamController(IHttpClientFactory httpClientFactory, ILogger<VideoStreamController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("proxy")]
        public async Task<IActionResult> ProxyVideo([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("URL is required");
            }

            try
            {
                // Decodificar la URL si está codificada
                string decodedUrl = WebUtility.UrlDecode(url);
                _logger.LogInformation($"Proxying video from: {decodedUrl}");

                var httpClient = _httpClientFactory.CreateClient();

                // Configurar el cliente HTTP para manejar archivos grandes
                httpClient.Timeout = TimeSpan.FromMinutes(10);

                // Realizar solicitud HEAD para obtener información del archivo
                using (var headRequest = new HttpRequestMessage(HttpMethod.Head, decodedUrl))
                {
                    var headResponse = await httpClient.SendAsync(headRequest);
                    headResponse.EnsureSuccessStatusCode();

                    // Registrar información de headers
                    _logger.LogInformation($"Content-Type: {headResponse.Content.Headers.ContentType}");
                    _logger.LogInformation($"Content-Length: {headResponse.Content.Headers.ContentLength}");
                }

                // Realizar la solicitud GET para obtener el contenido
                using (var response = await httpClient.GetAsync(decodedUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var contentType = response.Content.Headers.ContentType?.ToString() ?? "video/webm";
                    var contentLength = response.Content.Headers.ContentLength;

                    // Asegurar que el tipo de contenido sea correcto para WebM
                    if (contentType.Contains("octet-stream") || string.IsNullOrEmpty(contentType))
                    {
                        contentType = "video/webm";
                    }

                    // Configurar los headers de respuesta
                    Response.Headers.Add("Accept-Ranges", "bytes");
                    Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                    Response.Headers.Add("Pragma", "no-cache");
                    Response.Headers.Add("Expires", "0");
                    Response.Headers.Add("Access-Control-Allow-Origin", "*");

                    // Establecer el tipo de contenido
                    Response.ContentType = contentType;

                    // Transmitir el contenido al cliente
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        await stream.CopyToAsync(Response.Body);
                    }

                    _logger.LogInformation($"Successfully proxied video: {decodedUrl}");
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error proxying video: {ex.Message}");
                return StatusCode(500, $"Error proxying video: {ex.Message}");
            }
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetVideoInfo([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("URL is required");
            }

            try
            {
                string decodedUrl = WebUtility.UrlDecode(url);
                var httpClient = _httpClientFactory.CreateClient();

                using (var headRequest = new HttpRequestMessage(HttpMethod.Head, decodedUrl))
                {
                    var response = await httpClient.SendAsync(headRequest);

                    var info = new
                    {
                        Url = decodedUrl,
                        StatusCode = (int)response.StatusCode,
                        StatusDescription = response.StatusCode.ToString(),
                        ContentType = response.Content.Headers.ContentType?.ToString(),
                        ContentLength = response.Content.Headers.ContentLength,
                        Headers = response.Headers.ToDictionary(h => h.Key, h => h.Value.FirstOrDefault()),
                        ContentHeaders = response.Content.Headers.ToDictionary(h => h.Key, h => h.Value.FirstOrDefault())
                    };

                    return Ok(info);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting video info: {ex.Message}");
                return StatusCode(500, $"Error getting video info: {ex.Message}");
            }
        }
    }
}