﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ProveedorDao
    {
        public void AltaProveedor(Proveedor proveedor, byte[] pass, byte[] salt)
        {
            try
            {
                using(ContextDb ctx = new ContextDb())
                {
                    var proveedorDb = new PROVEEDOR
                    {
                        NOMBRE = proveedor.Nombre,
                        APELLIDO = proveedor.Apellido,
                        EMAIL = proveedor.Email,
                        DNI = proveedor.Dni,
                        TELEFONO = proveedor.Telefono,
                        ID_PROVINCIA = ProvinciaDao.GetIdProvincia(proveedor.Provincia),
                        DIRECCION = proveedor.Direccion,
                        SALT = salt,
                        PASSWORD = pass
                    };

                    ctx.PROVEEDOR.Add(proveedorDb);
                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


        public Proveedor GetProveedor(string email)
        {
            try
            {
                using (ContextDb ctx = new ContextDb())
                {
                    var proveedorDb = ctx.PROVEEDOR.SingleOrDefault(P => P.EMAIL == email) ?? throw new Exception("El usuario solicitado no existe");

                    var proveedor = new Proveedor
                    {
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
                using (ContextDb ctx = new ContextDb())
                {
                    var proveedorDb = ctx.PROVEEDOR.SingleOrDefault(P => P.ID_PROVEEDOR == proveedor.CodProveedor) ?? throw new Exception("El usuario solicitado no existe");

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
