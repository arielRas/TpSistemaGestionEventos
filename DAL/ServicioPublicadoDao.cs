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
                    var servicioPublicadoDb = new SERVICIO_PUBLICADO
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
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var serviciosPublicadosDb = ctx.SERVICIO_PUBLICADO.ToList();

                    var serviciosPublicados = new List<ServicioPublicado>();

                    foreach(var servicioPublicadoDb in serviciosPublicadosDb)
                    {
                        var servicioPublicado = new ServicioPublicado
                        {
                            CodPublicacion = servicioPublicadoDb.ID_SERV_PUB,
                            FechaPublicacion = servicioPublicadoDb.FECHA_PUBLICACION,
                            Titulo = servicioPublicadoDb.NOMBRE,
                            Descripcion = servicioPublicadoDb.DESCRIPCION,
                            HaceEnvio = Convert.ToBoolean(servicioPublicadoDb.ENVIO),
                            Precio = Convert.ToDouble(servicioPublicadoDb.PRECIO),
                            ServFinDeSemana = Convert.ToBoolean(servicioPublicadoDb.FIN_DE_SEMANA),
                            ServEntreSemana = Convert.ToBoolean(servicioPublicadoDb.ENTRE_SEMANA),
                            MaxServPorDia = servicioPublicadoDb.CANT_SERV_DIARIOS
                        };

                        serviciosPublicados.Add(servicioPublicado);
                    }

                    return serviciosPublicados;
                }
            }
            catch { throw; }
        }

        public List<ServicioPublicado> GetAllServicioPublicado(Guid idProveedor)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var serviciosPublicadosDb = ctx.SERVICIO_PUBLICADO.Where(S => S.ID_PROVEEDOR == idProveedor).ToList();

                    var serviciosPublicados = new List<ServicioPublicado>();

                    foreach (var servicioPublicadoDb in serviciosPublicadosDb)
                    {
                        var servicioPublicado = new ServicioPublicado
                        {
                            CodPublicacion = servicioPublicadoDb.ID_SERV_PUB,
                            FechaPublicacion = servicioPublicadoDb.FECHA_PUBLICACION,
                            Titulo = servicioPublicadoDb.NOMBRE,
                            Descripcion = servicioPublicadoDb.DESCRIPCION,
                            HaceEnvio = Convert.ToBoolean(servicioPublicadoDb.ENVIO),
                            Precio = Convert.ToDouble(servicioPublicadoDb.PRECIO),
                            ServFinDeSemana = Convert.ToBoolean(servicioPublicadoDb.FIN_DE_SEMANA),
                            ServEntreSemana = Convert.ToBoolean(servicioPublicadoDb.ENTRE_SEMANA),
                            MaxServPorDia = servicioPublicadoDb.CANT_SERV_DIARIOS
                        };

                        serviciosPublicados.Add(servicioPublicado);
                    }

                    return serviciosPublicados;
                }
            }
            catch { throw; }
        }
    }
}
