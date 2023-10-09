using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Reparacion
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? FechaSolicitada { get; set; }
        
        [Required]
        public int? IdAuto { get; set; }
        [ForeignKey("IdAuto")]
        public virtual Vehiculo? Vehiculo { get; set; }

        [Required]
        public int? IdHojaIngreso { get; set; }
        [ForeignKey("IdHojaIngreso")]
        public virtual HojaIngreso? HojaIngreso { get; set; }

        [Required]
        public int? IdProgreso { get; set; }
        [ForeignKey("IdProgreso")]
        public virtual Progreso? Progreso { get; set; }

        [Required]
        public int? IdInforme { get; set; }
        [ForeignKey("IdInforme")]
        public virtual InformeFinal? InformeFinal { get; set; }

        [Required]
        public int? IdMecanico { get; set; }
        [ForeignKey("IdMecanico")]
        public virtual Mecanico? Mecanico { get; set; }
        [Required]
        public int? IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual Estado? Estado { get; set; }
    }
}
