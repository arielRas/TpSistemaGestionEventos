using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Organizador : Persona
    {
        private List<Evento> eventos = new List<Evento>();

        public List<Evento> Eventos { get => eventos; set => eventos = value; }
    }
}
