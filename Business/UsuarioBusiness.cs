using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly CredencialesDao credencialesDao = new CredencialesDao();
        private readonly Encrypt encrypt = new Encrypt();
        //private readonly OrganizadorDao organizadorDao = new OrganizadorDao();
        //private readonly ProveedorDao proveedorDao = new ProveedorDao();

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

        public void ActualizarCredenciales(Guid idUsuario, string NuevoPassword)
        {
            try
            {
                byte[] salt = encrypt.GenerateSalt();

                byte[] hashedPassword = encrypt.GethashedPassword(NuevoPassword, salt);

                credencialesDao.ActualizarCredencial(idUsuario, salt, hashedPassword);
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
                    using (var transaction = new TransactionScope())
                    {
                        if (usuario is Organizador)
                        {
                            var organizadorDao = new OrganizadorDao();

                            organizadorDao.AltaOrganizador((usuario as Organizador));
                        }
                        else
                        {
                            var proveedorDao = new ProveedorDao();

                            if (usuario is Proveedor) proveedorDao.AltaProveedor((usuario as Proveedor));
                        }

                        //ESTE METODO LEE EL ID QUE FUE CREADO CON PROVEEDOR U ORGANIZADOR
                        Guid nuevoId = credencialesDao.GetIdUsuario(usuario.Email, esProveedor);

                        byte[] salt = encrypt.GenerateSalt();

                        byte[] hashedPassword = encrypt.GethashedPassword(password, salt);

                        credencialesDao.AltaCredencial(nuevoId, salt, hashedPassword);
                    }
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
