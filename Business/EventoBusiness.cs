using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public class EventoBusiness
    {
        private readonly EventoDao eventoDao = new EventoDao();
        private readonly InvitadoDao invitadoDao = new InvitadoDao();

        public void AltaEvento(Evento evento, Guid idOrganizador)
        {
            try
            {
                if (ValidarEvento(evento)) eventoDao.AltaEvento(evento, idOrganizador);

            }
            catch { throw; }
        }

        public void ActualizarEvento(Evento evento)
        {
            try
            {
                if (ValidarEvento(evento)) eventoDao.ActualizarEvento(evento);
            }
            catch { throw; }
        }

        public void AgregarInvitado(Invitado invitado, Guid codEvento)
        {
            try
            {
                if (!ExisteEvento(codEvento)) throw new Exception("El evento al que intenta agregar el invitado no existe");

                if (EsEventoFinalizado(codEvento)) throw new Exception("No se puede agregar un invitado a un evento finalizado");

                if (ValidarInvitado(invitado)) invitadoDao.AltaInvitado(invitado, codEvento);
            }
            catch { throw; }            
        }


        private bool ExisteEvento(Guid codEvento)
        {
            try
            {
                return eventoDao.ExisteEvento(codEvento);
            }
            catch { throw; }
        }

        
        private bool EsEventoFinalizado(Guid codEvento)
        {
            try
            {
                return eventoDao.EsEventoFinalizado(codEvento, DateTime.Now);
            }
            catch { throw; }
        }


        private bool ValidarInvitado(Invitado invitado)
        {
            if (string.IsNullOrEmpty(invitado.Nombre)) throw new Exception("El campo nombre no puede estar vacio");
            if (string.IsNullOrEmpty(invitado.Apellido)) throw new Exception("El campo nombre no puede estar vacio");
            if (Regex.IsMatch(invitado.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception("El campo email no tiene formato valido");
            if (invitado.CantInvitados > 1) throw new Exception("la cantidad de invitados debe ser mayor o igual a uno");
            return true;
        }


        private bool ValidarEvento(Evento evento)
        {
            if (evento == null) throw new Exception("Complete los campos para poder crear el evento");
            if (string.IsNullOrEmpty(evento.NombreEvento)) throw new Exception("Debe asignar un nombre o titulo al evento");
            if (evento.NombreEvento.Length < 5) throw new Exception("El nombre del evento debe tener al menos 5 caracteres");
            if (evento.FechaHora <= DateTime.Now.Date) throw new Exception("El evento no puede realizarse el mismmo dia de la creacion");
            if (string.IsNullOrEmpty(evento.Provincia)) throw new Exception("El campo provincia no puede estar vacio");
            if (string.IsNullOrEmpty(evento.Descripcion)) throw new Exception("El campoDescripcion no puede estar vacio");
            if (evento.CantMaxInvitados <= 0) throw new Exception("El campo cantidad maxima de invitados no puede estar vacio y debe ser mayor cero");
            return true;
        }

    }
}
