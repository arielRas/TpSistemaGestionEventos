namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SERVICIO_PUBLICADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICIO_PUBLICADO()
        {
            FECHA_RESERVADA = new HashSet<FECHA_RESERVADA>();
        }

        [Key]
        public Guid ID_SERV_PUB { get; set; }

        public DateTime FECHA_PUBLICACION { get; set; }

        [Required]
        [StringLength(30)]
        public string NOMBRE { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        public Guid ID_PROVEEDOR { get; set; }

        public int ID_SERVICIO { get; set; }

        public decimal PRECIO { get; set; }

        public bool? ENVIO { get; set; }

        public bool FIN_DE_SEMANA { get; set; }

        public bool ENTRE_SEMANA { get; set; }

        public int CANT_SERV_DIARIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FECHA_RESERVADA> FECHA_RESERVADA { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }

        public virtual SERVICIO SERVICIO { get; set; }
    }
}
