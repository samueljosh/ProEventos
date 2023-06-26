using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
  public class EventoService : IEventoService
  {
    private readonly IGeralPersist _geralPersist;
    private readonly IEventoPersist _eventoPersist;
    public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
    {
      _geralPersist = geralPersist;
      _eventoPersist = eventoPersist;

    }
    public async Task<Evento> AddEvento(Evento model)
    {
      try
      {
        _geralPersist.Add<Evento>(model);
        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GeEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
      try
      {
        var evento = await _eventoPersist.GeEventoByIdAsync(eventoId, false);

        if (evento == null) return null;

        model.Id = evento.Id;

        _geralPersist.Update(model);

        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GeEventoByIdAsync(model.Id, false);
        }
        return null;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }
    public async Task<bool> DeleteEvento(int eventoId)
    {
      try
      {
        var evento = await _eventoPersist.GeEventoByIdAsync(eventoId, false);
        if (evento == null) throw new Exception("Evento para delete não encontrado.");

        _geralPersist.Delete(evento);

        return await _geralPersist.SaveChangesAsync();

      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
    {
      try
      {
        var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrante);
        if (eventos == null) return null;

        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }
    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
    {
      try
      {
        var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrante);
        if (eventos == null) return null;

        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }
    public async Task<Evento> GeEventoByIdAsync(int eventoId, bool includePalestrante = false)
    {
        try
      {
        var eventos = await _eventoPersist.GeEventoByIdAsync(eventoId, includePalestrante);
        if (eventos == null) return null;

        return eventos;
      }
      catch (Exception ex)
      {

        throw new Exception(ex.Message);
      }
    }

  }
}
