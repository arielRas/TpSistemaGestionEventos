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
                using (DbGestionEventos ctx = new DbGestionEventos())
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


        public bool Haypublicaciones(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.SERVICIO_PUBLICADO.Any(S => S.ID_PROVEEDOR == idProveedor);
                }
            }
            catch { throw; }
        }


        public List<ServicioPublicado> ListarServiciosPublicados()
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
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
                            MaxServPorDia = servicioPublicadoDb.CANT_SERV_DIARIOS,
                            Servicio = new Servicio { idServicio = servicioPublicadoDb.ID_SERVICIO }
                        };

                        serviciosPublicados.Add(servicioPublicado);
                    }

                    return serviciosPublicados;
                }
            }
            catch { throw; }
        }

        public List<ServicioPublicado> ListarServiciosPublicados(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {                    
                    var serviciosPublicados = new List<ServicioPublicado>();

                    serviciosPublicados = (from SP in ctx.SERVICIO_PUBLICADO
                                           join S in ctx.SERVICIO
                                           on SP.ID_SERVICIO equals S.ID_SERVICIO
                                           where SP.ID_PROVEEDOR == idProveedor
                                           select new ServicioPublicado
                                           {                                               
                                               Servicio = new Servicio
                                               {
                                                   idServicio = S.ID_SERVICIO,
                                                   Categoria = S.CATEGORIA,
                                                   Descripcion = S.DESCRIPCION
                                               },
                                               CodPublicacion = SP.ID_SERV_PUB,
                                               FechaPublicacion = SP.FECHA_PUBLICACION,
                                               Titulo = SP.NOMBRE,
                                               Descripcion = SP.DESCRIPCION,
                                               HaceEnvio = Convert.ToBoolean(SP.ENVIO),
                                               Precio = Convert.ToDouble(SP.PRECIO),
                                               ServFinDeSemana = Convert.ToBoolean(SP.FIN_DE_SEMANA),
                                               ServEntreSemana = Convert.ToBoolean(SP.ENTRE_SEMANA),
                                               MaxServPorDia = SP.CANT_SERV_DIARIOS
                                           }).ToList();                    

                    return serviciosPublicados;
                }
            }
            catch { throw; }
        }
    }
}
