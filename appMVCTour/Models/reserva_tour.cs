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

        [Display(Name ="Tour")]
        public int idTour { get; set; }

        [Display(Name = "Cliente")]
        public int idCliente { get; set; }

        [Display(Name = "Cantidad de Niños")]
        [RegularExpression(@"[0-9]*",ErrorMessage ="Solo acepta números")]
        public int cantidadNinos { get; set; }

        [Display(Name = "Cantidad de Adultos")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo acepta números")]
        public int cantidadAdultos { get; set; }

        [Display(Name = "Costo Total")]
        [DisplayFormat(DataFormatString = "{0:N2}",
            ApplyFormatInEditMode = true)]
        public decimal costoTotal { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",
            ApplyFormatInEditMode =true)]
        public DateTime fechaReserva { get; set; }

        [Display(Name = "Cliente")]
        public virtual cliente cliente { get; set; }

        [Display(Name = "Tour")]
        public virtual tour tour { get; set; }
    }
}
