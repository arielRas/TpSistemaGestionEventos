using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ProvinciaDao
    {
        internal static string GetProvincia(int idProvincia)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var provinciaDb = ctx.PROVINCIA.SingleOrDefault(P => P.ID_PROVINCIA == idProvincia) ?? throw new ArgumentException("No se encuentra la provincia indicada");

                    return provinciaDb.NOMBRE.ToString();
                }
            }
            catch { throw; }
        }

        internal static int GetIdProvincia(string provincia)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {                    
                    var provinciaDb = ctx.PROVINCIA.SingleOrDefault(P => P.NOMBRE == provincia) ?? throw new ArgumentException("No se encuentra la provincia indicada");

                    return Convert.ToInt32(provinciaDb.ID_PROVINCIA);
                }
            }
            catch { throw; }
        }
    }
}
