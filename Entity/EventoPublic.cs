using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EventoPublic
    {
        //CONSTRUCTOR
        public EventoPublic(Evento evento)
        { 
            this.evento = evento;
        }

        //ATRIBUTOS
        private Evento evento;

        //PROPIEDADES
        public Usuario Organizador { get; set; }
        public string NombreEvento { get => evento.NombreEvento; }
        public DateTime FechaHora { get => evento.FechaHora; }
        public string Provincia { get => evento.Provincia; }
        public string Direccion { get => evento.Direccion; }
    }
}