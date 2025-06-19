using Microsoft.EntityFrameworkCore;
using SistemaTurismo.Data.Configurations;
using SistemaTurismo.Model;

namespace SistemaTurismo.Data;


public class SistemaTurismoContext : DbContext
{
    public SistemaTurismoContext()
    {
        
    }
    
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }

    public SistemaTurismoContext(DbContextOptions<SistemaTurismoContext> options) :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>().HasQueryFilter(c => c.DeletedAt == null);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaTurismoContext).Assembly);
    }
}