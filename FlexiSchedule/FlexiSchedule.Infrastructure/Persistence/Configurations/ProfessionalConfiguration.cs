using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiSchedule.Infrastructure.Persistence.Configurations;

[Table("Professionals")]
public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Company)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.Document)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(20)
            .IsRequired();
    }
}
