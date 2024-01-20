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
    }
}