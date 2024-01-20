using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioContratadoDao
    {
        public List<ServicioContratado> ListarServiciosContratados(Guid codEvento)
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    var serviciosContratadosDb = ctx.EVENTO_PROVEEDOR_SERVICIO.Where(E => E.ID_EVENTO == codEvento).ToList();

                    var serviciosContratados = new List<ServicioContratado>();

                    foreach(var servicioContratadoDb in serviciosContratadosDb)
                    {
                        var servicioContratado = new ServicioContratado
                        {
                            Cantidad = servicioContratadoDb.CANTIDAD,
                            PrecioPorUnidad = Convert.ToDouble(servicioContratadoDb.PRECIO_UNITARIO),
                            MontoTotal = Convert.ToDouble(servicioContratadoDb.MONTO_TOTAL),
                            EsPago = Convert.ToBoolean(servicioContratadoDb.PAGO),                            
                            ServicioCumplido = Convert.ToBoolean(servicioContratadoDb.COMPLETADO)
                        };

                        serviciosContratados.Add(servicioContratado);
                    }

                    return serviciosContratados;
                }
            }
            catch { throw; }
        }

        public List<Guid> ListarEventosPorCumplir(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    List<Guid> codEventos = ctx.EVENTO_PROVEEDOR_SERVICIO.Where(E => E.ID_PROVEEDOR == idProveedor).Select(E => E.ID_EVENTO).ToList();

                    return codEventos;
                }
            }
            catch { throw; }
        }


        public List<ServicioContratado> GetServiciosPorCumplir(Guid idProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var serviciosPorCumplirDb = ctx.EVENTO_PROVEEDOR_SERVICIO.Where(E => E.ID_PROVEEDOR == idProveedor && E.COMPLETADO == false).Select(E => E).ToList();

                    var serviciosPorCumplir = new List<ServicioContratado>();

                    if (serviciosPorCumplirDb.Any())
                    {
                        foreach (var servicioPorCumplirDb in serviciosPorCumplirDb)
                        {
                            var servicioPorCumplir = new ServicioContratado();
                            servicioPorCumplir.ServicioBrindado.idServicio = servicioPorCumplirDb.ID_SERVICIO;
                            servicioPorCumplir.Cantidad = servicioPorCumplirDb.CANTIDAD;
                            servicioPorCumplir.PrecioPorUnidad = Convert.ToDouble(servicioPorCumplirDb.PRECIO_UNITARIO);
                            servicioPorCumplir.MontoTotal = Convert.ToDouble(servicioPorCumplirDb.MONTO_TOTAL);
                            servicioPorCumplir.EsPago = Convert.ToBoolean(servicioPorCumplirDb.PAGO);
                            servicioPorCumplir.ServicioCumplido = Convert.ToBoolean(servicioPorCumplirDb.COMPLETADO);

                            serviciosPorCumplir.Add(servicioPorCumplir);                            
                        }                        
                    }

                    return serviciosPorCumplir;
                }
            }
            catch { throw; }
        }
    }
}