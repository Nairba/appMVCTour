namespace appMVCTour.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tour")]
    public partial class tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tour()
        {
            reserva_tour = new HashSet<reserva_tour>();
        }

        [Key]
        public int idTour { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }

        [Display(Name = "Precio Niños")]
        [DataType(DataType.Currency)]
        public decimal? precioNinos { get; set; }

        [Display(Name = "Precio Adultos")]
        [DisplayFormat(DataFormatString = "{0:N2}",
            ApplyFormatInEditMode =true)]
        public decimal? precioAdultos { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Restricciones")]
        [DataType(DataType.MultilineText)]
        public string restricciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva_tour> reserva_tour { get; set; }
    }
}
