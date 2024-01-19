using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public class OrganizadorBusiness
    {
        private readonly OrganizadorDao organizadorDao = new OrganizadorDao();
        private readonly EventoDao eventoDao = new EventoDao();
        private readonly ServicioContratadoDao servicioContratadoDao = new ServicioContratadoDao();
        private readonly InvitadoDao invitadoDao = new InvitadoDao();
       

        public void AltaOrganizador(Organizador organizador)
        {
            try
            {
                if (ValidarDatos(organizador))
                {
                    organizadorDao.AltaOrganizador(organizador);
                }
            }
            catch { throw; }
        }

        public void ActualizarOrganzador(Organizador organizador)
        {
            try
            {
                if (ValidarDatos(organizador))
                {
                    organizadorDao.ActualizarOrganizador(organizador);
                }
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
                organizador.Eventos = ListarEventos(organizador.Id);

                organizador.Eventos.ForEach(E => E.ServContratados = ListarServiciosContratados(E.CodigoEvento));

                organizador.Eventos.ForEach(E => E.Invitados = ListarInvitados(E.CodigoEvento));

                return organizador;
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
                return servicioContratadoDao.GetAllServiciosContratados(codEvento);
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
    }
}
