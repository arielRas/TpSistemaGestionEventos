using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDao
    {    
        public Proveedor GetProveedor(string email)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var proveedorDb = ctx.PROVEEDOR.SingleOrDefault(P => P.EMAIL == email) ?? throw new Exception("El usuario solicitado no existe");

                    var proveedor = new Proveedor
                    {
                        Id = proveedorDb.ID_PROVEEDOR,
                        Nombre = proveedorDb.NOMBRE,
                        Apellido = proveedorDb.APELLIDO,
                        Email = proveedorDb.EMAIL,
                        Dni = proveedorDb.DNI,
                        Telefono = proveedorDb.TELEFONO,
                        Provincia = ProvinciaDao.GetProvincia(proveedorDb.ID_PROVINCIA),
                        Direccion = proveedorDb.DIRECCION
                    };

                    return proveedor;
                }
            }
            catch { throw; }
        }


        public void ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                using (DbGestionEventos ctx = new DbGestionEventos())
                {
                    var proveedorDb = ctx.PROVEEDOR.SingleOrDefault(P => P.ID_PROVEEDOR == proveedor.Id) ?? throw new Exception("El usuario solicitado no existe");

                    proveedorDb.NOMBRE = proveedor.Nombre;
                    proveedorDb.APELLIDO = proveedor.Apellido;
                    proveedorDb.EMAIL = proveedor.Email;
                    proveedorDb.DNI = proveedor.Dni;
                    proveedorDb.TELEFONO = proveedor.Telefono;
                    proveedorDb.ID_PROVINCIA = ProvinciaDao.GetIdProvincia(proveedor.Provincia);
                    proveedorDb.DIRECCION = proveedor.Direccion;

                    ctx.SaveChanges();
                }
            }
            catch { throw; }
            
        }
    }
}
