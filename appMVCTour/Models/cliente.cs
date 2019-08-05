namespace appMVCTour.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            reserva_tour = new HashSet<reserva_tour>();
        }

        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage ="Identificación requerida")]
        [StringLength(15)]
        [Display(Name ="Identificación")]
        public string identificacion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Activo")]

        public bool activo { get; set; }

        public string NombreCompleto
        {
            get{
                return string.Format("{0} {1}", nombre, apellidos);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva_tour> reserva_tour { get; set; }
    }
}
