using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FechaReservadaDao
    {                
        public bool ExisteFechaReservada(Guid codPublicacion, DateTime fecha)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.FECHA_RESERVADA.Any(F => F.ID_SERV_PUB == codPublicacion && F.FECHA == fecha.Date);
                }
            }
            catch { throw; }
        }


        public bool HayFechasReservadas(Guid codPublicacion)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.FECHA_RESERVADA.Any(F => F.ID_SERV_PUB == codPublicacion);
                }
            }
            catch { throw; }
        }


        public FechaReservada GetFechaReservada(Guid codPublicacion, DateTime fecha)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var fechaReservadaDb = ctx.FECHA_RESERVADA.SingleOrDefault(F => F.ID_SERV_PUB == codPublicacion && F.FECHA == fecha.Date) 
                        ?? throw new Exception("No se encuentra la fecha indicada");

                    var fechaReservada = new FechaReservada
                    {
                        Fecha = fechaReservadaDb.FECHA,
                        Reservas = fechaReservadaDb.CANT_RESERVAS
                    };

                    return fechaReservada;
                }
            }
            catch { throw; }
        }


        public List<FechaReservada> ListarFechasReservadas(Guid codPublicacion)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var fechasReservadasDb = ctx.FECHA_RESERVADA.Where(F => F.ID_SERV_PUB == codPublicacion).ToList();

                    var fechasReservadas = new List<FechaReservada>();

                    foreach(var fechaReservadaDb in fechasReservadasDb)
                    {
                        var fechaReservada = new FechaReservada
                        {
                            Fecha = fechaReservadaDb.FECHA,
                            Reservas = fechaReservadaDb.CANT_RESERVAS
                        };

                        fechasReservadas.Add(fechaReservada);
                    }

                    return fechasReservadas;
                }
            }
            catch { throw; }
        }


        public void AltaFechaReservada(FechaReservada fecha, Guid codPublicacion)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var fechaReservadaDb = new FECHA_RESERVADA
                    {
                        ID_SERV_PUB = codPublicacion,
                        FECHA = fecha.Fecha,
                        CANT_RESERVAS = fecha.Reservas
                    };
                }
            }
            catch { throw; }
        }


        public void ModificarFechaReservada(Guid codPublicacion, FechaReservada fechaReservada)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var fechaReservadaDb = ctx.FECHA_RESERVADA.SingleOrDefault(F => F.ID_SERV_PUB == codPublicacion && F.FECHA == fechaReservada.Fecha.Date)
                        ?? throw new Exception("No se encuentra la fecha indicada");

                    fechaReservadaDb.CANT_RESERVAS = fechaReservada.Reservas;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }
    }
}
