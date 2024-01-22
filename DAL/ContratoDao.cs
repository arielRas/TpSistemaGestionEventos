using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContratoDao
    {

        public bool HayServiciosContratados(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.EVENTO_PROVEEDOR_SERVICIO.Any(E => E.ID_EVENTO == codEvento);
                }
            }
            catch { throw; }
        }


        public List<ServicioContratado> ListarServiciosContratados(Guid codEvento)
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    var serviciosContratados = new List<ServicioContratado>();

                    if (serviciosContratados.Any())
                    {
                        serviciosContratados = ctx.EVENTO_PROVEEDOR_SERVICIO
                                              .Where(E => E.ID_EVENTO == codEvento)
                                              .Select(E => new ServicioContratado
                                              {
                                                  Proveedor = new Usuario { Id = E.ID_PROVEEDOR },
                                                  ServicioContrato = new Servicio { idServicio = E.ID_SERVICIO },
                                                  Cantidad = E.CANTIDAD,
                                                  PrecioPorUnidad = Convert.ToDouble(E.PRECIO_UNITARIO),
                                                  MontoTotal = Convert.ToDouble(E.MONTO_TOTAL),
                                                  EsPago = Convert.ToBoolean(E.PAGO),
                                                  ServicioCumplido = Convert.ToBoolean(E.COMPLETADO)
                                              }).ToList();
                    } 
                    return serviciosContratados;
                }
            }
            catch { throw; }
        }       


        public bool HayServiciosPorCumplir(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.EVENTO_PROVEEDOR_SERVICIO.Any(E => E.ID_PROVEEDOR == idProveedor && E.COMPLETADO == false);
                }
            }
            catch { throw; }
        }


        public List<ServicioPorCumplir> ListarServiciosPorCumplir(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var serviciosPorCumplir = new List<ServicioPorCumplir>();

                    if (serviciosPorCumplir.Any())
                    {
                        serviciosPorCumplir = ctx.EVENTO_PROVEEDOR_SERVICIO
                                             .Where(E => E.ID_PROVEEDOR == idProveedor && E.COMPLETADO == false)
                                             .Select(E =>  new ServicioPorCumplir
                                             {
                                                 Evento = new EventoPublic { CodigoEvento = E.ID_EVENTO },
                                                 ServicioContrato = new Servicio { idServicio = E.ID_SERVICIO },
                                                 Cantidad = E.CANTIDAD,
                                                 PrecioPorUnidad = Convert.ToDouble(E.PRECIO_UNITARIO),
                                                 MontoTotal = Convert.ToDouble(E.MONTO_TOTAL),
                                                 EsPago = Convert.ToBoolean(E.PAGO),
                                                 ServicioCumplido = Convert.ToBoolean(E.COMPLETADO)
                                             }).ToList();                                                                        
                    }
                    return serviciosPorCumplir;
                }
            }
            catch { throw; }
        }
    }
}