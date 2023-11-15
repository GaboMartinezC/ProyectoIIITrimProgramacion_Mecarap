using System.ComponentModel.DataAnnotations;
namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class HojaIngreso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Fecha { get; set; }
        [Required]
        public string? Observaciones { get; set;}
        [Required]
        public bool? Borrado { get; set; }
    }
}
