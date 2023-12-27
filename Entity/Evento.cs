using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Evento : EventoPublic
    {
        //ATRIBUTOS
        private string descripcion;
        private int cantMaxInvitados;
        private List<Invitado> invitados = new List<Invitado>();
        private List<ServicioContratado> servContratados = new List<ServicioContratado>();

        //PROPIEDADES
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantMaxInvitados { get => cantMaxInvitados; set => cantMaxInvitados = value; }
        public List<Invitado> Invitados { get => invitados; set => invitados = value; }
        public List<ServicioContratado> ServContratados { get => servContratados; set => servContratados = value; }
    }
}
