using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor : Persona, ISystemUser
    {
        //ATRIBUTOS        
        private float puntaje;      
        private List<ServicioPublicado>serviciosPublicados = new List<ServicioPublicado>();
        private List<ServicioContratado>serviciosPorCumplir = new List<ServicioContratado>();

        //PROPIEDADES

        public Guid Id { get; set; }
        public Int64 Dni { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public float Puntaje { get => puntaje; set => puntaje = value; }
        public List<ServicioPublicado> ServiciosPublicados { get => serviciosPublicados; set => serviciosPublicados = value; }
        public List<ServicioContratado> ServiciosPorCumplir { get => serviciosPorCumplir; set => serviciosPorCumplir = value; }
    }       
}
