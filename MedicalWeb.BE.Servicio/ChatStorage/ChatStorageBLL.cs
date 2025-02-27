using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio
{
    public class ChatStorageBLL : IChatStorageBLL
    {
        private readonly IChatStorageDAL _chatStorageDAL;
        private readonly IFileStorageDAL _fileStorageDAL;

        public ChatStorageBLL(IChatStorageDAL chatStorageDAL, IFileStorageDAL fileStorageDAL)
        {
            _chatStorageDAL = chatStorageDAL;
            _fileStorageDAL = fileStorageDAL;
        }

        public async Task SaveMessageAsync(ChatMessageRequest request, CancellationToken cancellationToken)
        {
            var chatMessage = new ChatMessage
            {
                HorarioMedicoId = request.HorarioMedicoId,
                PacienteId = request.PacienteId,
                Mensaje = request.Mensaje,
                FechaEnvio = DateTime.UtcNow,
                EsMedico = request.EsMedico
            };

            if (request.Archivo != null)
            {
                chatMessage.ArchivoUrl = await _fileStorageDAL.UploadFileAsync(request.Archivo, $"chats/{request.HorarioMedicoId}/", cancellationToken);
            }

            await _chatStorageDAL.SaveMessageAsync(chatMessage, cancellationToken);
        }

        public async Task<string> SaveFileAsync(IFormFile file, int horarioMedicoId, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("El archivo no puede estar vacío");

            return await _fileStorageDAL.UploadFileAsync(file, $"chats/{horarioMedicoId}/", cancellationToken);
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int horarioMedicoId, string zonaHoraria, CancellationToken cancellationToken)
        {
            var mensajes = await _chatStorageDAL.GetChatHistoryAsync(horarioMedicoId, cancellationToken);

            // Obtener la zona horaria del usuario
            TimeZoneInfo zonaUsuario;
            try
            {
                zonaUsuario = TimeZoneInfo.FindSystemTimeZoneById(zonaHoraria);
            }
            catch
            {
                zonaUsuario = TimeZoneInfo.Utc; // Si la zona horaria es inválida, usa UTC
            }

            // Convertir la fecha a la zona horaria del usuario
            var response = mensajes.Select(m => new ChatMessage
            {
                Id = m.Id,
                HorarioMedicoId = m.HorarioMedicoId,
                PacienteId = m.PacienteId,
                Mensaje = m.Mensaje,
                ArchivoUrl = m.ArchivoUrl,
                FechaEnvio = TimeZoneInfo.ConvertTimeFromUtc(m.FechaEnvio, zonaUsuario),
                EsMedico = m.EsMedico
            });

            return response;
        }


        public async Task<string> SaveRecordingAsync(IFormFile file, int horarioMedicoId, CancellationToken cancellationToken)
        {
            return await _fileStorageDAL.UploadFileAsync(file, $"recordings/{horarioMedicoId}/", cancellationToken);
        }

        public async Task<List<string>> GetRecordingsAsync(int horarioMedicoId, CancellationToken cancellationToken)
        {
            return await _fileStorageDAL.GetFilesAsync($"recordings/{horarioMedicoId}/", cancellationToken);
        }

    }
}