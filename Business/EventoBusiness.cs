using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Business
{
    internal class EventoBusiness
    {
        private readonly EventoDao eventoDao = new EventoDao();
        private readonly InvitadoDao invitadoDao = new InvitadoDao();
        private readonly ContratoDao contratoDao = new ContratoDao();

    }
}
