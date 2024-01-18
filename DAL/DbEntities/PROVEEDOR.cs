namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROVEEDOR")]
    public partial class PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDOR()
        {
            EVENTO_PROVEEDOR_SERVICIO = new HashSet<EVENTO_PROVEEDOR_SERVICIO>();
            PAGO = new HashSet<PAGO>();
            SERVICIO_PUBLICADO = new HashSet<SERVICIO_PUBLICADO>();
        }

        [Key]
        public Guid ID_PROVEEDOR { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(30)]
        public string APELLIDO { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        public long DNI { get; set; }

        [StringLength(10)]
        public string TELEFONO { get; set; }

        public int ID_PROVINCIA { get; set; }

        [StringLength(100)]
        public string DIRECCION { get; set; }

        public decimal? PUNTAJE { get; set; }

        public virtual CREDENCIALES CREDENCIALES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENTO_PROVEEDOR_SERVICIO> EVENTO_PROVEEDOR_SERVICIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO> PAGO { get; set; }

        public virtual PROVINCIA PROVINCIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO_PUBLICADO> SERVICIO_PUBLICADO { get; set; }
    }
}
