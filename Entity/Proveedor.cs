﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor : Persona
    {
        //ATRIBUTOS
        private Guid codProveedor;
        private float puntaje;
        private string provincia;
        private string direccion;
        private string telefono;
        private Int64 dni;
        private List<ServicioPublicado>serviciosPublicados = new List<ServicioPublicado>();
        private List<ServicioContratado>serviciosPorCumplir = new List<ServicioContratado>();

        //PROPIEDADES
        public Guid CodProveedor { get => codProveedor; set => codProveedor = value; }
        public Int64 Dni { get => dni; set => dni = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public float Puntaje { get => puntaje; set => puntaje = value; }
        public List<ServicioPublicado> ServiciosPublicados { get => serviciosPublicados; set => serviciosPublicados = value; }
        public List<ServicioContratado> ServiciosPorCumplir { get => serviciosPorCumplir; set => serviciosPorCumplir = value; }
        
    }
    
        
       
        
}
