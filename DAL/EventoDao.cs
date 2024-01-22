using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventoDao
    {
        public bool ExisteEvento(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.EVENTO.Any(E => E.ID_EVENTO == codEvento);
                }
            }
            catch { throw; }
        }


        public bool HayEventos(Guid codOrganizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.EVENTO.Any(E => E.ID_ORGANIZADOR == codOrganizador);
                }
            }
            catch { throw; }
        }


        public void AltaEvento(Evento evento, Guid codOrganizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var eventoDb = new EVENTO
                    {
                       ID_ORGANIZADOR = codOrganizador,
                       NOMBRE = evento.NombreEvento,
                       DESCRIPCION = evento.Descripcion,
                       FECHA_HORA = evento.FechaHora,
                       ID_PROVINCIA = ProvinciaDao.GetIdProvincia(evento.Provincia),
                       DIRECCION = evento.Direccion,
                       CANT_INVITADOS = evento.CantMaxInvitados
                    };

                    ctx.EVENTO.Add(eventoDb);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


        public Guid GetIdNuevoEvento(Guid codOrganizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    Guid idNuevoEvento = ctx.EVENTO.Where(E => E.ID_ORGANIZADOR == codOrganizador).OrderByDescending(E => E.FECHA_HORA).Select(E => E.ID_EVENTO).FirstOrDefault();

                    return idNuevoEvento;
                }
            }
            catch { throw; }
        }


        public void ActualizarEvento(Evento evento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var eventoDb = ctx.EVENTO.SingleOrDefault(E => E.ID_EVENTO == evento.CodigoEvento) ?? throw new Exception("No se encuentra el evento indicado");

                    eventoDb.NOMBRE = evento.NombreEvento;
                    eventoDb.DESCRIPCION = evento.Descripcion;
                    eventoDb.FECHA_HORA = evento.FechaHora;
                    eventoDb.ID_PROVINCIA = ProvinciaDao.GetIdProvincia(evento.Provincia);
                    eventoDb.DIRECCION = evento.Direccion;
                    eventoDb.CANT_INVITADOS = evento.CantMaxInvitados;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


        public Evento GetEvento(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var eventoDb = ctx.EVENTO.SingleOrDefault(E => E.ID_EVENTO == codEvento) ?? throw new ArgumentException("No se encuentra el evento indicado");

                    var evento = new Evento
                    {
                        CodigoEvento = eventoDb.ID_EVENTO,
                        NombreEvento = eventoDb.NOMBRE,
                        FechaHora = eventoDb.FECHA_HORA,
                        Provincia = ProvinciaDao.GetProvincia(eventoDb.ID_PROVINCIA.Value),
                        Direccion = eventoDb.DIRECCION,
                        Descripcion = eventoDb.DESCRIPCION,
                        CantMaxInvitados = eventoDb.CANT_INVITADOS
                    };

                    return evento;
                }
            }
            catch { throw; }
        }

        public List<Evento> GetAllEventos(Guid IdOrganizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var codEventos = ctx.EVENTO.Where(E => E.ID_ORGANIZADOR == IdOrganizador).Select(E => E.ID_EVENTO).ToList();

                    var eventos = new List<Evento>();

                    codEventos.ForEach(C => eventos.Add(GetEvento(C)));

                    return eventos;
                }
            }
            catch { throw; }
        }


        public EventoPublic GetEventoPublic(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var eventoDb = ctx.EVENTO.SingleOrDefault(E => E.ID_EVENTO == codEvento) ?? throw new Exception("No se encuentra el evento indicado");

                    var eventoPublic = new EventoPublic
                    {
                        Organizador = new Usuario { Id = eventoDb.ID_ORGANIZADOR},
                        CodigoEvento = eventoDb.ID_EVENTO,
                        NombreEvento = eventoDb.NOMBRE,
                        FechaHora = eventoDb.FECHA_HORA,
                        Provincia = ProvinciaDao.GetProvincia(eventoDb.ID_PROVINCIA.Value),
                        Direccion = eventoDb.DIRECCION
                    };

                    return eventoPublic;
                }
            }
            catch { throw; }
        }


        public List<Evento> GetAllEventosPublic(Guid codOrganizador)
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    var eventosDb = ctx.EVENTO.Where(E => E.ID_ORGANIZADOR == codOrganizador).ToList();

                    var eventos = new List<Evento>();

                    foreach(var eventoDb in eventosDb)
                    {
                        var evento = new Evento 
                        {
                            CodigoEvento = eventoDb.ID_EVENTO,
                            NombreEvento = eventoDb.NOMBRE,
                            FechaHora = eventoDb.FECHA_HORA,
                            Provincia = ProvinciaDao.GetProvincia(eventoDb.ID_PROVINCIA.Value),
                            Direccion = eventoDb.DIRECCION
                        };

                        eventos.Add(evento);
                    }

                    return eventos;
                }
            }
            catch { throw; }
        }
        
    }
}
