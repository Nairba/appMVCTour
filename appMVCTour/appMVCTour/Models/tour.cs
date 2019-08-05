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
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public decimal? precioNinos { get; set; }

        public decimal? precioAdultos { get; set; }

        [Column(TypeName = "text")]
        public string restricciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva_tour> reserva_tour { get; set; }
    }
}
