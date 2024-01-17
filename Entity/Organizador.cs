using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Organizador : Persona, ISystemUser
    {
        //ATRIBUTOS        
        private List<Evento> eventos = new List<Evento>();
      

        //PROPIEDADES
        public Guid Id { get; set; }
        public Int64 Dni { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }        
        public List<Evento> Eventos { get => eventos; set => eventos = value; }
    }
}
