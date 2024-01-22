using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contrato
    {
        protected Servicio servicioContrato;
        protected int cantidad;
        protected double precioPorUnidad;
        protected double montoTotal;
        protected bool esPago;
        protected DateTime fechaPago;
        protected bool servicioCumplido;
    }
}
