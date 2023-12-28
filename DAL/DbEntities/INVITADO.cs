namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVITADO")]
    public partial class INVITADO
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID_EVENTO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(30)]
        public string APELLIDO { get; set; }

        public int CANT_COMPANIONS { get; set; }

        public virtual EVENTO EVENTO { get; set; }
    }
}
