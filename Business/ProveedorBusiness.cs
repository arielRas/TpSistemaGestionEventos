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
        private readonly OrganizadorDao organizadorDao = new OrganizadorDao();
        private readonly EventoDao eventoDao = new EventoDao();
        private readonly ServicioContratadoDao servicioContratadoDao = new ServicioContratadoDao();
        private readonly InvitadoDao invitadoDao = new InvitadoDao();
        private readonly CredencialesDao credencialesDao = new CredencialesDao();
        private readonly Encrypt encrypt = new Encrypt();
        
    }
}
