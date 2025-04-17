using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio.Interfaces
{
    public interface IChatStorageBLL
    {
        Task SaveMessageAsync(ChatMessageRequest request, CancellationToken cancellationToken);
        Task<string> SaveFileAsync(IFormFile file, int horarioMedicoId, CancellationToken cancellationToken);
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int horarioMedicoId, string zonaHoraria, CancellationToken cancellationToken);
        Task<string> SaveRecordingAsync(IFormFile file, int horarioMedicoId, CancellationToken cancellationToken);
        Task<List<string>> GetRecordingsAsync(int horarioMedicoId, CancellationToken cancellationToken);

    }
}