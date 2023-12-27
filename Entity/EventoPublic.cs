using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EventoPublic
    {
        //ATRIBUTOS
        protected Guid codigoEvento;
        protected string nombreEvento;
        protected DateTime fechaHora;
        protected string provincia;
        protected string direccion;

        //PROPIEDADES PUBLICAS
        public Guid CodigoEvento { get => codigoEvento; }
        public string NombreEvento { get => nombreEvento; }
        public DateTime FechaHora { get => fechaHora; }
        public string Provincia { get => provincia; }
        public string Direccion { get => direccion; }
    }
}
