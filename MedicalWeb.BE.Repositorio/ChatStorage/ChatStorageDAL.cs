using MedicalWeb.BE.Infraestructure;
using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio
{
    public class ChatStorageDAL : IChatStorageDAL
    {
        private readonly MedicalWebDbContext _context;

        public ChatStorageDAL(MedicalWebDbContext context)
        {
            _context = context;
        }

        public async Task SaveMessageAsync(ChatMessage message, CancellationToken cancellationToken)
        {
            _context.chatMessages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int horarioMedicoId, CancellationToken cancellationToken)
        {
            return await _context.chatMessages
                .Where(m => m.HorarioMedicoId == horarioMedicoId)
                .OrderBy(m => m.FechaEnvio)
                .ToListAsync(cancellationToken);
        }
    }
}
