using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProveedorBusiness
    {
        private readonly ProveedorDao proveedorDao = new ProveedorDao();
        private readonly ContratoDao contratoDao = new ContratoDao();
        private readonly ServicioPublicadoDao servPublDao = new ServicioPublicadoDao();
        private readonly FechaReservadaDao fechaReservadaDao = new FechaReservadaDao();
        private readonly UsuarioDao usuarioDao = new UsuarioDao();
        private readonly EventoDao eventoDao = new EventoDao();


        public Proveedor GetProveedor(Guid idProveedor)
        {
            try
            {
                var proveedor = proveedorDao.GetProveedor(idProveedor);

                proveedor = ObtenerRelaciones(proveedor);

                return proveedor;
            }
            catch { throw; }
        }


        private Proveedor ObtenerRelaciones(Proveedor proveedor)
        {
            try
            {
                if(HayServiciosPublicados(proveedor.Id)) proveedor.ServiciosPublicados = ListarServiciosPublicados(proveedor.Id);

                if(HayServiciosPorCumplir(proveedor.Id)) proveedor.ServiciosPorCumplir = ListarServiciosPorCumplir(proveedor.Id);

                return proveedor;
            }
            catch { throw; }
        }


        private List<ServicioPublicado> ListarServiciosPublicados(Guid idProveedor)
        {
            try
            {
                var serviciosPublicados = servPublDao.ListarServiciosPublicados(idProveedor);

                foreach (var publicacion in serviciosPublicados)
                {
                    if (HayFechasReservadas(publicacion.CodPublicacion))
                    {
                        publicacion.FechasReservados = ListarFechasReservadas(publicacion.CodPublicacion);
                    }
                }
                return serviciosPublicados;   
            }
            catch { throw; }
        }        


        private List<ServicioPorCumplir> ListarServiciosPorCumplir(Guid idProveedor)
        {
            try
            {
                var serviciosPorCumplir = contratoDao.ListarServiciosPorCumplir(idProveedor);

                foreach (var servicio in serviciosPorCumplir)
                {
                    servicio.Evento = GetEventoPublic(servicio.Evento.CodigoEvento);
                    servicio.Evento.Organizador = GetOrganizador(servicio.Evento.Organizador.Id);
                }

                return serviciosPorCumplir;
            }
            catch { throw; }
        }


        private EventoPublic GetEventoPublic(Guid codEvento)
        {
            try
            {
                return eventoDao.GetEventoPublic(codEvento);
            }
            catch { throw; }
        }


        private Usuario GetOrganizador(Guid idProveedor)
        {
            try
            {
                return usuarioDao.GetUsuario(idProveedor, false);
            }
            catch { throw; }
        }


        private bool HayServiciosPorCumplir(Guid idProveedor)
        {
            try
            {
                return contratoDao.HayServiciosPorCumplir(idProveedor);
            }
            catch { throw; }
        }


        private bool HayServiciosPublicados(Guid idProveedor)
        {
            try
            {
                return servPublDao.Haypublicaciones(idProveedor);
            }
            catch { throw; }
        }


        private bool HayFechasReservadas(Guid coPublicacion)
        {
            try
            {
                return fechaReservadaDao.HayFechasReservadas(coPublicacion);
            }
            catch { throw; }
        }


        private List<FechaReservada> ListarFechasReservadas(Guid codPublicacion)
        {
            try
            {
                return fechaReservadaDao.ListarFechasReservadas(codPublicacion);
            }
            catch { throw; }
        }
    }
}
