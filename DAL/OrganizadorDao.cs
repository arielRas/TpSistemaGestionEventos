using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrganizadorDao
    {
        public void AltaOrganizador(Organizador organizador)
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    var organizadorDb = new ORGANIZADOR
                    {
                        NOMBRE = organizador.Nombre,
                        APELLIDO = organizador.Apellido,
                        EMAIL = organizador.Email,
                        DNI = organizador.Dni,
                        TELEFONO = organizador.Telefono,
                        ID_PROVINCIA = ProvinciaDao.GetIdProvincia(organizador.Provincia),
                        DIRECCION = organizador.Direccion
                    };

                    ctx.ORGANIZADOR.Add(organizadorDb);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


        public void ActualizarOrganizador(Organizador organizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var organizadorDb = ctx.ORGANIZADOR.SingleOrDefault(O => O.ID_ORGANIZADOR == organizador.Id) ?? throw new Exception("El usuario solicitado no existe");

                    organizadorDb.NOMBRE = organizador.Nombre;
                    organizadorDb.APELLIDO = organizador.Apellido;
                    organizadorDb.EMAIL = organizador.Email;
                    organizadorDb.DNI = organizador.Dni;
                    organizadorDb.TELEFONO = organizador.Telefono;
                    organizadorDb.ID_PROVINCIA = ProvinciaDao.GetIdProvincia(organizador.Provincia);
                    organizadorDb.DIRECCION = organizador.Direccion;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


        public Organizador GetOrganizador(Guid idOrganizador)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var organizadorDb = ctx.ORGANIZADOR.SingleOrDefault(O => O.ID_ORGANIZADOR == idOrganizador) ?? throw new Exception("El usuario solicitado no existe");

                    var organizador = new Organizador
                    {
                        Id = organizadorDb.ID_ORGANIZADOR,
                        Nombre = organizadorDb.NOMBRE,
                        Apellido = organizadorDb.APELLIDO,
                        Dni = organizadorDb.DNI,
                        Email = organizadorDb.EMAIL,
                        Telefono = organizadorDb.TELEFONO,
                        Provincia = ProvinciaDao.GetProvincia(organizadorDb.ID_PROVINCIA),
                        Direccion = organizadorDb.DIRECCION
                    };

                    return organizador;
                }
            }
            catch { throw; }
        }
    }
}
