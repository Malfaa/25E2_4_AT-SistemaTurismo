using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTurismo.Model;

namespace SistemaTurismo.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    // Relacionamento um-para-muitos: Um Cliente tem muitas Reservas.
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasMany(c => c.Reservas)
            .WithOne(r => r.Cliente)
            .HasForeignKey(r => r.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}