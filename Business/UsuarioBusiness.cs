using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioDao usuarioDao = new UsuarioDao();
        private readonly CredencialesDao credencialesDao = new CredencialesDao();
        private readonly Encrypt encrypt = new Encrypt();

        public bool ValidarCredenciales(string email, string password, bool esProveedor)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new Exception("El usuario y la contraseña no pueden estar vacios");

                if (!ExisteUsuario(email, esProveedor)) throw new Exception("El usuario ingresado no existe");

                Guid idUsuario = GetIdUsuario(email, esProveedor);

                byte[] salt = GetUsuarioSalt(idUsuario);

                byte[] hashedPassword = encrypt.GethashedPassword(password, salt);

                return credencialesDao.ValidarCredenciales(idUsuario, hashedPassword);                
            }
            catch { throw; }
        }


        private bool ExisteUsuario(string email, bool esProveedor)
        {
            try
            {
                return credencialesDao.ExisteUsuario(email, esProveedor);
            }
            catch { throw; }
        }


        private Guid GetIdUsuario(string email, bool esProveedor)
        {
            try
            {
                return credencialesDao.GetIdUsuario(email, esProveedor);
            }
            catch { throw; }
        }


        private byte[] GetUsuarioSalt(Guid idUsuario)
        {
            try
            {
                return credencialesDao.GetUsuarioSalt(idUsuario);
            }
            catch { throw; }
        }


        public void AltaUsuario(Usuario usuario, string password, bool esProveedor)
        {
            try
            {
                if (password.Length < 8) throw new Exception("El campo contraseña debe tener al menos 8 caraccteres");

                if (ValidarDatos(usuario))
                {

                    byte[] salt = encrypt.GenerateSalt();

                    byte[] hashedPassword = encrypt.GethashedPassword(password, salt);

                    using (var transaction = new TransactionScope())
                    {
                        usuarioDao.AltaUsuario(usuario, salt, hashedPassword, esProveedor);

                        transaction.Complete();
                    }
                }
            }
            catch { throw; }
        }


        public void ActualizarCredenciales(Guid idUsuario, string NuevoPassword)
        {
            try
            {
                byte[] salt = encrypt.GenerateSalt();

                byte[] hashedPassword = encrypt.GethashedPassword(NuevoPassword, salt);

                using (var transaction = new TransactionScope())
                {
                    credencialesDao.ActualizarCredencial(idUsuario, salt, hashedPassword);

                    transaction.Complete();
                }                
            }
            catch { throw; }
        }
        

        private bool ValidarDatos(Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Nombre)) throw new Exception("El campo nombre no puede estar vacio");

                if (string.IsNullOrEmpty(usuario.Apellido)) throw new Exception("El campo apellido no puede estar vacio");

                if (string.IsNullOrEmpty(usuario.Provincia)) throw new Exception("El campo provincia no puede estar vacio");

                if (string.IsNullOrEmpty(usuario.Direccion)) throw new Exception("El campo direccion no puede estar vacio");

                if (string.IsNullOrEmpty(usuario.Email)) throw new Exception("El campo email no puede estar vacio");

                if (!Regex.IsMatch(usuario.Telefono, @"^\d+")) throw new Exception("El campo telefono solo admite campos numericos");

                if (Regex.IsMatch(usuario.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception("El campo email no tiene formato valido");

                if (usuario.Dni.ToString().Length != 8) throw new Exception("El campo de DNI debe tener 8 caracteres");

                return true;
            }
            catch { throw; }
        }
    }
}
