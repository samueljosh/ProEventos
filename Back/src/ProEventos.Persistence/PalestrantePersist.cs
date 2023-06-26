using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
  public class PalestrantePersist : IPalestrantePersist
  {
    private readonly ProEventosContext _context;
    public PalestrantePersist(ProEventosContext _context)
    {
      this._context = _context;
    }
    public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
        .Include(e => e.RedesSociais);

      if (includeEventos)
      {
        query = query
        .Include(e => e.PalestranteEventos)
        .ThenInclude(pe => pe.Evento);
      }
      query = query.AsNoTracking().OrderBy(e => e.Id);

      return await query.ToArrayAsync();
    }

    public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
   .Include(e => e.RedesSociais);

      if (includeEventos)
      {
        query = query
        .Include(e => e.PalestranteEventos)
        .ThenInclude(pe => pe.Evento);
      }
      query = query.AsNoTracking().OrderBy(e => e.Id)
        .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

      return await query.ToArrayAsync();
    }
    public async Task<Palestrante> GePalestranteByIdAsync(int palestranteId, bool includeEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
        .Include(e => e.RedesSociais);

      if (includeEventos)
      {
        query = query
        .Include(e => e.PalestranteEventos)
        .ThenInclude(pe => pe.Evento);
      }
      query = query.AsNoTracking().OrderBy(e => e.Id)
        .Where(p => p.Id == palestranteId);

      return await query.FirstOrDefaultAsync();
    }


  }
}