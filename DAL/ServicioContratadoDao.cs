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
        public List<ServicioContratado> GetAllServiciosContratados(Guid codEvento)
        {
            try
            {
                using(ContextDb ctx = new ContextDb())
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
    }
}