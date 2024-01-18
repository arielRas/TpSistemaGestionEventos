namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORGANIZADOR")]
    public partial class ORGANIZADOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORGANIZADOR()
        {
            EVENTO = new HashSet<EVENTO>();
        }

        [Key]
        public Guid ID_ORGANIZADOR { get; set; }

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

        public virtual CREDENCIALES CREDENCIALES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENTO> EVENTO { get; set; }

        public virtual PROVINCIA PROVINCIA { get; set; }
    }
}
