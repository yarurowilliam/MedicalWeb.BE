using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces
{
    public interface IChatStorageDAL
    {
        Task SaveMessageAsync(ChatMessage chatMessage, CancellationToken cancellationToken);
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int horarioMedicoId, CancellationToken cancellationToken);
    }
}