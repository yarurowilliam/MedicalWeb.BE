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

            // Convertir las rutas de archivo a URLs accesibles
            var baseUrl = $"{Request.Scheme}://{Request.Host}/uploads/";
            var recordingUrls = recordings
                .Select(file => baseUrl + file.Replace("\\", "/")) 
                .ToList();

            return Ok(recordingUrls);
        }

    }
}