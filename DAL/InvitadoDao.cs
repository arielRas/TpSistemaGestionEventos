using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvitadoDao
    {
        public void AltaInvitado(Invitado invitado, Guid codEvento)
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    var invitadoDb = new INVITADO
                    {
                        ID_EVENTO = codEvento,
                        EMAIL = invitado.Email,
                        NOMBRE = invitado.Nombre,
                        APELLIDO = invitado.Apellido,
                        CANT_COMPANIONS = invitado.CantInvitados
                    };

                    ctx.INVITADO.Add(invitadoDb);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public void ModificarInvitado(Guid codEvento, Invitado invitado)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var invitadoDb = ctx.INVITADO.SingleOrDefault(I => I.ID_EVENTO == codEvento && I.EMAIL == invitado.Email) ?? throw new Exception("No se encuentra el invitado indicado");

                    invitadoDb.EMAIL = invitado.Email;
                    invitadoDb.NOMBRE = invitado.Nombre;
                    invitadoDb.APELLIDO = invitado.Apellido;
                    invitadoDb.CANT_COMPANIONS = invitado.CantInvitados;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public void BajaInvitado(Guid codEvento, string email)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var invitadoDb = ctx.INVITADO.SingleOrDefault(I => I.ID_EVENTO == codEvento && I.EMAIL == email) ?? throw new Exception("No se encuentra el invitado indicado");

                    ctx.INVITADO.Remove(invitadoDb);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public List<Invitado> GetAllinvitados(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var invitadosDb = ctx.INVITADO.Where(I => I.ID_EVENTO == codEvento).ToList();

                    var invitados = new List<Invitado>();

                    foreach(var invitadoDb in invitadosDb)
                    {
                        var invitado = new Invitado
                        {
                            Nombre = invitadoDb.NOMBRE,
                            Apellido = invitadoDb.APELLIDO,
                            Email = invitadoDb.EMAIL,
                            CantInvitados = invitadoDb.CANT_COMPANIONS
                        };

                        invitados.Add(invitado);
                    }

                    return invitados;
                }
            }
            catch { throw; }
        }

        public bool HayInvitados(Guid codEvento)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.INVITADO.Any(I => I.ID_EVENTO == codEvento);
                }
            }
            catch { throw; }
        }
    }
}
