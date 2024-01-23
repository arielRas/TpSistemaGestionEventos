using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicioPorCumplir : Contrato
    {
        //ATRIBUTOS
        private Guid codEvento;
        private EventoPublic evento;


        //PROPIEDADES
        public Guid CodEvento { get => codEvento; set => codEvento = value; }
        public EventoPublic Evento { get => evento; set => evento = value; }
        public Servicio ServicioContrato { get => servicioContrato; set => servicioContrato = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioPorUnidad { get => precioPorUnidad; set => precioPorUnidad = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public bool EsPago { get => esPago; set => esPago = value; }
        public bool ServicioCumplido { get => servicioCumplido; set => servicioCumplido = value; }
        
    }
}
