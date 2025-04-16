using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.API.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatStorageController : ControllerBase
    {
        private readonly IChatStorageBLL _chatStorageBLL;
        private readonly IFileStorageDAL _fileStorageDAL;

        public ChatStorageController(IChatStorageBLL chatStorageBLL, IFileStorageDAL fileStorageDAL)
        {
            _chatStorageBLL = chatStorageBLL;
            _fileStorageDAL = fileStorageDAL;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromForm] ChatMessageRequest request, CancellationToken cancellationToken)
        {
            await _chatStorageBLL.SaveMessageAsync(request, cancellationToken);
            return Ok(new { Message = "Mensaje guardado correctamente" });
        }

        [HttpGet("historial/{horarioMedicoId}")]
        public async Task<IActionResult> GetChatHistoryAsync(int horarioMedicoId, [FromQuery] string zonaHoraria, CancellationToken cancellationToken)
        {
            var chatHistory = await _chatStorageBLL.GetChatHistoryAsync(horarioMedicoId, zonaHoraria, cancellationToken);
            return Ok(chatHistory);
        }

        [HttpPost("upload-recording/{horarioMedicoId}")]
        public async Task<IActionResult> UploadRecording(int horarioMedicoId, IFormFile file, CancellationToken cancellationToken)
        {
            var url = await _chatStorageBLL.SaveRecordingAsync(file, horarioMedicoId, cancellationToken);
            return Ok(new { RecordingUrl = url });
        }

        [HttpGet("recordings/{horarioMedicoId}")]
        public async Task<IActionResult> GetRecordings(int horarioMedicoId, CancellationToken cancellationToken)
        {
            var recordings = await _fileStorageDAL.GetFilesAsync($"recordings/{horarioMedicoId}", cancellationToken);

            // Asegurar que siempre usamos HTTPS para las URLs
            var scheme = "https"; // Forzar HTTPS
            var host = Request.Host.ToString();

            // Si estamos en desarrollo local y usando localhost, mantener el esquema original
            if (host.Contains("localhost") || host.Contains("127.0.0.1"))
            {
                scheme = Request.Scheme;
            }

            var baseUrl = $"{scheme}://{host}/uploads/";

            var recordingUrls = recordings
                .Select(file => baseUrl + file.Replace("\\", "/"))
                .ToList();

            // Agregar encabezados CORS específicos para videos
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Range");
            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Length, Content-Range, Content-Disposition");

            return Ok(recordingUrls);
        }
    }
}