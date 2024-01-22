using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor : Usuario
    {
        //ATRIBUTOS        
        private float puntaje;      
        private List<ServicioPublicado>serviciosPublicados = new List<ServicioPublicado>();
        private List<ServicioPorCumplir> serviciosPorCumplir = new List<ServicioPorCumplir>();

        //PROPIEDADES
        public float Puntaje { get => puntaje; set => puntaje = value; }
        public List<ServicioPublicado> ServiciosPublicados { get => serviciosPublicados; set => serviciosPublicados = value; }
        public List<ServicioPorCumplir> ServiciosPorCumplir { get => serviciosPorCumplir; set => serviciosPorCumplir = value; }
    }       
}
