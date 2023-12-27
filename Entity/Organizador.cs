using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Organizador : Persona
    {
        //ATRIBUTOS
        private string provincia;
        private string direccion;
        private string telefono;
        private List<Evento> eventos = new List<Evento>();

        //PROPIEDADES
        public string Provincia { get => provincia; set => provincia = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Evento> Eventos { get => eventos; set => eventos = value; }
    }
}
