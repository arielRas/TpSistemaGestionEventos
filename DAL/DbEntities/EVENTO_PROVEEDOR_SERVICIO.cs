namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EVENTO_PROVEEDOR_SERVICIO
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID_EVENTO { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ID_PROVEEDOR { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_SERVICIO { get; set; }

        public int CANTIDAD { get; set; }

        public decimal PRECIO_UNITARIO { get; set; }

        public decimal MONTO_TOTAL { get; set; }

        public bool? PAGO { get; set; }

        public DateTime? FECHA_PAGO { get; set; }

        public bool? COMPLETADO { get; set; }

        public virtual EVENTO EVENTO { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }

        public virtual SERVICIO SERVICIO { get; set; }
    }
}
