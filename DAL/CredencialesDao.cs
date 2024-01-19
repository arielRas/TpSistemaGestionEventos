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
                using(ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
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
                using (ContextDb ctx = new ContextDb())
                {
                    byte[] salt = ctx.CREDENCIALES.Where(C => C.ID == idUsuario).Select(C => C.SALT).FirstOrDefault() ?? throw new Exception("El usuario no existe");
                    
                    return salt;
                }
            }
            catch { throw; }
        }
    }
}
