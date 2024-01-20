using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Organizador : Usuario
    {
        //ATRIBUTOS        
        private List<Evento> eventos = new List<Evento>();
      

        //PROPIEDADES           
        public List<Evento> Eventos { get => eventos; set => eventos = value; }        
    }
}
