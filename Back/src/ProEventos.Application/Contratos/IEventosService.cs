using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
  public interface IEventoService
  {
    Task<Evento> AddEvento(Evento model);
    Task<Evento> UpdateEvento(int eventoId, Evento model);
    Task<bool> DeleteEvento(int eventoId);

    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
    Task<Evento> GeEventoByIdAsync(int EventoId, bool includePalestrante = false);
  }
}