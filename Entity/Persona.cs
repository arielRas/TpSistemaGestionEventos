using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        protected string nombre;
        protected string apellido;
        protected string email;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
    }
}
