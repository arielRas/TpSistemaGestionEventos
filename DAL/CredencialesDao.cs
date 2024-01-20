using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CredencialesDao
    {
        public bool ExisteUsuario (string email, bool esProveedor) 
        {
            try
            {
                using(DbGestionEventos ctx = new DbGestionEventos())
                {
                    if (esProveedor) return ctx.PROVEEDOR.Any(P => P.EMAIL == email);

                    return ctx.ORGANIZADOR.Any(O => O.EMAIL == email);                   
                }
            }
            catch { throw; }
        }

        public bool ValidarCredenciales(Guid idUsuario, byte[] password)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    return ctx.CREDENCIALES.Any(C => C.ID == idUsuario && C.PASSWORD == password);
                }
            }
            catch { throw; }
        }
        
        public Guid GetIdUsuario(string email, bool esProveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    if(esProveedor) return ctx.PROVEEDOR.Where(P => P.EMAIL == email).Select(P => P.ID_PROVEEDOR).FirstOrDefault();

                    return ctx.ORGANIZADOR.Where(P => P.EMAIL == email).Select(P => P.ID_ORGANIZADOR).FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public byte[] GetUsuarioSalt(Guid idUsuario)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    byte[] salt = ctx.CREDENCIALES.Where(C => C.ID == idUsuario).Select(C => C.SALT).FirstOrDefault() ?? throw new Exception("El usuario no existe");
                    
                    return salt;
                }
            }
            catch { throw; }
        }


        public void AltaCredencial(Guid idUsuario, byte[] salt, byte[] hashedPassword)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var credencial = new CREDENCIALES
                    {
                        ID = idUsuario,
                        SALT = salt,
                        PASSWORD = hashedPassword
                    };

                    ctx.CREDENCIALES.Add(credencial);

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public void ActualizarCredencial(Guid idUsuario, byte[] salt, byte[] hashedPassword)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var credencial = ctx.CREDENCIALES.SingleOrDefault(C => C.ID == idUsuario) ?? throw new Exception("El usuario solicitado no existe");

                    credencial.SALT = salt;

                    credencial.PASSWORD = hashedPassword;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }
    }
}
