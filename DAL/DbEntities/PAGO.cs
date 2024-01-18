namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAGO")]
    public partial class PAGO
    {
        public Guid? ID_PAGO { get; set; }

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

        public DateTime FECHA_PAGO { get; set; }

        public decimal? MONTO { get; set; }

        public virtual EVENTO EVENTO { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }

        public virtual SERVICIO SERVICIO { get; set; }
    }
}
