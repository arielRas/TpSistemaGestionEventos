namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FECHA_RESERVADA
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID_SERV_PUB { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime FECHA { get; set; }

        public int CANT_RESERVAS { get; set; }

        public virtual SERVICIO_PUBLICADO SERVICIO_PUBLICADO { get; set; }
    }
}
