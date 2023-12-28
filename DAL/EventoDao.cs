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
        public void AltaEvento(Evento evento, Guid codOrganizador)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
                {
                    Guid idNuevoEvento = ctx.EVENTO.Where(E => E.ID_ORGANIZADOR == codOrganizador).OrderByDescending(E => E.FECHA_HORA).Select(E => E.ID_EVENTO).FirstOrDefault();

                    return idNuevoEvento;
                }
            }
            catch { throw; }
        }


        public void ModificarEvento(Evento evento)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
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


        public List<Evento> GetAllEventos(Guid codOrganizador)
        {
            try
            {
                using(ContextDb ctx = new ContextDb())
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
                            Direccion = eventoDb.DIRECCION,
                            Descripcion = eventoDb.DESCRIPCION,
                            CantMaxInvitados = eventoDb.CANT_INVITADOS
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
