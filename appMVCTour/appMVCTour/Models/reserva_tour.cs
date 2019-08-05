namespace appMVCTour.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class reserva_tour
    {
        [Key]
        public int idReserva { get; set; }

        public int idTour { get; set; }

        public int idCliente { get; set; }

        public int cantidadNinos { get; set; }

        public int cantidadAdultos { get; set; }

        public decimal costoTotal { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaReserva { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual tour tour { get; set; }
    }
}
