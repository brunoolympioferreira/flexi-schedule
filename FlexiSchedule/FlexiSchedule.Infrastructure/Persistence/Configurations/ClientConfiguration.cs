namespace FlexiSchedule.Infrastructure.Persistence.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Client)
            .HasForeignKey(a => a.ClientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Professional)
            .WithMany(p => p.Clients)
            .HasForeignKey(c => c.ProfessionalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
