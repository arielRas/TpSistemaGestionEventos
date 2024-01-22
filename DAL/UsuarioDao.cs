using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDao
    {
        public void AltaUsuario(Usuario usuario, byte[] salt, byte[] hashedPasword, bool esProveedor)
        {
            try
            {
                using(var ctx = new DbGestionEventos())
                {
                    int idProvincia = ProvinciaDao.GetIdProvincia(usuario.Provincia);

                    ctx.SP_NUEVO_USUARIO(usuario.Nombre, usuario.Apellido, usuario.Email, idProvincia, usuario.Direccion, usuario.Telefono, usuario.Dni, esProveedor, salt, hashedPasword);
                }
            }
            catch { throw; }
        }


        public Usuario GetUsuario(Guid idUsuario, bool esProveedor)
        {
            try
            {
                using (var ctx = new DbGestionEventos())
                {
                    Usuario usuario = new Usuario();

                    if(esProveedor)
                    {
                        usuario = (from P in ctx.PROVEEDOR
                                   where P.ID_PROVEEDOR == idUsuario
                                   select new Usuario
                                   {
                                       Id = P.ID_PROVEEDOR,
                                       Nombre = P.NOMBRE,
                                       Apellido = P.APELLIDO,
                                       Email = P.EMAIL,
                                       Dni = P.DNI,
                                       Provincia = ProvinciaDao.GetProvincia(P.PROVINCIA.ID_PROVINCIA),
                                       Direccion = P.DIRECCION,
                                       Telefono = P.TELEFONO,
                                   }).SingleOrDefault();                        
                    }
                    else
                    {
                        usuario = (from O in ctx.ORGANIZADOR
                                   where O.ID_ORGANIZADOR == idUsuario
                                   select new Usuario
                                   {
                                       Id = O.ID_ORGANIZADOR,
                                       Nombre = O.NOMBRE,
                                       Apellido = O.APELLIDO,
                                       Email = O.EMAIL,
                                       Dni = O.DNI,
                                       Provincia = ProvinciaDao.GetProvincia(O.PROVINCIA.ID_PROVINCIA),
                                       Direccion = O.DIRECCION,
                                       Telefono = O.TELEFONO,
                                   }).SingleOrDefault();
                    }

                    return usuario;
                }
            }
            catch { throw; }
        }
    }
}