using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FechaReservada
    {
       
        //ATRIBUTOS
        private DateTime fecha;
        private int reservas;
        private int maxReservas;


        //PROPIEDADES
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Reservas { get => reservas; set => reservas = value; }
        public int MaxReservas { get => maxReservas; set => maxReservas = value; }

    }
}
