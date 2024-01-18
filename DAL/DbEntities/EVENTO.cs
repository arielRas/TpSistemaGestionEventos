namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EVENTO")]
    public partial class EVENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EVENTO()
        {
            EVENTO_PROVEEDOR_SERVICIO = new HashSet<EVENTO_PROVEEDOR_SERVICIO>();
            INVITADO = new HashSet<INVITADO>();
            PAGO = new HashSet<PAGO>();
        }

        [Key]
        public Guid ID_EVENTO { get; set; }

        public Guid ID_ORGANIZADOR { get; set; }

        [Required]
        [StringLength(30)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        public DateTime FECHA_HORA { get; set; }

        public int? ID_PROVINCIA { get; set; }

        [StringLength(100)]
        public string DIRECCION { get; set; }

        public int CANT_INVITADOS { get; set; }

        public virtual ORGANIZADOR ORGANIZADOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENTO_PROVEEDOR_SERVICIO> EVENTO_PROVEEDOR_SERVICIO { get; set; }

        public virtual PROVINCIA PROVINCIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVITADO> INVITADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO> PAGO { get; set; }
    }
}
