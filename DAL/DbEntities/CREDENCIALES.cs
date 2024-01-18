namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CREDENCIALES
    {
        public Guid ID { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] SALT { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] PASSWORD { get; set; }

        public virtual ORGANIZADOR ORGANIZADOR { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
