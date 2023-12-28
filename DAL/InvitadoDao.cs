﻿using Entity;
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
                using(ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
                {
                    var invitadoDb = ctx.INVITADO.SingleOrDefault(I => I.ID_EVENTO == codEvento && I.EMAIL == email) ?? throw new Exception("No se encuentra el invitado indicado");

                    ctx.INVITADO.Remove(invitadoDb);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }
    }
}
