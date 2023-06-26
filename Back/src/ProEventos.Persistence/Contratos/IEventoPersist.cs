using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
  public interface  IEventoPersist
  {
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
    Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
    Task<Evento> GeEventoByIdAsync(int EventoId, bool includePalestrante = false);
  }
}