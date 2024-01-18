namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVICIO")]
    public partial class SERVICIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICIO()
        {
            EVENTO_PROVEEDOR_SERVICIO = new HashSet<EVENTO_PROVEEDOR_SERVICIO>();
            PAGO = new HashSet<PAGO>();
            SERVICIO_PUBLICADO = new HashSet<SERVICIO_PUBLICADO>();
        }

        [Key]
        public int ID_SERVICIO { get; set; }

        [Required]
        [StringLength(20)]
        public string CATEGORIA { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENTO_PROVEEDOR_SERVICIO> EVENTO_PROVEEDOR_SERVICIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO> PAGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO_PUBLICADO> SERVICIO_PUBLICADO { get; set; }
    }
}
