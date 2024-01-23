using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Evento
    {
        //ATRIBUTOS        
        private Guid codigoEvento;
        private string nombreEvento;
        private DateTime fechaHora;
        private string provincia;
        private string direccion;
        private string descripcion;
        private int cantMaxInvitados;
        private List<Invitado> invitados = new List<Invitado>();
        private List<ServicioPorCumplir> servContratados = new List<ServicioPorCumplir>();

        //PROPIEDADES
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantMaxInvitados { get => cantMaxInvitados; set => cantMaxInvitados = value; }
        public List<Invitado> Invitados { get => invitados; set => invitados = value; }
        public List<ServicioPorCumplir> ServContratados { get => servContratados; set => servContratados = value; }
        public Guid CodigoEvento { get => codigoEvento; set => codigoEvento = value; }
        public string NombreEvento { get => nombreEvento; set => nombreEvento = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
