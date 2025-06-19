using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTurismo.Model;

namespace SistemaTurismo.Data.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    //Relacionamento um-para-muitos: Um PacoteTuristico tem muitas Reservas
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.HasOne(r => r.PacoteTuristico)
            .WithMany()
            .HasForeignKey(r => r.PacoteTuristicoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}