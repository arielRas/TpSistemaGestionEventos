using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicioPublicado
    {
        //ATRIBUTOS
        private string titulo;
        private DateTime fechaPublicacion;
        private string descripcion;
        private Servicio servicio;
        private double precio;
        private bool haceEnvio;
        private bool servFinDeSemana;
        private bool servEntreSemana;
        private int maxServPorDia;
        private List<FechaReservada> fechasReservados = new List<FechaReservada>();


        //PROPIEDADES
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Servicio Servicio { get => servicio; set => servicio = value; }
        public double Precio { get => precio; set => precio = value; }
        public bool HaceEnvio { get => haceEnvio; set => haceEnvio = value; }
        public bool ServFinDeSemana { get => servFinDeSemana; set => servFinDeSemana = value; }
        public bool ServEntreSemana { get => servEntreSemana; set => servEntreSemana = value; }
        public int MaxServPorDia { get => maxServPorDia; set => maxServPorDia = value; }
        public List<FechaReservada> FechasReservados { get => fechasReservados; set => fechasReservados = value; }
    }
}
