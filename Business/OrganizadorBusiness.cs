using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Business
{
    public class OrganizadorBusiness
    {
        private readonly OrganizadorDao organizadorDao = new OrganizadorDao();
        private readonly EventoDao eventoDao = new EventoDao();
        private readonly ContratoDao contratoDao = new ContratoDao();
        private readonly InvitadoDao invitadoDao = new InvitadoDao();
       
        public void ActualizarOrganizador(Organizador organizador)
        {
            try
            {
                using(var transaction = new TransactionScope())
                {
                    if (ValidarDatos(organizador)) organizadorDao.ActualizarOrganizador(organizador);
                }
            }
            catch { throw; }
        }

        public Organizador GetOrganizador(Guid idOrganizador)
        {
            try
            {                
                var organizador = organizadorDao.GetOrganizador(idOrganizador);

                organizador = ObtenerRelaciones(organizador);

                return organizador;
            }
            catch { throw; }
        }

        private Organizador ObtenerRelaciones(Organizador organizador)
        {
            try
            {
                if (HayEventos(organizador.Id))
                {
                    organizador.Eventos = ListarEventos(organizador.Id);

                    foreach(var evento in organizador.Eventos)
                    {
                        if(HayServiciosContratados(evento.CodigoEvento)) evento.ServContratados = ListarServiciosContratados(evento.CodigoEvento);

                        if (HayInvitados(evento.CodigoEvento)) evento.Invitados = ListarInvitados(evento.CodigoEvento);
                    }
                }
                return organizador;
            }
            catch { throw; }
        }

        private bool HayEventos(Guid idOrganizador)
        {
            try
            {
                return eventoDao.HayEventos(idOrganizador);
            }
            catch { throw; }
        }


        private bool HayServiciosContratados(Guid codEvento)
        {
            try
            {
                return contratoDao.HayServiciosContratados(codEvento);
            }
            catch { throw; }
        }


        private bool HayInvitados(Guid codEvento)
        {
            try
            {
                return invitadoDao.HayInvitados(codEvento);
            }
            catch { throw; }
        }


        private List<Evento> ListarEventos(Guid idOrganizador)
        {
            try
            {
                return eventoDao.GetAllEventos(idOrganizador);
            }
            catch { throw; }
        }

        private List<ServicioContratado> ListarServiciosContratados(Guid codEvento)
        {
            try
            {
                return contratoDao.ListarServiciosContratados(codEvento);
            }
            catch { throw; }
        }


        private List<Invitado> ListarInvitados(Guid CodEvento)
        {
            try
            {
                return invitadoDao.GetAllinvitados(CodEvento);
            }
            catch { throw; }
        }


        private bool ValidarDatos(Organizador organizador)
        {
            try
            {
                if (string.IsNullOrEmpty(organizador.Nombre)) throw new Exception("El campo nombre no puede estar vacio");

                if (string.IsNullOrEmpty(organizador.Apellido)) throw new Exception("El campo apellido no puede estar vacio");

                if (string.IsNullOrEmpty(organizador.Provincia)) throw new Exception("El campo provincia no puede estar vacio");

                if (string.IsNullOrEmpty(organizador.Direccion)) throw new Exception("El campo direccion no puede estar vacio");

                if (string.IsNullOrEmpty(organizador.Email)) throw new Exception("El campo email no puede estar vacio");

                if (!Regex.IsMatch(organizador.Telefono, @"^\d+")) throw new Exception("El campo telefono solo admite campos numericos");

                if (Regex.IsMatch(organizador.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception("El campo email no tiene formato valido");

                if (organizador.Dni.ToString().Length != 8) throw new Exception("El campo de DNI debe tener 8 caracteres");

                return true;
            }
            catch { throw; }
        }
    }
}
