//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CREDENCIALES
    {
        public System.Guid ID { get; set; }
        public byte[] SALT { get; set; }
        public byte[] PASSWORD { get; set; }
    
        public virtual ORGANIZADOR ORGANIZADOR { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
