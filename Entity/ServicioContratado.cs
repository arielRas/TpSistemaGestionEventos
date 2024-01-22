using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicioContratado : Contrato
    {
        //ATRIBUTOS
        private Usuario proveedor;
       

        //PROPIEDADES
        public Usuario Proveedor { get => proveedor; set => proveedor = value; }
        public Servicio ServicioContrato { get => servicioContrato; set => servicioContrato = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioPorUnidad { get => precioPorUnidad; set => precioPorUnidad = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public bool EsPago { get => esPago; set => esPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public bool ServicioCumplido { get => servicioCumplido; set => servicioCumplido = value; }
    }
}
