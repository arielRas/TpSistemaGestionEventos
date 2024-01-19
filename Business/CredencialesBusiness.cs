using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CredencialesBusiness
    {
        private readonly CredencialesDao credencialesDao = new CredencialesDao();
        private readonly Encrypt encrypt = new Encrypt();

        public bool ValidarCredenciales(string email, string password, bool esProveedor)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new Exception("El usuario y la contraseña no pueden estar vacios");

                if (!credencialesDao.ExisteUsuario(email, esProveedor)) throw new Exception("El usuario ingresado no existe");

                Guid idUsuario = credencialesDao.GetIdUsuario(email, esProveedor);

                byte[] salt = credencialesDao.GetUsuarioSalt(idUsuario);

                byte[] hashedPassword = encrypt.GethashedPassword(password, salt);

                return credencialesDao.ValidarCredenciales(idUsuario, hashedPassword);                
            }
            catch { throw; }
        }
    }
}
