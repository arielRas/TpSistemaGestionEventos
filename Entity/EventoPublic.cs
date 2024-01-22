using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EventoPublic
    {
        //PROPIEDADES PUBLICAS
        public Usuario Organizador {  get; set; }
        public Guid CodigoEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaHora { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
    }
}
