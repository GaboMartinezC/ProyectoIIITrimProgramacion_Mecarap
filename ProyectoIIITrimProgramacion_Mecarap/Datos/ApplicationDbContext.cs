using ProyectoIIITrimProgramacion_Mecarap.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIIITrimProgramacion_Mecarap.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoAuto> TiposAuto { get; set; }
        public DbSet<HojaIngreso> HojasIngreso { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<InformeFinal> InformesFinal { get; set; }
        public DbSet<Progreso> Progresos { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }

    }
}
