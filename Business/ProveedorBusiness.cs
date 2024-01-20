using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProveedorBusiness
    {
        private readonly ProveedorDao proveedorDao = new ProveedorDao();
        private readonly ServicioPublicadoDao servPublDao = new ServicioPublicadoDao();
        private readonly ServicioContratadoDao servContrDao = new ServicioContratadoDao();
        private readonly FechaReservadaDao fechaReservadaDao = new FechaReservadaDao(); 
        private readonly EventoDao eventoDao = new EventoDao();

        private List<ServicioPublicado> ListarServiciosPublicados(Guid idProveedor)
        {
            try
            {
                return servPublDao.GetAllServicioPublicado(idProveedor);
            }
            catch { throw; }
        }


        private List<Guid> ListarEventosPorCumplir(Guid idProveedor)
        {
            try
            {
                return servContrDao.ListarEventosPorCumplir(idProveedor);
            }
            catch { throw; }
        }


        private List<ServicioContratado> ListarServiciosPorCumplir(List<Guid> codEventos)
        {
            try
            {
                var serviciosPorCumplir = new List<ServicioContratado>();

                codEventos.ForEach(C => serviciosPorCumplir.Add(servContrDao.ListarServiciosContratados(C)))
            }
            catch { throw; }
        }
    }
}
