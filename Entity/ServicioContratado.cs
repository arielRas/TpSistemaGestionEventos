using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicioContratado
    {
        //ATRIBUTOS
        private Persona proveedor;
        private Persona organizador;
        private Servicio servicio;
        private int cantidad;
        private double precioPorUnidad;
        private double montoTotal;
        private bool esPago;
        private DateTime fechaPago;
        private bool servicioCumplido;

        //PROPIEDADES
        public Persona Proveedor { get => proveedor; set => proveedor = value; }
        public Persona Organizador { get => organizador; set => organizador = value; }
        public Servicio Servicio { get => servicio; set => servicio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioPorUnidad { get => precioPorUnidad; set => precioPorUnidad = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public bool EsPago { get => esPago; set => esPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public bool ServicioCumplido { get => servicioCumplido; set => servicioCumplido = value; }
    }
}
