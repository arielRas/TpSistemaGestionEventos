using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FechaReservada
    {
        public FechaReservada(DateTime fecha, int maxReservas) 
        {
            this.fecha = fecha;
            this.maxReservas = maxReservas;
        }

        //ATRIBUTOS
        private DateTime fecha;
        private int maxReservas;

        //PROPIEDADES
        public DateTime Fecha { get => fecha;}
        public int MaxReservas { get => maxReservas; }

        //METODOS
        public void AgregarReserva()
        {
            if (maxReservas > 0) this.maxReservas--;
                else throw new Exception("El provedor ha alcanzado el limite diario para brindar este servicio");
        }
    }
}
