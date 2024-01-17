using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioDao
    {
        public List<Servicio> ListarServicios()
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var serviciosDb = ctx.SERVICIO.ToList();

                    var servicios = new List<Servicio>();

                    foreach(var servicioDb in serviciosDb)
                    {
                        var servicio = new Servicio
                        {
                            idServicio = servicioDb.ID_SERVICIO,
                            Categoria = servicioDb.CATEGORIA,
                            Descripcion = servicioDb.DESCRIPCION
                        };
                        servicios.Add(servicio);
                    }

                    return servicios;
                }
            }
            catch { throw; }
        }
    }
}
