using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioPublicadoDao
    {
        public void AltaServicioPublicado(ServicioPublicado servicioPublicado, Guid idProveedor)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var ServicioPublicadoDb = new SERVICIO_PUBLICADO
                    {
                        FECHA_PUBLICACION = servicioPublicado.FechaPublicacion,
                        NOMBRE = servicioPublicado.Titulo,
                        DESCRIPCION = servicioPublicado.Descripcion,
                        ID_PROVEEDOR = idProveedor,
                        ID_SERVICIO = servicioPublicado.Servicio.idServicio,
                        ENVIO = servicioPublicado.HaceEnvio,
                        PRECIO = Convert.ToDecimal(servicioPublicado.Precio),
                        FIN_DE_SEMANA = servicioPublicado.ServFinDeSemana,
                        ENTRE_SEMANA = servicioPublicado.ServEntreSemana,
                        CANT_SERV_DIARIOS = servicioPublicado.MaxServPorDia
                     };
                }
            }
            catch { throw; }
        }

        public List<ServicioPublicado> GetAllServicioPublicado()
    }
}
