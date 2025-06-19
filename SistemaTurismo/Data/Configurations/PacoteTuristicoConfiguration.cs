using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTurismo.Model;

namespace SistemaTurismo.Data.Configurations;

public class PacoteTuristicoConfiguration : IEntityTypeConfiguration<PacoteTuristico>
{
    //Relacionamento muitos-para-muitos: Um PacoteTuristico tem muitos Destinos
    public void Configure(EntityTypeBuilder<PacoteTuristico> builder)
    {
        builder.HasMany(p => p.Destinos)
            .WithMany();
    }
}