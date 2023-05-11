

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
            
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
           try
           {
            _geralPersist.Add<Evento>(model);
            if(await _geralPersist.SaveChangesAsync())
            {
                return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
            }
            return null;
           }
           catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }
        public async Task<Evento> UpdateEventos(int evendoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(evendoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if(await _geralPersist.SaveChangesAsync())
            {
                return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
            }
            return null;
           
            }
             catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
             try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
           
           
            }
             catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
               catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
         try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
               catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
         try
            {
                var eventos = await _eventoPersist.GetEventosByIdAsync(eventoId,includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
               catch (Exception error)
           {
            
            throw new Exception(error.Message);
           }
        }

    }
}